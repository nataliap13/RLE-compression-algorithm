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
    //public enum EnumEncoding {UTF8, Unicode, ASCII }
    /// <summary>
    /// Logika interakcji dla klasy FileLoader.xaml
    /// </summary>
    public partial class FileLoaderWindow : Window
    {
        List<CharCountObject> MainList;
        const int factor = 100000;
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
            var TxtLength = textToAnalyze.Length;
            LabelCharsCount.Content = textToAnalyze.Length;
            Dictionary<char, int> dictCharsAndFrequency = new Dictionary<char, int>();
            foreach (var character in textToAnalyze)
            {                
                if (!dictCharsAndFrequency.ContainsKey(character))// if there isn't the char in the dictionary we add key
                { dictCharsAndFrequency.Add(character, 1); }
                else // if there is the char in the dictionary we just increase the value
                { dictCharsAndFrequency[character] += 1; }
            }

            //converting dictionary to list to display it in dataGrid
            var ListFromDictAsCharCountObjects = new List<CharCountObject>();
            var percentCount = 0;
            //var percentCount = 0.000;
            foreach (var pair in dictCharsAndFrequency)
            {
                int prob = (int)Math.Round((double)factor * (double)pair.Value / (double)TxtLength);
                //int prob = (int)Math.Round((double)pair.Value / (double)TxtLength * (double)factor );
                //var prob = 100.0 * (double)pair.Value / (double)TxtLength;
                //prob = Math.Round(prob, 3);
                if (prob < 1)
                { prob = 1; }
                percentCount += prob;
                ListFromDictAsCharCountObjects.Add(new CharCountObject() { Character = pair.Key, Count = pair.Value, Probability = prob });
            }

            if(percentCount!= factor)
            { LabelPercentWarning.Content = "Wynik != 100%"; LabelPercentWarning.Foreground = Brushes.Red; }
            else
            { LabelPercentWarning.Content = "100%"; LabelPercentWarning.Foreground = Brushes.Black; }

            var sortedList = ListFromDictAsCharCountObjects.OrderByDescending(x => x.Probability).ToList();//sort
            MainList = sortedList;
            dataGridCharsCount.ItemsSource = sortedList;
            string stringLabelPercentCount = percentCount.ToString().Insert(percentCount.ToString().Length-3,",");
            LabelPercentCount.Content = stringLabelPercentCount;
        }

        private void ButtonPercentReduction_Click(object sender, RoutedEventArgs e)
        {
            var workList = MainList.OrderBy(x => x.Probability).ToList();//sort

            var percent = 1;//initial value
            while (percent != 0)
            {
                foreach (var elem in workList)
                {
                    percent = 0;
                    foreach (var el in workList)
                    {
                        percent += el.Probability;
                    }
                    percent -= factor;
                    //LabelPercentWarning.Content = percent;
                    //System.Threading.Thread.Sleep(3000);
                    if (percent != 0)
                    {
                        if (elem.Probability != 1)
                        { elem.Probability -= Math.Sign(percent); }
                    }
                    else break;
                }
            }

            LabelPercentWarning.Content = "100%"; LabelPercentWarning.Foreground = Brushes.Black;
            MainList = workList.OrderByDescending(x => x.Probability).ToList();//sort
            dataGridCharsCount.ItemsSource = MainList;
            LabelPercentCount.Content = "100,000";
        }

        private void ButtonEntrophy_Click(object sender, RoutedEventArgs e)
        {
            double Entrophy = 0.0;
            foreach(var item in MainList)
            {
                var prob = (double)item.Probability / factor;
                Entrophy += prob * Math.Log(1.0/prob, 2.0);
            }
            LabelEntrophy.Content = Entrophy;
        }

        private void ButtonExampleFile_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFileContent.Text = "aaaabbcd";
        }
    }
}
