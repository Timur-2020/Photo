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
    /// Interaction logic for BasketWin.xaml
    /// </summary>
    public partial class BasketWin : Window
    {
        List<Service> services;
        public BasketWin(List<Service> servs)
        {
            InitializeComponent();
            services = servs;
            ServList.ItemsSource = servs;//выодим добавленые услуги
        }

        /// <summary>
        /// Обработка нажатия на кнопку Добавить заказ
        /// </summary>
        private void AddOrederClick(object sender, RoutedEventArgs e)
        {
            int idClnt = 0;
            if (!int.TryParse(ClientId.Text, out idClnt))//если не получается перевести текст в int
            {
                MessageBox.Show("Неверный Формат id");//выводим ошибку
                return;
            }

            if(ContextDB.Context.Client.Where(a => a.idClient == idClnt).Count() == 0)//если нету клиента с таким id
            {
                MessageBox.Show("Неверный id");//выводим ошибку
                return;
            }

            Client clnt = ContextDB.Context.Client.Where(a => a.idClient == idClnt).FirstOrDefault(); //получаем клиента с указанным id

            Order ord = new Order()//создаём новый заказ
            {
                ordDate = DateTime.Now,
                idClient = clnt.idClient
            };

            foreach (var serv in services) //добавляем все указанные услуги в заказ
            {
                ord.Service.Add(serv);
            }
            
            ContextDB.Context.Order.Add(ord);//Добавляем заказ

            ContextDB.Context.SaveChanges();//сохраняем
        }
    }
}
