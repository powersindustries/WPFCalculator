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

namespace WPFCalculator
{
    public partial class MainWindow : Window
    {
        double m_LastNumber;
        double m_Result;
        SelectedOperator m_SelectedOperator;


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

            ClearButton.Click += ClearButton_Click;
            SingleClearButton.Click += ClearButton_Click;
            NegativeButton.Click += NegativeButton_Click;
            PercentButton.Click += PercentButton_Click;
            EqualsButton.Click += EqualsButton_Click;
            DecimalButton.Click += DecimalButton_Click;

            DivideButton.Click += OperationButton_Click;
            MultiplyButton.Click += OperationButton_Click;
            AddButton.Click += OperationButton_Click;
            SubtractButton.Click += OperationButton_Click;

            FractionButton.Click += SingleCalculationButton_Click;
            SquareButton.Click += SingleCalculationButton_Click;
            SquareRootButton.Click += SingleCalculationButton_Click;
            BackspaceButton.Click += BackspaceButton_Click;

            ZeroButton.Click += NumberButton_Click;
            OneButton.Click += NumberButton_Click;
            TwoButton.Click += NumberButton_Click;
            ThreeButton.Click += NumberButton_Click;
            FourButton.Click += NumberButton_Click;
            FiveButton.Click += NumberButton_Click;
            SixButton.Click += NumberButton_Click;
            SevenButton.Click += NumberButton_Click;
            EightButton.Click += NumberButton_Click;
            NineButton.Click += NumberButton_Click;

        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            int resultLabelLength = ResultLabel.Content.ToString().Length;
            if (resultLabelLength > 1)
            {
                ResultLabel.Content = ResultLabel.Content.ToString().Remove(resultLabelLength - 1, 1);
            }
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        private void SingleCalculationButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                if (sender == FractionButton)
                {
                    m_Result = MathMethods.Fraction(newNumber);
                }

                if (sender == SquareButton)
                {
                    m_Result = MathMethods.Squared(newNumber);
                }

                if (sender == SquareRootButton)
                {
                    m_Result = MathMethods.SquareRoot(newNumber);
                }
                
                ResultLabel.Content = m_Result.ToString();
            }
        
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResultLabel.Content.ToString().Contains("."))
            {
                return;
            }

            ResultLabel.Content = $"{ResultLabel.Content}.";
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                switch (m_SelectedOperator)
                {
                    case SelectedOperator.eAddition:
                        m_Result = MathMethods.Add(m_LastNumber, newNumber);
                        break;
                    case SelectedOperator.eSubtraction:
                        m_Result = MathMethods.Subtract(m_LastNumber, newNumber);
                        break;
                    case SelectedOperator.eMultiplication:
                        m_Result = MathMethods.Multiply(m_LastNumber, newNumber);
                        break;
                    case SelectedOperator.eDivision:
                        m_Result = MathMethods.Divide(m_LastNumber, newNumber);
                        break;
                }

                ResultLabel.Content = m_Result.ToString();
            }
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out m_LastNumber))
            {
                m_LastNumber = m_LastNumber / 100;
                ResultLabel.Content = m_LastNumber.ToString();
            }
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResultLabel.Content.ToString() != "0" && double.TryParse(ResultLabel.Content.ToString(), out m_LastNumber))
            {
                m_LastNumber = m_LastNumber * -1;
                ResultLabel.Content = m_LastNumber.ToString();
            }
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out m_LastNumber))
            {
                ResultLabel.Content = "0";
            }

            if (sender == AddButton)
            {
                m_SelectedOperator = SelectedOperator.eAddition;
            }
            if (sender == SubtractButton)
            {
                m_SelectedOperator = SelectedOperator.eSubtraction;
            }
            if (sender == MultiplyButton)
            {
                m_SelectedOperator = SelectedOperator.eMultiplication;
            }
            if (sender == DivideButton)
            {
                m_SelectedOperator = SelectedOperator.eDivision;
            }
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            // Cast button 
            int selectedValue = Int16.Parse((sender as Button).Content.ToString());

            if (ResultLabel.Content.ToString() == "0")
            {
                ResultLabel.Content = $"{selectedValue}";
            }
            else
            {
                ResultLabel.Content = $"{ResultLabel.Content}{selectedValue}";
            }
        }
    }
}
