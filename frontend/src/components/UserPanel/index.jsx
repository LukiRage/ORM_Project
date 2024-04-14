import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Pie, Line } from 'react-chartjs-2';
import DataTable from './DataTable';
import './styles.css'; // Dodaj ten import

import { Chart as ChartJS, CategoryScale, LinearScale, PointElement, LineElement, Title, Tooltip, LogarithmicScale, Legend, ArcElement, PieController } from "chart.js";

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, Title, Tooltip, LogarithmicScale, Legend, ArcElement, PieController);


const UserPanel = () => {
  const [data, setData] = useState([]);
  const [selectedTable, setSelectedTable] = useState('');
  const [selectedColumns, setSelectedColumns] = useState({});
  const [selectedCountryCode, setSelectedCountryCode] = useState('');
  const [selectedYearCode, setSelectedYearCode] = useState('');
  const [chartData, setChartData] = useState(null);
  const [lineChartData, setLineChartData] = useState(null);
  const token = localStorage.getItem('token');

  
  const columnsMap = {
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

  const handlePieChart = async () => {
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
    } catch (error) {
      console.error('Błąd podczas pobierania danych:', error);
    }
  };

  const columns = React.useMemo(() => columnsMap[selectedTable], [selectedTable]);

  useEffect(() => {
    if (selectedTable === 'co2_emission' && selectedCountryCode && selectedYearCode) {
      const filteredData = data.filter(row => row.countryCode === selectedCountryCode && row.yearCode === selectedYearCode);
      if (filteredData.length > 0) {
        const pieData = {
          labels: ['Cement', 'Coal', 'Gas', 'Oil'],
          datasets: [
            {
              data: [
                filteredData[0].cement, 
                filteredData[0].coal, 
                filteredData[0].gas, 
                filteredData[0].oil
              ],
              backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#800080', '#00FFFF'],
            }
          ]
        };
        setChartData(pieData);
      }
    }
  }, [selectedTable, selectedCountryCode, selectedYearCode, data]);

  const handleLineChart = async () => {
    const lineData = {
      labels: [],
      datasets: [],
    };

    for (let table of Object.keys(selectedColumns)) {
      const selectedColumnsForTable = selectedColumns[table];

      if (!selectedColumnsForTable || selectedColumnsForTable.length < 1) {
        continue;
      }

      const tableMethodMap = {
        'air_quality': 'air_quality_all',
        'gdp_growth': 'gdp_growth_all',
        'industry': 'industry_all',
        'co2_emission': 'co2_emission_all',
      };

      try {
        const response = await axios.post(
          `http://localhost:8000/api/all/${tableMethodMap[table]}`,
          {},
          {
            headers: {
              'Authorization': `Bearer ${token}`,
            },
          }
        );
        const tableData = response.data;

        if (lineData.labels.length === 0) {
          lineData.labels = tableData.map(row => row.yearName);
        }

        selectedColumnsForTable.forEach(column => {
          const dataset = {
            label: `${column} (${table})`,
            data: tableData.map(row => row[column]),
            borderColor: '#' + Math.floor(Math.random() * 16777215).toString(16),
            borderWidth: 1,
          };
          lineData.datasets.push(dataset);
        });
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    }

    setLineChartData(lineData);
  };

  const handleCheckboxChange = (e) => {
    const [table, name] = e.target.name.split('-');
    const { checked } = e.target;
    setSelectedColumns(prev => {
      const prevColumns = prev[table] || [];
      if (checked) {
        return { ...prev, [table]: [...prevColumns, name] };
      } else {
        return { ...prev, [table]: prevColumns.filter(col => col !== name) };
      }
    });
  };
  
  const checkboxColumnsMap = {
    'air_quality': [
      { Header: 'PM2.5 Value', accessor: 'pM2_5_value' },
    ],
    'gdp_growth': [
      { Header: 'GDP Growth', accessor: 'gdP_growth' },
    ],
    'industry': [
      { Header: 'Industry', accessor: 'industry' },
    ],
    'co2_emission': [
      { Header: 'Coal', accessor: 'coal' },
      { Header: 'Oil', accessor: 'oil' },
      { Header: 'Gas', accessor: 'gas' },
      { Header: 'Cement', accessor: 'cement' },
      { Header: 'CO2 Emission Summary', accessor: 'cO2_emission_summary' },
    ],
  };
  
  return (
    <div className="container">
      <h2>Panel użytkownika</h2>

      <div className="form-container">
        <div>
          <select className="select" value={selectedTable} onChange={(e) => setSelectedTable(e.target.value)}>
            <option value="air_quality">air_quality</option>
            <option value="gdp_growth">gdp_growth</option>
            <option value="industry">industry</option>
            <option value="co2_emission">co2_emission</option>
          </select>
          
          <div>
            <input className="input" type="text" value={selectedCountryCode} onChange={(e) => setSelectedCountryCode(e.target.value)} placeholder="Country Code"/><br />
            <input className="input" type="text" value={selectedYearCode} onChange={(e) => setSelectedYearCode(e.target.value)} placeholder="Year Code"/>
          </div>
        </div>

        <div>
          {Object.keys(checkboxColumnsMap).map((table) => (
            checkboxColumnsMap[table].map(({ Header, accessor }) => (
              <div className="checkbox-container" key={`${table}-${accessor}`}>
                <input
                  className="checkbox"
                  type="checkbox"
                  id={`${table}-${accessor}`}
                  name={`${table}-${accessor}`}
                  checked={selectedColumns[table]?.includes(accessor) || false}
                  onChange={handleCheckboxChange}
                />
                <label className="label" htmlFor={`${table}-${accessor}`}>{`${Header} (${table})`}</label>
              </div>
            ))
          ))}
        </div>
      </div>

      <div>
        <button className="button" onClick={handlePieChart}>Wyświetl wykres kołowy</button>
        <button className="button line-chart-button" onClick={handleLineChart}>Wyświetl wykres liniowy</button>
      </div>

      <div className="chart-container">
        {chartData && <Pie data={chartData} options={{responsive: true}} key={Math.random()} />}
      </div>
      
      <div className="table-container">
        {lineChartData && <Line data={lineChartData} options={{responsive: true}} key={Math.random()} />}
      </div>

    </div>
  );



}

export default UserPanel;
