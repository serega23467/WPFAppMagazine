using System;
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
using System.Windows.Shapes;
using ProductMagazine;

namespace WPFAppMagazine
{
    /// <summary>
    /// Логика взаимодействия для WindowReceipt.xaml
    /// </summary>
    public partial class WindowReceipt : Window
    {
        ApplicationContext db;
        public WindowReceipt(List<ProductData> products)
        {
            InitializeComponent();
            db = new ApplicationContext();
            textBlockReceipt.Text = CashRegister.GenerateReceipt(products);
            foreach (ProductData product in products)
            {
                DateTime today = DateTime.Now;
                db.Warehouse.FirstOrDefault(p => p.ProductId == product.Id).ProductCount -= product.Count;
                if (product.Count > 1)
                {
                    for (int i = 0; i < product.Count; i++)
                    {
                        db.Receipts.Add(new Receipt() { DateR = $"{today.Year}-{today.Month}-{today.Day}-{today.Hour}-{today.Minute}", ProductId = product.Id, SumR = CashRegister.CalculateDiscountedPrice(product) });
                    }
                }
                else
                {
                    db.Receipts.Add(new Receipt() { DateR = $"{today.Year}-{today.Month}-{today.Day}-{today.Hour}-{today.Minute}", ProductId = product.Id, SumR = CashRegister.CalculateDiscountedPrice(product) });
                }
                db.SaveChanges();
            }

        }
    }
}
