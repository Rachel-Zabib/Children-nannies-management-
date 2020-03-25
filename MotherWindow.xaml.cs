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
    /// Interaction logic for MotherWindow.xaml
    /// </summary>
    public partial class MotherWindow : Window
    {
        public MotherWindow()
        {
            InitializeComponent();
            this.addButton.Click += AddButton_Click;
            this.removeButton.Click += RemoveButton_Click;
            this.updateButton.Click += UpdateButton_Click;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            this.mainFrame.Content = new PageUpdate();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            this.mainFrame.Content = new PageRemove();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.mainFrame.Content = new PageAdd(); 
        }
    }
}
