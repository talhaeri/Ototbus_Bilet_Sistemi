using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//SQL kütüphanesi

namespace Otobus_Bileti_Otomasyonu
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();//SQL bağlantımızı dahil ediyoruz.
        internal static string yetki;


        private void button1_Click(object sender, EventArgs e)//Giriş
        {
            try
            {

                SqlCommand giris = new SqlCommand("Select * From Kullanici Where Kul_adi='" + textBox1.Text + "' and Kul_sifre='" + textBox2.Text + "'", bgl.baglanti());
                SqlDataReader oku = giris.ExecuteReader();
                while (oku.Read())
                {
                    if (oku.GetValue(3).ToString() == "Admin")
                    {
                        yetki = "Admin";
                        Form1 menu = new Form1();
                        menu.Show();
                        this.Hide();
                    }
                    else if (oku.GetValue(3).ToString() == "Kullanıcı")
                    {
                        yetki = "Kullanıcı";
                        Bilet_Satis satis = new Bilet_Satis();
                        satis.Show();
                        this.Hide();
                    }
                    else
                    {

                        MessageBox.Show("Lütfen Bilgilerinizi Kontrol Ediniz.\nTekrar Deneyiniz.");
                    }


                    
                     SqlCommand giris2 = new SqlCommand("SELECT * FROM Kullanici WHERE kul_adi=@kul_adi and kul_sifre=@sifre", bgl.baglanti());
                     giris.Parameters.AddWithValue("@kul_adi", textBox1.Text);
                     giris.Parameters.AddWithValue("@sifre", textBox2.Text);
                     SqlDataReader oku2 = giris2.ExecuteReader();
                         if (oku2.GetValue(3).ToString() == "Admin")
                         {
                             Form1 menu = new Form1();
                             menu.Show();
                             this.Hide();
                         }
                         else if (oku2.GetValue(3).ToString() == "Kullanıcı")
                         {
                             Bilet_Satis bilet = new Bilet_Satis();
                             bilet.Show();
                             this.Hide();
                         }
                         else
                         {
                             MessageBox.Show("Yetkisiz Kullanıcı.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         }

                 }
             }
             catch (Exception)
             {
                
             }
                    
             }



        private void button2_Click(object sender, EventArgs e)//Temizle
        {
            try
            {
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)//Çıkış
        {
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
