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
    /// Interaction logic for AllergyWindow.xaml
    /// </summary>
    public partial class AllergyWindow : Window
    {
        IBL bl;
        public AllergyWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
        }

        private void Find_Click(object sender, RoutedEventArgs e)//find allergies and represent them
        {
            try
            {
                
                this.ListItem.Content = bl.all_allergies_in_nanny(int.Parse(this.id.Text));
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }
    }
}
