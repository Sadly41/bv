using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_vxod_Click(object sender, RoutedEventArgs e)
        {
            string cp = "server=localhost;user=root;database=testdb;Sslmode=none;";
            MySqlConnection connectioin = new MySqlConnection(cp);
            int i = 0;
            try
            {
                connectioin.Open();
                MySqlCommand cmd = connectioin.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from new where login='"+txtlogin.Text+"' and password='"+txtpassword.Password+"'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                cmd.CommandText = "select rol from new where login='" + txtlogin.Text + "' and password='" + txtpassword.Password + "'";
                string name = cmd.ExecuteScalar().ToString();

                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i==0)
                {
                    MessageBox.Show("не то значение");
                }
                else
                {
                    switch(name)
                    {
                        case "1":
                            MessageBox.Show("okey1");
                            Window win1 = new Window1();
                            win1.Show();
                            this.Close();
                            break;
                        case "2":
                            MessageBox.Show("okey2");
                            break;
                    }
                }


            }
            catch(Exception)
            {
                MessageBox.Show("error");
            }
            finally
            {
                connectioin.Close();
            }
        }

        private void button_regis_Click(object sender, RoutedEventArgs e)
        {
            Window win2 = new Window2();
            win2.Show();
            this.Close();
        }
    }
}
