using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Windows.Forms;

namespace Products
{
    public partial class Login : Form
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
        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length != 0 || textBox2.Text.Length != 0)
            {
                SqlDataReader rd;
                create_conn();
                String query = "select * from UserDet where UserID= '" + textBox3.Text + "'  ";
                cmd.CommandText = query;
                rd = cmd.ExecuteReader();


                while (rd.Read())
                {
                    String Username = rd[1].ToString();
                    String Password = rd[6].ToString();
                    String Userid = rd[0].ToString();
                    String Dept = rd[4].ToString();
                    WebConfigurationManager.AppSettings["Dept"] = Dept;

                    
                    if (textBox3.Text == Userid && textBox2.Text == Password)
                    {
                        Home h = new Home();
                        h.Show();
                        this.Hide();

                    }
                    else if(rd[0].ToString() == "")
                    {
                        MessageBox.Show("Incorrect Credentials");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Incorrect Credentials,", "Do You want to try again", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            this.Show();
                        }
                        else
                        {
                            this.Close();
                        }
                    }

                }

                scon.Close();
            }
            else
            {
                MessageBox.Show("Please input something");
            }//end of else
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
