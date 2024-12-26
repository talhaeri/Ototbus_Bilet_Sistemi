using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;//SQL kütüphanesi ekledik.


namespace Otobus_Bileti_Otomasyonu
{
    internal class sqlbaglanti
    {
        public SqlConnection baglanti()//baglanti adında heryerden erişilebilir bağlantı yaptık.
        {
            //Hocam kendi sunucu adınızı yazınız.
            SqlConnection baglan = new SqlConnection(@"Data Source=MONSTER;Initial Catalog=Turizm_db;Integrated Security=True");
            //baglan adında sql bağlantısı oluşturduk.
            baglan.Open();
            return baglan;
        }

    }
}
