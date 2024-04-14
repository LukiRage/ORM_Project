using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM_Projekt
{
    public class DataBaseModels
    {
        public class AirQuality
        {
            [Key]
            public int AirQualityID { get; set; }

            public string CountryCode { get; set; }

            public string YearCode { get; set; }

            public float PM2_5_value { get; set; }

            [ForeignKey("CountryCode")]
            public Country Country { get; set; }

            [ForeignKey("YearCode")]
            public Year Year { get; set; }
        }

        public class CO2Emission
        {
            [Key]
            public int CO2EmissionID { get; set; }

            public string CountryCode { get; set; }

            public string YearCode { get; set; }

            public float Coal { get; set; }

            public float Oil { get; set; }

            public float Gas { get; set; }

            public float Cement { get; set; }

            public float CO2_emission_summary { get; set; }

            [ForeignKey("CountryCode")]
            public Country Country { get; set; }

            [ForeignKey("YearCode")]
            public Year Year { get; set; }
        }

        public class GDPGrowth
        {
            [Key]
            public int GDPGrowthID { get; set; }

            public string CountryCode { get; set; }

            public string YearCode { get; set; }

            public float GDP_growth { get; set; }

            [ForeignKey("CountryCode")]
            public Country Country { get; set; }

            [ForeignKey("YearCode")]
            public Year Year { get; set; }
        }

        public class IndustryGrowth
        {
            [Key]
            public int IndustryID { get; set; }

            public string CountryCode { get; set; }

            public string YearCode { get; set; }

            public float Industry { get; set; }

            [ForeignKey("CountryCode")]
            public Country Country { get; set; }

            [ForeignKey("YearCode")]
            public Year Year { get; set; }
        }

        public class Country
        {
            [Key]
            public string CountryCode { get; set; }
            public string CountryName { get; set; }
        }

        public class Year
        {
            [Key]
            public string YearCode { get; set; }
            public int YearName { get; set; }
        }
    }
}
