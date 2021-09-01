using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceApp1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            var data = "It is WcfServiceApp1 on Windows User Node --> ";
            try
            {
                using (var client = new HttpClient())
                {
                    data += "Calling another service within same windows node --> ";
                    client.BaseAddress = new Uri("http://windowscoreapp1");
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = client.GetAsync("Sample").Result;
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var response = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        data += "Success --> ";
                        data += response + "--> ";
                    }
                    else
                    {
                        data += "Failed --> " + Res.StatusCode.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                data += "Failed --> " + ex.Message;

            }

            try
            {
                using (var client = new HttpClient())
                {
                    data += "Calling another service from windows node diff subnate --> ";
                    client.BaseAddress = new Uri("http://windowscoreapp3");
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = client.GetAsync("Sample").Result;
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var response = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        data += "Success --> ";
                        data += response + "--> ";
                    }
                    else
                    {
                        data += "Failed --> " + Res.StatusCode.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                data += "Failed --> " + ex.Message;

            }

            return string.Format($"{data}. You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
