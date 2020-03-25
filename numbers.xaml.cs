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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for numbers.xaml
    /// </summary>
    public partial class numbers : UserControl
    {

        private float? num = null;
        public float? Value
        {
            get { return (float?)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(float?), typeof(numbers), new PropertyMetadata(null, input2, Input));

        public static object Input(DependencyObject d, object baseValue)//check input correctness for set
        {
            float? val = baseValue as float?;
            numbers current = d as numbers;
            if (val > current.MaxValue)
                return current.MaxValue;
            else if (val < current.MinValue)
                return current.MinValue;
            else return val;
            //txtNum.Text = num == null ? "" : num.ToString();
        }

        public static void input2(DependencyObject d, DependencyPropertyChangedEventArgs e)//show on screen the changes from value(--/++)
        {
            numbers current = d as numbers;
            current.txtNum.Text = current.Value == null ? "" : current.Value.ToString();
        }


        public float? MinValue
        {
            get { return (float?)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(float?), typeof(numbers), new PropertyMetadata(null));


        // public float? MinValue { get; set; }


        public float? MaxValue
        {
            get { return (float?)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(float?), typeof(numbers), new PropertyMetadata(null));



        //public float? MaxValue { get; set; }

        public numbers()
        {
            InitializeComponent(); 
        }
        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            Value++;
        }
        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            Value--;
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum == null||txtNum.Text=="-") return;
            //if (txtNum.Text == "-")
            //{
            //    txtNum.Text = "0";
            //    return;
            //}
            if(int.Parse(txtNum.Text)<0)
                txtNum.Text = "0";
            float val;
            if (!float.TryParse(txtNum.Text, out val))
                txtNum.Text = Value.ToString();
            else
                Value = val;
        }


    }
}

