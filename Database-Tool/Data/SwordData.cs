using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;

namespace Database_Tool.Data
{
    class SwordData
    {
        public static DataTable LoadShopItemsInfos()
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
                        DataTable _gtd = new DataTable();

                        string _instruccion = "Select * from shop_iteminfos";

                        MySqlDataAdapter _adp = new MySqlDataAdapter(_instruccion, $"{_r}");

                        _adp.Fill(_gtd);

                        return _gtd;

                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error");
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static DataTable LoadShopItems()
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
                        DataTable _gtd = new DataTable();

                        string _instruccion = "Select * from shop_items";

                        MySqlDataAdapter _adp = new MySqlDataAdapter(_instruccion, $"{_r}");

                        _adp.Fill(_gtd);

                        return _gtd;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error");
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string InsertShopItemInfos(string id, string shopitemid, string pricegroupid, string effectgroupid, string isenabled)
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
                        //if (string.IsNullOrEmpty(id))
                        //{
                        //    System.Windows.Forms.MessageBox.Show("please check the information", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        //}
                        if (string.IsNullOrEmpty(shopitemid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(pricegroupid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(effectgroupid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(isenabled))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        //else if (string.IsNullOrWhiteSpace(id))
                        //{
                        //    System.Windows.Forms.MessageBox.Show("please check the information", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        //}
                        else if (string.IsNullOrWhiteSpace(shopitemid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(pricegroupid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(effectgroupid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(isenabled))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else
                        {
                            MySqlCommand _command = new MySqlCommand();
                            _command.CommandText = "INSERT INTO shop_iteminfos (ShopItemId, PriceGroupId, EffectGroupId, IsEnabled) values (@shopitemid, @pricegroupid, @effectgroupid, @isenabled)";
                            //_command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                            _command.Parameters.AddWithValue("@shopitemid", shopitemid);
                            _command.Parameters.AddWithValue("@pricegroupid", pricegroupid);
                            _command.Parameters.AddWithValue("@effectgroupid", effectgroupid);
                            _command.Parameters.AddWithValue("@isenabled", isenabled);
                            _command.Connection = con;
                            _command.ExecuteNonQuery();
                            System.Windows.Forms.MessageBox.Show($"Sucessfully has been inserted id = {id}", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            con.Close();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                return id + shopitemid + pricegroupid + effectgroupid + isenabled;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string InsertShopItems(string id, string requiredgender, string colors, string isdestroyable, string maintab, string subtab)
        {
            try
            {
                if (!File.Exists("settings.ini"))
                {
                    System.Windows.Forms.MessageBox.Show("The file settings.ini do not exist.", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                        if (string.IsNullOrEmpty(id))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(id))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(requiredgender))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(colors))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(isdestroyable))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(maintab))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(subtab))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(id))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(requiredgender))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(colors))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(isdestroyable))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(maintab))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(subtab))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else
                        {
                            MySqlCommand _command = new MySqlCommand();
                            _command.CommandText = "INSERT INTO shop_items (Id, RequiredGender, Colors, IsDestroyable, MainTab, SubTab) values (@id, @requiregender, @colors, @isdestroyable, @maintab, @subtab)";
                            _command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                            _command.Parameters.AddWithValue("@requiregender", requiredgender);
                            _command.Parameters.AddWithValue("@colors", colors);
                            _command.Parameters.AddWithValue("@isdestroyable", isdestroyable);
                            _command.Parameters.AddWithValue("@maintab", maintab);
                            _command.Parameters.AddWithValue("@subtab", subtab);
                            _command.Connection = con;
                            _command.ExecuteNonQuery();
                            System.Windows.Forms.MessageBox.Show($"Sucessfully has been inserted id = {id}", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            con.Close();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error", "Information: ShoItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                return id + requiredgender + colors + isdestroyable + maintab + subtab;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string UpdateShopItemInfos(string id, string shopitemid, string pricegroupid, string effectgroupid, string isenabled)
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
                        if (string.IsNullOrEmpty(id))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemsInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(shopitemid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemsInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(pricegroupid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemsInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(effectgroupid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemsInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(isenabled))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemsInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(id))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemsInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(shopitemid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemsInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(pricegroupid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemsInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(effectgroupid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemsInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(isenabled))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemsInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else
                        {
                            MySqlCommand _command = new MySqlCommand();
                            _command.CommandText = "UPDATE shop_iteminfos SET ShopItemId=@shopitemid, PriceGroupId=@pricegroupid, EffectGroupId=@effectgroupid, IsEnabled=@isenabled WHERE Id=@id";
                            _command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                            _command.Parameters.AddWithValue("@shopitemid", shopitemid);
                            _command.Parameters.AddWithValue("@pricegroupid", pricegroupid);
                            _command.Parameters.AddWithValue("@effectgroupid", effectgroupid);
                            _command.Parameters.AddWithValue("@isenabled", isenabled);
                            _command.Connection = con;
                            _command.ExecuteNonQuery();
                            System.Windows.Forms.MessageBox.Show($"Sucessfully has been update id = {id}", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            con.Close();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                return id + shopitemid + pricegroupid + effectgroupid + isenabled;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string UpdateShopItems(string id, string requiredgender, string colors, string isdestroyable, string maintab, string subtab)
        {
            try
            {
                if (!File.Exists("settings.ini"))
                {
                    System.Windows.Forms.MessageBox.Show("The file settings.ini do not exist.", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                        if (string.IsNullOrEmpty(id))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(id))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(requiredgender))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(colors))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(isdestroyable))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(maintab))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(subtab))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(id))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(requiredgender))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(colors))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(isdestroyable))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(maintab))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(subtab))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else
                        {
                            MySqlCommand _command = new MySqlCommand();
                            _command.CommandText = "UPDATE shop_items SET RequiredGender=@requiregender, Colors=@colors, IsDestroyable=@isdestroyable, MainTab=@maintab, SubTab=@subtab WHERE Id=@id";
                            _command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                            _command.Parameters.AddWithValue("@requiregender", requiredgender);
                            _command.Parameters.AddWithValue("@colors", colors);
                            _command.Parameters.AddWithValue("@isdestroyable", isdestroyable);
                            _command.Parameters.AddWithValue("@maintab", maintab);
                            _command.Parameters.AddWithValue("@subtab", subtab);
                            _command.Connection = con;
                            _command.ExecuteNonQuery();
                            System.Windows.Forms.MessageBox.Show($"Sucessfully has been update id = {id}", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            con.Close();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                return id + requiredgender + colors + isdestroyable + maintab + subtab;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string DeleteShopItemInfos(string id)
        {
            try
            {
                if (!File.Exists("settings.ini"))
                {
                    System.Windows.Forms.MessageBox.Show("The file settings.ini do not exist.", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                        if (string.IsNullOrEmpty(id))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        if (string.IsNullOrWhiteSpace(id))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else
                        {
                            MySqlCommand _command = new MySqlCommand();
                            _command.CommandText = "DELETE FROM shop_iteminfos WHERE Id=@id";
                            _command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                            _command.Connection = con;
                            _command.ExecuteNonQuery();
                            System.Windows.Forms.MessageBox.Show($"Sucessfully has been delete id = {id}", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            con.Close();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string DeleteShopItems(string id)
        {
            try
            {
                if (!File.Exists("settings.ini"))
                {
                    System.Windows.Forms.MessageBox.Show("The file settings.ini do not exist.", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                        if (string.IsNullOrEmpty(id))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        if (string.IsNullOrWhiteSpace(id))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else
                        {
                            MySqlCommand _command = new MySqlCommand();
                            _command.CommandText = "DELETE FROM shop_items WHERE Id=@id";
                            _command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                            _command.Connection = con;
                            _command.ExecuteNonQuery();
                            System.Windows.Forms.MessageBox.Show($"Sucessfully has been delete id = {id}", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            con.Close();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string LoadShopItemInfos(string shopitemid, string pricegroupid, string effectgroupid, string isenabled)
        {
            try
            {
                if (!File.Exists("settings.ini"))
                {
                    System.Windows.Forms.MessageBox.Show("The file settings.ini do not exist.", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                        //if (string.IsNullOrEmpty(id))
                        //{
                        //    System.Windows.Forms.MessageBox.Show("please check the information", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        //}
                        if (string.IsNullOrEmpty(shopitemid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(pricegroupid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(effectgroupid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(isenabled))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        //else if (string.IsNullOrWhiteSpace(id))
                        //{
                        //    System.Windows.Forms.MessageBox.Show("please check the information", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        //}
                        else if (string.IsNullOrWhiteSpace(shopitemid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(pricegroupid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(effectgroupid))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(isenabled))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else
                        {
                            MySqlCommand _command = new MySqlCommand();
                            _command.CommandText = "INSERT INTO shop_iteminfos (ShopItemId, PriceGroupId, EffectGroupId, IsEnabled) values (@shopitemid, @pricegroupid, @effectgroupid, @isenabled)";
                            //_command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                            _command.Parameters.AddWithValue("@shopitemid", shopitemid);
                            _command.Parameters.AddWithValue("@pricegroupid", pricegroupid);
                            _command.Parameters.AddWithValue("@effectgroupid", effectgroupid);
                            _command.Parameters.AddWithValue("@isenabled", isenabled);
                            _command.Connection = con;
                            _command.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                return shopitemid + pricegroupid + effectgroupid + isenabled;
            }
            catch (Exception ex)
            {
                return null;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public static string LoadShopItems(string id, string requiredgender, string colors, string isdestroyable, string maintab, string subtab)
        {
            try
            {
                if (!File.Exists("settings.ini"))
                {
                    System.Windows.Forms.MessageBox.Show("The file settings.ini do not exist.", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                        //if (string.IsNullOrEmpty(id))
                        //{
                        //    System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        //}
                        //else if (string.IsNullOrEmpty(id))
                        //{
                        //    System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        //}
                        if (string.IsNullOrEmpty(requiredgender))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(colors))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(isdestroyable))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(maintab))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrEmpty(subtab))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        //else if (string.IsNullOrWhiteSpace(id))
                        //{
                        //    System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        //}
                        else if (string.IsNullOrWhiteSpace(requiredgender))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(colors))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(isdestroyable))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(maintab))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else if (string.IsNullOrWhiteSpace(subtab))
                        {
                            System.Windows.Forms.MessageBox.Show("please check the information", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else
                        {
                            MySqlCommand _command = new MySqlCommand();
                            _command.CommandText = "INSERT INTO shop_items (Id, RequiredGender, Colors, IsDestroyable, MainTab, SubTab) values (@id, @requiredgender, @colors, @isdestroyable, @maintab, @subtab)";
                            _command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                            _command.Parameters.AddWithValue("@requiredgender", requiredgender);
                            _command.Parameters.AddWithValue("@colors", colors);
                            _command.Parameters.AddWithValue("@isdestroyable", isdestroyable);
                            _command.Parameters.AddWithValue("@maintab", maintab);
                            _command.Parameters.AddWithValue("@subtab", subtab);
                            _command.Connection = con;
                            _command.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Error", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                return id + requiredgender + colors + isdestroyable + maintab + subtab;
            }
            catch (Exception ex)
            {
                return null;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteAllShopItemInfos()
        {
            try
            {
                var ini = new IniFile();
                ini.Load("settings.ini");
                string _r = ini["ConnectionString"]["Source"].GetString();
                MySqlConnection con = new MySqlConnection($"{_r}");
                con.Open();

                MySqlCommand _command = new MySqlCommand();
                _command.CommandText = "DELETE FROM shop_iteminfos";
                _command.Connection = con;
                _command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show($"Sucessfully has been delete all", "Information: ShopItemInfos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteAllShopItems()
        {
            try
            {
                var ini = new IniFile();
                ini.Load("settings.ini");
                string _r = ini["ConnectionString"]["Source"].GetString();
                MySqlConnection con = new MySqlConnection($"{_r}");
                con.Open();

                MySqlCommand _command = new MySqlCommand();
                _command.CommandText = "DELETE FROM shop_items";
                _command.Connection = con;
                _command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show($"Sucessfully has been delete all", "Information: ShopItems", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
