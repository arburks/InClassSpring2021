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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtName.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string birthday = dpTextbox.SelectedDate.Value.ToString;
            string age = DateTime.Today;
            DateTime birthdayDate = DateTime.TryParse(birthday, out birthdayDate);
        }
    }
}
