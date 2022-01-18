using System;
using System.Data;
using Npgsql;
using System.Configuration;

namespace MilkDairy.Models
{
    public class queryExecitor
    {
        NpgsqlConnection con = null;
        NpgsqlCommand cmd = null;
        NpgsqlDataAdapter apd = null;

        public queryExecitor()
        {
            con = new NpgsqlConnection(ConfigurationManager.AppSettings["conStr"]);
            con.Open();
            cmd = new NpgsqlCommand();
            cmd.Connection = con;
        }
        public int Transaction(string query)
        {
            int res = 0;
            try
            {
                cmd.CommandText = query;
                res = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                res = 0;
            }
            return res;
        }

        public DataTable NonTransaction(string query)
        
        {
            DataTable res = new DataTable();
            try
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                apd = new NpgsqlDataAdapter(cmd);
                apd.Fill(res);
                con.Close();
            }
              catch (Exception)
            {
                res = null;
            }
            return res;
        }

        public double Aggregate(string query)
        {
            double res = 0;
            try
            { 
                cmd.CommandText = query;
                res = Convert.ToDouble(cmd.ExecuteScalar());
                con.Close();
            }
            catch(Exception)
            {
                res = 0;
            }
            return res;
        }
    }

}    