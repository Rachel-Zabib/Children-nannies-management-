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
    /// Interaction logic for PhonebookWindow.xaml
    /// </summary>
    public partial class PhonebookWindow : Window
    {
        IBL bl;
        public PhonebookWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
        }

       

        private void FindMother_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (bl.Get_Child(int.Parse(this.idChild.Text)) == null)
                    throw new Exception("this child doesnt exist");
                this.ListItem1.Content = bl.phonebook_for_mother(int.Parse(this.idChild.Text));
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }

        private void FindNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (bl.Get_Nanny(int.Parse(this.idNanny.Text)) ==null)
                    throw new Exception("this nanny doesnt exist");
                this.ListItem2.Content = bl.phonebook_for_nanny(int.Parse(this.idNanny.Text));
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }
    }
}
