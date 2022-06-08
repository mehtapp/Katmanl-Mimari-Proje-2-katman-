using IkORM.Entitiy;
using System;
using System.Data;
using System.Data.SqlClient;


namespace IkORM.Facade
{
    public class Sirketler
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("sirketListele", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }


        public static bool Ekle(Sirket sirket1)
        {
            SqlCommand komut = new SqlCommand("sirketEkle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@sAd", sirket1.SirketAd);
            komut.Parameters.AddWithValue("@sAdres", sirket1.SirketAdres);
            komut.Parameters.AddWithValue("@sTel", sirket1.Stel);
            komut.Parameters.AddWithValue("@sMail", sirket1.Smail);
            komut.Parameters.AddWithValue("@bolumId", sirket1.BolumId);
            komut.Parameters.AddWithValue("@pozId", sirket1.PozisyonId);
            return Tools.ExecuteNonQuery(komut); //baglantı open close işlemleri için çağırılan methoddur
        }

        public static bool Sil(Sirket sirket1)
        {
            SqlCommand komut = new SqlCommand("sirketSil", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", sirket1.sirketId);
            return Tools.ExecuteNonQuery(komut);
        }
        public static bool Guncelle(Sirket sirket1)
        {
            try
            {
                SqlCommand komut = new SqlCommand("sirketGuncelle", Tools.Baglanti);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@sAd", sirket1.SirketAd);
                komut.Parameters.AddWithValue("@sAdres", sirket1.SirketAdres);
                komut.Parameters.AddWithValue("@sTel", sirket1.Stel);
                komut.Parameters.AddWithValue("@sMail", sirket1.Smail);
                komut.Parameters.AddWithValue("@bolumId", sirket1.BolumId);
                komut.Parameters.AddWithValue("@pozId", sirket1.PozisyonId);
                komut.Parameters.AddWithValue("@sirketId", sirket1.sirketId);


                return Tools.ExecuteNonQuery(komut);
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
