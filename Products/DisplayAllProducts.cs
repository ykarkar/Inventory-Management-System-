using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Windows.Forms;

namespace Products
{
    public partial class DisplayAllProducts : Form
    {
        //create connection
        static String c = "Data Source=laptop-sv9bjutm\\sqlexpress;Initial Catalog=FinalProject;Integrated Security=True";
        SqlConnection scon = new SqlConnection(c);
        SqlCommand cmd;
        public void create_conn()
        {
            cmd = scon.CreateCommand();
            scon.Open();

        }

        private SqlDataReader rd;

        public DisplayAllProducts()
        {
            InitializeComponent();
        }

        public DisplayAllProducts(SqlDataReader rd)
        {
            this.rd = rd;
        }

        private void DisplayAllProducts_Load(object sender, EventArgs e)
        {

            create_conn();
            cmd.CommandText = " select * from Product";

            rd = cmd.ExecuteReader(); // store the resultset returned in rd
            DataTable dt = new DataTable();
            dt.Load(rd);//load table with datareader
            dataGridView1.DataSource = dt;//display data in datagridview 
            scon.Close();

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            String Productid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            WebConfigurationManager.AppSettings["Productid"] = Productid;
            Product u = new Product();
            u.Show();
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Product u = new Product();
            u.Show();
            this.Close();
        }
    }
}
