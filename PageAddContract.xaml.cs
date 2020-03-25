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
    /// Interaction logic for PageAddContract.xaml
    /// </summary>
    public partial class PageAddContract : Page
    {
        IBL bl;
        Contract conToAdd;
        public PageAddContract()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            conToAdd = new Contract() { Start_Date=DateTime.Now,End_Date=DateTime.Now.AddYears(1)};

            this.is_Month_SalaryCheckBox.Checked += Is_Month_SalaryCheckBox_Checked;
            this.is_Month_SalaryCheckBox.Unchecked += Is_Month_SalaryCheckBox_Unchecked;

            this.DataContext = conToAdd;
            this.addButton.Click += AddButton_Click;

            this.child_IdComboBox.ItemsSource = bl.Get_All_Children();
            this.child_IdComboBox.DisplayMemberPath = "Id";
            this.child_IdComboBox.SelectedValuePath = "Id";

            this.nanny_IdComboBox.ItemsSource = bl.GetAll_Nanny();
            this.nanny_IdComboBox.DisplayMemberPath = "Id";
            this.nanny_IdComboBox.SelectedValuePath = "Id";

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Add_Contract(conToAdd);

                //note the user about details that were changed while adding
                MessageBox.Show("your contract number is: " + conToAdd.Num_Of_Contract + "  please keep it!" + "\n"
                + "salary after discount is: " + conToAdd.Month_Salary,"",MessageBoxButton.OK,MessageBoxImage.Exclamation);

                //refresh
                conToAdd = new Contract() { Start_Date = DateTime.Now, End_Date = DateTime.Now.AddYears(1) };
                this.DataContext = conToAdd;
                this.child_IdComboBox.SelectedItem = null;
                this.nanny_IdComboBox.SelectedItem = null;

            }
            catch (Exception error)
            {
                //refresh id for chosing
                this.child_IdComboBox.SelectedItem = null;
                this.nanny_IdComboBox.SelectedItem = null;
                //print
                MessageBox.Show(error.Message);
            }
        }

        private void Is_Month_SalaryCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.hour_SalaryTextBox.IsEnabled =true;
             
        }

        private void Is_Month_SalaryCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.hour_SalaryTextBox.IsEnabled = false;
        }

        private void link_Click(object sender, RoutedEventArgs e)
        {
            Window backLink = new LinkWindow();
            backLink.ShowDialog();
        }

        private void child_IdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.child_IdComboBox.SelectedItem is Child)
               this.conToAdd.Child_Id=(int)this.child_IdComboBox.SelectedValue;
        }

        private void nanny_IdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.nanny_IdComboBox.SelectedItem is Nanny)
                this.conToAdd.Nanny_Id = (int)this.nanny_IdComboBox.SelectedValue;
        }


    }
}
