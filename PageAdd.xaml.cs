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
    /// Interaction logic for PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        IBL bl;
        Mother momToAdd;
        public PageAdd()
        {

            InitializeComponent();
            bl = FactoryBL.GetBL();
            momToAdd = new Mother() { Home_Country = "Israel" };
            this.DataContext = momToAdd;

            this.addButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //for fields without binding
                screenToHoursMatrix();//put in matrix
                screenToDaysArray();//put in days

                //add
                bl.Add_Mother(momToAdd);
                MessageBox.Show("mother was added succesfully :)", "", MessageBoxButton.OK, MessageBoxImage.Information);
                //new data
                momToAdd = new Mother() { Home_Country = "Israel" };
                this.DataContext = momToAdd;

                //refresh all fields without binding:
                refreshDays();//for days on screen
                refreshHours();//for hours on screen

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void Page_Error(object sender, ValidationErrorEventArgs e)
        {
            bool flag = true;
            if (e.Action == ValidationErrorEventAction.Added)
                flag = false;
            else
                flag = true;

            this.addButton.IsEnabled = flag;
        }


        private void screenToHoursMatrix()//binding to matrix
        {
            this.momToAdd.Wanted_Hours[0, 0] = new DateTime(0001, 01, 01, (int)this.s_hours1.Value, (int)this.s_minutes1.Value, 00);
            this.momToAdd.Wanted_Hours[1, 0] = new DateTime(0001, 01, 01, (int)this.e_hours1.Value, (int)this.e_minutes1.Value, 00);
            this.momToAdd.Wanted_Hours[0, 1] = new DateTime(0001, 01, 01, (int)this.s_hours2.Value, (int)this.s_minutes2.Value, 00);
            this.momToAdd.Wanted_Hours[1, 1] = new DateTime(0001, 01, 01, (int)this.e_hours2.Value, (int)this.e_minutes2.Value, 00);
            this.momToAdd.Wanted_Hours[0, 2] = new DateTime(0001, 01, 01, (int)this.s_hours3.Value, (int)this.s_minutes3.Value, 00);
            this.momToAdd.Wanted_Hours[1, 2] = new DateTime(0001, 01, 01, (int)this.e_hours3.Value, (int)this.e_minutes3.Value, 00);
            this.momToAdd.Wanted_Hours[0, 3] = new DateTime(0001, 01, 01, (int)this.s_hours4.Value, (int)this.s_minutes4.Value, 00);
            this.momToAdd.Wanted_Hours[1, 3] = new DateTime(0001, 01, 01, (int)this.e_hours4.Value, (int)this.s_minutes4.Value, 00);
            this.momToAdd.Wanted_Hours[0, 4] = new DateTime(0001, 01, 01, (int)this.s_hours5.Value, (int)this.s_minutes5.Value, 00);
            this.momToAdd.Wanted_Hours[1, 4] = new DateTime(0001, 01, 01, (int)this.e_hours5.Value, (int)this.e_minutes5.Value, 00);
            this.momToAdd.Wanted_Hours[0, 5] = new DateTime(0001, 01, 01, (int)this.s_hours6.Value, (int)this.s_minutes6.Value, 00);
            this.momToAdd.Wanted_Hours[1, 5] = new DateTime(0001, 01, 01, (int)this.e_hours6.Value, (int)this.e_minutes6.Value, 00);
        }

        private void screenToDaysArray()//binding to array
        {
            this.momToAdd.Wanted_Days[(int)Days.Sunday] = (bool)this.sunday.IsChecked;
            this.momToAdd.Wanted_Days[(int)Days.Monday] = (bool)this.monday.IsChecked;
            this.momToAdd.Wanted_Days[(int)Days.Tuesday] = (bool)this.tuesday.IsChecked;
            this.momToAdd.Wanted_Days[(int)Days.Wednesday] = (bool)this.wednesday.IsChecked;
            this.momToAdd.Wanted_Days[(int)Days.Thursday] = (bool)this.thursday.IsChecked;
            this.momToAdd.Wanted_Days[(int)Days.Friday] = (bool)this.friday.IsChecked;
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
