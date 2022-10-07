using SievePOS.ViewModels;
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
    }
}
