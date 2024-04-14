using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ServiceModel;
using static ORM_Projekt.DataContext;
using MySqlConnector;
using System.Data.SqlClient;
using System.Xml;

namespace ORM_Projekt
{
    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        string GetAirQualityData(string yearCode, string countryCode);

        [OperationContract]
        string GetCO2EmissionData(string yearCode, string countryCode);

        [OperationContract]
        string GetGDPGrowthData(string yearCode, string countryCode);

        [OperationContract]
        string GetIndustryGrowthData(string yearCode, string countryCode);
    }

    public class DataService : IDataService
    {
        private readonly DataContext _context;

        public DataService(DataContext context)
        {
            _context = context;
        }

        [OperationContract]
        public string GetData(string yearCode, string countryCode)
        {
            // Połączenie z bazą danych
            using (SqlConnection connection = new SqlConnection("your_database_connection_string"))
            {
                connection.Open();

                // Wykonanie zapytania SQL
                string query = "SELECT * FROM YourTable WHERE YearCode = @YearCode AND CountryCode = @CountryCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@YearCode", yearCode);
                    command.Parameters.AddWithValue("@CountryCode", countryCode);

                    SqlDataReader reader = command.ExecuteReader();

                    // Odczytanie wyników zapytania i zwrócenie jako tekst
                    if (reader.HasRows)
                    {
                        string result = "";
                        while (reader.Read())
                        {
                            // Przykładowe odczytywanie danych
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);

                            // Dodaj wynik do stringa
                            result += $"ID: {id}, Name: {name}\n";
                        }

                        return result;
                    }
                    else
                    {
                        return "No data found";
                    }
                }
            }
        }

            public string GetAirQualityData(string yearCode, string countryCode)
            {
                var airQualityData = _context.air_quality
                    .FirstOrDefault(aq => aq.YearCode == yearCode && aq.CountryCode == countryCode);

                // Przykład implementacji zwracający dane jako JSON
                if (airQualityData != null)
                {
                    var jsonData = new
                    {
                        AirQualityID = airQualityData.AirQualityID,
                        CountryCode = airQualityData.CountryCode,
                        YearCode = airQualityData.YearCode,
                        PM2_5_value = airQualityData.PM2_5_value
                    };

                    return JsonConvert.SerializeObject(jsonData);
                }

                return string.Empty;
            }

        public string GetCO2EmissionData(string yearCode, string countryCode)
        {
            var co2EmissionData = _context.co2_emission
                .FirstOrDefault(ce => ce.YearCode == yearCode && ce.CountryCode == countryCode);

            // Przykład implementacji zwracający dane jako XML
            if (co2EmissionData != null)
            {
                var jsonData = new
                {
                    CO2EmissionID = co2EmissionData.CO2EmissionID,
                    CountryCode = co2EmissionData.CountryCode,
                    YearCode = co2EmissionData.YearCode,
                    Coal = co2EmissionData.Coal,
                    Oil = co2EmissionData.Oil,
                    Gas = co2EmissionData.Gas,
                    CO2_emission_summary = co2EmissionData.CO2_emission_summary
                };
                return JsonConvert.SerializeObject(jsonData);
            }

            return string.Empty;
        }


        public string GetGDPGrowthData(string yearCode, string countryCode)
        {
            var gdpGrowthData = _context.gdp_growth
                .FirstOrDefault(gd => gd.YearCode == yearCode && gd.CountryCode == countryCode);

            // Przykład implementacji zwracający dane jako JSON
            if (gdpGrowthData != null)
            {
                var jsonData = new
                {
                    GDPGrowthID = gdpGrowthData.GDPGrowthID,
                    CountryCode = gdpGrowthData.CountryCode,
                    YearCode = gdpGrowthData.YearCode,
                    GDP_growth = gdpGrowthData.GDP_growth
                };

                return JsonConvert.SerializeObject(jsonData);
            }

            return string.Empty;
        }

        public string GetIndustryGrowthData(string yearCode, string countryCode)
        {
            var industryGrowthData = _context.industry
                .FirstOrDefault(ig => ig.YearCode == yearCode && ig.CountryCode == countryCode);

            // Przykład implementacji zwracający dane jako XML
            if (industryGrowthData != null)
            {
                var jsonData = new
                {
                    IndustryID = industryGrowthData.IndustryID,
                    CountryCode = industryGrowthData.CountryCode,
                    YearCode = industryGrowthData.YearCode,
                    Industry = industryGrowthData.Industry
                };

                return JsonConvert.SerializeObject(jsonData);
            }

            return string.Empty;
        }
    }

}
