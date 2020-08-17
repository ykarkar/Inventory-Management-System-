using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Products
{
    public partial class User : Form
    {

        static String c = "Data Source=laptop-sv9bjutm\\sqlexpress;Initial Catalog=FinalProject;Integrated Security=True";
        SqlConnection scon = new SqlConnection(c);
        SqlCommand cmd;
        private string username;

        public void create_conn()
        {
            cmd = scon.CreateCommand();
            scon.Open();

        }
        public User()
        {
            InitializeComponent();
        }

        public User(string username)
        {
            this.username = username;
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
        void visibleuser()
        {
            label4.Visible = true;
            label14.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            label7.Visible = true;
            label4.Visible = true;
            label17.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label6.Visible = true;
            label10.Visible = true;
            label1.Visible = label15.Visible = label11.Visible = label13.Visible = label12.Visible = true;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Length != 0 || textBox2.Text.Length != 0)
            {
                SqlDataReader rd;
                create_conn();
                String query = "select * from UserDet where FullName = '" + textBox1.Text + "' " +
                    "OR UserName = '" + textBox2.Text + "'  OR UserID = '" + textBox5.Text + "'";
                cmd.CommandText = query;
                rd = cmd.ExecuteReader();


                while (rd.Read())
                {   String Userid = rd[0].ToString();
                    String Name = rd[2].ToString();
                    String Email = rd[3].ToString();
                    String User = rd[1].ToString();
                    String Contact = rd[5].ToString();
                    String Dep = rd[4].ToString();
                    if (Name == textBox1.Text.ToString() || User == textBox2.Text.ToString())
                    {
                        label1.Text = Userid;
                        label14.Text = Name;
                        label12.Text = User;
                        label13.Text = Email;
                        label15.Text = Dep;
                        label1.Text = Contact;
                        textBox4.Text = Dep;

                        visibleuser();
                       

                        if (WebConfigurationManager.AppSettings["Dept"] == "Manager")
                        {
                            textBox4.Visible = true;
                            label15.Visible = false;

                        }


                    }
                    else if (textBox1.Text.ToString() != Name)
                    {
                        MessageBox.Show("Employee Does Not Work Here");
                    }

                }

                scon.Close();
            }

            else
            {
                MessageBox.Show("Please type the Employee Name Or ContactNumber or UserName");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DisplayAllUsers display = new DisplayAllUsers();
            display.Show();
            this.Close();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Sales u = new Sales();
            this.Hide();
            u.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {

            Product prod = new Product();
            prod.Show();
            this.Close();
        }

        private void User_Load(object sender, EventArgs e)
        {

            if (WebConfigurationManager.AppSettings["Dept"] == "Manager")
            {
                button1.Visible = button2.Visible = button3.Visible = true;

            }

           

            if (WebConfigurationManager.AppSettings["userid"] != "")
            {
                //label11.Text = WebConfigurationManager.AppSettings["userid"];
                SqlDataReader rd;
                create_conn();
                String query = "select * from UserDet where  UserID = '" + WebConfigurationManager.AppSettings["userid"] + "'";
                cmd.CommandText = query;
                rd = cmd.ExecuteReader();


                while (rd.Read())
                {
                    String Userid = rd[0].ToString();
                    String Name = rd[2].ToString();
                    String Email = rd[3].ToString();
                    String User = rd[1].ToString();
                    String Contact = rd[5].ToString();
                    String Dep = rd[4].ToString();

                    textBox9.Text = Email;
                    label11.Text = Userid;
                    label14.Text = Name;
                    label12.Text = User;
                    label13.Text = Email;
                    label15.Text = Dep;
                    label1.Text = Contact;
                    //  textBox4.Text = Dep;
                    visibleuser();
                    if (WebConfigurationManager.AppSettings["Dept"] == "Manager")
                    {
                        textBox4.Visible = textBox9.Visible=  true;
                        label15.Visible = false;

                    }

                }
                scon.Close();
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            //  l.Show();
            Application.Restart();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
                      
            create_conn();
            cmd.CommandText = " insert into UserDet values(@UserID,@UserName, @FullName, @ContactNumber)";
            cmd.Parameters.AddWithValue("@UserID", textBox5.Text);
            cmd.Parameters.AddWithValue("@UserName", textBox2.Text);
            cmd.Parameters.AddWithValue("@FullName", textBox1.Text);
            //cmd.Parameters.AddWithValue("@Emailid", textBox9.Text);
           // cmd.Parameters.AddWithValue("@Department", textBox4.Text);
            cmd.Parameters.AddWithValue("@ContactNumber", textBox3.Text);
            //cmd.Parameters.AddWithValue("@Password", textBox3.Text);

            int rows = cmd.ExecuteNonQuery();
            MessageBox.Show("Employee Added");
            scon.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            create_conn();
            cmd.CommandText = "update UserDet set  UserName= @UserName, FullName= @Emailid," +
                "Department=@Department, ContactNumber=@ContactNumber  where UserID = @UserID";
            cmd.Parameters.AddWithValue("@UserID", textBox5.Text);
            cmd.Parameters.AddWithValue("@UserName", textBox2.Text);
            cmd.Parameters.AddWithValue("@FullName", textBox1.Text);
            cmd.Parameters.AddWithValue("@Emailid", textBox9.Text);
            cmd.Parameters.AddWithValue("@Department", textBox4.Text);
            cmd.Parameters.AddWithValue("@ContactNumber", textBox3.Text);
            int rows_updated = cmd.ExecuteNonQuery();
            MessageBox.Show("Employee Details Updated");
            scon.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove the employee", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                create_conn();
                cmd.CommandText = "delete UserDet  Where UserID= @UserID OR UserName = @UserName";
                cmd.Parameters.AddWithValue("@UserID", textBox5.Text);
                cmd.Parameters.AddWithValue("@UserName", textBox2.Text);
                int rows_deleted = cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Is Deleted");
                scon.Close();
            }
            else
            {
                this.Show();
            }
        }
    }
}
