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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;
using ExcelDataReader.Exceptions;
using ExcelDataReader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Otobus_Bileti_Otomasyonu
{
    public partial class Silinen_Biletler : Form
    {
        public Silinen_Biletler()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();//SQL bağlantımızı dahil ediyoruz.

        void Listele()
        {
            try
            {
                DataTable Tablo = new DataTable();
                SqlDataAdapter oku = new SqlDataAdapter("SELECT * FROM Silinen_Biletler", bgl.baglanti());
                oku.Fill(Tablo);
                dataGridView1.DataSource = Tablo;
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //throw;
            }

        }

        public int kaydet(int Bilet_No)
        {
            try
            {
               

                    SqlCommand sqlKomut = new SqlCommand("INSERT INTO Silinen_Biletler VALUES (@Bilet_No)", bgl.baglanti());

                    // Parametreleri ekle
                    sqlKomut.Parameters.AddWithValue("@Bilet_No", Bilet_No);


                    int etkilenenSatirSayisi = sqlKomut.ExecuteNonQuery();
                    return etkilenenSatirSayisi;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return 0;
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

        private void button1_Click(object sender, EventArgs e)//Listele
        {
            try
            {
                Listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)//Aktar
        {
            //Sütun adlar yazmıyor



            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
            Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
            excelApp.Visible = true;

            try
            {
                int rowCount = dataGridView1.Rows.Count;
                int columnCount = dataGridView1.Columns.Count;

                // DataGridView verilerini Excel'e aktarma
                for (int i = 1; i <= rowCount; i++)
                {
                    for (int j = 1; j <= columnCount; j++)
                    {
                        // Excel hücrelerine DataGridView hücre değerlerini yazma
                        excelWorksheet.Cells[i, j] = dataGridView1.Rows[i - 1].Cells[j - 1].Value;
                    }
                }

                // Excel dosyasını kaydetme
                // Örnek olarak Masaüstüne 'ExcelData' adında bir dosya oluşturur
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                excelWorkbook.SaveAs(desktopPath + "\\Bilet.xlsx");
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
            

        }

        private void button3_Click(object sender, EventArgs e)//Çek
        {
            try
            {
                
                string secilenDosyaYolu = "C:\\dosya_yolu\\Bilet.xlsx";

                OpenFileDialog dosyaSecDialog = new OpenFileDialog();

                dosyaSecDialog.InitialDirectory = "C:\\"; // Varsayılan olarak başlayacağı dizin
                dosyaSecDialog.Title = "Dosya Seç"; // Dosya seçim penceresinin başlığı
                dosyaSecDialog.Filter = "Excel Dosyaları (*.xlsx)|*.xlsx|Tüm Dosyalar (*.*)|*.*"; // Seçilecek dosya türleri

                if (dosyaSecDialog.ShowDialog() == DialogResult.OK)
                {
                    // Kullanıcı dosyayı seçtiğinde yapılacak işlemler
                    secilenDosyaYolu = dosyaSecDialog.FileName;
                    MessageBox.Show("Seçilen dosya: " + secilenDosyaYolu);
                }
                
                
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Workbooks.Open(secilenDosyaYolu); // Excel dosyasının yolunu belirtin
                Excel._Worksheet worksheet = workbook.Sheets[1]; // Çekmek istediğiniz sayfa indeksini belirtin
                Excel.Range range = worksheet.UsedRange;

                int satirSayisi = range.Rows.Count;
                int sutunSayisi = range.Columns.Count;
                int etkilenenSatirSayisi = 0;
                for (int satir = 1; satir <= satirSayisi; satir++)
                {
                    string Bilet_No = (range.Cells[satir, 1] as Excel.Range).Value2.ToString();

                    
                    Bilet_Satis kayit = new Bilet_Satis();
                    etkilenenSatirSayisi = kaydet(Int16.Parse(Bilet_No));
                    button1.PerformClick();
                    
                }
            
                if (etkilenenSatirSayisi > 0)
                {
                    MessageBox.Show("Biletler Kayıt Edildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Biletler Kayıt Edilemedi!");
                }
            


                workbook.Close();
                excel.Quit();
                // Bellekten Excel nesnelerini temizleme
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                worksheet = null;
                workbook = null;
                excel = null;
                GC.Collect();

            
            
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
        }
       
        private void button5_Click(object sender, EventArgs e)//Tüm Biletler
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

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Tablo = new DataTable();
                //silinen bilet tablosunda Textbox1 e girilen sayıyı içeren silinen_id leri yazdıracak
                SqlDataAdapter oku = new SqlDataAdapter("SELECT * FROM Silinen_Biletler Where Silinen_id LIKE '%" + textBox1.Text + "%'", bgl.baglanti());
                oku.Fill(Tablo);
                dataGridView1.DataSource = Tablo;
            }
            catch (Exception)
            {
                MessageBox.Show("Beklenmedik Hata Oluştu.", "Tekrar Deneyiniz.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //throw;
            }
        }
    }
}
