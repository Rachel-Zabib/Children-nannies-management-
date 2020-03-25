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
    /// Interaction logic for BirthdayWindow.xaml
    /// </summary>
    public partial class BirthdayWindow : Window
    {
        IBL bl;
        public BirthdayWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (bl.Get_Nanny(int.Parse(this.id.Text)) ==null)
                    throw new Exception("this nanny doesnt exist");
                this.ListItem.Content = bl.birthdays_in_nanny(int.Parse(this.id.Text));
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
          
           
        }

       
    }
}
