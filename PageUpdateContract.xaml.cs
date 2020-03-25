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
    /// Interaction logic for PageUpdateContract.xaml
    /// </summary>
    public partial class PageUpdateContract : Page
    {
        IBL bl;
        Contract contractToUpdate;
        double previousMonthSalary;
        double previousHourSalary;


        public PageUpdateContract()
        {
            InitializeComponent();
            contractToUpdate = new Contract();
            bl = FactoryBL.GetBL();

            //without binding cause it is enabled just when it is not checked..in opposite of regular binding
            this.is_Month_SalaryCheckBox.Checked += Is_Month_SalaryCheckBox_Checked;
            this.is_Month_SalaryCheckBox.Unchecked += Is_Month_SalaryCheckBox_Unchecked;

            this.contract_counter_ComboBox.ItemsSource = bl.GetAll_Contract();
            this.contract_counter_ComboBox.DisplayMemberPath = "Num_Of_Contract";
            this.contract_counter_ComboBox.SelectedValuePath = "Num_Of_Contract";
        }

       

        private void contract_counter_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.contract_counter_ComboBox.SelectedItem is Contract)
            {
                contractToUpdate = ((Contract)this.contract_counter_ComboBox.SelectedItem).DeepClone();

                previousMonthSalary = contractToUpdate.Month_Salary;//save previous cause if she will change it we have to calcul again the discount
                previousHourSalary = contractToUpdate.Hour_Salary;//save previous cause if she will change it we have to calcul again the discount

                this.DataContext = contractToUpdate;
            }
            
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
             
                //if salary was changed we calculate again final salary after discount
                if (this.is_Month_SalaryCheckBox.IsChecked==true&&previousMonthSalary != contractToUpdate.Month_Salary)
                {
                    bl.Calculate_Salary(contractToUpdate, bl.Get_Nanny(contractToUpdate.Nanny_Id), bl.Get_Child(contractToUpdate.Child_Id));
                    bl.Update_Contract(contractToUpdate);
                    MessageBox.Show("your final salary is: " + contractToUpdate.Month_Salary,"",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                }
                else if(this.is_Month_SalaryCheckBox.IsChecked == false&&previousHourSalary!=contractToUpdate.Hour_Salary)
                {
                    bl.Calculate_Salary(contractToUpdate, bl.Get_Nanny(contractToUpdate.Nanny_Id), bl.Get_Child(contractToUpdate.Child_Id));
                    bl.Update_Contract(contractToUpdate);
                    MessageBox.Show("your final salary is: " + contractToUpdate.Month_Salary, "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else//same salary as before
                {
                    bl.Update_Contract(contractToUpdate);
                    MessageBox.Show("contract was changed succesfully :)", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
               
                
                this.DataContext = null;
                this.contractToUpdate = new Contract();
                this.contract_counter_ComboBox.ItemsSource = null;
                this.contract_counter_ComboBox.ItemsSource = bl.GetAll_Contract();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Is_Month_SalaryCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.hour_SalaryTextBox.IsEnabled = true;

        }

        private void Is_Month_SalaryCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.hour_SalaryTextBox.IsEnabled = false;
        }

    }
}
