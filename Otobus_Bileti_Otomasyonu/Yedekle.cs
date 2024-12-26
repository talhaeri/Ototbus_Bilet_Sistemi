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
using System.IO;



namespace Otobus_Bileti_Otomasyonu
{
    public partial class Yedekle : Form
    {
        public Yedekle()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();//SQL bağlantımızı dahil ediyoruz.

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)//Dosya Yolu
        {
            saveFileDialog1.Title = "Yedeklenecek yolu belirtiniz.";
            saveFileDialog1.Filter = "Yedekleme Dosyaları(*.bak)|*.bak|Tüm Dosyalar(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)//Yedekle
        {
            try
            {
               
                string backupQuery = $"BACKUP DATABASE Turizm_db TO DISK = '{textBox1.Text}'";

                using (SqlCommand command = new SqlCommand(backupQuery, bgl.baglanti()))
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Veritabanı yedekleme başarılı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void Yedekle_Load(object sender, EventArgs e)
        {

        }
    }
}
