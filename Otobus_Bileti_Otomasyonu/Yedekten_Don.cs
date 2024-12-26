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
    public partial class Yedekten_Don : Form
    {
        public Yedekten_Don()
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

        private void button1_Click(object sender, EventArgs e)//Dosya yolu
        {
            saveFileDialog1.Title = "Yedeklenecek yolu belirtiniz.";
            saveFileDialog1.Filter = "Yedekleme Dosyaları(*.bak)|*.bak|Tüm Dosyalar(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)//Yedekten Dön
        {
            try
            {

               
                    string sqlRestore = $"USE master RESTORE DATABASE Turizm_db FROM DISK = '{textBox1.Text}'";

                    SqlCommand command = new SqlCommand(sqlRestore, bgl.baglanti());
                    command.ExecuteNonQuery();

                    MessageBox.Show("Veritabanı başarıyla geri yüklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Yedekten_Don_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
