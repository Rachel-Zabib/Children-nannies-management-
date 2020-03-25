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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for PageAddChild.xaml
    /// </summary>
    public partial class PageAddChild : Page
    {
        IBL bl;
        Child childToAdd;
        public PageAddChild()
        {
            InitializeComponent();
            //this.birth_DateDatePicker= DateTime.Now;
            bl = FactoryBL.GetBL();
            childToAdd = new Child() {Birth_Date=DateTime.Now};
            this.DataContext = childToAdd;
            this.addButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //add
                bl.Add_Child(childToAdd);
                MessageBox.Show("child was added succesfully :)", "", MessageBoxButton.OK, MessageBoxImage.Information);
                //refresh
                childToAdd = new Child() { Birth_Date = DateTime.Now };
                this.DataContext = childToAdd;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Page_Error(object sender, ValidationErrorEventArgs e)
        {
            bool flag = true;
            if (e.Action == ValidationErrorEventAction.Added)
                flag = false;
            else
                flag = true;

            this.addButton.IsEnabled = flag;
        }

       
    }
}
