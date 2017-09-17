using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FinancialControl.Repositories;

namespace FinancialControl
{
    public partial class NewReceipt : Window
    {
        public NewReceipt(ICategoriesRepository categoriesRepository)
        {
            InitializeComponent();
            CategoriesList.DataContext = categoriesRepository.Categores.Select(x => x.Title);
        }
        private List<Product> Products { get; set; }

        private void AddProduct_OnClick(object sender, RoutedEventArgs e)
        {
            var product = new Product();
            if (string.IsNullOrWhiteSpace(ProductName.Text))
            {
                MessageBox.Show("Product name cannot be empty");
                return;
            }
            if (!ProductPrice.Value.HasValue)
            {
                MessageBox.Show("Product price cannot be empty");
                return;
            }
            if (!ProductVolume.Value.HasValue)
            {
                MessageBox.Show("Product volume cannot be empty");
                return;
            }
            if (CategoriesList.SelectedItem == null)
            {
                MessageBox.Show("You must select a category");
                return;
            }

            product.Name = ProductName.Text;
            product.Price = (float)ProductPrice.Value;
            product.Category = (Category)CategoriesList.SelectedItem;
            product.Volume = (float)ProductVolume.Value;
            Products.Add(product);

        }
    }
}
