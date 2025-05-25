using ClosedXML.Excel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;

namespace TradeApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            comboBoxEntities.SelectedIndex = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string selected = comboBoxEntities.SelectedItem.ToString();
            Form formToOpen = null;

            switch (selected)
            {
                case "Клиенты":
                    formToOpen = new ClientsForm();
                    break;
                case "Товары":
                    formToOpen = new ProductsForm();
                    break;
                case "Договоры":
                    formToOpen = new ContractsForm();
                    break;
            }

            if (formToOpen != null)
                formToOpen.ShowDialog();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            var reportData = GetReportData();

            var excelApp = new Excel.Application();
            excelApp.Visible = false;

            try
            {
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Материальный отчет";

                worksheet.Cells[1, 1] = "Клиент";
                worksheet.Cells[1, 2] = "Товар";
                worksheet.Cells[1, 3] = "Количество к отгрузке";
                worksheet.Cells[1, 4] = "Количество отгружено";
                worksheet.Cells[1, 5] = "Сумма к отгрузке";

                int row = 2;
                foreach (var item in reportData)
                {
                    worksheet.Cells[row, 1] = item.ClientName;
                    worksheet.Cells[row, 2] = item.ProductName;
                    worksheet.Cells[row, 3] = item.QuantityToShip;
                    worksheet.Cells[row, 4] = item.ShippedQuantity;
                    worksheet.Cells[row, 5] = item.AmountToShip;
                    row++;
                }

                // Авторазмер столбцов
                worksheet.Columns.AutoFit();

                Excel.ChartObjects charts = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Excel.ChartObject chartObject = charts.Add(500, 50, 600, 400); 
                Excel.Chart chart = chartObject.Chart;

                Excel.Range chartRange = worksheet.Range[worksheet.Cells[1, 2], worksheet.Cells[row - 1, 4]];

                chart.SetSourceData(chartRange);
                chart.ChartType = Excel.XlChartType.xlColumnClustered;
                chart.HasTitle = true;
                chart.ChartTitle.Text = "Отгрузка товаров";

                Excel.Axis categoryAxis = (Excel.Axis)chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
                categoryAxis.HasTitle = true;
                categoryAxis.AxisTitle.Text = "Товар";

                Excel.Axis valueAxis = (Excel.Axis)chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
                valueAxis.HasTitle = true;
                valueAxis.AxisTitle.Text = "Количество";

                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Сохранить отчет как"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Отчет успешно сохранен!");
                }

                workbook.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при формировании отчета: " + ex.Message);
            }
            finally
            {
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }

        private List<ReportItem> GetReportData()
        {
            using (var conn = Db.GetConnection())
            {
                string sql = @"
                    SELECT 
                        cl.name AS ClientName, 
                        p.name AS ProductName,
                        ci.quantity - ci.shipped_quantity AS QuantityToShip,
                        ci.shipped_quantity AS ShippedQuantity,
                        (ci.quantity - ci.shipped_quantity) * ci.amount AS AmountToShip
                    FROM contracts c
                    JOIN clients cl ON c.client_id = cl.client_id
                    JOIN contract_items ci ON ci.contract_id = c.contract_id
                    JOIN products p ON ci.product_id = p.product_id
                    WHERE (ci.quantity - ci.shipped_quantity) > 0
                    ORDER BY cl.name, p.name;
                ";

                return conn.Query<ReportItem>(sql).AsList();
            }
        }

        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {
            var reportData = GetReportData();

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);

            Series seriesToShip = new Series("К отгрузке")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String
            };
            Series seriesShipped = new Series("Отгружено")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String
            };

            foreach (var item in reportData)
            {
                seriesToShip.Points.AddXY(item.ProductName, item.QuantityToShip);
                seriesShipped.Points.AddXY(item.ProductName, item.ShippedQuantity);
            }

            chart1.Series.Add(seriesToShip);
            chart1.Series.Add(seriesShipped);

            chart1.Titles.Add("Отгрузка товаров");

            chart1.Legends[0].Docking = Docking.Top;

            chart1.Invalidate();
        }

    }

    public class ReportItem
    {
        public string ClientName { get; set; }
        public string ProductName { get; set; }
        public int QuantityToShip { get; set; }
        public int ShippedQuantity { get; set; }
        public decimal AmountToShip { get; set; }
    }
}
