﻿using System;
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
using System.IO;

namespace Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool letezik = false;
            foreach (var elem in panel.Children)
            {
                if (elem is Button)
                {
                    Button btn = (Button)elem;
                    if (btn.Name.ToLower() == txtName.Text.ToLower())
                    {
                        letezik = true;
                        MessageBox.Show("Ez az elem már létezik!");
                        break;
                    }
                }
                else if (elem is TextBlock)
                {
                    TextBlock txt = (TextBlock)elem;
                    if (txt.Name.ToLower() == txtName.Text.ToLower())
                    {
                        letezik = true;
                        MessageBox.Show("Ez az elem már létezik!");
                        break;
                    }
                }
            }
            if (rdbButton.IsChecked == true)
            {

                if (!letezik)
                {
                    Button gomb = new();
                    gomb.Click += NameButtonClick;
                    gomb.Content = txtName.Text;
                   
                    gomb.Name = txtName.Text;
                    panel.Children.Add(gomb);
                }
            }
            else if (rdbTextBlock.IsChecked == true)
            {
                if (!letezik)
                {
                    TextBlock blokk = new();
                    blokk.Text = txtName.Text;
                    blokk.Name = txtName.Text;
                    panel.Children.Add(blokk);
                }
            }
        }
        public void NameButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show($"Szia {btn.Name} vagyok!");
        }
    }
}
