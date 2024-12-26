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
    public partial class Guzergah : Form
    {
        public Guzergah()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();//SQL bağlantımızı dahil ediyoruz.

        void Listele()
        {
            try
            {
                DataTable Tablo = new DataTable();
                SqlDataAdapter oku = new SqlDataAdapter("SELECT * FROM Guzergahlar", bgl.baglanti());
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
            comboBox1.Text="";
            comboBox2.Text = "";
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
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

        private void button1_Click(object sender, EventArgs e)//Ekle
        {
            try
            {
                if (comboBox1.Text=="" || comboBox2.Text=="" || maskedTextBox1.Text=="" || maskedTextBox2.Text=="")
                {
                    MessageBox.Show("Bilgilerinizi Boş Bırakmayınız...");
                }
                else
                {
                    SqlCommand ekle = new SqlCommand("insert into Guzergahlar (Nereden,Nereye,Tarih,Saat) values (@p2,@p3,@p4,@p5)", bgl.baglanti());
                    ekle.Parameters.AddWithValue("@p2", comboBox1.Text);
                    ekle.Parameters.AddWithValue("@p3", comboBox2.Text);
                    ekle.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@p5", maskedTextBox2.Text);
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
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Bilgilerinizi Boş Bırakmayınız...");
                }
                else
                {
                    SqlCommand sil = new SqlCommand("Delete From Guzergahlar Where Guzergah_No='" + textBox1.Text + "'", bgl.baglanti());
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
                if (comboBox1.Text == "" || comboBox2.Text == "" || maskedTextBox1.Text == "" || maskedTextBox2.Text == "")
                {
                    MessageBox.Show("Bilgilerinizi Boş Bırakmayınız!!!");
                }else if (textBox1.Text == "")
                {
                    MessageBox.Show("Güncellemek İstediğiniz Güzergah Numarasını Giriniz.");
                }
                else
                {
                    SqlCommand guncelle = new SqlCommand("Update Guzergahlar set Nereden=@p2,Nereye=@p3,Tarih=@p4,Saat=@p5 Where Guzergah_No='" + textBox1.Text + "'", bgl.baglanti());
                    guncelle.Parameters.AddWithValue("@p2", comboBox1.Text);
                    guncelle.Parameters.AddWithValue("@p3", comboBox2.Text);
                    guncelle.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@p5", maskedTextBox2.Text);
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

        private void button4_Click(object sender, EventArgs e)
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
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
