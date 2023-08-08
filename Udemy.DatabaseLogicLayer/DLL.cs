using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entities;
using System.Data;
using System.Security.Policy;

namespace Udemy.DatabaseLogicLayer
{
    public class DLL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        int returnValues;

        public DLL()
        {
            con = new SqlConnection("data source =.\\SQLEXPRESS;Initial Catalog = TelefonRehberi;User ID = sa;Password=1;Integrated Security=True;");
            cmd = new SqlCommand();
        }

        public void BaglantiAyarla()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                con.Close();
            }
        }

        public int KayitEkle(Rehber R)
        {
            try
            {
                cmd = new SqlCommand("insert into Rehber(ID,Isim,Soyisim,TelefonNumarasiI,TelefonNumarasiII,TelefonNumarasiIII,EmailAdres,WebAdres,Adres,Aciklama) values (@ID,@Isim,@Soyisim,@TelefonNumarasiI,@TelefonNumarasiII,@TelefonNumarasiIII,@EmailAdres,@WebAdres,@Adres,@Aciklama)", con);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = R.ID;
                cmd.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = R.Isim;
                cmd.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = R.Soyisim;
                cmd.Parameters.Add("@TelefonNumarasiI", SqlDbType.NVarChar).Value = R.TelefonNumarasiI;
                cmd.Parameters.Add("@TelefonNumarasiII", SqlDbType.NVarChar).Value = R.TelefonNumarasiII;
                cmd.Parameters.Add("@TelefonNumarasiIII", SqlDbType.NVarChar).Value = R.TelefonNumarasiIII;
                cmd.Parameters.Add("@EmailAdres", SqlDbType.NVarChar).Value = R.EmailAdres;
                cmd.Parameters.Add("@WebAdres", SqlDbType.NVarChar).Value = R.WebAdres;
                cmd.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = R.Adres;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = R.Aciklama;
                BaglantiAyarla();
                returnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return returnValues;
        }

        public int SistemKontrol(Kullanici K)
        {
            try
            {
                cmd = new SqlCommand("select count(*) from Kullanici where KullaniciAdi = @KullaniciAdi and Sifre = @Sifre", con);
                cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = K.KullaniciAdi;
                cmd.Parameters.Add("@Sifre", SqlDbType.NVarChar).Value = K.Sifre;
                BaglantiAyarla();
                returnValues = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return returnValues;
        }

        public int KayitDuzenle(Rehber R)
        {
            try
            {
                cmd = new SqlCommand(@"update Rehber
set
Isim = @Isim,
Soyisim = @Soyisim,
TelefonNumarasiI = @TelefonNumarasiI,
TelefonNumarasiII = @TelefonNumarasiII,
TelefonNumarasiIII = @TelefonNumarasiIII,
EmailAdres = @EmailAdres,
WebAdres = @WebAdres,
Adres = @Adres,
Aciklama = @Aciklama
where ID = @ID
                ", con);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = R.ID;
                cmd.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = R.Isim;
                cmd.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = R.Soyisim;
                cmd.Parameters.Add("@TelefonNumarasiI", SqlDbType.NVarChar).Value = R.TelefonNumarasiI;
                cmd.Parameters.Add("@TelefonNumarasiII", SqlDbType.NVarChar).Value = R.TelefonNumarasiII;
                cmd.Parameters.Add("@TelefonNumarasiIII", SqlDbType.NVarChar).Value = R.TelefonNumarasiIII;
                cmd.Parameters.Add("@EmailAdres", SqlDbType.NVarChar).Value = R.EmailAdres;
                cmd.Parameters.Add("@WebAdres", SqlDbType.NVarChar).Value = R.WebAdres;
                cmd.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = R.Adres;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = R.Aciklama;
                BaglantiAyarla();
                returnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return returnValues;
        }

        public int KayitSil(Guid ID)
        {
            try
            {
                cmd = new SqlCommand(@"delete Rehber 
where ID = @ID
                ", con);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
                BaglantiAyarla();
                returnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return returnValues;
        }

        public SqlDataReader KayitListe()
        {
            cmd = new SqlCommand("select*from Rehber", con);
            BaglantiAyarla();
            return cmd.ExecuteReader();

        }
        public SqlDataReader KayitListeID(Guid ID)
        {
            cmd = new SqlCommand("select*from Rehber where ID = @ID", con);
            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
            BaglantiAyarla();
            return cmd.ExecuteReader();
        }
        public int KullaniciEkle(string kullaniciAdi, string sifre, Guid id)
        {
            int returnValues = 0;
            try
            {
                cmd = new SqlCommand("insert into Kullanici(KullaniciAdi,Sifre,KullaniciID) values (@KullaniciAdi,@Sifre,@id)", con);
                cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = kullaniciAdi;
                cmd.Parameters.Add("@Sifre", SqlDbType.NVarChar).Value = sifre;
                cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                BaglantiAyarla();
                returnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                BaglantiAyarla();
            }
            return returnValues;
        }
        public SqlDataReader KullaniciKayitListe()
        {
            cmd = new SqlCommand("select*from Kullanici", con);
            con.Open();
            return cmd.ExecuteReader();
        }

    }
}
