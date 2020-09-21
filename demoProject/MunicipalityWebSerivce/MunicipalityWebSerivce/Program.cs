using ApiMunicipality;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityWebSerivce
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            
            string ConnectionString = ConfigurationManager.ConnectionStrings["CoreServiceConnection"].ConnectionString;
            string filepath = @"D:\Pradeep\DemoProject\MunicipalityWebSerivce\MunicipalityWebSerivce\File\XMLFile1.xml";
            DataTable data = new DataTable();
            DataSet ds = new DataSet();
            ds.ReadXml(filepath);
            data = ds.Tables[0];
            for (int i = 0; i < data.Rows.Count; i++)
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Municipality", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add("@Municipality_name", SqlDbType.VarChar).Value = data.Rows[i]["MunicipalityName"];
                        cmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = data.Rows[i]["Date"];
                        cmd.Parameters.Add("@Result", SqlDbType.VarChar).Value = data.Rows[i]["Result"];

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            //string baseAddress = "http://localhost:9000/";


            //using (WebApp.Start<Startup>(url: baseAddress))
            //{

            //    HttpClient client = new HttpClient();

            //    var response = client.GetAsync(baseAddress + "api/values").Result;

            //    Console.WriteLine(response);
            //    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            //    Console.ReadLine();
            //    Console.ReadKey();
            //}
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
