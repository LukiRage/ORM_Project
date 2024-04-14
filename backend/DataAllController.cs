//kontroler do pobierania wszystkich danych z tablicy przez REST
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
    [Route("api/all")]
    [ApiController]
    public class DataAllController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public DataAllController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Isolation(IsolationLevel.Serializable)]
        [Authorize(Roles = "number,admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{tableName}")]
        public IActionResult GetData(string tableName)//, [FromBody] DataRequest request
        {
            var result = Enumerable.Empty<object>();

            switch (tableName.ToLower())
            {

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

    }
}
