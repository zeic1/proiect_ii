using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;

namespace TemperatureServiceClient
{
    public partial class Form1 : Form
    {
        // Web service URL - update this with your actual web service URL
        private string webServiceUrl = "https://localhost:44338/WebService1.asmx";

        public Form1()
        {
            InitializeComponent();
        }

        // Temperature conversion - F to C
        private void btnFtoC_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(txtTempF.Text, out double tempF))
                {
                    // Create and send the direct SOAP request
                    string result = InvokeWebService("ConvertTemperature",
                        new string[] { "temperature", "fromUnit" },
                        new string[] { tempF.ToString(), "F" });

                    double convertedTemp = double.Parse(result);
                    txtTempC.Text = convertedTemp.ToString("F2");
                    txtResult.Text = convertedTemp.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Please enter a valid temperature value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Temperature conversion - C to F
        private void btnCtoF_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(txtTempC.Text, out double tempC))
                {
                    string result = InvokeWebService("ConvertTemperature",
                        new string[] { "temperature", "fromUnit" },
                        new string[] { tempC.ToString(), "C" });

                    double convertedTemp = double.Parse(result);
                    txtTempF.Text = convertedTemp.ToString("F2");
                    txtResult.Text = convertedTemp.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Please enter a valid temperature value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Get current date and time
        private void btnGetDate_Click(object sender, EventArgs e)
        {
            try
            {
                string result = InvokeWebService("GetCurrentDateTime", null, null);
                DateTime dateTime = DateTime.Parse(result);
                lblDate.Text = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add element to the list
        private void btnAddList_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewItem.Text))
            {
                lstBox_Lista.Items.Add(txtNewItem.Text);
                txtNewItem.Clear();
            }
        }

        // Get 5 elements list from service
        private void btnGetList_Click(object sender, EventArgs e)
        {
            try
            {
                string result = InvokeWebService("GetFiveElements", null, null);

                // Parse the XML result to get the list items
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);

                XmlNodeList nodes = doc.GetElementsByTagName("string");

                lstBox_Lista.Items.Clear();
                foreach (XmlNode node in nodes)
                {
                    lstBox_Lista.Items.Add(node.InnerText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Currency conversion - Euro to Ron
        private void btnEuroToRon_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(txtEuro.Text, out double euroAmount))
                {
                    string result = InvokeWebService("ConvertCurrency",
                        new string[] { "amount", "fromCurrency", "toCurrency" },
                        new string[] { euroAmount.ToString(), "EURO", "LEI" });

                    double convertedAmount = double.Parse(result);
                    txtRon.Text = convertedAmount.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Please enter a valid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Currency conversion - Ron to Euro
        private void btnRonToEuro_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(txtRon.Text, out double ronAmount))
                {
                    string result = InvokeWebService("ConvertCurrency",
                        new string[] { "amount", "fromCurrency", "toCurrency" },
                        new string[] { ronAmount.ToString(), "LEI", "EURO" });

                    double convertedAmount = double.Parse(result);
                    txtEuro.Text = convertedAmount.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Please enter a valid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Generic method to invoke a web service method using raw SOAP
        private string InvokeWebService(string methodName, string[] paramNames, string[] paramValues)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(webServiceUrl);
            request.Headers.Add("SOAPAction", "http://tempuri.org/" + methodName);
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";

            string soapEnvelope =
                "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" " +
                "xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                "<soap:Body>" +
                "<" + methodName + " xmlns=\"http://tempuri.org/\">";

            // Add parameters if any
            if (paramNames != null && paramValues != null)
            {
                for (int i = 0; i < paramNames.Length; i++)
                {
                    soapEnvelope += "<" + paramNames[i] + ">" + paramValues[i] + "</" + paramNames[i] + ">";
                }
            }

            soapEnvelope += "</" + methodName + "></soap:Body></soap:Envelope>";

            // Send the SOAP request
            using (Stream stream = request.GetRequestStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(soapEnvelope);
                }
            }

            // Get the response
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();

                    // Parse the response to get the result
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(soapResult);

                    XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
                    nsManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
                    nsManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                    nsManager.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");
                    nsManager.AddNamespace("ns", "http://tempuri.org/");

                    XmlNode resultNode = doc.SelectSingleNode("//ns:" + methodName + "Response/ns:" + methodName + "Result", nsManager);

                    if (resultNode != null)
                    {
                        return resultNode.InnerXml;
                    }

                    return "";
                }
            }
        }
    }
}