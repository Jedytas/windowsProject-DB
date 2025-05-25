using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using Microsoft.VisualBasic;

namespace TradeApp
{
    public partial class ContractsForm : Form
    {
        private int nextItemId = 1;
        private int currentContractId = 0;
        private List<ContractItem> currentItems = new List<ContractItem>();

        public ContractsForm()
        {
            InitializeComponent();
            dataGridViewContractItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewContracts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewContracts.SelectionChanged += dataGridViewContracts_SelectionChanged;

            LoadClients();
            LoadProducts();
            LoadContracts();
        }

        private void LoadClients()
        {
            using (var conn = Db.GetConnection())
            {
                var clients = conn.Query<Client>("SELECT client_id AS Id, name AS Name FROM clients").AsList();
                comboBoxClients.DataSource = clients;
                comboBoxClients.DisplayMember = "Name";
                comboBoxClients.ValueMember = "Id";
            }
        }

        private void LoadProducts()
        {
            using (var conn = Db.GetConnection())
            {
                var products = conn.Query<Product>("SELECT product_id AS Id, name AS Name FROM products").AsList();
                comboBoxProducts.DataSource = products;
                comboBoxProducts.DisplayMember = "Name";
                comboBoxProducts.ValueMember = "Id";
            }
        }

        private void LoadContracts()
        {
            using (var conn = Db.GetConnection())
            {
                var contracts = conn.Query<Contract>(@"
                    SELECT c.contract_id AS Id, cl.name AS ClientName, c.contract_date AS ContractDate
                    FROM contracts c
                    JOIN clients cl ON c.client_id = cl.client_id
                    ORDER BY c.contract_date DESC
                ").AsList();

                dataGridViewContracts.DataSource = contracts;
            }

            if (dataGridViewContracts.Columns["Id"] != null)
                dataGridViewContracts.Columns["Id"].HeaderText = "Номер договора";

            if (dataGridViewContracts.Columns["ClientName"] != null)
                dataGridViewContracts.Columns["ClientName"].HeaderText = "Клиент";

            if (dataGridViewContracts.Columns["ContractDate"] != null)
                dataGridViewContracts.Columns["ContractDate"].HeaderText = "Дата договора";
        }

        private void LoadContractItems(int contractId)
        {
            using (var conn = Db.GetConnection())
            {
                var items = conn.Query<ContractItem>(@"
                    SELECT 
                        ci.contract_item_id AS Id,
                        p.name AS ProductName,
                        ci.quantity AS Quantity,
                        ci.shipped_quantity AS ShippedQuantity,
                        ci.amount AS Amount
                    FROM contract_items ci
                    JOIN products p ON ci.product_id = p.product_id
                    WHERE ci.contract_id = @ContractId
                ", new { ContractId = contractId }).ToList();

                currentItems = items;
                RefreshContractItemsGrid();
            }

            if (dataGridViewContractItems.Columns["Id"] != null)
                dataGridViewContractItems.Columns["Id"].HeaderText = "Номер позиции";

            if (dataGridViewContractItems.Columns["ProductName"] != null)
                dataGridViewContractItems.Columns["ProductName"].HeaderText = "Товар";

            if (dataGridViewContractItems.Columns["Quantity"] != null)
                dataGridViewContractItems.Columns["Quantity"].HeaderText = "Количество";

            if (dataGridViewContractItems.Columns["ShippedQuantity"] != null)
                dataGridViewContractItems.Columns["ShippedQuantity"].HeaderText = "Отгружено";

            if (dataGridViewContractItems.Columns["Amount"] != null)
                dataGridViewContractItems.Columns["Amount"].HeaderText = "Сумма";
        }

        private void dataGridViewContracts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewContracts.CurrentRow?.DataBoundItem is Contract selected)
            {
                currentContractId = selected.Id;
                LoadContractItems(currentContractId);
            }
        }

        private void RefreshContractItemsGrid()
        {
            dataGridViewContractItems.DataSource = null;
            dataGridViewContractItems.DataSource = currentItems;
            if (dataGridViewContractItems.Columns.Contains("ShippedQuantity"))
                dataGridViewContractItems.Columns["ShippedQuantity"].ReadOnly = false;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Введите корректное количество");
                return;
            }

            if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Введите корректную сумму");
                return;
            }

            var product = (Product)comboBoxProducts.SelectedItem;

            if (currentContractId != 0)
            {
                using (var conn = Db.GetConnection())
                {
                    var productId = product.Id;

                    conn.Execute(@"
                INSERT INTO contract_items 
                    (contract_id, product_id, quantity, amount) 
                VALUES 
                    (@ContractId, @ProductId, @Quantity, @Amount)",
                        new
                        {
                            ContractId = currentContractId,
                            ProductId = productId,
                            Quantity = quantity,
                            Amount = amount
                        });
                }

                LoadContractItems(currentContractId); 
            }
            else
            {
                var item = new ContractItem
                {
                    Id = nextItemId++,
                    ProductName = product.Name,
                    Quantity = quantity,
                    Amount = amount
                };

                currentItems.Add(item);
                RefreshContractItemsGrid();
            }

            txtQuantity.Clear();
            txtAmount.Clear();
        }

        private void btnCreateEmptyContract_Click(object sender, EventArgs e)
        {
            if (comboBoxClients.SelectedItem == null)
            {
                MessageBox.Show("Выберите клиента для создания договора");
                return;
            }

            var client = (Client)comboBoxClients.SelectedItem;

            using (var conn = Db.GetConnection())
            {
                try
                {
                    var contractId = conn.ExecuteScalar<int>(@"
                INSERT INTO contracts (client_id, contract_date)
                VALUES (@ClientId, CURRENT_DATE)
                RETURNING contract_id", new { ClientId = client.Id });

                    MessageBox.Show($"Пустой договор создан (ID: {contractId})");

                    LoadContracts();

                    var contracts = (List<Contract>)dataGridViewContracts.DataSource;
                    var created = contracts.FirstOrDefault(c => c.Id == contractId);
                    if (created != null)
                    {
                        var rowIndex = contracts.IndexOf(created);
                        dataGridViewContracts.ClearSelection();
                        dataGridViewContracts.Rows[rowIndex].Selected = true;
                        currentContractId = created.Id;
                        LoadContractItems(currentContractId);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при создании пустого договора: " + ex.Message);
                }
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (currentContractId == 0)
            {
                MessageBox.Show("Сначала выберите договор.");
                return;
            }

            var paymentForm = new AddPaymentForm(currentContractId);
            paymentForm.ShowDialog();
        }

        private void btnEditShippedQuantity_Click(object sender, EventArgs e)
        {
            if (dataGridViewContractItems.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар для изменения.");
                return;
            }

            var selectedItem = (ContractItem)dataGridViewContractItems.CurrentRow.DataBoundItem;

            using (var conn = Db.GetConnection())
            {
                decimal paidAmount = conn.ExecuteScalar<decimal>(@"
            SELECT COALESCE(SUM(amount), 0)
            FROM payments
            WHERE contract_id = @ContractId",
                    new { ContractId = currentContractId });

                if (paidAmount <= 0)
                {
                    MessageBox.Show("Нельзя изменить отгруженное количество, так как по договору нет внесенной оплаты.");
                    return;
                }
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Введите новое значение отгруженного количества для товара \"{selectedItem.ProductName}\":",
                "Изменить отгруженное количество",
                selectedItem.ShippedQuantity.ToString());

            if (int.TryParse(input, out int newShippedQty) && newShippedQty >= 0)
            {

                if (newShippedQty > selectedItem.Quantity)
                {
                    MessageBox.Show($"Отгруженное количество не может быть больше общего количества ({selectedItem.Quantity}).");
                    return;
                }

                using (var conn = Db.GetConnection())
                {
                    conn.Execute(@"
                UPDATE contract_items
                SET shipped_quantity = @ShippedQuantity
                WHERE contract_item_id = @ItemId",
                        new { ShippedQuantity = newShippedQty, ItemId = selectedItem.Id });
                }

                selectedItem.ShippedQuantity = newShippedQty;
                RefreshContractItemsGrid();
            }
            else
            {
                MessageBox.Show("Некорректное значение. Введите неотрицательное целое число.");
            }
        }


        private void ContractsForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class Contract
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public DateTime ContractDate { get; set; }
    }

    public class ContractItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int ShippedQuantity { get; set; }
        public decimal Amount { get; set; }
    }
}
