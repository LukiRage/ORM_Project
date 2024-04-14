import React, { useState, useEffect } from 'react';
import axios from 'axios';
import DataTable from './DataTable';
import fileDownload from 'js-file-download';
import './AdminPanel.css';

const AdminPanel = () => {
  const [data, setData] = useState([]);
  const [token, setToken] = useState('');
  const [yearCode, setYearCode] = useState('');
  const [countryCode, setCountryCode] = useState('');
  const [selectedTable, setSelectedTable] = useState('');
  const [fileType, setFileType] = useState('json');
  const [operationType, setOperationType] = useState('import');
  const [protocolType, setProtocolType] = useState('soap');
  const [columns, setColumns] = useState([]);


  useEffect(() => {
    const userToken = localStorage.getItem('token');
    setToken(userToken);
  }, []);
  
  useEffect(() => {
    const fetchAllData = async () => {
      if (selectedTable) {
        await handleVisualizationAll();
      }
    };
  
    fetchAllData();
  }, [selectedTable]);
  

  const handleImportExport = async () => {
    try {
      const response = await axios.post(`http://localhost:8000/importer/${selectedTable}`, {
          fileType,
          operationType,
          yearCode,
          countryCode,
      });
      alert(response.data);
    } catch (error) {
      alert(`Wystąpił błąd: ${error}`);
    }
  };


  const handleImportExportREST = async () => {
    try {
      const response = await axios({
        method: operationType === 'import' ? 'post' : 'get',
        url: `http://localhost:8000/importer/${selectedTable}`,
        headers: {
          'Content-Type': fileType === 'json' ? 'application/json' : 'text/xml'
        },
        data: {
          fileType,
          yearCode,
          countryCode,
        }
      });
      alert(response.data);
    } catch (error) {
      alert(`Wystąpił błąd: ${error}`);
    }
  };
  

  const handleVisualization = async () => {
    const tableMethodMap = {
      'air_quality': 'GetAirQualityData',
      'gdp_growth': 'GetGDPGrowthData',
      'industry': 'GetIndustryGrowthData', 
      'co2_emission': 'GetCO2EmissionData',
    };
  
    try {
      const xmlData = `
      <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:dat="http://tempuri.org/">
        <soapenv:Header/>
        <soapenv:Body>
          <dat:${tableMethodMap[selectedTable]}>
            ${yearCode ? `<dat:yearCode>${yearCode}</dat:yearCode>` : ''}
            ${countryCode ? `<dat:countryCode>${countryCode}</dat:countryCode>` : ''}
          </dat:${tableMethodMap[selectedTable]}>
        </soapenv:Body>
      </soapenv:Envelope>
    `;
    
      const response = await axios.post('http://localhost:8000/DataService', xmlData, {
        headers: { 'Content-Type': 'text/xml' },
      });
    
      const parser = new DOMParser();
      const xmlDoc = parser.parseFromString(response.data, 'text/xml');
      const resultElement = xmlDoc.getElementsByTagName(`${tableMethodMap[selectedTable]}Result`)[0];
          
      if (!resultElement || !resultElement.textContent.trim()) {
        console.log('No data found for this year and country code.');
        setData([]);
        return;
      }
    
      const dataJson = JSON.parse(resultElement.textContent);
      setData([dataJson]);
  
      // setting columns state here
      setColumns(columnsMap[selectedTable]); 
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };
  

  const handleVisualizationAll = async () => {
    const tableMethodMap = {
      'air_quality': 'air_quality_all',
      'gdp_growth': 'gdp_growth_all',
      'industry': 'industry_all',
      'co2_emission': 'co2_emission_all',
    };


    try {
      const response = await axios.post(
        `http://localhost:8000/api/all/${tableMethodMap[selectedTable]}`,
        {},
        {
          headers: {
            'Authorization': `Bearer ${token}`,
          },
        }
      );
      setData(response.data);
      setColumns(columnsMapAll[selectedTable]); // update columns state
    } catch (error) {
      console.error('Błąd podczas pobierania danych:', error);
    }
  };

  const handleVisualizationREST = async () => {
  const tableMethodMap = {
    'air_quality': 'air_quality',
    'gdp_growth': 'gdp_growth',
    'industry': 'industry', 
    'co2_emission': 'co2_emission',
  };

  try {
    const response = await axios.post(
      `http://localhost:8000/api/data/${tableMethodMap[selectedTable]}`, 
      {
        YearCode: yearCode,
        CountryCode: countryCode,
      },
      {
        headers: {
          'Authorization': `Bearer ${token}`, // dodajemy token do nagłówków
        },
      }
    );

    if (!response.data || !response.data.length) {
      console.log('No data found for this year and country code.');
      setData([]);
      return;
    }

    setData(response.data);
  } catch (error) {
    console.error('Error fetching data:', error);
  }
};

  

  const columnsMap = {
    'air_quality': [
      { Header: 'Country Code', accessor: 'CountryCode' },
      { Header: 'Year', accessor: 'YearCode' },
      { Header: 'PM2.5 Value', accessor: 'PM2_5_value' },
    ],
    'gdp_growth': [
      { Header: 'Country Code', accessor: 'CountryCode' },
      { Header: 'Year', accessor: 'YearCode' },
      { Header: 'GDP Growth', accessor: 'GDP_growth' },
    ],
    'industry': [
      { Header: 'Country Code', accessor: 'CountryCode' },
      { Header: 'Year', accessor: 'YearCode' },
      { Header: 'Industry', accessor: 'Industry' },
    ],
    'co2_emission': [
      { Header: 'Country Code', accessor: 'CountryCode' },
      { Header: 'Year', accessor: 'YearCode' },
      { Header: 'Coal', accessor: 'Coal' },
      { Header: 'Oil', accessor: 'Oil' },
      { Header: 'Gas', accessor: 'Gas' },
      { Header: 'Cement', accessor: 'Cement' },
      { Header: 'CO2 Emission Summary', accessor: 'CO2_emission_summary' },
    ],
  };

  //Obsługa dla wyświetlania
  const columnsMapAll = {
    'air_quality': [
      { Header: 'Air Quality ID', accessor: 'airQualityID' },
      { Header: 'Country Code', accessor: 'countryCode' },
      { Header: 'Country Name', accessor: 'countryName' },
      { Header: 'Year Code', accessor: 'yearCode' },
      { Header: 'Year Name', accessor: 'yearName' },
      { Header: 'PM2.5 Value', accessor: 'pM2_5_value' },
    ],
    'gdp_growth': [
      { Header: 'GDP Growth ID', accessor: 'gdpGrowthID' },
      { Header: 'Country Code', accessor: 'countryCode' },
      { Header: 'Country Name', accessor: 'countryName' },
      { Header: 'Year Code', accessor: 'yearCode' },
      { Header: 'Year Name', accessor: 'yearName' },
      { Header: 'GDP Growth', accessor: 'gdP_growth' },
    ],
    'industry': [
      { Header: 'Industry ID', accessor: 'industryID' },
      { Header: 'Country Code', accessor: 'countryCode' },
      { Header: 'Country Name', accessor: 'countryName' },
      { Header: 'Year Code', accessor: 'yearCode' },
      { Header: 'Year Name', accessor: 'yearName' },
      { Header: 'Industry', accessor: 'industry' },
    ],
    'co2_emission': [
      { Header: 'CO2 Emission ID', accessor: 'cO2EmissionID' },
      { Header: 'Country Code', accessor: 'countryCode' },
      { Header: 'Country Name', accessor: 'countryName' },
      { Header: 'Year Code', accessor: 'yearCode' },
      { Header: 'Year Name', accessor: 'yearName' },
      { Header: 'Coal', accessor: 'coal' },
      { Header: 'Oil', accessor: 'oil' },
      { Header: 'Gas', accessor: 'gas' },
      { Header: 'Cement', accessor: 'cement' },
      { Header: 'CO2 Emission Summary', accessor: 'cO2_emission_summary' },
    ],
  };
  


  const exportToJson = () => {
    fileDownload(JSON.stringify(data, null, 4), `${selectedTable}.json`);
  };

  const exportToXml = () => {
    let xmlData = '<?xml version="1.0" encoding="UTF-8"?>\n<root>\n';
    data.forEach((item) => {
      xmlData += '  <item>\n';
      Object.entries(item).forEach(([key, value]) => {
        xmlData += `    <${key}>${value}</${key}>\n`;
      });
      xmlData += '  </item>\n';
    });
    xmlData += '</root>';
    fileDownload(xmlData, `${selectedTable}.xml`);
  };

  return (
    <div className="admin-container">
      <h2>Admin Panel</h2>

      {token ? (
        <p>Current User Token: {token}</p>
      ) : (
        <p>Please login to access the Admin Panel.</p>
      )}

      <div className="selectors-and-buttons">
        <div className="selectors">
        <label>
          <h4>Wybierz protokół:</h4>
          <select value={protocolType} onChange={(e) => setProtocolType(e.target.value)}>
              <option value="soap">SOAP</option>
              <option value="rest">REST</option>
          </select>
        </label>

        <label>
          <h4>Wybierz typ pliku:</h4>
          <select value={fileType} onChange={(e) => setFileType(e.target.value)}>
              <option value="json">JSON</option>
              <option value="xml">XML</option>
          </select>
        </label>

        <label>
          <h4>Wybierz typ operacji:</h4>
          <select value={operationType} onChange={(e) => setOperationType(e.target.value)}>
              <option value="import">Import</option>
              <option value="export">Eksport</option>
          </select>
        </label>

        <label>
          <h4>Wybierz tabelę:</h4>
          <select value={selectedTable} onChange={(e) => setSelectedTable(e.target.value)}>
            <option value="air_quality">Air Quality</option>
            <option value="gdp_growth">GDP Growth</option>
            <option value="industry">Industry</option>
            <option value="co2_emission">CO2 Emission</option>
          </select>
        </label>
        </div>
        <div className="buttons">
          <button onClick={handleVisualizationAll}>Wyświetl wszystkie dane</button>
          <button onClick={exportToJson}>Export to JSON</button>
          <button onClick={exportToXml}>Export to XML</button>
          <button onClick={protocolType === 'soap' ? (operationType === 'import' ? handleImportExport : handleVisualization) : (operationType === 'import' ? handleImportExportREST : handleVisualizationREST)}>
            {operationType === 'import' ? 'Importuj dane' : 'Wizualizuj dane'}
          </button>
        </div>
      </div>
      {operationType === 'export' && (
        <div className="extra-inputs">
          <input value={yearCode} onChange={(e) => setYearCode(e.target.value)} placeholder="Enter Year Code"/>
          <input value={countryCode} onChange={(e) => setCountryCode(e.target.value)} placeholder="Enter Country Code"/>
        </div>
      )}
      {selectedTable && <DataTable data={data} columns={columns} />}
    </div>
  );
}

export default AdminPanel;
