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

INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2007]',18.42,24.17,9.74,1.41,53.74);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2008]',16.13,23.32,9.83,1.15,50.43);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2009]',15.78,22.30,9.41,0.76,48.26);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2010]',15.35,21.95,10.57,0.67,48.54);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2011]',12.91,20.92,8.98,0.86,43.68);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2012]',10.08,19.95,8.41,0.87,39.32);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2013]',12.75,19.57,7.94,0.87,41.14);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2014]',10.14,19.08,6.82,0.89,36.93);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2015]',7.24,19.58,6.91,0.93,34.67);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2016]',8.41,19.86,7.01,1.10,36.39);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2017]',6.25,20.03,6.68,1.19,34.16);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2018]',6.36,20.09,6.48,1.16,34.09);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2019]',3.59,19.70,6.02,1.13,30.43);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2020]',3.14,18.59,4.79,1.23,27.75);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('DNK','[YR2021]',4.38,18.67,4.78,1.23,29.05);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2007]',33.03,58.61,77.47,0.40,169.52);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2008]',32.02,59.06,81.20,0.40,172.68);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2009]',29.41,55.78,81.74,0.42,167.35);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2010]',30.42,56.98,91.54,0.35,179.28);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2011]',29.62,56.39,79.73,0.35,166.09);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2012]',31.88,54.30,76.11,0.31,162.60);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2013]',32.44,52.67,76.95,0.27,162.33);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2014]',35.80,52.20,67.01,0.28,155.29);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2015]',43.55,51.89,66.15,0.25,161.83);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2016]',40.07,53.20,68.95,0.24,162.46);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2017]',36.03,52.93,70.73,0.30,159.99);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2018]',32.53,53.61,69.86,0.22,156.22);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2019]',25.31,53.00,72.47,0.01,150.79);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2020]',16.99,48.16,70.67,0.00,135.82);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('NLD','[YR2021]',23.00,47.94,68.08,0.01,139.03);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2007]',227.71,66.01,27.91,7.05,328.68);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2008]',220.47,67.23,28.13,6.69,322.53);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2009]',209.07,67.93,27.27,5.76,310.03);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2010]',220.93,70.86,29.13,6.22,327.15);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2011]',218.38,70.53,29.33,7.38,325.61);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2012]',214.04,67.27,30.56,6.38,318.25);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2013]',214.31,62.58,30.80,5.87,313.57);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2014]',203.00,62.29,29.46,6.46,301.21);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2015]',201.65,65.70,30.63,6.34,304.32);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2016]',202.10,73.98,32.42,6.53,315.03);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2017]',203.60,83.59,34.13,7.00,328.31);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2018]',198.83,86.61,34.28,7.66,327.38);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2019]',177.94,88.16,35.49,7.69,309.28);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2020]',164.23,85.53,36.76,7.69,294.22);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('POL','[YR2021]',179.50,91.71,40.57,7.50,319.28);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2007]',17.56,9.30,11.38,1.48,39.73);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2008]',17.06,9.63,11.77,1.60,40.06);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2009]',16.03,9.00,10.41,1.21,36.65);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2010]',16.05,9.33,11.05,0.86,37.29);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2011]',16.30,8.86,10.42,1.26,36.85);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2012]',14.58,9.12,10.06,1.10,34.86);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2013]',14.28,8.99,10.24,1.14,34.64);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2014]',14.08,8.87,8.49,1.27,32.70);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2015]',13.92,9.65,8.71,1.31,33.59);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2016]',13.83,10.02,8.85,1.34,34.04);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2017]',14.28,10.14,9.39,1.37,35.18);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2018]',14.21,10.23,9.36,1.35,35.15);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2019]',11.78,10.32,9.37,1.40,32.87);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2020]',9.96,9.61,9.29,1.44,30.30);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('SVK','[YR2021]',12.58,10.09,10.39,1.44,34.51);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2007]',150.84,196.16,196.52,6.12,549.64);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2008]',139.22,188.80,202.65,5.20,535.88);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2009]',113.82,180.26,188.07,3.72,485.88);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2010]',118.03,179.85,201.93,3.79,503.60);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2011]',117.15,172.06,168.24,4.10,461.54);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2012]',148.01,170.29,158.24,3.72,480.26);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2013]',142.46,165.76,157.62,4.03,469.86);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2014]',115.43,166.51,144.49,4.21,430.65);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2015]',91.55,170.77,147.90,4.39,414.61);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2016]',47.82,173.93,165.74,4.55,392.05);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2017]',39.13,174.85,161.70,4.41,380.09);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2018]',33.28,173.09,161.49,4.36,372.22);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2019]',24.51,169.00,159.32,4.45,357.28);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2020]',22.81,143.98,149.42,3.90,320.11);
INSERT INTO co2_emission(CountryCode,YearCode,Coal,Oil,Gas,Cement,CO2_emission_summary) VALUES ('GBR','[YR2021]',23.69,154.11,158.86,3.90,340.56);
