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
            TextBoxSeparatorChar.Text = "?";
            TextBoxSeparatorASCII.Text = ((int)'?').ToString();
        }

        // Do the validation in a separate function which can be reused
        public static bool IsValid(string str)
        {
            int i;
            return (int.TryParse(str, out i) && i >= 0 && i <= 9999);
        }

        private void TextBoxSeparatorChar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //bool isValid = false;
            //if(TextBoxSeparatorChar.Text.Count() <2)
            //{ isValid = true; }
            //if (isValid)
            //{ TextBoxSeparatorASCII.Text = ((int)(((TextBox)sender).Text[0])).ToString(); }
            ////{ TextBoxSeparatorASCII.Text = TextBoxSeparatorChar.Text.Count().ToString(); }
            //e.Handled = !isValid;
        }

        private void TextBoxSeparatorASCII_TextChanged(object sender, TextChangedEventArgs e)
        {
            //bool isValid = IsValid(((TextBox)sender).Text);
            //if (isValid)
            //{ TextBoxSeparatorChar.Text = ((char)Convert.ToInt32(((TextBox)sender).Text)).ToString(); }
            //e.Handled = !isValid;
        }
        private void TextBoxSeparatorChar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool isValid = false;
            if (TextBoxSeparatorChar.Text.Count() < 2)
            { isValid = true; }
            if (isValid)
            {
                try
                {
                    TextBoxSeparatorASCII.Text = ((int)(e.Text[0])).ToString();
                }
                catch (Exception) { }
            }

            //{ TextBoxSeparatorASCII.Text = TextBoxSeparatorChar.Text.Count().ToString(); }
            e.Handled = !isValid;
        }
        private void TextBoxSeparatorASCII_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[^0-9]+");
            bool isValid = IsValid(((TextBox)sender).Text + e.Text);
            //bool isValid = TextBoxSeparatorChar.Text.Count() == 1 ? true : false;
            if (isValid)
            { TextBoxSeparatorChar.Text = ((char)Convert.ToInt32(((TextBox)sender).Text + e.Text)).ToString(); }
            e.Handled = !isValid;
        }



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
            //TextBoxAfterCodingContent = EncodingRLE.Encode(TextBoxFileContent.Text, );
        }

        private void ButtonDecode_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSaveFile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
