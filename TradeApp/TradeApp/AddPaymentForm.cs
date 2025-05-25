using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dapper;

namespace TradeApp
{
    public partial class AddPaymentForm : Form
    {
        private int contractId;

        public AddPaymentForm(int contractId)
        {
            InitializeComponent();
            this.contractId = contractId;

            labelContractId.Text = $"Договор № {contractId}";

            comboBoxPaymentType.Items.Add("cash");
            comboBoxPaymentType.Items.Add("transfer");
            comboBoxPaymentType.SelectedIndex = 0;

            dateTimePickerDate.Value = DateTime.Today;

            LoadPayments();
        }

        private void LoadPayments()
        {
            using (var conn = Db.GetConnection())
            {
                var payments = conn.Query<Payment>(@"
                    SELECT payment_id AS Id, payment_date AS PaymentDate, amount AS Amount, payment_type AS PaymentType
                    FROM payments
                    WHERE contract_id = @ContractId
                    ORDER BY payment_date DESC",
                    new { ContractId = contractId }).ToList();

                dataGridViewPayments.DataSource = payments;

                dataGridViewPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dataGridViewPayments.Columns.Contains("PaymentDate"))
                    dataGridViewPayments.Columns["PaymentDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
        }

        private void btnSavePayment_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Введите корректную сумму");
                return;
            }

            var paymentType = comboBoxPaymentType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(paymentType))
            {
                MessageBox.Show("Выберите тип платежа");
                return;
            }

            var paymentDate = dateTimePickerDate.Value.Date;

            using (var conn = Db.GetConnection())
            {
                // Получаем сумму всех позиций по договору
                decimal contractTotalAmount = conn.ExecuteScalar<decimal?>(@"
            SELECT COALESCE(SUM(amount), 0)
            FROM contract_items
            WHERE contract_id = @ContractId",
                    new { ContractId = contractId }) ?? 0m;

                decimal paidAmount = conn.ExecuteScalar<decimal?>(@"
            SELECT COALESCE(SUM(amount), 0)
            FROM payments
            WHERE contract_id = @ContractId",
                    new { ContractId = contractId }) ?? 0m;

                decimal remainingAmount = contractTotalAmount - paidAmount;

                if (amount > remainingAmount)
                {
                    MessageBox.Show($"Сумма платежа не может превышать остаток к оплате");
                    return;
                }


                conn.Execute(@"
            INSERT INTO payments (contract_id, payment_date, amount, payment_type)
            VALUES (@ContractId, @PaymentDate, @Amount, @PaymentType)",
                    new
                    {
                        ContractId = contractId,
                        PaymentDate = paymentDate,
                        Amount = amount,
                        PaymentType = paymentType
                    });
            }

            MessageBox.Show("Платёж добавлен");


            txtAmount.Clear();
            dateTimePickerDate.Value = DateTime.Today;
            comboBoxPaymentType.SelectedIndex = 0;
        }

    }

    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }
    }
}
