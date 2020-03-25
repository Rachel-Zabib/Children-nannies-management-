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
    /// Interaction logic for PageUpdateNanny.xaml
    /// </summary>
    public partial class PageUpdateNanny : Page
    {
        IBL bl;
        Nanny nanToUpdate;
        public PageUpdateNanny()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            nanToUpdate = new Nanny();//prepare place in memory..

            this.idComboBox.ItemsSource = bl.GetAll_Nanny();
            this.idComboBox.DisplayMemberPath = "Id";//show mother jusy by id
            this.idComboBox.SelectedValuePath = "Id";//connection background is really by id
        }

        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //we select nanny but doesnt want to change imidietly in list so first we copy to another, update there and put her now in list
            if (this.idComboBox.SelectedItem is Nanny)
            {
                this.nanToUpdate = ((Nanny)this.idComboBox.SelectedItem).DeepClone();//extention method for each T that makes deep copy by place in memory
                this.DataContext = nanToUpdate;

                //puts values in fields without binding 
                DaysArrayToScreen();
                HoursMatrixToScreen();
                LanguagesArrayToScreen();
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try//try to update with new details
            {
                //puts fields that dont have binding
                screenToHoursMatrix();
                screenToDaysArray();
                screenToLanguagesArray();

                bl.Update_Nanny(nanToUpdate);
                MessageBox.Show("nanny was changed succesfully :)", "", MessageBoxButton.OK, MessageBoxImage.Information);

                //refresh fields without binding 
                refreshDays();
                refreshLanguages();
                refrehHours();

                this.DataContext = null;//now can update another
                nanToUpdate = new Nanny();//now we can copy to new one
                this.idComboBox.ItemsSource =null;
                this.idComboBox.ItemsSource = bl.GetAll_Nanny();//is connected now to the update list
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void HoursMatrixToScreen()//nanny hours to show
        {
            this.s_hours1.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[0, 0].Hour;
            this.s_minutes1.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[0, 0].Minute;
            this.e_hours1.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[1, 0].Hour;
            this.e_minutes1.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[1, 0].Minute;

            this.s_hours2.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[0, 1].Hour;
            this.s_minutes2.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[0, 1].Minute;
            this.e_hours2.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[1, 1].Hour;
            this.e_minutes2.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[1, 1].Minute;

            this.s_hours3.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[0, 2].Hour;
            this.s_minutes3.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[0, 2].Minute;
            this.e_hours3.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[1, 2].Hour;
            this.e_minutes3.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[1, 2].Minute;

            this.s_hours4.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[0, 3].Hour;
            this.s_minutes4.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[0, 3].Minute;
            this.e_hours4.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[1, 3].Hour;
            this.e_minutes4.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[1, 3].Minute;

            this.s_hours5.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[0, 4].Hour;
            this.s_minutes5.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[0, 4].Minute;
            this.e_hours5.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[1, 4].Hour;
            this.e_minutes5.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[1, 4].Minute;

            this.s_hours6.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[0, 5].Hour;
            this.s_minutes6.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[0, 5].Minute;
            this.e_hours6.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[1, 5].Hour;
            this.e_minutes6.Value = ((Nanny)this.idComboBox.SelectedItem).Work_Hours[1, 5].Minute;
        }

        private void DaysArrayToScreen()//nanny days to show
        {
            this.sunday.IsChecked = ((Nanny)this.idComboBox.SelectedItem).Work_Day[(int)Days.Sunday];
            this.monday.IsChecked = ((Nanny)this.idComboBox.SelectedItem).Work_Day[(int)Days.Monday];
            this.tuesday.IsChecked = ((Nanny)this.idComboBox.SelectedItem).Work_Day[(int)Days.Tuesday];
            this.wednesday.IsChecked = ((Nanny)this.idComboBox.SelectedItem).Work_Day[(int)Days.Wednesday];
            this.thursday.IsChecked = ((Nanny)this.idComboBox.SelectedItem).Work_Day[(int)Days.Thursday];
            this.friday.IsChecked = ((Nanny)this.idComboBox.SelectedItem).Work_Day[(int)Days.Friday];
        }

        private void LanguagesArrayToScreen()//nanny languages to show
        {
            this.hebrew.IsChecked = ((Nanny)this.idComboBox.SelectedItem).Spoken_Languages[(int)Languages.Hebrew];
            this.english.IsChecked = ((Nanny)this.idComboBox.SelectedItem).Spoken_Languages[(int)Languages.English];
            this.french.IsChecked = ((Nanny)this.idComboBox.SelectedItem).Spoken_Languages[(int)Languages.French];
            this.russian.IsChecked = ((Nanny)this.idComboBox.SelectedItem).Spoken_Languages[(int)Languages.Russian];
            this.yiddish.IsChecked = ((Nanny)this.idComboBox.SelectedItem).Spoken_Languages[(int)Languages.Yiddish];
            this.amharic.IsChecked = ((Nanny)this.idComboBox.SelectedItem).Spoken_Languages[(int)Languages.Amharic];
        }

        private void screenToHoursMatrix()//binding matrix to nanny
        {
            this.nanToUpdate.Work_Hours[0, 0] = new DateTime(0001, 01, 01, (int)this.s_hours1.Value, (int)this.s_minutes1.Value, 00);
            this.nanToUpdate.Work_Hours[1, 0] = new DateTime(0001, 01, 01, (int)this.e_hours1.Value, (int)this.e_minutes1.Value, 00);
            this.nanToUpdate.Work_Hours[0, 1] = new DateTime(0001, 01, 01, (int)this.s_hours2.Value, (int)this.s_minutes2.Value, 00);
            this.nanToUpdate.Work_Hours[1, 1] = new DateTime(0001, 01, 01, (int)this.e_hours2.Value, (int)this.e_minutes2.Value, 00);
            this.nanToUpdate.Work_Hours[0, 2] = new DateTime(0001, 01, 01, (int)this.s_hours3.Value, (int)this.s_minutes3.Value, 00);
            this.nanToUpdate.Work_Hours[1, 2] = new DateTime(0001, 01, 01, (int)this.e_hours3.Value, (int)this.e_minutes3.Value, 00);
            this.nanToUpdate.Work_Hours[0, 3] = new DateTime(0001, 01, 01, (int)this.s_hours4.Value, (int)this.s_minutes4.Value, 00);
            this.nanToUpdate.Work_Hours[1, 3] = new DateTime(0001, 01, 01, (int)this.e_hours4.Value, (int)this.s_minutes4.Value, 00);
            this.nanToUpdate.Work_Hours[0, 4] = new DateTime(0001, 01, 01, (int)this.s_hours5.Value, (int)this.s_minutes5.Value, 00);
            this.nanToUpdate.Work_Hours[1, 4] = new DateTime(0001, 01, 01, (int)this.e_hours5.Value, (int)this.e_minutes5.Value, 00);
            this.nanToUpdate.Work_Hours[0, 5] = new DateTime(0001, 01, 01, (int)this.s_hours6.Value, (int)this.s_minutes6.Value, 00);
            this.nanToUpdate.Work_Hours[1, 5] = new DateTime(0001, 01, 01, (int)this.e_hours6.Value, (int)this.e_minutes6.Value, 00);
        }

        private void screenToDaysArray()//binding array to nanny
        {
            this.nanToUpdate.Work_Day[(int)Days.Sunday] = (bool)this.sunday.IsChecked;
            this.nanToUpdate.Work_Day[(int)Days.Monday] = (bool)this.monday.IsChecked;
            this.nanToUpdate.Work_Day[(int)Days.Tuesday] = (bool)this.tuesday.IsChecked;
            this.nanToUpdate.Work_Day[(int)Days.Wednesday] = (bool)this.wednesday.IsChecked;
            this.nanToUpdate.Work_Day[(int)Days.Thursday] = (bool)this.thursday.IsChecked;
            this.nanToUpdate.Work_Day[(int)Days.Friday] = (bool)this.friday.IsChecked;
        }

        private void screenToLanguagesArray()//binding array to nanny
        {
            this.nanToUpdate.Spoken_Languages[(int)Languages.Hebrew] = (bool)this.hebrew.IsChecked;
            this.nanToUpdate.Spoken_Languages[(int)Languages.English] = (bool)this.english.IsChecked;
            this.nanToUpdate.Spoken_Languages[(int)Languages.French] = (bool)this.french.IsChecked;
            this.nanToUpdate.Spoken_Languages[(int)Languages.Russian] = (bool)this.russian.IsChecked;
            this.nanToUpdate.Spoken_Languages[(int)Languages.Yiddish] = (bool)this.yiddish.IsChecked;
            this.nanToUpdate.Spoken_Languages[(int)Languages.Amharic] = (bool)this.amharic.IsChecked;
        }

        private void refrehHours()//refresh
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

        private void refreshDays()//refresh
        {
            this.sunday.IsChecked = false;
            this.monday.IsChecked = false;
            this.tuesday.IsChecked = false;
            this.wednesday.IsChecked = false;
            this.thursday.IsChecked = false;
            this.friday.IsChecked = false;
        }

        private void refreshLanguages()//refresh
        {
            this.hebrew.IsChecked = false;
            this.english.IsChecked = false;
            this.russian.IsChecked = false;
            this.french.IsChecked = false;
            this.yiddish.IsChecked = false;
            this.amharic.IsChecked = false;
        }
    }
}
