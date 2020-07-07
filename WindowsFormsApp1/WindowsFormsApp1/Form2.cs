using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        Form1 f = new Form1();
        

        public Form2()
        {
            InitializeComponent();
        }

        public void sendbutton_Click(object sender, EventArgs e)
        {
           
            this.f.buybox.Text = send.Text;
            f.buybox.Refresh();
            
            this.Close();
        }
    }
}
