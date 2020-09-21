using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
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

    public List<Taxdetail> getTaxdetails(string name, string dt)
    {
        try
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["CoreServiceConnection"].ConnectionString;
            List<Taxdetail> list = new List<Taxdetail>();
            SqlConnection conn = new SqlConnection(ConnectionString);

            string Query = "select * from Municipalitydetails where municipalityName='" + name + "' and Result='" + dt + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Taxdetail meta = new Taxdetail();
                    meta.municipalityName = dr["municipalityName"].ToString();
                    meta.date = dr["Date"].ToString();
                    meta.result = Convert.ToDecimal(dr["Result"]);
                    list.Add(meta);
                }
            }
            dr.Close();
            return list;
        }
        catch (Exception ex )
        {

            throw ex;
        }
       
    }
}
