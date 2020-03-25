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
    /// Interaction logic for ViewsWindow.xaml
    /// </summary>
    public partial class ViewsWindow : Window
    {
        IBL bl;
        public ViewsWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
        }

        private void FindNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.parameter.SelectedItem == this.all)
                {
                    if (bl.GetAll_Nanny().Count() == 0)
                        throw new Exception("we dont have any nanny");
                    this.ListNanny.ItemsSource = bl.GetAll_Nanny();
                    return;
                }
                if (this.parameter.SelectedItem == this.name)
                {
                    if (bl.GetAll_Nanny(nan => nan.First_Name == this.value.Text).Count() == 0)
                        throw new Exception("this nanny doesnt exist");
                    this.ListNanny.ItemsSource = bl.GetAll_Nanny(nan => nan.First_Name == this.value.Text);
                    return;
                }
                if (this.parameter.SelectedItem == this.city)
                {
                    if (bl.GetAll_Nanny(nan => nan.City == this.value.Text).Count() == 0)
                        throw new Exception("we dont have nannies in this city");
                    this.ListNanny.ItemsSource = bl.GetAll_Nanny(nan => nan.City == this.value.Text);
                    return;
                }
                if (this.parameter.SelectedItem == this.monthSalary)
                {
                    if (bl.GetAll_Nanny(nan => nan.Month_Salary <= float.Parse(this.value.Text)).Count() == 0)
                        throw new Exception("we dont have nannies that takes less or equal to this salary");
                    this.ListNanny.ItemsSource = bl.GetAll_Nanny(nan => nan.Month_Salary <= float.Parse(this.value.Text));
                    return;
                }
                if (this.parameter.SelectedItem == this.hourSalary)
                {
                    if (bl.GetAll_Nanny(nan => nan.Hour_Salary <= float.Parse(this.value.Text) && nan.Hour_Salary != 0).Count() == 0)
                        throw new Exception("we dont have nannies that takes less or equal to this salary");

                    this.ListNanny.ItemsSource = bl.GetAll_Nanny(nan => nan.Hour_Salary <= float.Parse(this.value.Text) && nan.Hour_Salary != 0);//she enables by hour and takes the sum mom wants
                    return;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void FindMom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.parameter2.SelectedItem == this.allmom)
                {
                    if (bl.GetAll_Mother().Count() == 0)
                        throw new Exception("we dont have any mothers");
                    this.ListMom.ItemsSource = bl.GetAll_Mother();
                    return;
                }
                if (this.parameter2.SelectedItem == this.namemom)
                {
                    if (bl.GetAll_Mother(mom => mom.Family_Name == this.value2.Text).Count() == 0)
                        throw new Exception("there isnt mom with this name");
                    this.ListMom.ItemsSource = bl.GetAll_Mother(mom => mom.Family_Name == this.value2.Text);
                    return;
                }
                

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void FindCh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.parameter3.SelectedItem == this.allch)
                {
                    if (bl.Get_All_Children().Count()==0)
                        throw new Exception("we dont have any children");
                    this.ListChild.ItemsSource = bl.Get_All_Children();
                    return;
                }
                if (this.parameter3.SelectedItem == this.momid)
                {
                    if (bl.Get_All_Children(ch => ch.Mother_Id == int.Parse(this.value3.Text)).Count()==0)
                        throw new Exception("there isnt child of this mom");
                    this.ListChild.ItemsSource = bl.Get_All_Children(ch => ch.Mother_Id == int.Parse(this.value3.Text));
                    return;
                }
                if (this.parameter3.SelectedItem == this.special)
                {
                    if (bl.Get_All_Children(ch => ch.Is_Special_Needs == true).Count()==0)
                        throw new Exception("there isnt special children");
                    this.ListChild.ItemsSource = bl.Get_All_Children(ch => ch.Is_Special_Needs== true);
                    return;
                }
                if (this.parameter3.SelectedItem == this.without)
                {
                    if (bl.children_without_nanny().Count() == 0)
                        throw new Exception("all children have nannies");
                    this.ListChild.ItemsSource = bl.children_without_nanny();
                    return;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Findcon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.parameter4.SelectedItem == this.allcon)
                {
                    if (bl.GetAll_Contract().Count()==0)
                        throw new Exception("we dont have any conctracts");
                    this.ListContract.ItemsSource = bl.GetAll_Contract();
                    return;
                }
                if (this.parameter4.SelectedItem == this.nanid)
                {
                    if (bl.GetAll_Contract(con => con.Nanny_Id == int.Parse(this.value4.Text)).Count()==0)
                        throw new Exception("this nanny doesnt have contracts");
                    this.ListContract.ItemsSource = bl.GetAll_Contract(con => con.Nanny_Id == int.Parse(this.value4.Text));
                    return;
                }
                if (this.parameter4.SelectedItem == this.valid)
                {
                    if (bl.GetAll_Contract(con => con.End_Date > DateTime.Now.Date).Count()==0)
                        throw new Exception("there are not valid contracts");
                    this.ListContract.ItemsSource = bl.GetAll_Contract(con => con.End_Date>DateTime.Now.Date);
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
