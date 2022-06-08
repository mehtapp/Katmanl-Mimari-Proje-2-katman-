using IkORM.Entitiy;
using System;
using System.Data;
using System.Data.SqlClient;

namespace IkORM.Facade
{
    public class Bolumler
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("bolumListele", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static string BolumlerCombo(string bolumId)
        {
            string secilibolum = "";
            SqlCommand cmd = new SqlCommand("Select bolumAd from bolum where id=@id", Tools.Baglanti);
            try
            {
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@id", bolumId);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    secilibolum = rdr["bolumAd"].ToString();
                }
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                cmd.Connection.Close();
            }
            return secilibolum;

        }

        public static bool Ekle(Bolum bolum1)
        {
            SqlCommand komut = new SqlCommand("bolumEkle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@bolumAdi", bolum1.BolumAd);

            return Tools.ExecuteNonQuery(komut); //baglantı open close işlemleri için çağırılan methoddur
        }

        public static bool Sil(Bolum bolum1)
        {
            SqlCommand komut = new SqlCommand("bolumSil", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", bolum1.Bolumid);
            return Tools.ExecuteNonQuery(komut);
        }
        public static bool Guncelle(Bolum bolum1)
        {
            SqlCommand komut = new SqlCommand("bolumGuncelle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", bolum1.Bolumid);
            komut.Parameters.AddWithValue("@bolumAdi", bolum1.BolumAd);

            return Tools.ExecuteNonQuery(komut);



        }
    }
}
