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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for LinkWindow.xaml
    /// </summary>
    public partial class LinkWindow : Window
    {
        public LinkWindow()
        {
            InitializeComponent();
        }

        private void views_Click(object sender, RoutedEventArgs e)
        {
            Window views = new ViewsWindow();
            views.ShowDialog();
        }

        private void match_Click(object sender, RoutedEventArgs e)
        {
            Window match = new MatchWindow();
           match.ShowDialog();
        }

        private void groupingNanny_Click(object sender, RoutedEventArgs e)
        {
            Window groupNanny = new GroupNannyWindow();
            groupNanny.ShowDialog();
        }

        private void groupingContract_Click(object sender, RoutedEventArgs e)
        {
            Window groupContract = new GroupContractWindow();
            groupContract.ShowDialog();
        }

        private void phoneBook_Click(object sender, RoutedEventArgs e)
        {
            Window phonebook = new PhonebookWindow();
            phonebook.ShowDialog();
        }

        private void Recommendations_Click(object sender, RoutedEventArgs e)
        {
            Window recomnd = new RecomndWindow();
            recomnd.ShowDialog();
        }

        private void birthday_Click(object sender, RoutedEventArgs e)
        {
            Window birthday = new BirthdayWindow();
            birthday.ShowDialog();
        }

        private void allergies_Click(object sender, RoutedEventArgs e)
        {
            Window allergies= new AllergyWindow();
            allergies.ShowDialog();
        }
    }
}
