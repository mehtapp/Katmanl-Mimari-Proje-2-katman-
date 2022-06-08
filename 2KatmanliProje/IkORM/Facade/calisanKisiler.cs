using IkORM.Entitiy;
using System.Data;
using System.Data.SqlClient;


namespace IkORM.Facade
{
    public class calisanKisiler
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("calisanListele", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }


        public static bool Ekle(calisanKisi calisan)
        {
            SqlCommand komut = new SqlCommand("calisanEkle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@adSoyad", calisan.calisanAdSoyad);
            komut.Parameters.AddWithValue("@yas", calisan.calisanYas);
            komut.Parameters.AddWithValue("@adres", calisan.calisanAdres);
            komut.Parameters.AddWithValue("@mail", calisan.calisanMail);
            komut.Parameters.AddWithValue("@maas", calisan.calisanMaas);
            komut.Parameters.AddWithValue("@pozisyonId", calisan.pozisyonId);

            return Tools.ExecuteNonQuery(komut); //baglantı open close işlemleri için çağırılan methoddur
        }

        public static bool Sil(calisanKisi calisan)
        {
            SqlCommand komut = new SqlCommand("calisanSil", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", calisan.calisanId);
            return Tools.ExecuteNonQuery(komut);
        }
        public static bool Guncelle(calisanKisi calisan)
        {
            SqlCommand komut = new SqlCommand("calisanGuncelle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", calisan.calisanId);
            komut.Parameters.AddWithValue("@adSoyad", calisan.calisanAdSoyad);
            komut.Parameters.AddWithValue("@yas", calisan.calisanYas);
            komut.Parameters.AddWithValue("@adres", calisan.calisanAdres);
            komut.Parameters.AddWithValue("@mail", calisan.calisanMail);
            komut.Parameters.AddWithValue("@maas", calisan.calisanMaas);
            komut.Parameters.AddWithValue("@pozisyonId", calisan.pozisyonId);
            return Tools.ExecuteNonQuery(komut);



        }
    }
}
