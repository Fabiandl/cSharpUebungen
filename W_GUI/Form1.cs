using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Random rdm = new Random();
            for (int i = 0; i < 10; i++)
            {
                listBox.Items.Add(rdm.Next(1,100));
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                textBox.Text = listBox.SelectedItem.ToString();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                int item = listBox.SelectedIndex;
                listBox.Items.RemoveAt(item);
            }
            else
            {
                MessageBox.Show("zuerst muss eine Zahl ausgewäht werden!");
            }
        }
    }
}