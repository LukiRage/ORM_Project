using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ORM_Projekt
{
    internal class DB_import_export
    {

        public static void ExportToJson<T>(IEnumerable<T> data, string fileName)
        {
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public static void ExportToXml<T>(IEnumerable<T> data, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fileStream, data);
            }
        }

        public static void ImportTableFromJson<T>(string filePath, DbSet<T> dbSet, DbContext dbContext) where T : class
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string jsonString = reader.ReadToEnd();
                List<T> records = System.Text.Json.JsonSerializer.Deserialize<List<T>>(jsonString);

                using (var transaction = dbContext.Database.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        dbSet.AddRange(records);
                        dbContext.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Wystąpił błąd podczas importu danych: " + ex.Message);
                    }
                }
            }
        }

        public static void ImportDataFromXml<T>(DataContext context, string filePath, DbSet<T> dbSet) where T : class
        {
            var xmlData = File.ReadAllText(filePath);
            var xmlDoc = XDocument.Parse(xmlData);

            var records = xmlDoc.Root.Elements().Select(element => ParseXmlData<T>(element)).ToList();

            using (var transaction = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    dbSet.AddRange(records);
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Wystąpił błąd podczas importu danych: " + ex.Message);
                }
            }
        }



        public static T ParseXmlData<T>(XElement element) where T : class
        {
            var properties = typeof(T).GetProperties();

            var record = Activator.CreateInstance<T>();

            foreach (var property in properties)
            {
                var xmlValue = element.Element(property.Name)?.Value;
                var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                if (xmlValue != null)
                {
                    var convertedValue = Convert.ChangeType(xmlValue, propertyType);
                    property.SetValue(record, convertedValue);
                }
            }
            return record;
        }

    }
}
