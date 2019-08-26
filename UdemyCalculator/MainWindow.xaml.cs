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

namespace UdemyCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result, firstNumber;
        SelectedOperator SelectedOperator;
        bool percantageClicked;
        public MainWindow()
        {
            InitializeComponent();            
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)            //DRY!!! percantage chalenge
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {                          
                switch (SelectedOperator)
                {
                    case SelectedOperator.Addition:
                        if (percantageClicked)
                            newNumber = firstNumber * newNumber;
                        result = SimpleMath.Add(firstNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        if (percantageClicked)              
                            newNumber = firstNumber * newNumber;
                        result = SimpleMath.Substraction(firstNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiplication(firstNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Division(firstNumber, newNumber);
                        break;
                }
                percantageClicked = false;
                resultLabel.Content = result;                
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = lastNumber / 100;
                percantageClicked = true;
            }                
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            percantageClicked = false;
            
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                firstNumber = double.Parse(resultLabel.Content.ToString());
                resultLabel.Content = "0";
            }            
                            
            if(sender == divisionButton)
                SelectedOperator = SelectedOperator.Division;
            if (sender == multiplicationButton)
                SelectedOperator = SelectedOperator.Multiplication;
            if (sender == plusButton)
                SelectedOperator = SelectedOperator.Addition;
            if (sender == minusButton)
                SelectedOperator = SelectedOperator.Substraction;            
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string selectedValue = button.Content.ToString();
            if (resultLabel.Content.ToString() == "0")
                resultLabel.Content = selectedValue;
            else
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains(','))
                resultLabel.Content = $"{resultLabel.Content},";
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
                lastNumber = -lastNumber;
            resultLabel.Content = lastNumber;
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = 0;
            result = 0;
            lastNumber = 0;
        }

    }

    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }

    public static class SimpleMath
    {
        public static double Add(double firstOperator, double secondOperator)
        {
            return firstOperator + secondOperator;
        }

        public static double Substraction(double firstOperator, double secondOperator)
        {
            return firstOperator - secondOperator;
        }
        public static double Division(double firstOperator, double secondOperator)
        {
            if(secondOperator != 0)
                return firstOperator / secondOperator;

            MessageBox.Show("Division by 0 not supporting", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
            return 0;
        }
        public static double Multiplication(double firstOperator, double secondOperator)
        {
            return firstOperator * secondOperator;
        }
    }
}
