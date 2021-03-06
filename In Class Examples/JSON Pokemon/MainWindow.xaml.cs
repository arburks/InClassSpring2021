using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace JSON_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int btn = 0;

        public MainWindow()
        {
            InitializeComponent();

            lblHeightStat.Content = String.Empty;
            lblWeightStat.Content = String.Empty;

            AllPokemonAPI api;
            string url = "https://pokeapi.co/api/v2/pokemon?limit=1200";

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;

                api = JsonConvert.DeserializeObject<AllPokemonAPI>(json);
            }

            foreach (var item in api.results.OrderBy(x => x.name).ToList())
            {
                lstPokemon.Items.Add(item);
            }
        }

        private void lstPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResultsObject api = (ResultsObject)lstPokemon.SelectedItem;
            string name = api.name.ToUpper();
            lblName.Content = name;
            string url = api.url;
            PokemonStats stats;

            using (var client = new HttpClient())
            {
                string pokemon = client.GetStringAsync(url).Result;

                stats = JsonConvert.DeserializeObject<PokemonStats>(pokemon);
            }

            lblHeightStat.Content = stats.height;
            lblWeightStat.Content = stats.weight;
            imgSprite.Source = new BitmapImage(new Uri(stats.sprites.front_default));
            btn = 0;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            ResultsObject api = (ResultsObject)lstPokemon.SelectedItem;
            string name = api.name.ToUpper();
            string url = api.url;
            PokemonStats stats;

            using (var client = new HttpClient())
            {
                string pokemon = client.GetStringAsync(url).Result;

                stats = JsonConvert.DeserializeObject<PokemonStats>(pokemon);
            }

            string front_default = stats.sprites.front_default;
            string back_default = stats.sprites.back_default;

            if (btn == 0)
            {
                if (string.IsNullOrEmpty(back_default))
                {
                    btn = 1;
                    MessageBox.Show($"Sorry {name} does not have a back image. Please select another Pokemon!", "Error: Back Image is Missing");
                }
                else
                {
                    imgSprite.Source = new BitmapImage(new Uri(back_default));
                    btn = 1;
                }
            }
            else if (btn == 1)
            {
                imgSprite.Source = new BitmapImage(new Uri(front_default));
                btn = 0;
            }
        }
    }
}