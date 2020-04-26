using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyChiTieu2
{
    public partial class Bieu_do : Form
    {
        public Bieu_do()
        {
            InitializeComponent();
        }

        private void Bieu_do_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DHFMQ88\MSSQLSERVER03;Integrated Security=SSPI;Initial Catalog=Quanlychitieu");
            SqlDataAdapter adapter = new SqlDataAdapter(" select ngaythang, sum(sotien) AS sotien from thongtinchitieu group by ngaythang", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            chart1.DataSource = dt;
            chart1.ChartAreas["Biểu đồ thống kê chi tiêu"].AxisX.Title = " tên chi tiêu";
            chart1.ChartAreas["Biểu đồ thống kê chi tiêu"].AxisX.Title = "Biểu đồ thống kê chi tiêu";

            chart1.Series["Số tiền chi tiêu"].XValueMember = " ngaythang";
            chart1.Series["Số tiền chi tiêu"].YValueMembers = " sotien";
        }
    }
}
