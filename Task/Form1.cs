using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {

            DateTime AgreementData = monthCalendar1.SelectionRange.Start;
            DateTime CalculationData = monthCalendar2.SelectionRange.Start;
            double X = Convert.ToDouble(textBox1.Text);
            double R = Convert.ToDouble(textBox2.Text);
            int N = Int32.Parse(textBox3.Text);

            Investment investment = new Investment(AgreementData, CalculationData, X, R, N);
            Result result = investment.Calculate();

            textBox4.Text = result.FixedPayment.ToString();
            richTextBox1.Text = string.Join(" ", result.AllInterest);
            textBox5.Text = result.Nextintrest.ToString();
            textBox6.Text = result.SumInterest.ToString();
        }
    }
}
