using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Windows.Forms;

namespace Products
{
    public partial class DisplayAllOrders : Form
    {
        //create connection
        static String c = "Data Source=laptop-sv9bjutm\\sqlexpress;Initial Catalog=FinalProject;Integrated Security=True";
        SqlConnection scon = new SqlConnection(c);
        SqlCommand cmd;
        private SqlDataReader rd;

        public void create_conn()
        {
            cmd = scon.CreateCommand();
            scon.Open();

        }
        public DisplayAllOrders()
        {
            InitializeComponent();
        }

        private void DisplayAllOrders_Load(object sender, EventArgs e)
        {
            create_conn();
            cmd.CommandText = " select * from Sales";

            rd = cmd.ExecuteReader(); // store the resultset returned in rd
            DataTable dt = new DataTable();
            dt.Load(rd);//load table with datareader
            dataGridView1.DataSource = dt;//display data in datagridview 
            scon.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Sales s = new Sales();
            s.Show();
            this.Close();
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String Orderid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            WebConfigurationManager.AppSettings["Orderid"] = Orderid;
            Sales s = new Sales();
            s.Show();
            this.Close();
        }
    }
}
