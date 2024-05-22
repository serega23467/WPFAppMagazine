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

namespace WPFAppMagazine
{
    /// <summary>
    /// Логика взаимодействия для WindowAcceptCancel.xaml
    /// </summary>
    public partial class WindowAcceptCancel : Window
    {
        private static int code = 123456;
        public WindowAcceptCancel()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            if(passwordBoxCode.Password == code.ToString())
            {
                MainWindow.trueCode = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong code!");
            }
        }
    }
}
