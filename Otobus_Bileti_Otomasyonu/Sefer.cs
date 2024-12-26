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
    public partial class Sefer : Form
    {
        public Sefer()
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

                DataTable Tablo2 = new DataTable();
                SqlDataAdapter oku2 = new SqlDataAdapter("SELECT * FROM Otobus_Bilgileri", bgl.baglanti());
                oku2.Fill(Tablo2);
                dataGridView2.DataSource = Tablo2;

                DataTable Tablo3 = new DataTable();
                SqlDataAdapter oku3 = new SqlDataAdapter("SELECT * FROM Seferler", bgl.baglanti());
                oku3.Fill(Tablo3);
                dataGridView3.DataSource = Tablo3;
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
            comboBox1.Text = "";
            comboBox2.Text = "";
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

        private void button1_Click(object sender, EventArgs e)//Oluştur
        {
            try
            {
                //
                SqlCommand guzergah_listele = new SqlCommand("Select count(*) From Seferler Where Guzergah_No='"+comboBox1.Text+"'and Otobus_No='"+comboBox2.Text+"'", bgl.baglanti());
                int guzergah_oku = Convert.ToInt32(guzergah_listele.ExecuteScalar());
                    if (guzergah_oku > 0)
                    {
                    MessageBox.Show("Aynı Seferden Var");

                }
                else
                {

                    if (comboBox1.Text == "" || comboBox2.Text == "")
                    {
                        MessageBox.Show("Bilgilerinizi Boş Bırakmayınız...");
                    }
                    else
                    {

                        SqlCommand ekle = new SqlCommand("insert into Seferler (Guzergah_No,Otobus_No) values (@p2,@p3)", bgl.baglanti());
                        ekle.Parameters.AddWithValue("@p2", comboBox1.Text);
                        ekle.Parameters.AddWithValue("@p3", comboBox2.Text);
                        ekle.ExecuteNonQuery();
                        MessageBox.Show("Ekleme Başarılı");
                        Listele();
                        Temizle();
                    }

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
                    MessageBox.Show("Silmek İstedğiniz Sefer Numarasını Giriniz!!!");
                }
                else
                {
                    SqlCommand sil = new SqlCommand("Delete From Seferler Where Sefer_No='" + textBox1.Text + "'", bgl.baglanti());
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
                if (comboBox1.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show("Bilgilerinizi Boş Bırakmayınız...");
                }
                else if (textBox1.Text=="")
                {
                    MessageBox.Show("Güncellemek İstedğiniz Sefer Numarasını Giriniz!!!");
                }
                else 
                {
                    SqlCommand guncelle = new SqlCommand("Update Seferler set Guzergah_No=@p2,Otobus_No=@p3 Where Sefer_No='" + textBox1.Text + "'", bgl.baglanti());
                    guncelle.Parameters.AddWithValue("@p2", comboBox1.Text);
                    guncelle.Parameters.AddWithValue("@p3", comboBox2.Text);
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

        private void button4_Click(object sender, EventArgs e)//Temizle-Listele
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

        private void Sefer_Load(object sender, EventArgs e)//Açılışta
        {
            try
            {
                Listele();

                SqlCommand guzergah_listele = new SqlCommand("Select * From Guzergahlar", bgl.baglanti());
                SqlDataReader guzergah_oku = guzergah_listele.ExecuteReader();
                while (guzergah_oku.Read())
                {
                        comboBox1.Items.Add(guzergah_oku.GetValue(0).ToString());
                }


                SqlCommand otobus_listele = new SqlCommand("Select * From Otobus_Bilgileri", bgl.baglanti());
                SqlDataReader otobus_oku = otobus_listele.ExecuteReader();
                while (otobus_oku.Read())
                {
                    comboBox2.Items.Add(otobus_oku.GetValue(0).ToString());
                }





            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                textBox1.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                comboBox1.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                comboBox2.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }
    }
}
