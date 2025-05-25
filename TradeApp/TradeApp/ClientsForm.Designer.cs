namespace TradeApp
{
    partial class ClientsForm
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
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.btnLoadClients = new System.Windows.Forms.Button();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.labelClName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.Size = new System.Drawing.Size(462, 368);
            this.dataGridViewClients.TabIndex = 0;
            // 
            // btnLoadClients
            // 
            this.btnLoadClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLoadClients.Location = new System.Drawing.Point(494, 222);
            this.btnLoadClients.Name = "btnLoadClients";
            this.btnLoadClients.Size = new System.Drawing.Size(168, 56);
            this.btnLoadClients.TabIndex = 1;
            this.btnLoadClients.Text = "Загрузить клиентов";
            this.btnLoadClients.UseVisualStyleBackColor = true;
            this.btnLoadClients.Click += new System.EventHandler(this.btnLoadClients_Click);
            // 
            // txtClientName
            // 
            this.txtClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtClientName.Location = new System.Drawing.Point(491, 114);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(171, 23);
            this.txtClientName.TabIndex = 2;
            // 
            // btnAddClient
            // 
            this.btnAddClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddClient.Location = new System.Drawing.Point(491, 155);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(171, 49);
            this.btnAddClient.TabIndex = 3;
            this.btnAddClient.Text = "Добавить клиента";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // labelClName
            // 
            this.labelClName.AutoSize = true;
            this.labelClName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelClName.Location = new System.Drawing.Point(491, 88);
            this.labelClName.Name = "labelClName";
            this.labelClName.Size = new System.Drawing.Size(154, 17);
            this.labelClName.TabIndex = 4;
            this.labelClName.Text = "Введите имя клиента:";
            // 
            // ClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 406);
            this.Controls.Add(this.labelClName);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.btnLoadClients);
            this.Controls.Add(this.dataGridViewClients);
            this.Name = "ClientsForm";
            this.Text = "ClientsForm";
            this.Load += new System.EventHandler(this.ClientsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.Button btnLoadClients;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Label labelClName;
    }
}