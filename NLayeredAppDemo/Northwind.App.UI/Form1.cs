using Northwind.Buisness.Abstract;
using Northwind.Buisness.Concrete;
using Northwind.Buisness.DependencyResolver.Ninject;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.App.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }

        private IProductService _productService;
        private ICategoryService _categoryService;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();


        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategory2.DataSource = _categoryService.GetAll();
            cbxCategory2.DisplayMember = "CategoryName";
            cbxCategory2.ValueMember = "CategoryId";

            cbxCategory3.DataSource = _categoryService.GetAll();
            cbxCategory3.DisplayMember = "CategoryName";
            cbxCategory3.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch 
            {

            }
            
        }

        private void tbxProductName_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxProductName.Text))
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(tbxProductName.Text);
            }
            else
            {
            LoadProducts();
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productService.Add(new Product
            {
                CategoryID = Convert.ToInt32(cbxCategory2.SelectedValue),
                ProductName = tbxProductName2.Text,
                QuantityPerUnit = tbxQuantityPerUnit.Text,
                UnitPrice =Convert.ToDecimal(tbxUnitPrice.Text),
                UnitsInStock=Convert.ToInt16(tbxStock.Text)

            }) ;
            MessageBox.Show("Ürün Başarıyla Eklendi!");
            LoadProducts();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId=Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                ProductName=tbxUpdateName.Text,
                CategoryID=Convert.ToInt32(cbxCategory3.SelectedValue),
                UnitsInStock=Convert.ToInt16(tbxUpdateStock.Text),
                UnitPrice=Convert.ToDecimal(tbxUpdatePrice.Text),
                QuantityPerUnit=tbxUpdateQuantity.Text,
            });
                MessageBox.Show("Ürün Başarıyla Güncellendi!");
                LoadProducts();
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxUpdateName.Text = dgwProduct.CurrentRow.Cells[1].Value.ToString();
            cbxCategory3.SelectedValue = dgwProduct.CurrentRow.Cells[2].Value;
            tbxUpdatePrice.Text = dgwProduct.CurrentRow.Cells[3].Value.ToString();
            tbxUpdateQuantity.Text = dgwProduct.CurrentRow.Cells[4].Value.ToString();
            tbxUpdateStock.Text = dgwProduct.CurrentRow.Cells[5].Value.ToString();


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgwProduct.CurrentRow != null)
            {
            _productService.Delete(new Product { ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)});
            }
            
            MessageBox.Show("Ürün Başarıyla Silindi!");
            LoadProducts();
        }
    }
}
