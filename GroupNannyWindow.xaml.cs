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
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GroupNannyWindow.xaml
    /// </summary>
    public partial class GroupNannyWindow : Window
    {
        IBL bl;
        public GroupNannyWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();

        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.age.SelectedItem==this.min)
                {
                    this.listViewGroups.ItemsSource = bl.nannies_by_children_age(false, true);
                    return;
                }
                if (this.age.SelectedItem == this.max)
                {
                    this.listViewGroups.ItemsSource = bl.nannies_by_children_age(true, true);
                    return;
                }

            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }

        }
    }
}
