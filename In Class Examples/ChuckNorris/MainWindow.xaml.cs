using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Windows;

namespace ChuckNorris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // URLS
        // Random any category
        private string randomURL = "https://api.chucknorris.io/jokes/random";

        // Random given category
        private string randomFromCategoryURL = "https://api.chucknorris.io/jokes/random?category=";

        // List of Categories
        private string categoryURL = "https://api.chucknorris.io/jokes/categories";

        public MainWindow()
        {
            InitializeComponent();

            PopulateCategories();
        }

        private void PopulateCategories()
        {
            cbxCategory.Items.Add("All");
            cbxCategory.SelectedIndex = 0;

            string[] categories;

            using (var client = new HttpClient())
            {
                string category = client.GetStringAsync(categoryURL).Result;

                categories = JsonConvert.DeserializeObject<string[]>(category);
            }

            foreach (var item in categories.ToList())
            {
                string items = item[0].ToString().ToUpper() + item.Substring(1);
                cbxCategory.Items.Add(items);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (cbxCategory.SelectedIndex.Equals(0))
            {
                using (var client = new HttpClient())
                {
                    string category = client.GetStringAsync(randomURL).Result;

                    ChuckNorrisAPI api = JsonConvert.DeserializeObject<ChuckNorrisAPI>(category);

                    txtJoke.Text = $"\"{api.value} \"";
                }
            }
            else
            {
                string selectedCategory = cbxCategory.SelectedItem.ToString().ToLower();
                string newURL = $"{randomFromCategoryURL}{selectedCategory}";

                using (var client = new HttpClient())
                {
                    string category = client.GetStringAsync(newURL).Result;

                    ChuckNorrisAPI api = JsonConvert.DeserializeObject<ChuckNorrisAPI>(category);

                    txtJoke.Text = $"\"{api.value}\"";
                }
            }
        }
    }
}