using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;

namespace Database_Tool
{
    public partial class Caps : Form
    { 
        public Caps()
        {
            InitializeComponent();
            textBox4.Text = "1";
            textBox5.Text = "1";
            textBox6.Text = "0";
            textBox11.Text = "1";

            button1.Enabled = false;
            button2.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            groupBox3.Enabled = false;
            groupBox2.Enabled = false;
            groupBox4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog _openFile = new OpenFileDialog();
            _openFile.Title = "Select txt";
            _openFile.Filter = "TXT files|*.txt";
            _openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (_openFile.ShowDialog() == DialogResult.OK)
            {
                string _filename = _openFile.FileName;

                string[] _lines = File.ReadAllLines(_filename);

                //int _count = listBox1.Items.Count;               

                var prgrid = Interaction.InputBox("Write for continue", "priceGroupId", "", -1, -1);

                var efgrpid = Interaction.InputBox("Write for continue", "shop_effect_group", "", -1, -1);

                foreach (string _line in _lines)
                {                                     
                    listBox1.Items.Add(_line);

                    //string price = textBox14.Text;
                    //string effectgroupid = textBox13.Text;
                    //string isenabled = textBox15.Text;

                    //Data.CapsData.LoadShopItemInfos(_line, price, effectgroupid, isenabled);

                    label1.Text = listBox1.Items.Count.ToString();

                    Data.CapsData.LoadShopItems(_line, "0", "1", "1", "1", "0");

                    Data.CapsData.LoadShopItemInfos(_line, prgrid, efgrpid, "1");
                }

                System.Windows.Forms.MessageBox.Show($"Sucessfully has been inserted list", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);                
            }        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label1.Text = listBox1.Items.Count.ToString();

            //var test = listBox1.Items[0];
            //MessageBox.Show(test.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Data.CapsData.LoadShopItemsInfos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Data.CapsData.LoadShopItems();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = false;

                button1.Enabled = false;
                button2.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
            }
            else if (radioButton1.Checked == true)
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = true;

                button1.Enabled = true;
                button2.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog _openFile = new OpenFileDialog();
            _openFile.Title = "Select txt";
            _openFile.Filter = "TXT files|*.txt";
            _openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (_openFile.ShowDialog() == DialogResult.OK)
            {
                string _filename = _openFile.FileName;

                string[] _lines = File.ReadAllLines(_filename);

                foreach (string _line in _lines)
                {
                    listBox1.Items.Add(_line);
                }

                label1.Text = listBox1.Items.Count.ToString();

                System.Windows.Forms.MessageBox.Show($"Sucessfully has been load list", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var _rg = Interaction.InputBox("Write for continue", "requiredGender", "", -1, -1);
                var _mt = Interaction.InputBox("Write for continue", "MainTab", "", -1, -1);
                var _st = Interaction.InputBox("Write for continue", "SubTab", "", -1, -1);

                SaveFileDialog _sv = new SaveFileDialog();
                _sv.Title = "Save in directory";
                _sv.Filter = "Sql files|*.sql";
                _sv.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (_sv.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter _SaveFile = new System.IO.StreamWriter(_sv.FileName))
                    {
                        foreach (var item in listBox1.Items)
                        {
                            string insert = $"INSERT INTO `shop_items` VALUES ('{item}', '0', '{_rg}', '0', '0', '0', '0', '0', '0', '1', '{_mt}', '{_st}');";
                            _SaveFile.WriteLine(insert.ToString());
                        }
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Data.CapsData.InsertShopItemInfos(textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Data.CapsData.InsertShopItems(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Data.CapsData.UpdateShopItemInfos(textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text);
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
        }       

        private void button13_Click(object sender, EventArgs e)
        {
            Data.CapsData.UpdateShopItems(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Data.CapsData.DeleteShopItemInfos(textBox7.Text);
            textBox7.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Data.CapsData.DeleteShopItems(textBox1.Text);
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Data.CapsData.DeleteAllShopItemInfos();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Data.CapsData.DeleteAllShopItems();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
