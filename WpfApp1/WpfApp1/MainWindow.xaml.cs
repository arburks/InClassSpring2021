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

            TimeSpan birthday = DateTime.Now - Convert.ToDateTime(dpEnteredDate.SelectedDate);
            int age = Convert.ToInt32(birthday.Days) / 365;
            string name = txtName.Text;
            MessageBox.Show($"{name} is {age} years old!! \n" +
                $"\n My parents didn't want to move to Florida," +
                $"\n but they turned 60 and that's the law. —Jerry Seinfeld", "Age", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }

        private void btnCalculate_MouseEnter(object sender, MouseEventArgs e)
        {
            wndMain.Background = Brushes.DarkTurquoise;
        }

        private void btnCalculate_MouseLeave(object sender, MouseEventArgs e)
        {
            wndMain.Background = new ImageBrush(new BitmapImage(new Uri("https://aic.azureedge.net/pgl-release/Images/ArticleImages/19/19156.jpg")));
        }
    }
}
