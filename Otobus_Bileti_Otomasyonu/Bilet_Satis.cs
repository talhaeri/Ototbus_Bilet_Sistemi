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
using System.Collections;//Dizi Kütüphanesi


namespace Otobus_Bileti_Otomasyonu
{
    public partial class Bilet_Satis : Form
    {
        public Bilet_Satis()
        {
            InitializeComponent();
        }

        int sefer_no = 0;

        sqlbaglanti bgl = new sqlbaglanti();//SQL bağlantımızı dahil ediyoruz.

        void Listele()
        {
            try
            {
                DataTable Tablo = new DataTable();
                SqlDataAdapter oku = new SqlDataAdapter("SELECT * FROM Bilet", bgl.baglanti());
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
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            maskedTextBox1.Clear();
            textBox2.Clear();
            comboBox6.Text = "";
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();



        }

        void koltuksayisi()
        {
            comboBox5.Items.Clear();
            for (int i = 1; i < 42; i++)
            {
                comboBox5.Items.Add(i.ToString());

            }
        }


        void koltukyesil()
        {
            button1.BackColor = Color.LawnGreen;
            button2.BackColor = Color.LawnGreen;
            button3.BackColor = Color.LawnGreen;
            button4.BackColor = Color.LawnGreen;
            button5.BackColor = Color.LawnGreen;
            button6.BackColor = Color.LawnGreen;
            button7.BackColor = Color.LawnGreen;
            button8.BackColor = Color.LawnGreen;
            button9.BackColor = Color.LawnGreen;
            button10.BackColor = Color.LawnGreen;
            button11.BackColor = Color.LawnGreen;
            button12.BackColor = Color.LawnGreen;
            button13.BackColor = Color.LawnGreen;
            button14.BackColor = Color.LawnGreen;
            button15.BackColor = Color.LawnGreen;
            button16.BackColor = Color.LawnGreen;
            button17.BackColor = Color.LawnGreen;
            button18.BackColor = Color.LawnGreen;
            button19.BackColor = Color.LawnGreen;
            button20.BackColor = Color.LawnGreen;
            button21.BackColor = Color.LawnGreen;
            button22.BackColor = Color.LawnGreen;
            button23.BackColor = Color.LawnGreen;
            button24.BackColor = Color.LawnGreen;
            button25.BackColor = Color.LawnGreen;
            button26.BackColor = Color.LawnGreen;
            button27.BackColor = Color.LawnGreen;
            button28.BackColor = Color.LawnGreen;
            button29.BackColor = Color.LawnGreen;
            button30.BackColor = Color.LawnGreen;
            button31.BackColor = Color.LawnGreen;
            button32.BackColor = Color.LawnGreen;
            button33.BackColor = Color.LawnGreen;
            button34.BackColor = Color.LawnGreen;
            button35.BackColor = Color.LawnGreen;
            button36.BackColor = Color.LawnGreen;
            button37.BackColor = Color.LawnGreen;
            button38.BackColor = Color.LawnGreen;
            button39.BackColor = Color.LawnGreen;
            button40.BackColor = Color.LawnGreen;
            button41.BackColor = Color.LawnGreen;

        }

        void koltukkontrol()
        {



            koltukyesil();




            ArrayList koltukno = new ArrayList();
            SqlCommand komut = new SqlCommand("SELECT * FROM Bilet WHERE Sefer_No='" + sefer_no + "'", bgl.baglanti());
            SqlDataReader veriokuyucu = komut.ExecuteReader();
            while (veriokuyucu.Read())
            {
                koltukno.Add(veriokuyucu["Koltuk_No"]);

                switch (veriokuyucu["Koltuk_No"])
                {
                    case 1:
                        button1.BackColor = Color.Red;
                        break;
                    case 2:
                        button2.BackColor = Color.Red;
                        break;
                    case 3:
                        button3.BackColor = Color.Red;
                        break;
                    case 4:
                        button4.BackColor = Color.Red;
                        break;
                    case 5:
                        button5.BackColor = Color.Red;
                        break;
                    case 6:
                        button6.BackColor = Color.Red;
                        break;
                    case 7:
                        button7.BackColor = Color.Red;
                        break;
                    case 8:
                        button8.BackColor = Color.Red;
                        break;



                    case 9:
                        button9.BackColor = Color.Red;
                        break;
                    case 10:
                        button10.BackColor = Color.Red;
                        break;
                    case 11:
                        button11.BackColor = Color.Red;
                        break;
                    case 12:
                        button12.BackColor = Color.Red;
                        break;
                    case 13:
                        button13.BackColor = Color.Red;
                        break;
                    case 14:
                        button14.BackColor = Color.Red;
                        break;
                    case 15:
                        button15.BackColor = Color.Red;
                        break;
                    case 16:
                        button16.BackColor = Color.Red;
                        break;
                    case 17:
                        button17.BackColor = Color.Red;
                        break;
                    case 18:
                        button18.BackColor = Color.Red;
                        break;
                    case 19:
                        button19.BackColor = Color.Red;
                        break;
                    case 20:
                        button20.BackColor = Color.Red;
                        break;
                    case 21:
                        button21.BackColor = Color.Red;
                        break;
                    case 22:
                        button22.BackColor = Color.Red;
                        break;
                    case 23:
                        button23.BackColor = Color.Red;
                        break;
                    case 24:
                        button24.BackColor = Color.Red;
                        break;
                    case 25:
                        button25.BackColor = Color.Red;
                        break;
                    case 26:
                        button26.BackColor = Color.Red;
                        break;
                    case 27:
                        button27.BackColor = Color.Red;
                        break;
                    case 28:
                        button28.BackColor = Color.Red;
                        break;
                    case 29:
                        button29.BackColor = Color.Red;
                        break;
                    case 30:
                        button30.BackColor = Color.Red;
                        break;
                    case 31:
                        button31.BackColor = Color.Red;
                        break;
                    case 32:
                        button32.BackColor = Color.Red;
                        break;
                    case 33:
                        button33.BackColor = Color.Red;
                        break;
                    case 34:
                        button34.BackColor = Color.Red;
                        break;
                    case 35:
                        button35.BackColor = Color.Red;
                        break;
                    case 36:
                        button36.BackColor = Color.Red;
                        break;
                    case 37:
                        button37.BackColor = Color.Red;
                        break;
                    case 38:
                        button38.BackColor = Color.Red;
                        break;
                    case 39:
                        button39.BackColor = Color.Red;
                        break;
                    case 40:
                        button40.BackColor = Color.Red;
                        break;
                    case 41:
                        button41.BackColor = Color.Red;
                        break;


                }
            }




            int a;
            a = koltukno.Count;
            textBox1.Text = a.ToString();

            for (int i = 0; i < a; i++)
            {
                comboBox5.Items.Remove("" + koltukno[i] + "");
            }


        }













        private void pictureBox1_Click_1(object sender, EventArgs e)//Anasayfa
        {
            Form1 menu = new Form1();
            menu.Show();
            this.Hide();
           
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)//Çıkış
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


        private void Bilet_Satis_Load(object sender, EventArgs e)//Açılış
        {
            try
            {
                Listele();
                if (Giris.yetki == "Admin")
                {
                    pictureBox1.Visible = true;

                }
                else
                {
                    pictureBox1.Visible = false;
                }
                /*
                SqlCommand guzergah_listele = new SqlCommand("Select * From Guzergahlar", bgl.baglanti());
                SqlDataReader guzergah_oku = guzergah_listele.ExecuteReader();
                while (guzergah_oku.Read())
                {
                    comboBox1.Items.Add(guzergah_oku.GetValue(0).ToString());
                }


                SqlCommand otobus_listele = new SqlCommand("Select * From Guzergahlar", bgl.baglanti());
                SqlDataReader otobus_oku = otobus_listele.ExecuteReader();
                while (otobus_oku.Read())
                {
                    comboBox2.Items.Add(otobus_oku.GetValue(0).ToString());
                }
                */




            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }


        private void button44_Click(object sender, EventArgs e)//Nereden-Nereye-Tarih Seçildikten Sonra Saatleri Listele
        {
            try
            {
                comboBox4.Items.Clear();
                Listele();

                SqlCommand guzergah_listele = new SqlCommand("Select * From Guzergahlar Where Nereden='" + comboBox1.Text + "' and Nereye='" + comboBox2.Text + "' and Tarih='" + maskedTextBox1.Text + "'", bgl.baglanti());
                SqlDataReader guzergah_oku = guzergah_listele.ExecuteReader();
                while (guzergah_oku.Read())
                {
                    comboBox4.Items.Add(guzergah_oku.GetValue(4).ToString());
                }

                if (comboBox4.Items.Count == 0)
                {
                    MessageBox.Show("İstediğiniz Tarihte ve Güzergahta Seferimiz Yoktur. \nFirma Yetkililerimiz İle İletişime Geçebilirsiniz.");

                }
                else
                {
                    groupBox1.Visible = true;
                }






            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)//Saati seçtikten sonra sefer_no belirlenir
        {
            try
            {

                koltuksayisi();
                Listele();

                SqlCommand guzergah_listele = new SqlCommand("Select * From Guzergahlar Where Nereden='" + comboBox1.Text + "' and Nereye='" + comboBox2.Text + "' and Tarih='" + maskedTextBox1.Text + "'and Saat='" + comboBox4.SelectedItem + "'", bgl.baglanti());
                SqlDataReader guzergah_oku = guzergah_listele.ExecuteReader();
                while (guzergah_oku.Read())
                {
                    sefer_no = Convert.ToInt32(guzergah_oku.GetValue(0).ToString());
                }

                koltukkontrol();


            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }


        private void button42_Click(object sender, EventArgs e)//Bilet Al
        {
            try
            {
                if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || maskedTextBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Bilgilerinizi Boş Bırakmayınız!!!");
                }
                else if (textBox3.TextLength != 11)
                {
                    MessageBox.Show("Kimlik Bilgilerinizi Eksiksiz Doldurunuz!!!");

                }
                else
                {
                    SqlCommand ekle = new SqlCommand("insert into Bilet (Sefer_No,Koltuk_No,Ucret,Bilet_Durumu,M_TC,M_Adi,M_Soyadi) values (@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());

                    ekle.Parameters.AddWithValue("@p2", sefer_no);
                    ekle.Parameters.AddWithValue("@p3", comboBox5.Text);//KoltukNo
                    ekle.Parameters.AddWithValue("@p4", float.Parse(textBox2.Text));//Ücret
                    ekle.Parameters.AddWithValue("@p5", comboBox6.Text);//Rezerve/Satış

                    //Müşteri Bilgileri
                    ekle.Parameters.AddWithValue("@p6", textBox3.Text);
                    ekle.Parameters.AddWithValue("@p7", textBox4.Text);
                    ekle.Parameters.AddWithValue("@p8", textBox5.Text);

                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Ekleme Başarılı");
                    Listele();
                    Temizle();
                    koltukyesil();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.\n" + a.Message, "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void button43_Click(object sender, EventArgs e)//Bileti İptal Et
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Silmek İstediğiniz Bilet Numarasını Giriniz!!!");
                }
                else
                {
                    SqlCommand sil = new SqlCommand("Delete From Bilet Where Bilet_No='" + textBox1.Text + "'", bgl.baglanti());

                    ///Bilet Numarasından sonra Silinen Biletlere ekle
                    SqlCommand Silinenekle = new SqlCommand("insert into Silinen_Biletler(Bilet_No) values (@p2)", bgl.baglanti());

                    Silinenekle.Parameters.AddWithValue("@p2", textBox1.Text);
                    Silinenekle.ExecuteNonQuery();



                    sil.ExecuteNonQuery();
                    MessageBox.Show("Bilet İptal Edilmiştir.");
                    Listele();
                    Temizle();
                    koltukyesil();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void button45_Click(object sender, EventArgs e)//Bileti Güncelle
        {
            try
            {
                if (comboBox5.Text == "" || comboBox6.Text == "")
                {
                    MessageBox.Show("Bilgilerinizi Boş Bırakmayınız!!!");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Güncellemek İstediğiniz Bilet Numarasını Giriniz.");
                }
                else
                {
                    SqlCommand guncelle = new SqlCommand("Update Bilet set Bilet_Durumu=@p3 Where Bilet_No='" + textBox1.Text + "'", bgl.baglanti());
                    guncelle.Parameters.AddWithValue("@p3", comboBox6.Text);//Rezerve/Satış

                    
                     guncelle.Parameters.AddWithValue("@p6", textBox3.Text);
                     guncelle.Parameters.AddWithValue("@p7", textBox4.Text);
                     guncelle.Parameters.AddWithValue("@p8", textBox5.Text);
                    
                    guncelle.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme Başarılı");
                    Listele();
                    Temizle();
                    koltukyesil();
                }


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
                comboBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }
    }
}
