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
    /// Interaction logic for MatchWindow.xaml
    /// </summary>
    public partial class MatchWindow : Window
    {
        IBL bl;
        public MatchWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
        }

        private void FindMother_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(this.id.Text);
                //thread for calling to google maps in bl and show results on screen
                Thread t = new Thread(() =>
                {
                    try
                    {
                        var v = bl.best_match(id).ToList();
                        Action<IEnumerable<Nanny>> a = match;
                        Dispatcher.BeginInvoke(a, v);//show results on screen
                    }
                    catch (Exception error)
                    {
                        if (error is ApplicationException)//we identify the exception is bacause wrong id
                            MessageBox.Show(error.Message);
                        else //we identify the exception is bacause google maps
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

        private void match(IEnumerable<Nanny> v)// show results on screen
        {
            try
            {
                this.matchList1.ItemsSource = v;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
