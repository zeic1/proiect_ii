using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TemperatureWebService1
{
    /// <summary>
    /// Web service that provides various utility methods
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UtilityService : WebService
    {
        // Method 1: Convert temperature from Fahrenheit to Celsius and vice versa
        [WebMethod]
        public double ConvertTemperature(double temperature, string fromUnit)
        {
            if (fromUnit.ToUpper() == "F")
            {
                // Convert Fahrenheit to Celsius
                return (temperature - 32) * 5 / 9;
            }
            else if (fromUnit.ToUpper() == "C")
            {
                // Convert Celsius to Fahrenheit
                return (temperature * 9 / 5) + 32;
            }
            else
            {
                throw new ArgumentException("Unit must be 'F' or 'C'");
            }
        }

        // Method 2: Get the current date and time
        [WebMethod]
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        // Method 3: Get a list with 5 elements
        [WebMethod]
        public List<string> GetFiveElements()
        {
            List<string> elements = new List<string>
            {
                "Element 1",
                "Element 2",
                "Element 3",
                "Element 4",
                "Element 5"
            };

            return elements;
        }

        // Method 4: Convert between two currencies (lei - euro)
        [WebMethod]
        public double ConvertCurrency(double amount, string fromCurrency, string toCurrency)
        {
            // Using fixed exchange rates for demonstration
            // In a real application, these would be retrieved from a service
            const double leiToEuroRate = 0.2; // 1 leu = 0.2 euro
            const double euroToLeiRate = 5.0; // 1 euro = 5 lei

            if (fromCurrency.ToUpper() == "LEI" && toCurrency.ToUpper() == "EURO")
            {
                return amount * leiToEuroRate;
            }
            else if (fromCurrency.ToUpper() == "EURO" && toCurrency.ToUpper() == "LEI")
            {
                return amount * euroToLeiRate;
            }
            else
            {
                throw new ArgumentException("Only conversion between LEI and EURO is supported");
            }
        }
    }

}
