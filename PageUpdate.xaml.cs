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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for PageUpdate.xaml
    /// </summary>
    public partial class PageUpdate : Page
    {
        IBL bl;
        Mother momToUpdate;
        public PageUpdate()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            momToUpdate = new Mother();//prepare place in memory..

            this.idComboBox.ItemsSource = bl.GetAll_Mother();
            this.idComboBox.DisplayMemberPath = "Id";//show mother jusy by id
            this.idComboBox.SelectedValuePath = "Id";//connection background is really by id
        }

        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //we select mom but doesnt want to change imidietly in list so first we copy to another update there and put her now in list
            if(this.idComboBox.SelectedItem is Mother)
            {
                this.momToUpdate = ((Mother)this.idComboBox.SelectedItem).DeepClone();//extention method for each T that makes deep copy by place in memory
                this.DataContext = momToUpdate;

                //puts values in fields without binding 
                DaysArrayToScreen();//put days
                HoursMatrixToScreen();//put hours

            }
           
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try//try to update with new details
            {
                //puts values from fields without binding
                screenToHoursMatrix();//for hours
                screenToDaysArray();//for days
                
                //update
                bl.Update_Mother(momToUpdate);
                MessageBox.Show("mother was changed succesfully :)", "", MessageBoxButton.OK, MessageBoxImage.Information);

                this.DataContext = null;//now can update another
                momToUpdate = new Mother();//now we can copy to new one

                //refresh fields without binding
                refreshHours();
                refreshDays();

                this.idComboBox.ItemsSource = null;
                this.idComboBox.ItemsSource = bl.GetAll_Mother();//is connected now to the update list
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void HoursMatrixToScreen()//binding to matrix in screen
        {
            this.s_hours1.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[0, 0].Hour;
            this.s_minutes1.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[0, 0].Minute;
            this.e_hours1.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[1, 0].Hour;
            this.e_minutes1.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[1, 0].Minute;

            this.s_hours2.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[0, 1].Hour;
            this.s_minutes2.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[0, 1].Minute;
            this.e_hours2.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[1, 1].Hour;
            this.e_minutes2.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[1, 1].Minute;

            this.s_hours3.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[0, 2].Hour;
            this.s_minutes3.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[0, 2].Minute;
            this.e_hours3.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[1, 2].Hour;
            this.e_minutes3.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[1, 2].Minute;

            this.s_hours4.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[0, 3].Hour;
            this.s_minutes4.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[0, 3].Minute;
            this.e_hours4.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[1, 3].Hour;
            this.e_minutes4.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[1, 3].Minute;

            this.s_hours5.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[0, 4].Hour;
            this.s_minutes5.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[0, 4].Minute;
            this.e_hours5.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[1, 4].Hour;
            this.e_minutes5.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[1, 4].Minute;

            this.s_hours6.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[0, 5].Hour;
            this.s_minutes6.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[0, 5].Minute;
            this.e_hours6.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[1, 5].Hour;
            this.e_minutes6.Value = ((Mother)this.idComboBox.SelectedItem).Wanted_Hours[1, 5].Minute;
        }

        private void DaysArrayToScreen()//binding to array in screen
        {
            this.sunday.IsChecked = ((Mother)this.idComboBox.SelectedItem).Wanted_Days[(int)Days.Sunday];
            this.monday.IsChecked = ((Mother)this.idComboBox.SelectedItem).Wanted_Days[(int)Days.Monday];
            this.tuesday.IsChecked = ((Mother)this.idComboBox.SelectedItem).Wanted_Days[(int)Days.Tuesday];
            this.wednesday.IsChecked = ((Mother)this.idComboBox.SelectedItem).Wanted_Days[(int)Days.Wednesday];
            this.thursday.IsChecked = ((Mother)this.idComboBox.SelectedItem).Wanted_Days[(int)Days.Thursday];
            this.friday.IsChecked = ((Mother)this.idComboBox.SelectedItem).Wanted_Days[(int)Days.Friday];
        }

        private void screenToHoursMatrix()//binding matrix to mom
        {
            this.momToUpdate.Wanted_Hours[0, 0] = new DateTime(0001, 01, 01, (int)this.s_hours1.Value, (int)this.s_minutes1.Value, 00);
            this.momToUpdate.Wanted_Hours[1, 0] = new DateTime(0001, 01, 01, (int)this.e_hours1.Value, (int)this.e_minutes1.Value, 00);
            this.momToUpdate.Wanted_Hours[0, 1] = new DateTime(0001, 01, 01, (int)this.s_hours2.Value, (int)this.s_minutes2.Value, 00);
            this.momToUpdate.Wanted_Hours[1, 1] = new DateTime(0001, 01, 01, (int)this.e_hours2.Value, (int)this.e_minutes2.Value, 00);
            this.momToUpdate.Wanted_Hours[0, 2] = new DateTime(0001, 01, 01, (int)this.s_hours3.Value, (int)this.s_minutes3.Value, 00);
            this.momToUpdate.Wanted_Hours[1, 2] = new DateTime(0001, 01, 01, (int)this.e_hours3.Value, (int)this.e_minutes3.Value, 00);
            this.momToUpdate.Wanted_Hours[0, 3] = new DateTime(0001, 01, 01, (int)this.s_hours4.Value, (int)this.s_minutes4.Value, 00);
            this.momToUpdate.Wanted_Hours[1, 3] = new DateTime(0001, 01, 01, (int)this.e_hours4.Value, (int)this.s_minutes4.Value, 00);
            this.momToUpdate.Wanted_Hours[0, 4] = new DateTime(0001, 01, 01, (int)this.s_hours5.Value, (int)this.s_minutes5.Value, 00);
            this.momToUpdate.Wanted_Hours[1, 4] = new DateTime(0001, 01, 01, (int)this.e_hours5.Value, (int)this.e_minutes5.Value, 00);
            this.momToUpdate.Wanted_Hours[0, 5] = new DateTime(0001, 01, 01, (int)this.s_hours6.Value, (int)this.s_minutes6.Value, 00);
            this.momToUpdate.Wanted_Hours[1, 5] = new DateTime(0001, 01, 01, (int)this.e_hours6.Value, (int)this.e_minutes6.Value, 00);
        }

        private void screenToDaysArray()//binding array to mom
        {
            this.momToUpdate.Wanted_Days[(int)Days.Sunday] = (bool)this.sunday.IsChecked;
            this.momToUpdate.Wanted_Days[(int)Days.Monday] = (bool)this.monday.IsChecked;
            this.momToUpdate.Wanted_Days[(int)Days.Tuesday] = (bool)this.tuesday.IsChecked;
            this.momToUpdate.Wanted_Days[(int)Days.Wednesday] = (bool)this.wednesday.IsChecked;
            this.momToUpdate.Wanted_Days[(int)Days.Thursday] = (bool)this.thursday.IsChecked;
            this.momToUpdate.Wanted_Days[(int)Days.Friday] = (bool)this.friday.IsChecked;
        }

        private void refreshDays()//refresh
        {
            this.sunday.IsChecked = false;
            this.monday.IsChecked = false;
            this.tuesday.IsChecked = false;
            this.wednesday.IsChecked = false;
            this.thursday.IsChecked = false;
            this.friday.IsChecked = false;
        }

        private void refreshHours()//refresh
        {
            this.s_hours1.Value = 0;
            this.s_minutes1.Value = 0;
            this.e_hours1.Value = 0;
            this.e_minutes1.Value = 0;

            this.s_hours2.Value = 0;
            this.s_minutes2.Value = 0;
            this.e_hours2.Value = 0;
            this.e_minutes2.Value = 0;

            this.s_hours3.Value = 0;
            this.s_minutes3.Value = 0;
            this.e_hours3.Value = 0;
            this.e_minutes3.Value = 0;

            this.s_hours4.Value = 0;
            this.s_minutes4.Value = 0;
            this.e_hours4.Value = 0;
            this.e_minutes4.Value = 0;

            this.s_hours5.Value = 0;
            this.s_minutes5.Value = 0;
            this.e_hours5.Value = 0;
            this.e_minutes5.Value = 0;

            this.s_hours6.Value = 0;
            this.s_minutes6.Value = 0;
            this.e_hours6.Value = 0;
            this.e_minutes6.Value = 0;
        }
    }
}
