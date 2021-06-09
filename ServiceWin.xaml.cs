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
    /// Interaction logic for ServiceWin.xaml
    /// </summary>
    public partial class ServiceWin : Window
    {
        List<Service> basket = new List<Service>(); // создаём корзину(список услуг)
        public ServiceWin()
        {
            InitializeComponent();
            ServList.ItemsSource = ContextDB.Context.Service.ToList(); //подгружаем данные о услугах из бд
        }

        /// <summary>
        /// Обработка нажатия на кнопку добавить
        /// </summary>
        private void AddClick(object sender, RoutedEventArgs e)
        {
            AddWin addWin = new AddWin();
            addWin.ShowDialog();//показываем окно добавления
            ServList.ItemsSource = ContextDB.Context.Service.ToList(); //обновляем данные в таблице
        }

        /// <summary>
        /// Обработка нажатия на кнопку Удалить
        /// </summary>
        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (ServList.SelectedItem == null)//если не выбрана запись в таблице
            {
                MessageBox.Show("Выберите запись в таблице");
                return;
            }

            Service serv = (Service)ServList.SelectedItem; //получаем выбранную запись
            ContextDB.Context.Service.Remove(serv);//удаляем запись из бд
            ContextDB.Context.SaveChanges();//сохраняем изменения
            ServList.ItemsSource = ContextDB.Context.Service.ToList(); //обновляем данные в таблице
        }

        /// <summary>
        /// Обработка нажатия на кнопку Обнавить
        /// </summary>
        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (ServList.SelectedItem == null)//как и в удалении проверяем выбрана ли запись
            {
                MessageBox.Show("Выберите запись в таблице");
                return;
            }

            Service serv = (Service)ServList.SelectedItem; //получаем выбранную запись
            EditWin editWin = new EditWin(serv); // создаём новое окно изменения и передаём ему запись 
            editWin.ShowDialog();
            ServList.ItemsSource = ContextDB.Context.Service.ToList(); //обновляем данные в таблице
        }

        /// <summary>
        /// Обработка нажатия на кнопку Добавить в корзину
        /// </summary>
        private void AddBasketClick(object sender, RoutedEventArgs e)
        {
            if (ServList.SelectedItem == null)//как и в удалении проверяем выбрана ли запись
            {
                MessageBox.Show("Выберите запись в таблице");
                return;
            }

            Service serv = (Service)ServList.SelectedItem; //получаем выбранную запись
            if (!basket.Contains(serv)) //если запись не содержится в корзине
            {
                basket.Add(serv); //добавляем в корзину 
            }
        }

        /// <summary>
        /// Обработка нажатия на кнопку Корзина
        /// </summary>
        private void OpenBasket(object sender, RoutedEventArgs e)
        {
            BasketWin basketWin = new BasketWin(basket);// создаём новое окно корзины и передаём ему записи 
            basketWin.ShowDialog();
            basket.Clear(); // очищаем корзину
        }
    }
}
