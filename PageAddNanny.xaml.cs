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
    /// Interaction logic for PageAddNanny.xaml
    /// </summary>
    public partial class PageAddNanny : Page
    {
        IBL bl;
        Nanny nanToAdd;
        public PageAddNanny()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            nanToAdd = new Nanny() { Birth_Date = new DateTime(1990, 01, 01),Country="Israel" };
            this.DataContext = nanToAdd;
            this.addButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //put values to fields without binding
                screenToHoursMatrix();//for hours

                screenToDaysArray();//for days

                screenToLanguagesArray();//for languages

                //add
                bl.Add_Nanny(nanToAdd);
                MessageBox.Show("nanny was added succesfully :)", "", MessageBoxButton.OK, MessageBoxImage.Information);

                //refresh
                nanToAdd = new Nanny() { Birth_Date = new DateTime(1990, 01, 01), Country = "Israel" };
                this.DataContext = nanToAdd;

                //refresh all fields without binding:

                refreshDays();//for days
                refreshLanguges();//for languages
                refreshHours();//for hours

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
            this.nanToAdd.Work_Hours[0, 0] = new DateTime(0001, 01, 01, (int)this.s_hours1.Value, (int)this.s_minutes1.Value, 00);
            this.nanToAdd.Work_Hours[1, 0] = new DateTime(0001, 01, 01, (int)this.e_hours1.Value, (int)this.e_minutes1.Value, 00);
            this.nanToAdd.Work_Hours[0, 1] = new DateTime(0001, 01, 01, (int)this.s_hours2.Value, (int)this.s_minutes2.Value, 00);
            this.nanToAdd.Work_Hours[1, 1] = new DateTime(0001, 01, 01, (int)this.e_hours2.Value, (int)this.e_minutes2.Value, 00);
            this.nanToAdd.Work_Hours[0, 2] = new DateTime(0001, 01, 01, (int)this.s_hours3.Value, (int)this.s_minutes3.Value, 00);
            this.nanToAdd.Work_Hours[1, 2] = new DateTime(0001, 01, 01, (int)this.e_hours3.Value, (int)this.e_minutes3.Value, 00);
            this.nanToAdd.Work_Hours[0, 3] = new DateTime(0001, 01, 01, (int)this.s_hours4.Value, (int)this.s_minutes4.Value, 00);
            this.nanToAdd.Work_Hours[1, 3] = new DateTime(0001, 01, 01, (int)this.e_hours4.Value, (int)this.s_minutes4.Value, 00);
            this.nanToAdd.Work_Hours[0, 4] = new DateTime(0001, 01, 01, (int)this.s_hours5.Value, (int)this.s_minutes5.Value, 00);
            this.nanToAdd.Work_Hours[1, 4] = new DateTime(0001, 01, 01, (int)this.e_hours5.Value, (int)this.e_minutes5.Value, 00);
            this.nanToAdd.Work_Hours[0, 5] = new DateTime(0001, 01, 01, (int)this.s_hours6.Value, (int)this.s_minutes6.Value, 00);
            this.nanToAdd.Work_Hours[1, 5] = new DateTime(0001, 01, 01, (int)this.e_hours6.Value, (int)this.e_minutes6.Value, 00);
        }

        private void screenToDaysArray()//binding to array of days
        {
            this.nanToAdd.Work_Day[(int)Days.Sunday] = (bool)this.sunday.IsChecked;
            this.nanToAdd.Work_Day[(int)Days.Monday] = (bool)this.monday.IsChecked;
            this.nanToAdd.Work_Day[(int)Days.Tuesday] = (bool)this.tuesday.IsChecked;
            this.nanToAdd.Work_Day[(int)Days.Wednesday] = (bool)this.wednesday.IsChecked;
            this.nanToAdd.Work_Day[(int)Days.Thursday] = (bool)this.thursday.IsChecked;
            this.nanToAdd.Work_Day[(int)Days.Friday] = (bool)this.friday.IsChecked;
        }

        private void screenToLanguagesArray()//binding to array of langugaes
        {
            this.nanToAdd.Spoken_Languages[(int)Languages.Hebrew] = (bool)this.hebrew.IsChecked;
            this.nanToAdd.Spoken_Languages[(int)Languages.English] = (bool)this.english.IsChecked;
            this.nanToAdd.Spoken_Languages[(int)Languages.French] = (bool)this.french.IsChecked;
            this.nanToAdd.Spoken_Languages[(int)Languages.Russian] = (bool)this.russian.IsChecked;
            this.nanToAdd.Spoken_Languages[(int)Languages.Yiddish] = (bool)this.yiddish.IsChecked;
            this.nanToAdd.Spoken_Languages[(int)Languages.Amharic] = (bool)this.amharic.IsChecked;
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

        private void refreshLanguges()//refresh
        {
            this.hebrew.IsChecked = false;
            this.english.IsChecked = false;
            this.russian.IsChecked = false;
            this.french.IsChecked = false;
            this.yiddish.IsChecked = false;
            this.amharic.IsChecked = false;
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
