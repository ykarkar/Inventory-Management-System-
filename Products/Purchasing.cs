using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Net;

namespace Products
{
    public partial class Purchasing : Form
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
        public Purchasing()
        {
            InitializeComponent();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            richTextBox1.Text = textBox2.Text = label3.Text = comboBox1.Text= textBox3.Text = textBox4.Text = "" ;
            
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            create_conn();
            cmd.CommandText = " insert into Sales(OrderID, OrderType,Description,OrderStatus,ProductsID,Vendor,ShipmentAddress,VendorContact)" +
                " values( @OrderID,@OrderType, @Description,@OrderStatus,@ProductsID,@Vendor,@ShipmentAddress,@VendorContact)";
            Random r = new Random();
            int numid = r.Next(1002, 9999);
            cmd.Parameters.AddWithValue("@OrderID", numid.ToString() );
            cmd.Parameters.AddWithValue("@OrderType", textBox1.Text);
            cmd.Parameters.AddWithValue("@Description", textBox2.Text);
            cmd.Parameters.AddWithValue("@OrderStatus", "OrderPlaced");
            cmd.Parameters.AddWithValue("@ProductsID", richTextBox1.Text );
            cmd.Parameters.AddWithValue("@Vendor",comboBox1.SelectedIndex);
            cmd.Parameters.AddWithValue("@ShipmentAddress", textBox3.Text);
            cmd.Parameters.AddWithValue("@VendorContact", textBox4.Text);


            int rows = cmd.ExecuteNonQuery();
            MessageBox.Show("Order Placed");

            scon.Close();

            label12.Text = numid.ToString();
            label3.Text = "Order Placed";
            label13.Visible = true;
            label12.Visible = true;
            String Body = "Order ID:-" + numid + "\n Description:-" +textBox2.Text + "\n Product IDs:" + richTextBox1.Text 
                + "Shipment Address:" + textBox3.Text;

            try
            {
               
                MailMessage msg = new MailMessage("yashkarkar.yk@gmail.com", textBox5.Text,"Order Details",  Body);
                msg.IsBodyHtml = true;
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential("yashkarkar.yk@gmail.com", "Newpassword123!@#" );//your mail password
                sc.Credentials = cre;
                sc.EnableSsl = true;
                sc.Send(msg);
                MessageBox.Show("Mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Purchasing_Load(object sender, EventArgs e)
        {

        }
    }
}
