using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dapper;

namespace TradeApp
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLoadProducts_Click(object sender, EventArgs e)
        {
            using (var connection = Db.GetConnection())
            {
                var products = connection.Query<Product>("SELECT product_id AS Id, name, price FROM products").AsList();
                dataGridViewProducts.DataSource = products;
            }

            if (dataGridViewProducts.Columns["Id"] != null)
                dataGridViewProducts.Columns["Id"].HeaderText = "Идентификатор";

            if (dataGridViewProducts.Columns["Name"] != null)
                dataGridViewProducts.Columns["Name"].HeaderText = "Название товара";

            if (dataGridViewProducts.Columns["Price"] != null)
                dataGridViewProducts.Columns["Price"].HeaderText = "Цена";
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var name = txtProductName.Text.Trim();
            if (!decimal.TryParse(txtProductPrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Введите корректную цену");
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите название товара");
                return;
            }

            using (var connection = Db.GetConnection())
            {
                connection.Open();
                var sql = "INSERT INTO products (name, price) VALUES (@Name, @Price)";
                connection.Execute(sql, new { Name = name, Price = price });
            }

            MessageBox.Show("Товар добавлен");
            txtProductName.Clear();
            txtProductPrice.Clear();

            btnLoadProducts.PerformClick();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            //btnLoadProducts.PerformClick();
        }

        private void labelNameProducts_Click(object sender, EventArgs e)
        {

        }
    }

    public class Product
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
