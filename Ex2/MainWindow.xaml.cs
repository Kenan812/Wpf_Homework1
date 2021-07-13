using System;
using System.Windows;
using System.Windows.Controls;

namespace Ex2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FullEquation { get; set; }




        public MainWindow()
        {
            InitializeComponent();

            resultNumberTextBox.Text = String.Empty;
            equationTextBox.Text = String.Empty;
        }

        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            equationTextBox.Text += b.Content;
        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            char sign = equationTextBox.Text[equationTextBox.Text.Length - 1];

            if (sign != '+' && sign != '-' && sign != 'x' && sign != '/')
                equationTextBox.Text += b.Content;

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            if (b.Name == "CE")
            {

            }
            else if (b.Name == "C")
            {

            }
            else if (b.Name == "deleteButton")
            {
                equationTextBox.Text = equationTextBox.Text.Remove(equationTextBox.Text.Length - 1, 1);

            }


        }




        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
