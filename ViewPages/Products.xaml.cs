using SievePOS.ViewModels;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace SievePOS.ViewPages
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public Products()
        {
            this.DataContext = new ProductsViewModel();
            InitializeComponent();
        }

        private void NumberOnly_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
