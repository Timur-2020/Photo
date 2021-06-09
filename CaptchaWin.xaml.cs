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
    /// Interaction logic for CaptchaWin.xaml
    /// </summary>
    public partial class CaptchaWin : Window
    {
        CapthaClass captha;
        public CaptchaWin()
        {
            InitializeComponent();
            //создаём и генерируем новую капчу
            captha = new CapthaClass();
            captha.Generate();
            Captha.Text = captha.Captha;
        }

        /// <summary>
        /// Обработка нажатия на кнопку Ok
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CapthaProv.Text == captha.Captha)//если капча совпадает с введенной
            {
                ServiceWin serviceWin = new ServiceWin();//открываем окно с услугами и закрываем это окно
                serviceWin.Show();
                this.Close();
            }
            else // иначе выводим ошибку и генерируем новую капчу
            {
                MessageBox.Show("Ошибка!");
                captha.Generate();
                Captha.Text = captha.Captha;
            }
        }
    }
}
