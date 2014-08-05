using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace SqleVeriGirişiYapma
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //appConfig Dosyasından Kullanıcı ve Kolon Bilgilerini Çekiyoruz.

            KullanıcıBilgileri();
            KolonBilgileri();

            //Veri tabanı ile bağlantıyı sağlıyoruz. 

            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqleVeriGirişiYapma.Properties.Settings.baglantiyolu"].ConnectionString;
                
            try
            {
                baglanti.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hatalı Kullanım. Hata Nedeni:", ex);
                return;
               
            }
           
            //Konsoldan Verileri Alıyoruz.

            if (args.Length < c)
            {
                Console.WriteLine("Eksik parametre girdiniz.");
                Console.Write("kullanım: ***.exe"+"  ");
                for (int k = 0; k < c; k++)
                {
                    Console.Write(b[k]+"  ");
                }
                Console.ReadLine();
                return;
            }
            else if (args.Length > c)
            {
                Console.WriteLine("Fazla parametre girdiniz.");
                Console.WriteLine("kullanım: ***.exe"+"  ");
                for (int l = 0; l < c; l++)
                {
                    Console.Write(b[l]+"  ");
                };
                Console.ReadLine();
                return;
            }

            string kullanıcıAdı = args[0];
            string Adı = args[1];
            string Soyadı = args[2];
            string Yasi = args[3];
            string TelNumarasi = args[4];

            int TelNumarası = Convert.ToInt32(TelNumarasi);
            int Yas = Convert.ToInt32(Yasi);

            //Sql veritabanına veri kayıt edebilmek için gereken kod parçası.Table değişken olarak alındı.
            string tableName = Properties.Settings.Default.tabloadı;
            SqlCommand cmd = new SqlCommand("Insert into'" + tableName + "'" + "(kullanıcıAdı,Adı,Soyadı,Yas,TelNumarası) values(@kullanıcıAdı,@Adı,@Soyadı,@Yas,@TelNumarası)", baglanti);
            cmd.Connection = baglanti;
            
            //cmd.Parameters.AddWithValue("@table", tableName);
            cmd.Parameters.AddWithValue("@kullanıcıAdı",kullanıcıAdı);
            cmd.Parameters.AddWithValue("@Adı",Adı);
            cmd.Parameters.AddWithValue("@Soyadı",Soyadı);
            cmd.Parameters.AddWithValue("@Yas",Yas);
            cmd.Parameters.AddWithValue("@TelNumarası",TelNumarası);
           
            //kaynakları iade etmek için bağlantıyı kapatıyoruz.
            //cmd.ExecuteNonQuery();
            //baglanti.Close();
           
            
              //SqlCommand üzerinde bir komutu çalıştırmak için ExecuteNonQery metodunu çağırıyoruz.
            
             
                 int a = 0;
                  try
                  {
                      a = cmd.ExecuteNonQuery();
                      Console.WriteLine("asfasfaj="+a);
                  }
                  catch(Exception ex)
                  {
                      Console.WriteLine("Burdayım.Hatalı Kullanım. Hata Nedeni:",ex);
                  }
            
                  //kaynakları iade etmek için bağlantıyı kapatıyoruz.

                   baglanti.Close();

                   Console.WriteLine("asfasfaj=" + a);
                  if ( a >= 1 )
                  {
                      Console.WriteLine("Kayıt eklendi,başarılı.");
                  }
                  else
                  {
                      Console.WriteLine("burda2Hatalı kod,Kayıt eklenemedi.");
                  }

                  Console.ReadKey(true);
                 
              


            //Birden fazla satırın sonuç olarak doneceği sorgularda kullanılır.Kolonbilgileri yordamıyla aynı işi mi yapıyor?
                
               SqlCommand comm1 = new SqlCommand("select * from kullanıcıBilgileri", baglanti);
                baglanti.Open();
                SqlDataReader DR1 = comm1.ExecuteReader();
                if (DR1.Read())
                {
                    Console.WriteLine("DR1.GetValue(0).ToString()");
                    Console.WriteLine(DR1.GetValue(0).ToString());
                }
                baglanti.Close();
                
        }
       

            
        //appConfig dosyasından kullanıcı bilgilerimizi çekecek yordam.
            
        public static void KullanıcıBilgileri()
        {
            string a = Properties.Settings.Default.tabloadı;
            Console.WriteLine(a);
        }
       
        //appConfig dosyasından kolon bilgilerimizi çekecek yordam.

        static int c;
        static string[] b;
        public static void KolonBilgileri()
            {
                c = Properties.Settings.Default.kolonlar.Count;
                 b = new string[c];
                for (int i = 0; i < c; i++)
                {
                    b[i] = Properties.Settings.Default.kolonlar[i];
                    Console.WriteLine(b[i]);
                }
                
            
            }
    
           /*Gerek yok silinecek???
                Sql veritabanına veri kayıt edebilmek için gereken kod parçasını yazıyorum.
           
                SqlCommand cmd = new SqlCommand("Insert into "+AppSettingsReader("tabloismi") +"(kullanıcıAdı,Adı,Soyadı,Yasi,telNo) values('"+kullanıcıAdı+"','"+Adı+"','"+Soyadı+"','"+Yas+"','"+TelNumarası+"')");
                cmd.Connection = baglanti;

            
               */                

    }
}

