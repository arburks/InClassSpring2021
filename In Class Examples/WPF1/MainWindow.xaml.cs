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

namespace WPF1
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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string zip = txtZip.Text;
            int validZip;
            if (int.TryParse(zip, out validZip) == false)
            {
                string tryAgain = "That is not a valid Zip Code, please try again!";
                MessageBox.Show(tryAgain);
                txtZip.Clear();
            }
            else
            {
                EntryForm entryForm = new EntryForm(txtName.Text, txtAddress.Text, validZip);
                //Convert.ToInt32(txtZip.Text)
                lstApplications.Items.Add(entryForm);
                ClearTxtBoxes();
            }
        }

        private void ClearTxtBoxes()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtZip.Clear();
        }
    }
}