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
using System.Windows.Shapes;

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            Window win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void button_regis_Click(object sender, RoutedEventArgs e)
        {
            bool number = false;
            if (txtlogin1.Text.Length > 0)
            {
                if (txtpassword1.Password.Length >= 0)
                {
                    if (txtpassword1.Password.Length >= 6)
                    {
                        for (int i = 0; txtpassword1.Password.Length > i; i++)
                        {
                            if (txtpassword1.Password[i] >= '0' && txtpassword1.Password[i] <= '9')
                                number = true;
                        }

                                if (number == true)
                                {
                            if (txtpassword1.Password == txtpassword2.Password)
                            {
                                string cp = "server=localhost;user=root;database=testdb;Sslmode=none";
                                MySqlConnection connectioin = new MySqlConnection(cp);
                                connectioin.Open();
                                MySqlCommand cmd = connectioin.CreateCommand();
                                cmd.CommandType = CommandType.Text;
                                string qeury = "insert into new(login,password,rol) values('"+txtlogin1.Text+"','"+txtpassword1.Password+"',1)";
                                MySqlCommand cmd1 = new MySqlCommand(qeury,connectioin);
                                cmd1.ExecuteNonQuery();


                                MessageBox.Show("Пользователь зареегестреаыфп2124");
                            }
                            else
                                MessageBox.Show("Пароли не совпадают");
                                }   
                            else
                                MessageBox.Show("В пароле должна быть хоть одна цифра");
                        
                    }
                    else
                        MessageBox.Show("Пароль должен иметь больше 6 символов");
                }
                else
                    MessageBox.Show("Введите пароль");
            }
            else
                MessageBox.Show("Введите логин");
        }
    }
}
