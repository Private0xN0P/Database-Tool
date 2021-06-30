using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Database_Tool
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.Server != string.Empty)
            {
                textBox1.Text = Properties.Settings.Default.Server;
                textBox2.Text = Properties.Settings.Default.Db;
                textBox3.Text = Properties.Settings.Default.User;
                textBox4.Text = Properties.Settings.Default.Password;
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    button1.Enabled = false;
        //    backgroundWorker1.RunWorkerAsync();
        //}

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    try
        //    {
        //        List<string> archivos = new List<string>();
        //        archivos.Add("test6.txt"); archivos.Add("test7.txt"); archivos.Add("text5.txt");
        //        int filesCount = archivos.Count();

        //        Invoke(new Action(() =>
        //        {
        //            for (int i = 0; i < filesCount; i++)
        //            {
        //                int percentage = (i + 1) * 100 / filesCount;
        //                label1.Text = percentage + "%";
        //                backgroundWorker1.ReportProgress(percentage);
        //            }
        //        }));
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    button1.Enabled = true;
        //}

        //private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    progressBar1.Value = e.ProgressPercentage;
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    progressBar1.Value = 0;
        //    label1.Text = string.Empty;
        //}
        private void SaveConnectionStringIni()
        {
            if (!File.Exists("settings.ini"))
            {
                string _connection = $"server={textBox1.Text}; database={textBox2.Text}; Uid={textBox3.Text}; password={textBox4.Text};";

                IniFile _ini = new IniFile();
                _ini["ConnectionString"]["Source"] = _connection;
                _ini.Save("settings.ini");
            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {                             
                if (checkBox1.Checked == true)
                {
                    Properties.Settings.Default.Server = textBox1.Text;
                    Properties.Settings.Default.Db = textBox2.Text;
                    Properties.Settings.Default.User = textBox3.Text;
                    Properties.Settings.Default.Password = textBox4.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Server = string.Empty;
                    Properties.Settings.Default.Db = string.Empty;
                    Properties.Settings.Default.User = string.Empty;
                    Properties.Settings.Default.Password = string.Empty;
                    Properties.Settings.Default.Save();
                }

                if (string.IsNullOrEmpty(textBox1.Text))
                {

                }
                else if (string.IsNullOrEmpty(textBox2.Text))
                {

                }
                else if (string.IsNullOrEmpty(textBox3.Text))
                {

                }
                else if (string.IsNullOrWhiteSpace(textBox1.Text))
                {

                }
                else if (string.IsNullOrWhiteSpace(textBox2.Text))
                {

                }
                else if (string.IsNullOrWhiteSpace(textBox3.Text))
                {

                }
                else
                {
                    string _svw = textBox1.Text;
                    string _dbw = textBox2.Text;
                    string _userw = textBox3.Text;
                    string _passw = textBox4.Text;

                    MySqlConnection _con = new MySqlConnection($"server={_svw}; database={_dbw}; Uid={_userw}; password={_passw};");
                    _con.Open();
                    if (_con.State == ConnectionState.Open)
                    {
                        await Task.Delay(1000);
                        Home.Form2 _frm2 = new Home.Form2();
                        _frm2.Text = textBox1.Text;
                        _frm2.Show();
                        this.Hide();
                        MessageBox.Show("Sucess", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveConnectionStringIni();
                    }
                    else if (_con.State == ConnectionState.Closed)
                    {
                        MessageBox.Show("Close", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                  
                }                          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Text = "Connected to :";
        }
     
        private bool ValidateServer()
        {
            bool bStatus = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "please check the information");
                bStatus = false;
            }
            else if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "please check the information");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
            return bStatus;
        }

        private bool ValidateDB()
        {
            bool bStatus = true;
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "please check the information");
                bStatus = false;
            }
            else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "please check the information");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
            return bStatus;
        }

        private bool ValidateUser()
        {
            bool bStatus = true;
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "please check the information");
                bStatus = false;
            }
            else if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "please check the information");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
            return bStatus;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            ValidateServer();
        }
        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            ValidateDB();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            ValidateDB();
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            ValidateUser();
        }        
    }
}
