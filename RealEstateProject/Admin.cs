using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace RealEstateProject
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();

            DataSet ds = new DataSet();

            using (realestateEntities db = new realestateEntities())
            {
                var data = (from x in db.houses select x).ToList();
                dataGridView1.DataSource = data;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnaddHouse_Click(object sender, EventArgs e)
        {
            //check if textboxes are not empty
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {
                MessageBox.Show("Text boxes must be filled out!", "Error");
            }
            else
            {
                //open db connection

                //check if this house exists
                var address = txtAddress.Text;
                var idv = Convert.ToInt32(txtId.Text);
                using (realestateEntities db = new realestateEntities())
                {
                    //check if this entry already doesn't exists in the db (no duplicates)
                    var check = (from x in db.houses where x.Address == address select x).FirstOrDefault();
                    var check1 = (from x in db.houses where x.t_Id == idv select x).FirstOrDefault();
                    //if not then create an entry
                    if (check == null && check1 == null)
                    {
                        house h = new house
                        {
                            //add house
                            t_Id = Convert.ToInt32(txtId.Text),
                            type = txtType.Text,
                            Address = txtAddress.Text,
                            State = txtState.Text,
                            City = txtCity.Text,
                            Cost = txtCost.Text,
                            Offer = "None",
                            Offer_by ="None"
                        };
                        db.houses.Add(h);
                        db.SaveChanges(); //saves to the db
                    }
                    else if (check != null)
                    {
                        MessageBox.Show("Address already exist in Database.", "Error");
                    }
                    else if (check1 != null)
                    {
                        MessageBox.Show("Enter new ID.", "Error");
                    }

                }
            }
        }
    }
}
