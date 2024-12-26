using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;//SQL kütüphanesi

namespace Otobus_Bileti_Otomasyonu
{
    public partial class Yetki_Kaldir : Form
    {
        public Yetki_Kaldir()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();//SQL bağlantımızı dahil ediyoruz.

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

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Yetkilendirmek İstediğiniz Kişi Bilgilerinizi Boş Bırakmayınız!!!");
                }
                else
                {
                    SqlCommand guncelle = new SqlCommand("Update Kullanici set Yetki=@p3 Where Kul_id='" + textBox1.Text + "'", bgl.baglanti());
                    guncelle.Parameters.AddWithValue("@p3", "Kullanıcı");
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
    }
}
