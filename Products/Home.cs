using System;
using System.Drawing;
using System.Web.Configuration;
using System.Windows.Forms;
using System.Windows.Media;

namespace Products
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
            button4.Visible = false;
            if (WebConfigurationManager.AppSettings["Dept"].ToString() == "Manager")
            {
                button4.Visible = true;
                button5.Visible = true;
                label6.Visible = true;
            }
            if (WebConfigurationManager.AppSettings["Dept"].ToString() == "Purchasing")
            {
                button5.Visible = true;
                label4.Visible = true;
                label6.Text = "Purchasing Department";

            }



        }

     
        private void Label1_Click(object sender, EventArgs e)
        {
           
        }

        private void Mousehover(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Show();
            this.Hide();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Sales u = new Sales();
            u.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Show();
            this.Hide();

        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Size = new Size(123, 123);
            label2.Visible = true;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Size = new Size(120, 120);
            label2.Visible = false;
        }

        private void Button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Size = new Size(124, 124);
            label2.Visible = true;
        }

        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Size = new Size(120, 120);
            label3.Visible = false;
        }

        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Size = new Size(124, 124);
            label4.Visible = true;
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Size = new Size(120, 120);
            label4.Visible = false;
        }

        private void Button4_MouseEnter(object sender, EventArgs e)
        {
            button4.Size = new Size(124, 124);
            label4.Visible = true;
        }

        private void Button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Size = new Size(120, 120);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Purchasing p = new Purchasing();
            p.Show();
            this.Close();
        }

        private void Button5_MouseEnter(object sender, EventArgs e)
        {
            button5.Size = new Size(123, 123);
            label5.Visible = true;
        }

        private void Button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Size = new Size(120, 120);
            label5.Visible = false;

        }
    }
}
