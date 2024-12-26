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
    public partial class Yetkilendir : Form
    {
        public Yetkilendir()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();//SQL bağlantımızı dahil ediyoruz.


        private void button1_Click(object sender, EventArgs e)//Yetki Güncelle
        {
            try
            {

                SqlCommand kullanici = new SqlCommand("Select * From Kullanici Where Kul_id='"+textBox1.Text+"'", bgl.baglanti());
                SqlDataReader kul_oku= kullanici.ExecuteReader();
                while (kul_oku.Read())
                {

                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox2.Text=(kul_oku.GetValue(1).ToString());
                    textBox3.Text = (kul_oku.GetValue(2).ToString());

                }


                if (textBox1.Text == "")
                {
                    MessageBox.Show("Yetkilendirmek İstediğiniz Kişi Bilgilerinizi Boş Bırakmayınız!!!");
                }
                else if (radioButton1.Checked==false && radioButton2.Checked==false)
                {
                    MessageBox.Show("Yetkilendirmek İstediğiniz Kişi Yetkisini Seçiniz!!!");
                }
                else
                {
                    SqlCommand guncelle = new SqlCommand("Update Kullanici set Yetki=@p3 Where Kul_id='" + textBox1.Text + "'", bgl.baglanti());
                    if (radioButton1.Checked==true)
                    {
                        guncelle.Parameters.AddWithValue("@p3", "Kullanıcı");

                    }
                    else
                    {
                        guncelle.Parameters.AddWithValue("@p3", "Admin");

                    }
                    guncelle.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme Başarılı");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)//Anasayfa
        {
            try
            {
                Form1 menu = new Form1();
                menu.Show();
                this.Hide();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
