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
            string szoveg = txtName.Text.Trim();

            foreach (var elem in panel.Children)
            {
                if (elem is Button)
                {
                    Button btn = (Button)elem;
                    if (btn.Name.ToLower() == szoveg.ToLower())
                    {
                        letezik = true;
                        break;
                    }
                }
                else if (elem is TextBlock)
                {
                    TextBlock txt = (TextBlock)elem;
                    if (txt.Name.ToLower() == szoveg.ToLower())
                    {
                        letezik = true;
                        break;
                    }
                }
            }

            if (!letezik && szoveg != "")
            {

                if (rdbButton.IsChecked == true)
                {
                    Button gomb = new();
                    gomb.Click += NameButtonClick;
                    gomb.Content = szoveg;
                    gomb.Name = szoveg;
                    gomb.Margin = new Thickness(5);
                    panel.Children.Add(gomb);
                }

                else if (rdbTextBlock.IsChecked == true)
                {
                    TextBlock blokk = new();
                    blokk.Text = szoveg;
                    blokk.Name = szoveg;
                    blokk.Margin = new Thickness(5);
                    panel.Children.Add(blokk);
                }
            }

            else if (letezik)
            {
                MessageBox.Show("Ez az elem már létezik!");
            }
        }
        public void NameButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                MessageBox.Show($"Szia {btn.Name} vagyok!");
            }
        }
    }
}
