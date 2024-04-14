using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//program.cs
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;
using static ORM_Projekt.DB_import_export;
using static ORM_Projekt.DataBaseModels;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.ServiceModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

//api controller (DataController)
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using ORM_Projekt.Controllers;
using Microsoft.IdentityModel.Tokens;

namespace ORM_Projekt
{
    [Route("importer")]
    public class ImporterController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public ImporterController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }


        //[Isolation(IsolationLevel.Serializable)]  //można dodać jak chcemy
        //Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //można dodać jak chcemy
        [HttpPost("{importTableName}")]
        public IActionResult GetImportData(string importTableName, [FromBody] DataRequest request)
        {
            if (string.IsNullOrEmpty(request.fileType) || string.IsNullOrEmpty(request.operationType)) //importFile='json'/'xml' importType='import/export'
            {
                return BadRequest("Nieprawidłowe dane wejściowe.");
            }
            else
            {

                var serverVersion = new MySqlServerVersion(new Version(8, 1, 10));
                var serviceProvider = new ServiceCollection()
                    .AddDbContext<DataContext>(options =>
                        options.UseMySql("Server=localhost;Port=3306;Database=projekt_db;Uid=root;Pwd=;", serverVersion))
                    .BuildServiceProvider();
                var context = serviceProvider.GetService<DataContext>();//<-- context

                var result = string.Empty;
                switch (importTableName.ToLower())
                {
                    case "air_quality":
                        if (request.fileType == "json" && request.operationType == "import")
                        {
                            
                            ImportTableFromJson<AirQuality>(Path.Combine("DATA(XML_JSON)", "json", "air_quality.json"), context.air_quality, context);
                            result = "Imported air_quality data from JSON successfully.";
                        }
                        else if (request.fileType == "json" && request.operationType == "export")
                        {
                            if (string.IsNullOrEmpty(request.yearCode) || string.IsNullOrEmpty(request.countryCode))
                            {
                                return BadRequest("Nie podano parametrów eksportu");
                            }
                            else
                            {
                                var airQualityData_JSON = context.air_quality
                                .Where(aq => aq.YearCode == request.yearCode && aq.CountryCode == request.countryCode)
                                .ToList();
                                ExportToJson(airQualityData_JSON, "export_air_quality.json");
                                result = "Exported air_quality data to JSON successfully.";
                            }

                        }
                        else if (request.fileType == "xml" && request.operationType == "import")
                        {
                            
                            ImportDataFromXml(context, Path.Combine("DATA(XML_JSON)", "xml", "air_quality.xml"), context.air_quality);
                            result = "Imported air_quality data from XML successfully.";
                        }
                        else if (request.fileType == "xml" && request.operationType == "export")
                        {
                            //kod eksportu
                            if (string.IsNullOrEmpty(request.yearCode) || string.IsNullOrEmpty(request.countryCode))
                            {
                                return BadRequest("Nie podano parametrów eksportu");
                            }
                            else
                            {
                                var airQualityData_XML = context.air_quality
                                .Where(ce => ce.YearCode == request.yearCode && ce.CountryCode == request.countryCode)
                                .ToList();
                                ExportToXml(airQualityData_XML, "export_air_quality.xml");
                                result = "Exported air_quality data to XML successfully.";
                            }
                            
                        }
                        break;

                    case "co2_emission":
                        if (request.fileType == "json" && request.operationType == "import")
                        {
                            
                            ImportTableFromJson<CO2Emission>(Path.Combine("DATA(XML_JSON)", "json", "co2_emission.json"), context.co2_emission, context);
                            result = "Imported co2_emission data from JSON successfully.";
                        }
                        else if (request.fileType == "json" && request.operationType == "export")
                        {
                            //kod eksportu
                            if (string.IsNullOrEmpty(request.yearCode) || string.IsNullOrEmpty(request.countryCode))
                            {
                                return BadRequest("Nie podano parametrów eksportu");
                            }
                            else
                            {
                                var co2EmissionData_JSON = context.co2_emission
                                .Where(ce => ce.YearCode == request.yearCode && ce.CountryCode == request.countryCode)
                                .ToList();
                                ExportToJson(co2EmissionData_JSON, "export_co2_emission.json");
                                result = "Exported co2_emission data to JSON successfully.";
                            }
                            
                        }
                        else if (request.fileType == "xml" && request.operationType == "import")
                        {
                            
                            ImportDataFromXml(context, Path.Combine("DATA(XML_JSON)", "xml", "co2_emission.xml"), context.co2_emission);
                            result = "Imported co2_emission data from XML successfully.";
                        }
                        else if (request.fileType == "xml" && request.operationType == "export")
                        {
                            //kod eksportu
                            if (string.IsNullOrEmpty(request.yearCode) || string.IsNullOrEmpty(request.countryCode))
                            {
                                return BadRequest("Nie podano parametrów eksportu");
                            }
                            else
                            {
                                var co2EmissionData_XML = context.co2_emission
                                .Where(ce => ce.YearCode == request.yearCode && ce.CountryCode == request.countryCode)
                                .ToList();
                                ExportToXml(co2EmissionData_XML, "export_co2_emission.xml");
                                result = "Exported co2_emission data to XML successfully.";
                            }
                            
                        }
                        break;

                    case "gdp_growth":
                        if (request.fileType == "json" && request.operationType == "import")
                        {
                           
                            ImportTableFromJson<GDPGrowth>(Path.Combine("DATA(XML_JSON)", "json", "GPD_growth.json"), context.gdp_growth, context);
                            result = "Imported gdp_growth data from JSON successfully.";
                        }
                        else if (request.fileType == "json" && request.operationType == "export")
                        {
                            //kod eksportu
                            if (string.IsNullOrEmpty(request.yearCode) || string.IsNullOrEmpty(request.countryCode))
                            {
                                return BadRequest("Nie podano parametrów eksportu");
                            }
                            else
                            {
                                var GPD_growthData_JSON = context.gdp_growth
                                .Where(ce => ce.YearCode == request.yearCode && ce.CountryCode == request.countryCode)
                                .ToList();
                                ExportToJson(GPD_growthData_JSON, "export_GPD_growth.json");
                                result = "Exported gpd_growth data to JSON successfully.";
                            }
                        }
                        else if (request.fileType == "xml" && request.operationType == "import")
                        {
                            
                            ImportDataFromXml(context, Path.Combine("DATA(XML_JSON)", "xml", "GPD_growth.xml"), context.gdp_growth);
                            result = "Imported gdp_growth data from XML successfully.";
                        }
                        else if (request.fileType == "xml" && request.operationType == "export")
                        {
                            //kod eksportu
                            if (string.IsNullOrEmpty(request.yearCode) || string.IsNullOrEmpty(request.countryCode))
                            {
                                return BadRequest("Nie podano parametrów eksportu");
                            }
                            else
                            {
                                var GPD_growthData_XML = context.gdp_growth
                                .Where(ce => ce.YearCode == request.yearCode && ce.CountryCode == request.countryCode)
                                .ToList();
                                ExportToXml(GPD_growthData_XML, "export_GPD_growth.xml");
                                result = "Exported gpd_growth data to XML successfully.";
                            }
                        }


                        break;
                    case "industry":
                        if (request.fileType == "json" && request.operationType == "import")
                        {
                            
                            ImportTableFromJson<IndustryGrowth>(Path.Combine("DATA(XML_JSON)", "json", "industry.json"), context.industry, context);
                            result = "Imported industry data from JSON successfully.";
                        }
                        else if (request.fileType == "json" && request.operationType == "export")
                        {
                            //kod eksportu
                            if (string.IsNullOrEmpty(request.yearCode) || string.IsNullOrEmpty(request.countryCode))
                            {
                                return BadRequest("Nie podano parametrów eksportu");
                            }
                            else
                            {
                                var Industry_growthData_JSON = context.industry
                                .Where(ce => ce.YearCode == request.yearCode && ce.CountryCode == request.countryCode)
                                .ToList();
                                ExportToJson(Industry_growthData_JSON, "export_Industry_growth.json");
                                result = "Exported industry data to JSON successfully.";
                            }
                        }
                        else if (request.fileType == "xml" && request.operationType == "import")
                        {
                            
                            ImportDataFromXml(context, Path.Combine("DATA(XML_JSON)", "xml", "industry.xml"), context.industry);
                            result = "Imported industry data from XML successfully.";
                        }
                        else if (request.fileType == "xml" && request.operationType == "export")
                        {
                            //kod eksportu
                            if (string.IsNullOrEmpty(request.yearCode) || string.IsNullOrEmpty(request.countryCode))
                            {
                                return BadRequest("Nie podano parametrów eksportu");
                            }
                            else
                            {
                                var Industry_growthData_XML = context.industry
                                   .Where(ce => ce.YearCode == request.yearCode && ce.CountryCode == request.countryCode)
                                    .ToList();
                                ExportToXml(Industry_growthData_XML, "export_Industry_growth.xml");
                                result = "Exported industry data to XML successfully.";
                            }
                        }
                        break;
                    default:
                        return BadRequest("Nieprawidłowa nazwa tabeli.");
                }
                return Ok(result);
            }
        }

        /*[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
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
        }*/

        /* public class DataRequest
         {
             public string importFile
             {
                 get; set;
             }
             public string importType
             {
                 get; set;
             }
         }*/

        public class DataRequest
        {
            public string fileType
            {
                get; set;
            }
            public string operationType
            {
                get; set;
            }  
            public string yearCode
            {

                get;set;
            }
            public string countryCode
            {

                get;set;
            }
        }









    }
}

