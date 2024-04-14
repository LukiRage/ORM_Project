CREATE DATABASE IF NOT EXISTS projekt_db;
USE projekt_db;

CREATE TABLE IF NOT EXISTS country_dictionary (
    CountryCode VARCHAR(3) PRIMARY KEY,
    CountryName VARCHAR(100)
);


CREATE TABLE IF NOT EXISTS year_dictionary (
    YearCode VARCHAR(8) PRIMARY KEY,
    YearName INT
);


CREATE TABLE IF NOT EXISTS air_quality (
    AirQualityID INT PRIMARY KEY AUTO_INCREMENT,
    CountryCode VARCHAR(3),
    YearCode VARCHAR(8),
    PM2_5_value FLOAT,
    FOREIGN KEY (CountryCode) REFERENCES country_dictionary(CountryCode),
    FOREIGN KEY (YearCode) REFERENCES year_dictionary(YearCode)
);

CREATE TABLE IF NOT EXISTS co2_emission (
    CO2EmissionID INT PRIMARY KEY AUTO_INCREMENT,
    CountryCode VARCHAR(3),
    YearCode VARCHAR(8),
    Coal FLOAT,
    Oil FLOAT,
    Gas FLOAT,
    Cement FLOAT,
    CO2_emission_summary FLOAT,
    FOREIGN KEY (CountryCode) REFERENCES country_dictionary(CountryCode),
    FOREIGN KEY (YearCode) REFERENCES year_dictionary(YearCode)
);

CREATE TABLE IF NOT EXISTS gdp_growth (
    GDPGrowthID INT PRIMARY KEY AUTO_INCREMENT,
    CountryCode VARCHAR(3),
    YearCode VARCHAR(8),
    GDP_growth FLOAT,
    FOREIGN KEY (CountryCode) REFERENCES country_dictionary(CountryCode),
    FOREIGN KEY (YearCode) REFERENCES year_dictionary(YearCode)
);

CREATE TABLE IF NOT EXISTS industry (
    IndustryID INT PRIMARY KEY AUTO_INCREMENT,
    CountryCode VARCHAR(3),
    YearCode VARCHAR(8),
    Industry FLOAT,
    FOREIGN KEY (CountryCode) REFERENCES country_dictionary(CountryCode),
    FOREIGN KEY (YearCode) REFERENCES year_dictionary(YearCode)
);

INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2007]',2007);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2008]',2008);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2009]',2009);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2010]',2010);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2011]',2011);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2012]',2012);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2013]',2013);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2014]',2014);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2015]',2015);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2016]',2016);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2017]',2017);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2018]',2018);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2019]',2019);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2020]',2020);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2021]',2021);
INSERT INTO year_dictionary(YearCode,YearName) VALUES ('[YR2022]',2022);

INSERT INTO country_dictionary(CountryCode,CountryName) VALUES ('DNK','Denmark');
INSERT INTO country_dictionary(CountryCode,CountryName) VALUES ('GBR','Great Britain');
INSERT INTO country_dictionary(CountryCode,CountryName) VALUES ('NLD','Netherlands');
INSERT INTO country_dictionary(CountryCode,CountryName) VALUES ('POL','Poland');
INSERT INTO country_dictionary(CountryCode,CountryName) VALUES ('SVK','Slovakia');