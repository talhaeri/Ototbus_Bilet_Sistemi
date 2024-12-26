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
    public partial class Otobus : Form
    {
        public Otobus()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();//SQL bağlantımızı dahil ediyoruz.

        void Listele()
        {
            try
            {
            DataTable Tablo = new DataTable();
            SqlDataAdapter oku = new SqlDataAdapter("SELECT * FROM Otobus_Bilgileri", bgl.baglanti());
            oku.Fill(Tablo);
            dataGridView1.DataSource = Tablo;
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //throw;
            }

        }

        void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)//MENÜ
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

        private void pictureBox2_Click(object sender, EventArgs e)//ÇIKIŞ
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

        private void button1_Click(object sender, EventArgs e)//Ekle
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Bilgilerinizi Boş Bırakmayınız...");
                }
                else if (textBox2.TextLength>8)
                {
                    MessageBox.Show("Plaka Bilgisini Hatalı Girdiniz!!");
                }
                else
                {
                    SqlCommand ekle = new SqlCommand("insert into Otobus_Bilgileri (Plaka,Marka_Model) values (@p2,@p3)", bgl.baglanti());
                    ekle.Parameters.AddWithValue("@p2", textBox2.Text);
                    ekle.Parameters.AddWithValue("@p3", textBox3.Text);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Ekleme Başarılı");
                    Listele();
                    Temizle();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)//Sil
        {
            try
            {
                if (textBox1.Text == "" )
                {
                    MessageBox.Show("Silmek İstediğiniz Otobüs Numarasını Giriniz!!!");
                }
                else
                {
                    SqlCommand sil = new SqlCommand("Delete From Otobus_Bilgileri Where Otobus_No='" + textBox1.Text + "'", bgl.baglanti());
                    sil.ExecuteNonQuery();
                    MessageBox.Show("Silme İşlemi Tamamlandı.");
                    Listele();
                    Temizle();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }
       
        private void button3_Click(object sender, EventArgs e)//Güncelle
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Bilgilerinizi Boş Bırakmayınız...");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Güncellemek İstediğiniz Otobüs Numarasını Giriniz.!!!");
                }
                else
                {
                    SqlCommand guncelle = new SqlCommand("Update Otobus_Bilgileri set Plaka=@p2,Marka_Model=@p3 Where Otobus_No='" + textBox1.Text + "'", bgl.baglanti());
                    guncelle.Parameters.AddWithValue("@p2", textBox2.Text);
                    guncelle.Parameters.AddWithValue("@p3", textBox3.Text);
                    guncelle.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme Başarılı");
                    Listele();
                    Temizle();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)//Listele-Temizle
        {
            try
            {
                Listele();
                Temizle();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
