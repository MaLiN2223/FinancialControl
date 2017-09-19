using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using FinancialControl.Repositories;
using FinancialControl.Repositories.Dto;

namespace FinancialControl
{
    public partial class NewReceiptWindow : Window
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IReceiptsRepository _receiptsRepository;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public NewReceiptWindow(ICategoriesRepository categoriesRepository, IReceiptsRepository receiptsRepository)
        {
            _categoriesRepository = categoriesRepository;
            _receiptsRepository = receiptsRepository;
            InitializeComponent();
            Categories = _categoriesRepository.Categores.Select(x => x).ToList();
            CategoriesList.ItemsSource = Categories;
            DataGrid.DataContext = Products;

        }

        private ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        private Receipt Receipt { get; set; } = new Receipt();
        public List<Category> Categories { get; set; }
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

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Receipt.Products = Products.ToList();
                _receiptsRepository.AddReceipt(Receipt);
            }
            catch (Exception ex)
            {
                log.Error("Something went wrong while saving receipt", ex);
                return;
            }
            MessageBox.Show("Success");
            Close();
        }


    }
}
