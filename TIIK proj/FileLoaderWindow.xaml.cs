using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace TIIK_proj
{
    /// <summary>
    /// Logika interakcji dla klasy FileLoader.xaml
    /// </summary>
    public partial class FileLoaderWindow : Window
    {
        public FileLoaderWindow()
        {
            InitializeComponent();
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

        private void ButtonCountChars_Click(object sender, RoutedEventArgs e)
        {
            var textToAnalyze = TextBoxFileContent.Text;
            LabelCharsCount.Content = textToAnalyze.Length;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var character in textToAnalyze)
            {                
                if (!dict.ContainsKey(character))// if there isn't the char in the dictionary we add key
                { dict.Add(character, 1); }
                else // if there is the char in the dictionary we just increase the value
                { dict[character] += 1; }
            }
            var dictAsCharCountObjectList = new List<CharCountObject>();
            foreach (var pair in dict)
            {
                dictAsCharCountObjectList.Add(new CharCountObject() { Character = pair.Key, Count = pair.Value });
            }
            dataGridCharsCount.ItemsSource = dictAsCharCountObjectList;
        }
    }
}
