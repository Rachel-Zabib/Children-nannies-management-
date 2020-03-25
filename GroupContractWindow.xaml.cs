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
using BE;
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GroupContractWindow.xaml
    /// </summary>
    public partial class GroupContractWindow : Window
    {
        IBL bl;
        public GroupContractWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //thread for calling to google maps in bl and show results on screen
                Thread t = new Thread(() =>
                {
                    try
                    {
                        var v = bl.contracts_by_km(true).ToList();
                        Action<IEnumerable<IGrouping<int, Contract>>> a = find;
                        Dispatcher.BeginInvoke(a, v);//show results on screen
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("problem in connection to internet or in adresses please correct and try again", "wrong address", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                });
                t.Start();
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
           
        }

        private void find(IEnumerable<IGrouping<int,Contract>> v)//show results on screen
        {
            try
            {
                this.listViewGroups.ItemsSource = v;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }
    }
}
