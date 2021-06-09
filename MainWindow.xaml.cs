using System;
using System.Collections.Generic;
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

namespace Photo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработка нажатия на кнопку входа
        /// </summary>
        private void LoginButton(object sender, RoutedEventArgs e)
        {
            //получаем логин и пароль из текст боксов
            string login = Login.Text;
            string pas = Password.Password;

            //проверяем логин и пароль в бд
            if(ContextDB.Context.Employee.Where(a => a.empLogin == login).Count() == 0) // если нету записей с таким логином
            {
                MessageBox.Show("Неверный логин"); 
                return;
            }

            if (ContextDB.Context.Employee.Where(a => a.empLogin == login).FirstOrDefault().empPassword != pas) // если пароль не совпадает
            {
                MessageBox.Show("Неверный пароль");
                return;
            }

            new CaptchaWin().Show(); //показываем окно с капчей
            this.Close(); //закрываем это окно
        }
    }
}
