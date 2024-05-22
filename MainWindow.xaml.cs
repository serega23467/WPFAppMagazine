using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProductMagazine;

namespace WPFAppMagazine
{
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        List<ProductData> productsToBuy;
        bool hasProductByBarcode = false;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            productsToBuy = new List<ProductData>();
            UpdateWarehouseList();
            UpdateProductsToBuyList();
        }
        private void UpdateWarehouseList()
        {

            List<Product> products = db.Products.ToList();
            List<string> productsList = new List<string>();
            List<Warehouse> warehouse = db.Warehouse.ToList();
            foreach (Product product in products)
            {
                Warehouse warehouseLot = warehouse.FirstOrDefault(w => w.ProductId == product.Id);
                if (warehouseLot != null)
                {
                    productsList.Add(product.Name + " - " + warehouse.FirstOrDefault(w => w.ProductId == product.Id).ProductCount);
                }
            }
            listBoxStorage.ItemsSource = productsList;
        }
        private void UpdateProductsToBuyList()
        {
            dataGridProductsToBuy.ItemsSource = null;
            dataGridProductsToBuy.ItemsSource = productsToBuy;
            textBlockSum.Text = CashRegister.SumProducts(productsToBuy).ToString();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxBarCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            string barCode = textBoxBarCode.Text;
            int productId = 0;
            Product product = db.Products.FirstOrDefault(p => p.BarCode == barCode);
            if (product != null)
            {
                productId = product.Id;
                Warehouse warehouseLot = db.Warehouse.FirstOrDefault(w => w.ProductId == productId);
                if (warehouseLot != null)
                {
                    if (warehouseLot.ProductCount > 0)
                    {
                        if (productsToBuy.FirstOrDefault(p => p.Id == productId) != null)
                        {
                            textBlockHasProduct.Text = "this product has already been added";
                        }
                        else
                        {
                            hasProductByBarcode = true;
                            textBlockHasProduct.Text = "";
                        }
                    }
                    else
                    {
                        textBlockHasProduct.Text = "no products in warehouse";
                    }

                }
                else
                {
                    hasProductByBarcode = false;
                    textBlockHasProduct.Text = "no products with this barcode";
                }
            }
            else
            {
                hasProductByBarcode = false;
            }
            buttonAddByBarcode.IsEnabled = hasProductByBarcode;
        }
        private void buttonAddByBarcode_Click(object sender, RoutedEventArgs e)
        {
            string barCode = textBoxBarCode.Text;
            textBoxBarCode.Text = "";
            Product product = db.Products.FirstOrDefault(p => p.BarCode == barCode);
            if (product != null)
            {
                ProductData productData = new ProductData();
                productData.Id = product.Id;
                productData.Price = product.Price;
                productData.Discount = product.Discount;
                productData.HasDiscount = product.HasDiscount;
                productData.Name = product.Name;
                productData.BarCode = barCode;
                productData.Brand = product.Brand;
                productData.ExpirationDate = product.ExpirationDate;
                productData.Count = 1;
                productsToBuy.Add(productData);
                UpdateProductsToBuyList();
                Debugger.Log("product added to shopping list by barcode");
            }
        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductData product = ((FrameworkElement)sender).DataContext as ProductData;
            if (product != null)
            {
                if (db.Warehouse.FirstOrDefault(w => w.ProductId == product.Id).ProductCount >= productsToBuy.FirstOrDefault(p=>p.Id == product.Id).Count + 1)
                {
                    int h = db.Warehouse.FirstOrDefault(w => w.ProductId == product.Id).ProductCount;
                    int index = productsToBuy.FindIndex(p => p.Id == product.Id);
                    productsToBuy[index].Count++;
                    UpdateProductsToBuyList();
                    Debugger.Log("product added to shopping list");
                }
                else
                {
                    MessageBox.Show("No more products in warehouse");
                }
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            ProductData product = ((FrameworkElement)sender).DataContext as ProductData;
            if (product != null)
            {
                int index = productsToBuy.FindIndex(p => p.Id == product.Id);
                productsToBuy[index].Count--;
                if (productsToBuy[index].Count == 0)
                {
                    productsToBuy.Remove(product);
                }
                UpdateProductsToBuyList();
                Debugger.Log("product removed from shopping list");
            }
        }

        private void buttonCalculateDiscount_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Final discount: " + CashRegister.GetDiscountSum(productsToBuy).ToString() + " usd");
            Debugger.Log("discount calculated");
        }

        private void buttonPrintReceipt_Click(object sender, RoutedEventArgs e)
        {
            WindowReceipt windowReceipt = new WindowReceipt(productsToBuy);
            windowReceipt.ShowDialog();
            productsToBuy.Clear();
            UpdateProductsToBuyList();
            UpdateWarehouseList();
            Debugger.Log("receipt printed");
        }
    }
}