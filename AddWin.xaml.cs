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
using System.Windows.Shapes;

namespace Photo
{
    /// <summary>
    /// Interaction logic for AddWin.xaml
    /// </summary>
    public partial class AddWin : Window
    {
        public AddWin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработка нажатия на кнопку Сохранить
        /// </summary>
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            string name = NameTB.Text;//получаем имя и описание из текст боксов
            string desc = Desc.Text;
            decimal price = 0; 

            if(!decimal.TryParse(Price.Text, out price))//если не получается перевести текст в decimal
            {
                MessageBox.Show("Неверная цена");//выводим ошибку
                return;
            }

            var serv = new Service()//создаём новую услугу
            {
                servName = name,
                servDescription = desc,
                servPrice = price
            };

            ContextDB.Context.Service.Add(serv); //добавляем услугу и сохраняем
            ContextDB.Context.SaveChanges();

            this.Close(); //закрываем это окно
        }
    }
}
