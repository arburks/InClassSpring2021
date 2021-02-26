using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Participation_3_Classes
{
    /// <summary>
    /// Interaction logic for StudentAddressDisplayWindow.xaml
    /// </summary>
    public partial class StudentAddressDisplayWindow : Window
    {
        public StudentAddressDisplayWindow()
        {
            InitializeComponent();
        }

        public void GetAddress(int streetnumber, string streetname, string state, string city, int zipcode)
        {
            Address addressDisplay = new Address();
            addressDisplay.StreetNumber = streetnumber;
            addressDisplay.StreetName = streetname;
            addressDisplay.State = state;
            addressDisplay.City = city;
            addressDisplay.ZipCode = zipcode;


            try {
                StringBuilder queryAddress = new StringBuilder();
                queryAddress.Append("http://maps.google.com/maps?q=");
                queryAddress.Append(addressDisplay.StreetNumber + "," + "+");
                queryAddress.Append(addressDisplay.StreetName + "," + "+");
                queryAddress.Append(addressDisplay.City + "," + "+");
                queryAddress.Append(addressDisplay.State + "," + "+");
                queryAddress.Append(addressDisplay.ZipCode);

                webMap.Navigate(queryAddress.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

            lblStreetNumber.Content = addressDisplay.StreetNumber;
            lblStreetName.Content = addressDisplay.StreetName;
            lblCity.Content = addressDisplay.City;
            lblState.Content = addressDisplay.State;
            lblZipCode.Content = addressDisplay.ZipCode;

        }

        public void GetStudentName(string firstname, string lastname)
        {

            lblFirstName.Content = firstname;
            lblLastName.Content = lastname;
        }
    }
}
