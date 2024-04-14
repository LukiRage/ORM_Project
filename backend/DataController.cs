using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace ORM_Projekt.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public DataController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Isolation(IsolationLevel.Serializable)]
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{tableName}")]
        public IActionResult GetData(string tableName, [FromBody] DataRequest request)
        {
            
            // Sprawdź poprawność parametrów YearCode i CountryCode
            if (string.IsNullOrEmpty(request.YearCode) || string.IsNullOrEmpty(request.CountryCode))
            {
                return BadRequest("Nieprawidłowe dane wejściowe.");
            } 

            if (Request.ContentType == "application/xml") // Sprawdzenie, czy zapytanie jest w formacie XML (SOAP)
            {
                if (tableName.ToLower() != "soap") // Jeśli tabela nie jest "soap", zwróć błąd
                {
                    return BadRequest("Nieprawidłowa nazwa tabeli.");
                }

                // Wywołaj metodę SOAP
                var result = SoapGetData(request.YearCode, request.CountryCode);
                return Content(result, "application/xml"); // Zwróć wynik jako XML
            }
            else // Zapytanie w formacie REST
            {
                // Pobierz dane z bazy danych na podstawie YearCode i CountryCode
                var result = Enumerable.Empty<object>();

                switch (tableName.ToLower())
                {
                    case "air_quality":
                        result = _dbContext.air_quality
                            .Include(a => a.Country)
                            .Include(a => a.Year)
                            .Where(a => a.Year.YearCode == request.YearCode && a.Country.CountryCode == request.CountryCode)
                            .Select(a => new
                            {
                                a.AirQualityID,
                                a.Country.CountryCode,
                                a.Country.CountryName,
                                a.Year.YearCode,
                                a.Year.YearName,
                                a.PM2_5_value
                            })
                            .ToList();
                        break;
                        
                    case "air_quality_all":
                        result = _dbContext.air_quality
                            .Include(a => a.Country)
                            .Include(a => a.Year)
                            .Select(a => new
                            {
                                a.AirQualityID,
                                a.Country.CountryCode,
                                a.Country.CountryName,
                                a.Year.YearCode,
                                a.Year.YearName,
                                a.PM2_5_value
                            })
                            .ToList();
                        break;

                    case "co2_emission":
                        result = _dbContext.co2_emission
                            .Include(a => a.Country)
                            .Include(a => a.Year)
                            .Where(a => a.Year.YearCode == request.YearCode && a.Country.CountryCode == request.CountryCode)
                            .Select(a => new
                            {
                                a.CO2EmissionID,
                                a.Country.CountryCode,
                                a.Country.CountryName,
                                a.Year.YearCode,
                                a.Year.YearName,
                                a.Coal,
                                a.Oil,
                                a.Gas,
                                a.Cement,
                                a.CO2_emission_summary
                            })
                            .ToList();
                        break;
                    case "co2_emission_all":
                        result = _dbContext.co2_emission
                            .Include(a => a.Country)
                            .Include(a => a.Year)
                            .Select(a => new
                            {
                                a.CO2EmissionID,
                                a.Country.CountryCode,
                                a.Country.CountryName,
                                a.Year.YearCode,
                                a.Year.YearName,
                                a.Coal,
                                a.Oil,
                                a.Gas,
                                a.Cement,
                                a.CO2_emission_summary
                            })
                            .ToList();
                        break;
                    case "gdp_growth":
                        result = _dbContext.gdp_growth
                            .Include(a => a.Country)
                            .Include(a => a.Year)
                            .Where(a => a.Year.YearCode == request.YearCode && a.Country.CountryCode == request.CountryCode)
                            .Select(a => new
                            {
                                a.GDPGrowthID,
                                a.Country.CountryCode,
                                a.Country.CountryName,
                                a.Year.YearCode,
                                a.Year.YearName,
                                a.GDP_growth
                            })
                            .ToList();
                        break;
                    case "gdp_growth_all":
                        result = _dbContext.gdp_growth
                            .Include(a => a.Country)
                            .Include(a => a.Year)
                            .Select(a => new
                            {
                                a.GDPGrowthID,
                                a.Country.CountryCode,
                                a.Country.CountryName,
                                a.Year.YearCode,
                                a.Year.YearName,
                                a.GDP_growth
                            })
                            .ToList();
                        break;
                    case "industry":
                        result = _dbContext.industry
                            .Include(a => a.Country)
                            .Include(a => a.Year)
                            .Where(a => a.Year.YearCode == request.YearCode && a.Country.CountryCode == request.CountryCode)
                            .Select(a => new
                            {
                                a.IndustryID,
                                a.Country.CountryCode,
                                a.Country.CountryName,
                                a.Year.YearCode,
                                a.Year.YearName,
                                a.Industry
                            })
                            .ToList();
                        break;
                    case "industry_all":
                        result = _dbContext.industry
                            .Include(a => a.Country)
                            .Include(a => a.Year)
                            .Select(a => new
                            {
                                a.IndustryID,
                                a.Country.CountryCode,
                                a.Country.CountryName,
                                a.Year.YearCode,
                                a.Year.YearName,
                                a.Industry
                            })
                            .ToList();
                        break;
                    default:
                        return BadRequest("Nieprawidłowa nazwa tabeli.");
                }

                return Ok(result);
            }
        }

        // Metoda obsługująca wywołanie SOAP
        private string SoapGetData(string yearCode, string countryCode)
        {
            // Tworzenie dokumentu XML z zapytaniem SOAP
            var xmlDoc = new XmlDocument();
            var envelope = xmlDoc.CreateElement("soap", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
            var body = xmlDoc.CreateElement("soap", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            var getData = xmlDoc.CreateElement("GetData", "http://example.com/soapwebservice");

            var yearCodeNode = xmlDoc.CreateElement("yearCode");
            yearCodeNode.InnerText = yearCode;
            getData.AppendChild(yearCodeNode);

            var countryCodeNode = xmlDoc.CreateElement("countryCode");
            countryCodeNode.InnerText = countryCode;
            getData.AppendChild(countryCodeNode);

            body.AppendChild(getData);
            envelope.AppendChild(body);
            xmlDoc.AppendChild(envelope);

            // Wywołanie metody SOAP na usłudze sieciowej
            var soapClient = new MySoapWebServiceClient();
            var soapResponse = soapClient.Invoke(xmlDoc);

            return soapResponse; // Zwrócenie odpowiedzi SOAP
        }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class IsolationAttribute : Attribute
    {
        public IsolationAttribute(IsolationLevel isolationLevel)
        {
            IsolationLevel = isolationLevel;
        }

        public IsolationLevel IsolationLevel
        {
            get;
        }
    }

    public class DataRequest
    {
        public string YearCode { get; set; }
        public string CountryCode { get; set; }
    }

    // Klient SOAP dla usługi sieciowej
    public class MySoapWebServiceClient
    {
        private const string SoapUrl = "http://example.com/soapwebservice"; // Adres URL usługi sieciowej SOAP

        public string Invoke(XmlDocument requestXml)
        {
            // Utwórz żądanie HTTP POST do usługi sieciowej SOAP
            var httpRequest = (HttpWebRequest)WebRequest.Create(SoapUrl);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "text/xml; charset=utf-8";

            // Konwersja dokumentu XML na tablicę bajtów
            byte[] xmlBytes = Encoding.UTF8.GetBytes(requestXml.OuterXml);

            // Ustawienie nagłówków żądania
            httpRequest.ContentLength = xmlBytes.Length;
            httpRequest.Headers.Add("SOAPAction", ""); // Ustawienie SOAPAction, jeśli jest wymagane

            // Zapisanie danych XML do strumienia żądania
            using (var requestStream = httpRequest.GetRequestStream())
            {
                requestStream.Write(xmlBytes, 0, xmlBytes.Length);
            }

            // Odebranie odpowiedzi od usługi sieciowej SOAP
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            // Odczytanie danych z odpowiedzi
            string soapResponse;
            using (var responseStream = httpResponse.GetResponseStream())
            {
                using (var reader = new StreamReader(responseStream))
                {
                    soapResponse = reader.ReadToEnd();
                }
            }

            return soapResponse; // Zwrócenie odpowiedzi SOAP
        }
    }
}
