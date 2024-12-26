using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;//SQL kütüphanesi ekledik.

namespace Otobus_Bileti_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void pictureBox3_Click(object sender, EventArgs e)//Otobüs İşlemleri
        {
            try
            {
                Otobus otobus= new Otobus();
                otobus.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)//Güzergah işlemleri
        {
            try
            {
                Guzergah guzergah= new Guzergah();
                guzergah.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)//Sefer
        {
            try
            {
                Sefer sefer= new Sefer();
                sefer.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)//Bilet
        {
            try
            {
                Bilet_Satis bilet= new Bilet_Satis();
                bilet.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)//Kullanıcı İşlemleri
        {
            try
            {
                Kullanici_islemleri Kullanici_islemleri = new Kullanici_islemleri();
                Kullanici_islemleri.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)//Yetkilendir
        {
            try
            {
                Yetkilendir Yetkilendir = new Yetkilendir();
                Yetkilendir.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)//Yetki Kaldırma
        {
            try
            {
                Yetki_Kaldir YetkiKaldir = new Yetki_Kaldir();
                YetkiKaldir.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)//Silinen Biletler
        {
            try
            {
                Silinen_Biletler Silinen= new Silinen_Biletler();
                Silinen.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }

        }

        private void ydkle_Click(object sender, EventArgs e)
        {
            try
            {
                Yedekle yedek = new Yedekle();
                yedek.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void ydktendon_Click(object sender, EventArgs e)
        {
            try
            {
                Yedekten_Don yedektenDon = new Yedekten_Don();
                yedektenDon.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }
    }
}
