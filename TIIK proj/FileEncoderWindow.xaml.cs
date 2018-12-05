using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TIIK_proj
{
    /// <summary>
    /// Logika interakcji dla klasy FileEncoderWindow.xaml
    /// </summary>
    public partial class FileEncoderWindow : Window
    {
        public FileEncoderWindow()
        {
            InitializeComponent();
        }

        /*// Do the validation in a separate function which can be reused
        public static bool IsOnlyNumbers(string str)
        {
            int i;
            return (int.TryParse(str, out i) && i >= 0 && i <= 9999);
        }*/

        private void ButtonChooseFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                LabelPath.Content = openFileDialog.FileName;
                TextBoxFileContent.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void ButtonReturn_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void ButtonExampleFile_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFileContent.Text = "aaaabbcd";
        }

        private void ButtonEncode_Click(object sender, RoutedEventArgs e)
        {
            TextBoxAfterCodingContent.Text = EncodingRLE.Encode(TextBoxFileContent.Text);
            TextBlockCharsCount.Text = TextBoxAfterCodingContent.Text.Length.ToString();
        }

        private void ButtonDecode_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSaveFileLeft_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.FileName = "Origin_1";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, TextBoxFileContent.Text);
            }
        }

        private void ButtonSaveFileRight_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.FileName = "Aftercoding_1";
            //saveFileDialog.OverwritePrompt = false;
            /*int iterator = 1;
            while (File.Exists(saveFileDialog.FileName))
            {
                //MessageBox.Show("Istnieje plik " + saveFileDialog.FileName);
                iterator++;
                saveFileDialog.FileName = "Aftercoding_" + iterator;
                //MessageBox.Show("FileName " + saveFileDialog.FileName + "!");
            }*/

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, TextBoxAfterCodingContent.Text);
            }
        }
    }
}
