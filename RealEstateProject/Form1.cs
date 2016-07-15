using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using DAL;

namespace RealEstateProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != string.Empty && txtPass.Text != string.Empty)
            {
                var uname = txtUsername.Text;
                var pass = txtPass.Text;

                using (realestateEntities db = new realestateEntities())
                {
                    var user = (from x in db.users where x.uName == uname && x.pw == pass select x).FirstOrDefault();

                    if (user != null)
                    {
                        //open next window
                        if (user.permissions == "Admin")
                        {
                            Admin ad = new Admin();
                            this.Hide();
                            ad.Show();
                        }
                        if(user.permissions == "Client")
                        {
                            UserP userp = new UserP();
                            this.Hide();
                            userp.Show();
                        }
                    }
                    else
                    {
                        //error
                        MessageBox.Show("Incorrect Username or Password!","Error");
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
