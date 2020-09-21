using ApiMunicipality;
using ExcelDataReader;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityWebSerivce
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            this.ScheduleService();
            
        }

        protected override void OnStop()
        {
        }

        public void ScheduleService()
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CoreServiceConnection"].ConnectionString;
                string filepath = ConfigurationManager.AppSettings["FilePathName"];
                DataTable data = new DataTable("Municipaliytable");
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
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
