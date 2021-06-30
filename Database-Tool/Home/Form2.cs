using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Tool.Home
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database_Tool.Caps frmcaps = new Database_Tool.Caps();
            frmcaps.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database_Tool.Costumes frmcostumes = new Database_Tool.Costumes();
            frmcostumes.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database_Tool.Guns frmguns = new Database_Tool.Guns();
            frmguns.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Database_Tool.Pets frmpets = new Database_Tool.Pets();
            frmpets.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Database_Tool.Sword frmsword = new Database_Tool.Sword();
            frmsword.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Database_Tool.ShopVersion frmshopversion = new Database_Tool.ShopVersion();
            frmshopversion.Show();
            this.Hide();
        }
    }
}
