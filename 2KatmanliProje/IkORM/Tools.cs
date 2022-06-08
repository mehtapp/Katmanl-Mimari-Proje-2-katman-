using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;

namespace IkORM
{
    public class Tools
    {
        //sitatic olunca  nesne üretmeden direk erişim sağlama imkanı veriri.
        private static SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["insanKaynaklari"].ConnectionString);
        public static SqlConnection Baglanti
        {
            get { return baglanti; }
            set { baglanti = value; }

        }

        public static bool ExecuteNonQuery(SqlCommand komut)
        {
            try
            {
                if (komut.Connection.State != ConnectionState.Open)

                    komut.Connection.Open();
                return komut.ExecuteNonQuery() > 0;


            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Close();
            }
        }
    }
}
