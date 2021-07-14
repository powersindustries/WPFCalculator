using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WPFCalculator
{
    public enum SelectedOperator
    {
        eAddition,
        eSubtraction,
        eMultiplication,
        eDivision
    }


    public class MathMethods
    {


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        public static double Add(double input1, double input2)
        {
            return input1 + input2;
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        public static double Subtract(double input1, double input2)
        {
            return input1 - input2;
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        public static double Multiply(double input1, double input2)
        {
            return input1 * input2;
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        public static double Divide(double input1, double input2)
        {
            // Error handle for divide by zero
            if (input2 == 0)
            {
                MessageBox.Show("You are attempting to divide by zero.", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return input1 / input2;
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        public static double Fraction(double input)
        {
            // Error handle for divide by zero
            if (input == 0)
            {
                MessageBox.Show("You are attempting to divide by zero.", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return 1 / input;
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        public static double Squared(double input)
        {
            return input * input;
        }


        // -------------------------------------------------------------------------
        // -------------------------------------------------------------------------
        public static double SquareRoot(double input)
        {
            return Math.Sqrt(input);
        }

    }
}
