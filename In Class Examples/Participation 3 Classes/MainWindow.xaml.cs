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

namespace Participation_3_Classes
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
            bool isFirstNameValid, isLastNameValid, isMajorValid, isGPAValid, isStreetNumberValid, isStreetNameValid, isCityValid, isStateValid, isZipCodeValid = true;
            //First Name
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("That is not a valid first name, please try again!");
                txtFirstName.Clear();
                txtFirstName.Background = Brushes.IndianRed;
                isFirstNameValid = false;
            }
            else
            {
                txtFirstName.Background = Brushes.White;
                isFirstNameValid = true;
            }
            //Last Name
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("That is not a valid last name, please try again!");
                txtLastName.Clear();
                txtLastName.Background = Brushes.IndianRed;
                isLastNameValid = false;
            }
            else
            {
                txtLastName.Background = Brushes.White;
                isLastNameValid = true;
            }
            //Major
            if (string.IsNullOrWhiteSpace(txtMajor.Text))
            {
                MessageBox.Show("That is not a valid major, please try again!");
                txtMajor.Clear();
                txtMajor.Background = Brushes.IndianRed;
                isMajorValid = false;
            }
            else
            {
                txtMajor.Background = Brushes.White;
                isMajorValid = true;
            }
            //GPA
            double gpa;
            if (double.TryParse(txtGPA.Text, out gpa) == false)
            {
                MessageBox.Show("That is not a valid GPA, please try again!");
                txtGPA.Clear();
                txtGPA.Background = Brushes.IndianRed;
                isGPAValid = false;
            }
            else
            {
                txtGPA.Background = Brushes.White;
                isGPAValid = true;
            }
            //Street Number
            int validStreetNumber;
            if (int.TryParse(txtStreetNumber.Text, out validStreetNumber) == false)
            {
                MessageBox.Show("That is not a valid street number, please try again!");
                txtStreetNumber.Clear();
                txtStreetNumber.Background = Brushes.IndianRed;
                isStreetNumberValid = false;
            }
            else
            {
                txtStreetNumber.Background = Brushes.White;
                isStreetNumberValid = true;
            }
            //Street Name
            if (string.IsNullOrWhiteSpace(txtStreetName.Text))
            {
                MessageBox.Show("That is not a valid street name, please try again!");
                txtStreetName.Clear();
                txtStreetName.Background = Brushes.IndianRed;
                isStreetNameValid = false;
            }
            else
            {
                txtStreetName.Background = Brushes.White;
                isStreetNameValid = true;
            }
            //City
            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("That is not a valid city, please try again!");
                txtCity.Clear();
                txtCity.Background = Brushes.IndianRed;
                isCityValid = false;
            }
            else
            {
                txtCity.Background = Brushes.White;
                isCityValid = true;
            }
            //State
            if (string.IsNullOrWhiteSpace(txtState.Text))
            {
                MessageBox.Show("That is not a valid state, please try again!");
                txtState.Clear();
                txtState.Background = Brushes.IndianRed;
                isStateValid = false;
            }
            else
            {
                txtState.Background = Brushes.White;
                isStateValid = true;
            }
            //Zip Code
            int validZip;
            if (int.TryParse(txtZipCode.Text, out validZip) == false)
            {
                MessageBox.Show("That is not a valid Zip Code, please try again!");
                txtZipCode.Clear();
                txtZipCode.Background = Brushes.IndianRed;
                isZipCodeValid = false;
            }
            else
            {
                txtZipCode.Background = Brushes.White;
                isZipCodeValid = true;
            }

            if (isFirstNameValid == true && isLastNameValid == true && isMajorValid == true && isGPAValid == true && isStreetNumberValid == true && isStreetNameValid == true && isCityValid == true && isStateValid == true && isZipCodeValid == true)
            {
                Student student = new Student()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    GPA = gpa,
                    Major = txtMajor.Text
                };
                student.setAddress(validStreetNumber, txtStreetName.Text, txtState.Text, txtCity.Text, validZip);

                listHandout.Items.Add(student);
                ClearTxtBoxes();
            }
            else
            {
                return;
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            listHandout.Items.Remove(listHandout.SelectedItem);
        }

        private void ClearTxtBoxes()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtGPA.Clear();
            txtMajor.Clear();
            txtStreetNumber.Clear();
            txtStreetName.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtZipCode.Clear();
        }

        private void listHandout_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Student stu = listHandout.SelectedItem as Student;
            //Student Info
            string firstname = stu.FirstName;
            string lastname = stu.LastName;
            //Address Info
            int streetnumber = stu.address.StreetNumber;
            string streetname = stu.address.StreetName;
            string city = stu.address.City;
            string state = stu.address.State;
            int zip = stu.address.ZipCode;

            //New Window Methods
            StudentAddressDisplayWindow newStudentWindow = new StudentAddressDisplayWindow();
            newStudentWindow.GetAddress(streetnumber, streetname, state, city, zip);
            newStudentWindow.GetStudentName(firstname, lastname);
            newStudentWindow.ShowDialog();
        }
    }
}
