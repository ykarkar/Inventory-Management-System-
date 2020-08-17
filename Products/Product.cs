using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Windows.Forms;

namespace Products
{
    public partial class Product : Form
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


        public Product()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (WebConfigurationManager.AppSettings["Productid"] != "")
            {
                //label11.Text = WebConfigurationManager.AppSettings["userid"];
                SqlDataReader rd;
                create_conn();
                String query = "select * from Product where  ProductID = '" + WebConfigurationManager.AppSettings["Productid"] + "'";
                cmd.CommandText = query;
                rd = cmd.ExecuteReader();


                while (rd.Read())
                {
                    int ID = int.Parse(rd[0].ToString());
                    String name = rd[1].ToString();
                    String price = rd[2].ToString();
                    String cat = rd[3].ToString();
                    int orderid = int.Parse(rd[4].ToString());
                    String status = rd[5].ToString();

                    label11.Text = name;
                    label12.Text = ID.ToString();
                    label13.Text = orderid.ToString();
                    textBox4.Text = status;
                    label15.Text = cat;
                    label16.Text = price;


                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    label15.Visible = true;
                    label16.Visible = true;
                    textBox4.Visible = true;
                   // label1.Visible = label15.Visible = label11.Visible = label13.Visible = label12.Visible = true;

                }
                scon.Close();
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 || textBox3.Text.Length != 0)
            {
                SqlDataReader rd;
                create_conn();
                String query = "select * from Product where ProductName= '" + textBox1.Text + "' " +
                    "OR ProductID= '" + textBox3.Text + "' ";
                cmd.CommandText = query;
                rd = cmd.ExecuteReader();


                while (rd.Read())
                {


                    int ID = int.Parse(rd[0].ToString());
                    String name = rd[1].ToString();
                    String price = rd[2].ToString();
                    String cat = rd[3].ToString();
                    int orderid = int.Parse(rd[4].ToString());
                    String status = rd[5].ToString();
                    if (name == textBox1.Text.ToString() || ID.ToString() == textBox3.Text.ToString())
                    {

                        label11.Text = name;
                        label12.Text = ID.ToString();
                        label13.Text = orderid.ToString();
                        textBox4.Text = status;
                        label15.Text = cat;
                        label16.Text = price;


                        label4.Visible = true;
                        label5.Visible = true;
                        label6.Visible = true;
                        label8.Visible = true;
                        label9.Visible = true;
                        label10.Visible = true;
                        label11.Visible = true;
                        label12.Visible = true;
                        label13.Visible = true;
                        label15.Visible = true;
                        label16.Visible = true;
                        textBox4.Visible = true;

                    }
                    else if (textBox1.Text.ToString() != name)
                    {
                        MessageBox.Show("Product Not Available");
                    }


                    if (WebConfigurationManager.AppSettings["Dept"] == "Manager")
                    {
                        textBox2.Visible = true;
                        label16.Visible = false;

                    }
                }

                scon.Close();
            }

            else
            {
                MessageBox.Show("Please type the Product Name or ProductID");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            create_conn();
            cmd.CommandText = " insert into Product values( @ProductID,@ProductName, @Price,@Category,@OrderID, @Status)";
            cmd.Parameters.AddWithValue("@ProductName", textBox1.Text);
            cmd.Parameters.AddWithValue("@Price", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Category", textBox5.Text);
            cmd.Parameters.AddWithValue("@ProductID", textBox3.Text);
            cmd.Parameters.AddWithValue("@OrderID", textBox4.Text);
            cmd.Parameters.AddWithValue("@Status", textBox3.Text);

            int rows = cmd.ExecuteNonQuery();
            MessageBox.Show("Product Inserted");

            scon.Close();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {

            DisplayAllProducts display = new DisplayAllProducts();
            display.ShowDialog();
            this.Close();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Sales s = new Sales();
            this.Hide();
            s.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            User u = new User();
            this.Hide();
            u.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            create_conn();
            cmd.CommandText = "update Product set Status =  @status where ProductID = @ProductID";
            cmd.Parameters.AddWithValue("@status", textBox4.Text);
            
            if(label12.Text == "")
            {
                cmd.Parameters.AddWithValue("@ProductID", textBox3.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ProductID", label12.Text);
            }
            int rows_updated = cmd.ExecuteNonQuery();
            MessageBox.Show("Product Updated");
            scon.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the product", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                create_conn();
                cmd.CommandText = "delete Product  Where ProductName= @ProductName OR ProductID = @ProductID";
                cmd.Parameters.AddWithValue("@ProductName", textBox1.Text);
                cmd.Parameters.AddWithValue("@ProductID", textBox3.Text);
                int rows_deleted = cmd.ExecuteNonQuery();
                MessageBox.Show("Product Deleted");
                scon.Close();
            }
            else
            {
                this.Show();
            }

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }
    }
}
