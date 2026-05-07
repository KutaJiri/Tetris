using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private int ziskaneBody;
        public string Prezdivka() {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                return textBox1.Text;
            }
            else { 
                return "další co neumí psát";
            }

             }
        public Form2(int pocetBodu)
        {
            InitializeComponent();
            ziskaneBody = pocetBodu;
            switch (pocetBodu) {
                case 0:
                    labelPovzbuzujiciText.Text = "Bro i moje baby to umí líp";
                    break;
                                    case 1:
                    labelPovzbuzujiciText.Text = "Tak jeden bod se dá ale nic moc";
                    break;
                case 2:
                    labelPovzbuzujiciText.Text = "Dva body , tak to už si docela dáváš";
                    break;
                case 3:
                    labelPovzbuzujiciText.Text = "Tři už jsou docela dobrý ";
                    break;
                case 4:
                    labelPovzbuzujiciText.Text = "Tvůj výkon je nadprůměrný";
                    break;
                case 5:
                    labelPovzbuzujiciText.Text = "už jsi lepší než 9 z 10 babiček";
                    break;
                case 6:
                    labelPovzbuzujiciText.Text = "Tvůj výkon už ceněj i na ministerstvu";
                    break;
                case 7:
                    labelPovzbuzujiciText.Text = "Jsi neporazitelný jako Napoleon";
                    break;
                case 8:
                    labelPovzbuzujiciText.Text = "Takových bodů asi ještě nikdo nedosáhl";
                    break;
                case 9:
                    labelPovzbuzujiciText.Text = "Ani moje baby by neměla tolik bodů";
                    break;
                default:
                    labelPovzbuzujiciText.Text = "není co dodat fakt ti to jde";
                    break;
            }

            labelPovzbuzujiciText.Left = (int)(this.ClientSize.Width * 0.5 - labelPovzbuzujiciText.Width * 0.5);


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
