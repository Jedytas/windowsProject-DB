namespace TradeApp
{
    partial class AddPaymentForm
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
            this.labelContractId = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelPaymentType = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.comboBoxPaymentType = new System.Windows.Forms.ComboBox();
            this.btnSavePayment = new System.Windows.Forms.Button();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewPayments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // labelContractId
            // 
            this.labelContractId.AutoSize = true;
            this.labelContractId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelContractId.Location = new System.Drawing.Point(38, 43);
            this.labelContractId.Name = "labelContractId";
            this.labelContractId.Size = new System.Drawing.Size(115, 17);
            this.labelContractId.TabIndex = 0;
            this.labelContractId.Text = "Номер договора";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelAmount.Location = new System.Drawing.Point(38, 73);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(114, 17);
            this.labelAmount.TabIndex = 0;
            this.labelAmount.Text = "Сумма платежа:";
            // 
            // labelPaymentType
            // 
            this.labelPaymentType.AutoSize = true;
            this.labelPaymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelPaymentType.Location = new System.Drawing.Point(38, 150);
            this.labelPaymentType.Name = "labelPaymentType";
            this.labelPaymentType.Size = new System.Drawing.Size(97, 17);
            this.labelPaymentType.TabIndex = 0;
            this.labelPaymentType.Text = "Тип платежа:";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAmount.Location = new System.Drawing.Point(41, 106);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(208, 23);
            this.txtAmount.TabIndex = 1;
            // 
            // comboBoxPaymentType
            // 
            this.comboBoxPaymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxPaymentType.FormattingEnabled = true;
            this.comboBoxPaymentType.Location = new System.Drawing.Point(41, 188);
            this.comboBoxPaymentType.Name = "comboBoxPaymentType";
            this.comboBoxPaymentType.Size = new System.Drawing.Size(208, 24);
            this.comboBoxPaymentType.TabIndex = 2;
            // 
            // btnSavePayment
            // 
            this.btnSavePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSavePayment.Location = new System.Drawing.Point(38, 276);
            this.btnSavePayment.Name = "btnSavePayment";
            this.btnSavePayment.Size = new System.Drawing.Size(211, 35);
            this.btnSavePayment.TabIndex = 3;
            this.btnSavePayment.Text = "Сохранить";
            this.btnSavePayment.UseVisualStyleBackColor = true;
            this.btnSavePayment.Click += new System.EventHandler(this.btnSavePayment_Click);
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePickerDate.Location = new System.Drawing.Point(41, 230);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(208, 23);
            this.dateTimePickerDate.TabIndex = 4;
            // 
            // dataGridViewPayments
            // 
            this.dataGridViewPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPayments.Location = new System.Drawing.Point(304, 43);
            this.dataGridViewPayments.Name = "dataGridViewPayments";
            this.dataGridViewPayments.Size = new System.Drawing.Size(364, 268);
            this.dataGridViewPayments.TabIndex = 5;
            // 
            // AddPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 388);
            this.Controls.Add(this.dataGridViewPayments);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.btnSavePayment);
            this.Controls.Add(this.comboBoxPaymentType);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.labelPaymentType);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelContractId);
            this.Name = "AddPaymentForm";
            this.Text = "AddPaymentForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelContractId;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelPaymentType;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox comboBoxPaymentType;
        private System.Windows.Forms.Button btnSavePayment;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.DataGridView dataGridViewPayments;
    }
}