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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for RecomndWindow.xaml
    /// </summary>
    public partial class RecomndWindow : Window
    {
        IBL bl;
        public RecomndWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
        }

        private void Find_Click(object sender, RoutedEventArgs e)//find mothers in nanny and give their phones for recommendations
        {
            try
            {
                if (bl.phones_for_recommendations(this.firstName.Text, this.lastName.Text).Length==0)
                    throw new Exception("this nanny doesnt exist");
                this.ListItem.Content = bl.phones_for_recommendations(this.firstName.Text,this.lastName.Text);
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }
    }
}
