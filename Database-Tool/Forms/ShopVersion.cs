using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Database_Tool
{
    public partial class ShopVersion : Form
    {
        public ShopVersion()
        {
            InitializeComponent();
        }

        private void LoadShopVersion()
        {
            try
            {
                if (!File.Exists("settings.ini"))
                {
                    System.Windows.Forms.MessageBox.Show("The file settings.ini do not exist.", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                else
                {
                    var ini = new IniFile();
                    ini.Load("settings.ini");
                    string _r = ini["ConnectionString"]["Source"].GetString();
                    MySqlConnection con = new MySqlConnection($"{_r}");
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        MySqlDataReader _myReader = null;
                            
                        string _instruccion = "Select * from shop_version";

                        MySqlCommand _command = new MySqlCommand(_instruccion, con);

                       _myReader = _command.ExecuteReader();

                        while (_myReader.Read())
                        {
                            numericUpDown1.Value = Convert.ToDecimal((_myReader["Version"]));
                        }

                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void UpdateShopVersion()
        {
            try
            {
                if (!File.Exists("settings.ini"))
                {
                    System.Windows.Forms.MessageBox.Show("The file settings.ini do not exist.", "Information: ShopItemsInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                else
                {
                    var ini = new IniFile();
                    ini.Load("settings.ini");
                    string _r = ini["ConnectionString"]["Source"].GetString();
                    MySqlConnection con = new MySqlConnection($"{_r}");
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        MySqlCommand _command = new MySqlCommand();
                        _command.CommandText = "UPDATE shop_version SET Version=@version";
                        _command.Parameters.AddWithValue("@version", numericUpDown1.Value);
                        _command.Connection = con;
                        _command.ExecuteNonQuery();
                        System.Windows.Forms.MessageBox.Show($"Sucessfully has been update shop_version", "Information: shop_version", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        con.Close();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error", "Information: shop_version", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void ShopVersion_Load(object sender, EventArgs e)
        {
            LoadShopVersion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateShopVersion();
        }
    }
}
