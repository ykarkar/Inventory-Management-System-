using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Products
{
    public partial class Sales : Form
    {

        //create connection
        static String c = "Data Source=laptop-sv9bjutm\\sqlexpress;Initial Catalog=FinalProject;Integrated Security=True";
        SqlConnection scon = new SqlConnection(c);
        SqlCommand cmd;
        private string  ProductID;
        private string[] tokens;
        private string stid;

        public void create_conn()
        {
            cmd = scon.CreateCommand();
            scon.Open();

        }
        public Sales()
        {
            InitializeComponent();
        }

        void visible()
        {
            label7.Visible  = true;
            label5.Visible = true;
            label6.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            richTextBox1.Visible = label3.Visible = label14.Visible = label13.Visible = true;
            label15.Visible = true;
            label16.Visible = true;

            if (label3.Text.ToString() == "JustShipped")
            {
                label3.ForeColor = Color.DarkGreen;
            }
           // splitproducts();

        }
        private void Button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 || textBox2.Text.Length != 0)
            {
                SqlDataReader rd;
                create_conn();
                String query = "select * from Sales where OrderID= '" + textBox1.Text + "' " +
                    "OR OrderDate= '" + textBox2.Text +"'";
                cmd.CommandText = query;
                rd = cmd.ExecuteReader();


                while (rd.Read())
                {
                    String ID = rd[0].ToString();
                    String ordertype = rd[1].ToString();
                    String date = rd[2].ToString();
                    String Description = rd[3].ToString();
                     ProductID = rd[5].ToString();
                    String status = rd[4].ToString();
                    String ReceivedDate = rd[6].ToString();


                    if (ID == textBox1.Text.ToString())
                    {

                        label12.Text = ID;
                        label13.Text = ordertype;
                        label14.Text = date;
                        label15.Text = ReceivedDate;
                        label16.Text = Description;
                        label3.Text = status;
                        richTextBox1.Text = ProductID;
                        //visible method
                        visible();
                      

                    }
                    else if (textBox1.Text.ToString() != ID)
                    {
                        MessageBox.Show("Order Number is Wrong");
                    }

                }

                scon.Close();
            }

            else
            {
                MessageBox.Show("Please type the Order ID");
            }
        }

     
        private void Button6_Click(object sender, EventArgs e)
        {
            Product prod = new Product();
            prod.Show();
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DisplayAllOrders du = new DisplayAllOrders();
            du.ShowDialog();
            this.Close();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Sales_Load(object sender, EventArgs e)
        {

            if (WebConfigurationManager.AppSettings["Orderid"] != "")
            {
                SqlDataReader rd;
                create_conn();
                String query = "select * from Sales where  OrderID = '" + WebConfigurationManager.AppSettings["Orderid"] + "'";
                cmd.CommandText = query;
                rd = cmd.ExecuteReader();


                while (rd.Read())
                {
                    String ID = rd[0].ToString();
                    String ordertype = rd[1].ToString();
                    String date = rd[2].ToString();
                    String Description = rd[3].ToString();
                     ProductID = rd[5].ToString();
                    String status = rd[4].ToString();
                    String ReceivedDate = rd[6].ToString();

                    label12.Text = ID;
                    label13.Text = ordertype;
                    label14.Text = date;
                    label15.Text = ReceivedDate;
                    label16.Text = Description;
                    label3.Text = status;
                    richTextBox1.Text= ProductID;
                    visible();
                    

                }
                scon.Close();

            }

        }

        void splitproducts()
        {
            
             tokens = ProductID.Split(',');
            //stid = tokens[].ToString();


        }
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                create_conn();
                cmd.CommandText = " insert into Product(ProductID) values( @ProductID)";
                cmd.Parameters.AddWithValue("@ProductID", stid);
                tokens = ProductID.Split(',');
                stid = tokens[i].ToString();
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show("Product Inserted");

                scon.Close();

            }

        }
    }
}
