using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cs_calc_area_exercise.Models
{
    //calculates inch and fraction values for dropdownlist
    public class Dimension
    {
        
        public readonly List<int> inch;
        public readonly List<string> frac;


        //cunstructor generates inch and frac lists
        // these values are set per given requirement
        // inch : 3-120
        // frac 0, 1/8, 1/4, 3/8, 1/2, 5/8, 3/4, 7/8
        public Dimension()
        {
            //Inch options are limited from 3 to 120 per requirement
            inch = setInchValues(3,120);
            frac = setFrachValues();
        }

        //inch options takes two integers for lower and upper limit
        private List<int> setInchValues(int lowerLimit,int upperLimit)
        {
            List<int> values = new List<int>();
            for (int i = lowerLimit; i <= upperLimit; i++)
            {
                values.Add(i);
            }
            return values;

        }

      


        //fraction options
        private List<string> setFrachValues()
        {
            double fraction = 0.125;
            List<string> values = new List<string>();

            
                for (int k = 0; k < 8; k++)
                {
                    if (k != 0)
                    {
                        values.Add(convertFractionDoubleToString(fraction * k));
                    }
                    else if (k == 0)
                    {
                        values.Add("0");
                    }
                }

            return values;

        }

        //converts given double value to string representation
        public static string convertFractionDoubleToString(double fraction)
        {

            string cRefString = fraction.ToString();

            int length = (cRefString.Substring(cRefString.IndexOf(".")).Length - 1);

            string[] subString = cRefString.Split('.');


            int a = Convert.ToInt32(subString[1]);

            int b = (int)Math.Pow(10, (double)length);

            int gcd = GCDRecursive(a, b);
            return (a / gcd).ToString() + "/" + (b / gcd).ToString();
        }

        //returns greatest common divisor for given two integers
        private static int GCDRecursive(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            if (a > b)
                return GCDRecursive(a % b, b);
            else
                return GCDRecursive(a, b % a);
        }

    }
}