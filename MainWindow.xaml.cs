
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
using System.Media;
using Microsoft.Win32;
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
       private MediaPlayer myMedia = new MediaPlayer();
        public MainWindow()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            this.openPicture.MouseDown += OpenPicture_MouseDown;
            this.motherButton.Click += MotherButton_Click;
            this.nannyButton.Click += NannyButton_Click;
            this.ChildButton.Click += ChildButton_Click;
            this.contractButton.Click += ContractButton_Click;
            this.linqButton.Click += LinqButton_Click;
            this.takanon.Click += Takanon_Click;
        }

        private void LinqButton_Click(object sender, RoutedEventArgs e)
        {
            Window linkWindow = new LinkWindow();
            linkWindow.ShowDialog();
        }

        private void ContractButton_Click(object sender, RoutedEventArgs e)
        {
            Window contractWindow = new ContractWindow();
          // SystemSounds.Hand.Play();
            contractWindow.ShowDialog();
        }

        private void ChildButton_Click(object sender, RoutedEventArgs e)
        {
            Window childWindow = new ChildWindow();
            childWindow.ShowDialog();
        }

        private void Takanon_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("takanon.txt");

        }

        private void NannyButton_Click(object sender, RoutedEventArgs e)
        {
            Window nannyWindow = new NannyWindow();
            nannyWindow.ShowDialog();
        }

        private void MotherButton_Click(object sender, RoutedEventArgs e)
        {
            Window motherWindow = new MotherWindow();
            motherWindow.ShowDialog();
        }

        private void OpenPicture_MouseDown(object sender, MouseEventArgs e)
        {
           
               myMedia.Open(new Uri("song.mpeg",UriKind.Relative));
               myMedia.Volume = 1;
                myMedia.Play();
           
            this.openPicture.Visibility = Visibility.Hidden;
        }

        private void sound_Click(object sender, RoutedEventArgs e)
        {
            myMedia.Stop();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);//stop all back threads
        }
    }
}
