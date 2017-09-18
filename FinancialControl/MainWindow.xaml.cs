﻿using System;
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
using FinancialControl.Repositories;
using RestSharp;

namespace FinancialControl
{
    public interface IMainWindow
    {
        void Show();
    }
    public partial class MainWindow : Window, IMainWindow
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public MainWindow()
        {
#if DEBUG
            var restClient = new RestClient("http://localhost:53809");
#else
            var restClient = new RestClient(apiUrl);
#endif
            _categoriesRepository =
                new CategoriesRepository(new DataAccess(new RestHelper(restClient)), new PathRepository());
            var data = _categoriesRepository.Categores;
            InitializeComponent();
        }

        private void AddNewReceiptClick(object sender, RoutedEventArgs e)
        {
            var window = new NewReceipt(_categoriesRepository);
            window.ShowDialog();
        }

        private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
