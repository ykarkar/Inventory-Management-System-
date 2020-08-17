using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Windows.Forms;

namespace Products
{
    public partial class DisplayAllUsers : Form
    {
        static String c = "Data Source=laptop-sv9bjutm\\sqlexpress;Initial Catalog=FinalProject;Integrated Security=True";
        SqlConnection scon = new SqlConnection(c);
        SqlCommand cmd;
        private SqlDataReader rd;

        public void create_conn()
        {
            cmd = scon.CreateCommand();
            scon.Open();

        }
        public DisplayAllUsers()
        {
            InitializeComponent();
        }

        private void DisplayAllUsers_Load(object sender, EventArgs e)
        {
            create_conn();
            cmd.CommandText = " select * from UserDet";

            rd = cmd.ExecuteReader(); // store the resultset returned in rd
            DataTable dt = new DataTable();
            dt.Load(rd);//load table with datareader
            dataGridView1.DataSource = dt;//display data in datagridview 
            scon.Close();

        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String Userid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            String Username = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String FullName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String Email = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            String Dep = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            String Contact = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //String Password = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            // Properties.Settings.Default.sid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
            WebConfigurationManager.AppSettings["Userid"] = Userid;
            User u = new User();
            u.Show();
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Show();
            this.Close();
        }
    }
}
