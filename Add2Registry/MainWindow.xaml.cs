
using Microsoft.Win32;
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

namespace Add2Registry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string keyPath = @"SOFTWARE\Policies\Microsoft\Windows\System\HagH_TestReg";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\" + keyPath , "HgH", txtVal.Text, RegistryValueKind.String);
            MessageBox.Show("Registery Added!");
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var myKey = hklm.OpenSubKey(keyPath, true))
            {
                if (myKey == null)
                    MessageBox.Show("Register alredy deleted");
                else
                {
                    myKey.DeleteValue("HgH");
                    myKey.Close();
                    MessageBox.Show("Register delited!");
                }
            }
        }
    }
}