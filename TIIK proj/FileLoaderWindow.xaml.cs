﻿using Microsoft.Win32;
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
            var percentCount = 0.000;
            foreach (var pair in dictCharsAndFrequency)
            {
                var prob = 100.0 * (double)pair.Value / (double)TxtLength;
                prob = Math.Round(prob, 3);
                if (prob == 0.000)
                { prob = 0.001; }
                percentCount += prob;
                ListFromDictAsCharCountObjects.Add(new CharCountObject() { Character = pair.Key, Count = pair.Value, Probability = prob });
            }

            if(percentCount!=100.0)
            { LabelPercentWarning.Content = "Wynik != 100%"; LabelPercentWarning.Foreground = Brushes.Red; }
            else
            { LabelPercentWarning.Content = "100%"; LabelPercentWarning.Foreground = Brushes.Black; }

            var sortedList = ListFromDictAsCharCountObjects.OrderByDescending(x => x.Probability).ToList();//sort
            MainList = sortedList;
            dataGridCharsCount.ItemsSource = sortedList;
            LabelPercentCount.Content = (percentCount == 100.000 ? 100.000 : percentCount);
        }

        private void ButtonPercentReduction_Click(object sender, RoutedEventArgs e)
        {
            var workList = MainList.OrderBy(x => x.Probability).ToList();//sort
            foreach(var elem in workList)
            {
                var percent = 0.0;
                foreach (var el in workList)
                {
                    percent += el.Probability;
                }
                percent -= 100.0;
                if (percent == 0.0)
                { break; }
                LabelPercentWarning.Content = percent;
                //System.Threading.Thread.Sleep(3000);
                if (percent != 0.0)
                {
                    elem.Probability -= Math.Sign(percent) * 0.001;
                }
                else break;
            }

            LabelPercentWarning.Content = "100%"; LabelPercentWarning.Foreground = Brushes.Black;
            MainList = workList.OrderByDescending(x => x.Probability).ToList();//sort
            dataGridCharsCount.ItemsSource = MainList;
            LabelPercentCount.Content = (100.000);
        }
    }
}
