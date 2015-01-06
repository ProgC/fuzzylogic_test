using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Fuzzy
{
    public static double FuzzyGrade(double value, double x0, double x1)
    {
        double result = 0;
        double x = value;

        if (x <= x0)
            result = 0;
        else if (x >= x1)
            result = 1;
        else
            result = (x - x0) / (x1 - x0);

        return result;
    }

    public static double FuzzyReverseGrade(double value, double x0, double x1)
    {
        double result = 0;
        double x = value;

        if (x <= x0)
            result = 1;
        else if (x >= x1)
            result = 0;
        else
            result = (-x + x1) / (x1 - x0);

        return result;
    }

    public static double FuzzyTriangle(double value, double x0, double x1, double x2)
    {
        double result = 0;
        double x = value;

        if (x <= x0)
            result = 0;
        else if (x == x1)
            result = 1;
        else if (x > x0 && x < x1)
            result = (x - x0) / (x1 - x0);
        else
            result = (-x + x2) / (x2 - x1);

        return result;
    }

    public static double FuzzyTrapezoid(double value, double x0, double x1, double x2, double x3)
    {
        double result = 0;
        double x = value;

        if (x <= x0)
            result = 0;
        else if (x >= x1 && x <= x2)
            result = 1;
        else if (x > x0 && x < x1)
            result = (x - x0) / (x1 - x0);
        else
            result = (-x + x3) / (x3 - x2);

        return result;
    }

    public static double AND(double a, double b)
    {
        return Math.Min(a, b);
    }

    public static double OR(double a, double b)
    {
        return Math.Max(a, b);
    }

    public static double NOT(double a)
    {
        return 1 - a;
    }
}

