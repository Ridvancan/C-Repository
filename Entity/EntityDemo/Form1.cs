using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            Refill();
        }

        private void Refill()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product 
            {
                Name = tbxName.Text,
                UnitPrice =Convert.ToDecimal( tbxUnitPrice.Text),
                Stock=Convert.ToInt32(tbxStockAmount.Text)
            });
            MessageBox.Show("Done!Added");
            Refill();
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product 
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxupname.Text,
                UnitPrice = Convert.ToDecimal(tbxupprice.Text),
                Stock = Convert.ToInt32(tbxupstock.Text)
            });
            Refill();
            
            MessageBox.Show("Güncellendi!");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxupname.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxupprice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxupstock.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            }) ;
            Refill();
            
            MessageBox.Show("Deleted!");

        }

       

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            Research(tbxSearch.Text);
        }
        private void Research(string key)
        {
            var result = _productDal.GetByname(key);
            dgwProducts.DataSource = result;
            
        }

        private void tbxGetbyid_Click(object sender, EventArgs e)
        {
            _productDal.GetById(2);
        }
    }
}
