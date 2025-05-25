namespace TradeApp
{
    partial class ContractsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewContractItems = new System.Windows.Forms.DataGridView();
            this.comboBoxClients = new System.Windows.Forms.ComboBox();
            this.comboBoxProducts = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelClient = new System.Windows.Forms.Label();
            this.dataGridViewContracts = new System.Windows.Forms.DataGridView();
            this.btnCreateEmptyContract = new System.Windows.Forms.Button();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.btnEditShippedQuantity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContractItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContracts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewContractItems
            // 
            this.dataGridViewContractItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContractItems.Location = new System.Drawing.Point(454, 22);
            this.dataGridViewContractItems.Name = "dataGridViewContractItems";
            this.dataGridViewContractItems.Size = new System.Drawing.Size(420, 300);
            this.dataGridViewContractItems.TabIndex = 0;
            // 
            // comboBoxClients
            // 
            this.comboBoxClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxClients.FormattingEnabled = true;
            this.comboBoxClients.Location = new System.Drawing.Point(12, 372);
            this.comboBoxClients.Name = "comboBoxClients";
            this.comboBoxClients.Size = new System.Drawing.Size(326, 24);
            this.comboBoxClients.TabIndex = 1;
            // 
            // comboBoxProducts
            // 
            this.comboBoxProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(454, 372);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(237, 24);
            this.comboBoxProducts.TabIndex = 2;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtQuantity.Location = new System.Drawing.Point(454, 420);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(237, 23);
            this.txtQuantity.TabIndex = 3;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAmount.Location = new System.Drawing.Point(454, 465);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(237, 23);
            this.txtAmount.TabIndex = 4;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddItem.Location = new System.Drawing.Point(715, 354);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(159, 69);
            this.btnAddItem.TabIndex = 5;
            this.btnAddItem.Text = "Добавить товар в договор";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelQuantity.Location = new System.Drawing.Point(454, 400);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(90, 17);
            this.labelQuantity.TabIndex = 7;
            this.labelQuantity.Text = "Количество:\n";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelAmount.Location = new System.Drawing.Point(454, 449);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(54, 17);
            this.labelAmount.TabIndex = 7;
            this.labelAmount.Text = "Сумма:\n";
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelProduct.Location = new System.Drawing.Point(454, 354);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(126, 17);
            this.labelProduct.TabIndex = 7;
            this.labelProduct.Text = "Название товара:";
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelClient.Location = new System.Drawing.Point(12, 346);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(97, 17);
            this.labelClient.TabIndex = 7;
            this.labelClient.Text = "Имя клиента:";
            // 
            // dataGridViewContracts
            // 
            this.dataGridViewContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContracts.Location = new System.Drawing.Point(12, 21);
            this.dataGridViewContracts.Name = "dataGridViewContracts";
            this.dataGridViewContracts.Size = new System.Drawing.Size(420, 301);
            this.dataGridViewContracts.TabIndex = 13;
            // 
            // btnCreateEmptyContract
            // 
            this.btnCreateEmptyContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCreateEmptyContract.Location = new System.Drawing.Point(12, 409);
            this.btnCreateEmptyContract.Name = "btnCreateEmptyContract";
            this.btnCreateEmptyContract.Size = new System.Drawing.Size(147, 68);
            this.btnCreateEmptyContract.TabIndex = 14;
            this.btnCreateEmptyContract.Text = "Создать договор на выбранного клиента";
            this.btnCreateEmptyContract.UseVisualStyleBackColor = true;
            this.btnCreateEmptyContract.Click += new System.EventHandler(this.btnCreateEmptyContract_Click);
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddPayment.Location = new System.Drawing.Point(176, 409);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(162, 68);
            this.btnAddPayment.TabIndex = 5;
            this.btnAddPayment.Text = "Добавить платёж в выбранный договор";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // btnEditShippedQuantity
            // 
            this.btnEditShippedQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEditShippedQuantity.Location = new System.Drawing.Point(715, 437);
            this.btnEditShippedQuantity.Name = "btnEditShippedQuantity";
            this.btnEditShippedQuantity.Size = new System.Drawing.Size(159, 61);
            this.btnEditShippedQuantity.TabIndex = 5;
            this.btnEditShippedQuantity.Text = "Изменить отгруженное количество";
            this.btnEditShippedQuantity.UseVisualStyleBackColor = true;
            this.btnEditShippedQuantity.Click += new System.EventHandler(this.btnEditShippedQuantity_Click);
            // 
            // ContractsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 510);
            this.Controls.Add(this.btnCreateEmptyContract);
            this.Controls.Add(this.dataGridViewContracts);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.btnEditShippedQuantity);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.comboBoxProducts);
            this.Controls.Add(this.comboBoxClients);
            this.Controls.Add(this.dataGridViewContractItems);
            this.Name = "ContractsForm";
            this.Text = "ContractsForm";
            this.Load += new System.EventHandler(this.ContractsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContractItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContracts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewContractItems;
        private System.Windows.Forms.ComboBox comboBoxClients;
        private System.Windows.Forms.ComboBox comboBoxProducts;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.DataGridView dataGridViewContracts;
        private System.Windows.Forms.Button btnCreateEmptyContract;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button btnEditShippedQuantity;
    }
}