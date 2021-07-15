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

        bool dotAvailable = false;
        bool isFirstNumber = true;
        bool newNumber = true;

        public MainWindow()
        {
            InitializeComponent();

            resultNumberTextBox.Text = String.Empty;
            equationTextBox.Text = String.Empty;
        }

        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            if (!String.IsNullOrEmpty(equationTextBox.Text))
            {
                if (newNumber)
                {
                    // MessageBox.Show("if");
                    equationTextBox.Text += b.Content;
                    newNumber = false;
                }

                else if (equationTextBox.Text.Length >= 2 && equationTextBox.Text[equationTextBox.Text.Length - 2] != '0')
                {
                    //MessageBox.Show("else if");
                    equationTextBox.Text += b.Content;
                }
                else if (equationTextBox.Text[equationTextBox.Text.Length - 1] != '0')
                    equationTextBox.Text += b.Content;


                if (isFirstNumber)
                {
                    isFirstNumber = false;
                    dotAvailable = true;
                }
            }

            else
            {
                equationTextBox.Text += b.Content;
                newNumber = false;
            }
        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            if (String.IsNullOrEmpty(equationTextBox.Text)) return;

            char sign = equationTextBox.Text[equationTextBox.Text.Length - 1];

            if (sign != '+' && sign != '-' && sign != 'x' && sign != '/' && sign != '.')
                equationTextBox.Text += b.Content;

            dotAvailable = true;

            newNumber = true;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            if (String.IsNullOrEmpty(equationTextBox.Text)) return;

            if (b.Name == "CE")
            {
                resultNumberTextBox.Text = String.Empty;
            }
            else if (b.Name == "C")
            {
                resultNumberTextBox.Text = String.Empty;
                equationTextBox.Text = String.Empty;

                isFirstNumber = true;
                newNumber = true;
            }
            else if (b.Name == "deleteButton")
            {
                int equationLength = equationTextBox.Text.Length;
                char lastChar = 'n';
                char prevToLastChar = 'n';


                if (equationLength >= 1)
                    lastChar = equationTextBox.Text[equationTextBox.Text.Length - 1];  // char to delete

                if (equationLength >= 2)
                    prevToLastChar = equationTextBox.Text[equationTextBox.Text.Length - 2];


                if (lastChar == '.')
                {
                    dotAvailable = true;
                    if (prevToLastChar == '0')
                        newNumber = false;
                }

                else if (prevToLastChar == '+' || prevToLastChar == '-' || prevToLastChar == 'x' || prevToLastChar == '/')
                {
                    newNumber = true;
                }

                equationTextBox.Text = equationTextBox.Text.Remove(equationTextBox.Text.Length - 1, 1);

                if (String.IsNullOrEmpty(equationTextBox.Text))
                {
                    newNumber = true;
                    isFirstNumber = true;
                }
            }
        }


        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            string eq = equationTextBox.Text;

            if (eq[eq.Length - 1] == '+' || eq[eq.Length - 1] == '/' || eq[eq.Length - 1] == 'x' || eq[eq.Length - 1] == '-')
                return;
            if (String.IsNullOrEmpty(eq)) return;


            if (!String.IsNullOrEmpty(eq))
            {
                Double res = 0;

                try
                {
                    string prevNumStr = "";
                    string currNumStr = "";
                    double prevNum;
                    double currNum;
                    String sign = String.Empty;

                    bool first = true;

                    for (int i = 0; i < eq.Length; i++)
                    {
                        if (eq[i] == '+' || eq[i] == '-' || eq[i] == 'x' || eq[i] == '/')  // takes sign
                        {
                            if (sign != String.Empty)
                            {
                                if (sign == "+")
                                    res += Double.Parse(currNumStr);

                                else if (sign == "-")
                                    res -= Double.Parse(currNumStr);

                                else if (sign == "x")
                                    res *= Double.Parse(currNumStr);

                                else if (sign == "/")
                                    res /= Double.Parse(currNumStr);
                                //MessageBox.Show($"Res: {res} sign: {sign}");


                                currNumStr = String.Empty;
                            }



                            sign = eq[i].ToString();

                            if (first)
                            {
                                first = false;
                                res = Double.Parse(currNumStr);
                                currNumStr = String.Empty;
                                //MessageBox.Show($"first res: {res}");
                            }
                        }

                        else // takes number
                        {
                            currNumStr += eq[i];
                        }
                    }


                    if (sign != String.Empty)
                    {
                        if (sign == "+")
                            res += Double.Parse(currNumStr);

                        else if (sign == "-")
                            res -= Double.Parse(currNumStr);

                        else if (sign == "x")
                            res *= Double.Parse(currNumStr);

                        else if (sign == "/")
                            res /= Double.Parse(currNumStr);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Message: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                resultNumberTextBox.Text = res.ToString();
            }
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(equationTextBox.Text)) return;

            char c = equationTextBox.Text[equationTextBox.Text.Length - 1];  // previoues to dot character

            if ((c == '0' || c == '1' || c == '2' || c == '3' ||
                c == '4' || c == '5' || c == '6' ||
                c == '7' || c == '8' || c == '9') && dotAvailable)
            {
                equationTextBox.Text += ".";
                dotAvailable = false;
            }
        }
    }
}
