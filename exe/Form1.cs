using classes;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tester tester = new tester();
            string gedcom = tester.test();
            textBox1.Text = gedcom;

            //filer f = new filer("output.ged");
            filer f = new filer(@"gedcom.ged");
            f.write(gedcom);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new_individiual ni = new new_individiual();
            ni.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new_event ne = new new_event();
            ne.ShowDialog();
        }
    }
}
