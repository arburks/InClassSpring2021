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

namespace WPF_JSON_Rick_and_Morty
{
    /// <summary>
    /// Interaction logic for Rick_and_Morty_Image_Window.xaml
    /// </summary>
    public partial class Rick_and_Morty_Image_Window : Window
    {
        public Rick_and_Morty_Image_Window()
        {
            InitializeComponent();
        }

        public void GetCharacterImage(Character selectedCharacter)
        {
            imgCharacter.Source = new BitmapImage(new Uri(selectedCharacter.image));
        }

        public void GetCharacterName(Character selectedCharacter)
        {
            txbCharacter.Text = selectedCharacter.name;
        }
    }
}
