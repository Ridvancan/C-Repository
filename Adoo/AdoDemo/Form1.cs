using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoDemo
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name =tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount=Convert.ToInt32(tbxStockAmount.Text)

            });
            Refill();
            MessageBox.Show("Product Added!");

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxupname.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxupprice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxupstock.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            Product product = new Product 
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxupname.Text,
                UnitPrice = Convert.ToDecimal(tbxupprice.Text),
                StockAmount= Convert.ToInt32(tbxupstock.Text)
        };
            _productDal.Update(product);
            MessageBox.Show("Done!");
            Refill();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            MessageBox.Show("Done! Deleted");
            Refill();
        }

        private void tbxupname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
