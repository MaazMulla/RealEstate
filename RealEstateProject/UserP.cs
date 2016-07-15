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
    public partial class UserP : Form
    {
        public UserP()
        {
            InitializeComponent();

            DataSet ds = new DataSet();

            using (realestateEntities db = new realestateEntities())
            {
                var data = (from x in db.houses select x).ToList();
                dataGridView1.DataSource = data;
            }
        }

        protected void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddOffer_Click(object sender, EventArgs e)
        {
            ////check if textboxes are not empty
            //if()
            ////open db connection
            
            ////check if this house exists
            //var idv = 678;

            //using (realestateEntities db = new realestateEntities())
            //{

            //    //check if this entry already doesn't exists in the db (no duplicates)
            //    var check = (from x in db.houses where x.t_Id == idv select x).FirstOrDefault();

            //    //if not then create an entry
            //    if (check != null)
            //    {
            //        house h = new house
            //        {
            //            //add offer
            //        };
            //        db.houses.Add(h);
            //        db.SaveChanges(); //saves to the db
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}
