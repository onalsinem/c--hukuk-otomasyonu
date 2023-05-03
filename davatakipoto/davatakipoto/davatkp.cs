using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace davatakipoto
{
    internal class davatkp
    {
        public static SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-BBH06M4\SQLEXPRESS;Initial Catalog=davatakipotomasayonu;Integrated Security=True");
        public static String sqladress = @"Data Source=DESKTOP-BBH06M4\SQLEXPRESS;Initial Catalog=davatakipotomasayonu;Integrated Security=True";
        public static void baglantikntrl( SqlConnection tempkontrol)
        {
            if(tempkontrol.State==System.Data.ConnectionState.Closed)
            {
                tempkontrol.Open();
            }
        }
    }
}
