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
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for PageRemoveContract.xaml
    /// </summary>
    public partial class PageRemoveContract : Page
    {
        IBL bl;
        public PageRemoveContract()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            this.removeButton.Click += RemoveButton_Click;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Remove_Contract(int.Parse(this.removeId.Text));
                MessageBox.Show("contract was deleteded succesfully :)", "", MessageBoxButton.OK, MessageBoxImage.Information);
                this.removeId.Text = "";
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }
    }
}
