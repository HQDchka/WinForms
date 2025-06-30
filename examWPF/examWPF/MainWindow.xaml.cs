using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using examWPF;
using System.Windows.Controls;

namespace examWPF
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Хлеб", Price = 30.0m, Quantity = 10 },
                new Product { Name = "Молоко", Price = 60.0m, Quantity = 5 },
                new Product { Name = "Сыр", Price = 250.0m, Quantity = 2 }
            };
            DataContext = this;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            bool priceParsed = decimal.TryParse(PriceTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price);
            bool quantityParsed = int.TryParse(QuantityTextBox.Text, out int quantity);

            if (string.IsNullOrWhiteSpace(name) || !priceParsed || !quantityParsed)
            {
                MessageBox.Show("Введите корректные данные для всех полей.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Products.Add(new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity
            });

            NameTextBox.Text = "";
            PriceTextBox.Text = "";
            QuantityTextBox.Text = "";
        }

        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListView.SelectedItem is Product selectedProduct)
            {
                Products.Remove(selectedProduct);
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.", "Удаление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
