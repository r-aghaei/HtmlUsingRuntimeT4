using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlUsingRuntimeT4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var rpt = new ReportTemplate();
            rpt.Session = new Dictionary<string, object>();
            rpt.Session["Model"] = new ReportModel
            {
                CustomerName = "Reza",
                Date = DateTime.Now,
                OrderItems = new List<OrderItem>()
                {
                    new OrderItem(){Name="Product 1", Price =100, Count=2 },
                    new OrderItem(){Name="Product 2", Price =200, Count=3 },
                    new OrderItem(){Name="Product 3", Price =50, Count=1 },
                }
            };
            rpt.Initialize();
            this.webBrowser1.DocumentText = rpt.TransformText();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }
    }
}
