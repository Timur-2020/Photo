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
    /// Interaction logic for EditWin.xaml
    /// </summary>
    public partial class EditWin : Window
    {
        Service serv;
        public EditWin(Service service)
        {
            InitializeComponent();
            serv = service;
            //выводим данные о записи в текст боксы
            NameTB.Text = serv.servName;
            Desc.Text = serv.servDescription;
            Price.Text = serv.servPrice.ToString();
        }

        /// <summary>
        /// Обработка нажатия на кнопку Сохранить
        /// </summary>
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            string name = NameTB.Text;//получаем имя и описание из текст боксов
            string desc = Desc.Text;
            decimal price = 0;

            if (!decimal.TryParse(Price.Text, out price))//если не получается перевести текст в decimal
            {
                MessageBox.Show("Неверная цена(Должна быть через запятую)");//выводим ошибку
                return;
            }

            //меняем данные
            serv.servName = name;
            serv.servDescription = desc;
            serv.servPrice = price;

            ContextDB.Context.SaveChanges();//сохраняем

            this.Close(); //закрываем это окно
        }
    }
}
