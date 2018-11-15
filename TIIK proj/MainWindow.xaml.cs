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

namespace TIIK_proj
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonFileLoaderWindow_Click(object sender, RoutedEventArgs e)
        {
            new FileLoaderWindow().Show();
            Close();
        }

        private void ButtonFileEncoderWindow_Click(object sender, RoutedEventArgs e)
        {
            new FileEncoderWindow().Show();
            Close();
        }
    }
}
