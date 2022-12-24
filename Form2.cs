using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3._2
{
    public partial class Form2 : Form
    {
        public int W
        {

            get
            {
                string text = tbW.Text;
                int value = Convert.ToInt32(text);
                return value;
            }
        }
        public int H
        {
            get
            {
                string text = tbH.Text;
                int value = Convert.ToInt32(text);
                return value;
            }
        }
        public string FileName
        {
            get
            {
                return tbName.Text;
            }
        }
        bool _canceled = false;
        public bool Canceled
        {
            get { return _canceled; }
        }
         
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _canceled = true;
            Close();
        }
    }
}
