using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOIslem
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Listeleme
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security=true");
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT CategoryID,CategoryName,Description FROM Categories";
                con.Open();
                //veritabınından tablo gelirse SqlDataReader Kullanılır
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())//Read() = Daha okunacak satır var ise True Döndürür
                {
                    int ID = reader.GetInt32(0);
                    string isim = reader.GetString(1);
                    string aciklama = reader.GetString(2);
                    Console.WriteLine(ID + ") " + isim + " - "+ aciklama);
                }
            }
            catch
            {
                Console.WriteLine("Hata");
            }
            finally
            {
                con.Close();
            }

            #endregion

            #region Veri Ekleme

            //Console.WriteLine("Lütfen Eklemek istegiğiniz kategori adını yazınız");
            //string Kategori = Console.ReadLine();
            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Coderz_Blog_DB;Integrated Security=true");
            //try
            //{
            //    SqlCommand cmd = con.CreateCommand();
            //    cmd.CommandText = "INSERT INTO Kategoriler(Isim) VALUES('"+Kategori+"')";
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    Console.WriteLine("kategori başarıyla eklendi");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine("Hata Oluştu");
            //}
            //finally
            //{
            //    con.Close();
            //}

            #endregion


        }
    }
}
