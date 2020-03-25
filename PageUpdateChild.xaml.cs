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
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for PageUpdateChild.xaml
    /// </summary>
    public partial class PageUpdateChild : Page
    {
        IBL bl;
        Child childToUpdate;

        public PageUpdateChild()
        {
            InitializeComponent();
            childToUpdate=new Child();
            bl = FactoryBL.GetBL();

            this.idComboBox.ItemsSource = bl.Get_All_Children();
            this.idComboBox.DisplayMemberPath = "Id";
            this.idComboBox.SelectedValuePath = "Id";
          
        }

        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.idComboBox.SelectedItem is Child)
            {
                childToUpdate = ((Child)this.idComboBox.SelectedItem).DeepClone();
                this.DataContext = childToUpdate;
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Update_Child(childToUpdate);
                MessageBox.Show("child was changed succesfully :)", "", MessageBoxButton.OK, MessageBoxImage.Information);
                childToUpdate = new Child();
                this.DataContext = null;
                this.idComboBox.ItemsSource = null;
                this.idComboBox.ItemsSource = bl.Get_All_Children();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
