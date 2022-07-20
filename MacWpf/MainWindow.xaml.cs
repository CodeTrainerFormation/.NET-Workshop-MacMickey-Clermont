using BusinessLayer;
using DomainModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MacWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ProductOrder order = new ProductOrder();

            order.OrderDelegate += message => MessageBox.Show(message);

            Product p = new Product()
            {
                Name = "Big Mick'",
                Description = "Le seul, l'unique Big Mick' de chez Mac Mickey ! Ses deux steaks hachés, son cheddar fondu, ses oignons, ses cornichons, son lit de salade et sa sauce inimitable, font du Big Mick' un sandwich culte et indémodable.",
                Price = 4.00M,
                Stockpiled = 50,
            };
            order.AddProduct(p);
        }
    }
}
