using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace TemperatureWebService2
{
    /// <summary>
    /// Utility Web Service that provides various methods for temperature conversion,
    /// date/time, list management, and currency conversion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class UtilityService : System.Web.Services.WebService
    {
        /// <summary>
        /// Method 1: Converts temperature between Fahrenheit and Celsius
        /// </summary>
        /// <param name="temperature">The temperature value to convert</param>
        /// <param name="fromUnit">The source unit ('F' for Fahrenheit or 'C' for Celsius)</param>
        /// <returns>The converted temperature value</returns>
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

        /// <summary>
        /// Method 2: Returns the current date and time
        /// </summary>
        /// <returns>Current date and time</returns>
        [WebMethod]
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Method 3: Returns a list with 5 elements
        /// </summary>
        /// <returns>List of 5 string elements</returns>
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

        /// <summary>
        /// Method 4: Converts between currencies (LEI - EURO)
        /// </summary>
        /// <param name="amount">The amount to convert</param>
        /// <param name="fromCurrency">Source currency ('LEI' or 'EURO')</param>
        /// <param name="toCurrency">Target currency ('LEI' or 'EURO')</param>
        /// <returns>The converted amount</returns>
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