using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dapper;

namespace TradeApp
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
            dataGridViewClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            //btnLoadClients.PerformClick();
        }

        private void btnLoadClients_Click(object sender, EventArgs e)
        {
            using (var connection = Db.GetConnection())
            {
                var clients = connection.Query<Client>("SELECT client_id AS Id, name FROM clients").AsList();
                dataGridViewClients.DataSource = clients;
            }

            if (dataGridViewClients.Columns["Id"] != null)
                dataGridViewClients.Columns["Id"].HeaderText = "Идентификатор";

            if (dataGridViewClients.Columns["Name"] != null)
                dataGridViewClients.Columns["Name"].HeaderText = "Имя клиента";
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            var clientName = txtClientName.Text.Trim();
            if (string.IsNullOrEmpty(clientName))
            {
                MessageBox.Show("Введите имя клиента");
                return;
            }

            using (var connection = Db.GetConnection())
            {
                connection.Open();
                var sql = "INSERT INTO clients (name) VALUES (@Name)";
                connection.Execute(sql, new { Name = clientName });
            }

            MessageBox.Show("Клиент добавлен");
            txtClientName.Clear();

            btnLoadClients.PerformClick();
        }
    }

    public class Client
    {
        public int Id { get; set; }  
        public string Name { get; set; }
    }
}
