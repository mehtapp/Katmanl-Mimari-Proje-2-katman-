using IkORM.Entitiy;
using System;
using System.Data;
using System.Data.SqlClient;

namespace IkORM.Facade
{
    public class Pozisyonlar
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("pozisyonListele", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static string PozisyonCombo(string pozisyonId)
        {
            string secilipoz = "";
            SqlCommand cmd = new SqlCommand("Select pozisyonAd from pozisyon where pozisyonId=@pozId", Tools.Baglanti);
            try
            {
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@pozId", pozisyonId);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    secilipoz = rdr["pozisyonAd"].ToString();
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
            return secilipoz;



        }



        public static bool Ekle(Pozisyon pozisyon1)
        {
            SqlCommand komut = new SqlCommand("pozisyonEkle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@pozisyonAdi", pozisyon1.pozisyonAd);

            return Tools.ExecuteNonQuery(komut); //baglantı open close işlemleri için çağırılan methoddur
        }

        public static bool Sil(Pozisyon pozisyon1)
        {
            SqlCommand komut = new SqlCommand("pozisyonSil", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", pozisyon1.pozisyonId);
            return Tools.ExecuteNonQuery(komut);
        }
        public static bool Guncelle(Pozisyon pozisyon1)
        {
            SqlCommand komut = new SqlCommand("pozisyonGuncelle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", pozisyon1.pozisyonId);
            komut.Parameters.AddWithValue("@pozisyonAdi", pozisyon1.pozisyonAd);

            return Tools.ExecuteNonQuery(komut);



        }
    }
}
