using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cs_calc_area_exercise.Models
{
    public class Glass
    {
        //make private 
        public readonly int width;
        public readonly int length;

        public readonly int area;
        public readonly string cRef;
        public int Id { get; set; }


        public Glass(int wI, string wF, int lI, string lF)
        {
            double wFrac = ConvertFractionToDouble(wF);
            double lFrac = ConvertFractionToDouble(lF);


            width = RoundDimension(wI, wFrac);
            length = RoundDimension(lI, lFrac);

            area = CalcArea(width, length);
            cRef = CalcRef(wI, wFrac, lI, lFrac);
        }


        private double ConvertFractionToDouble(string frac)
        {
            if (frac.Contains('/'))
            {
                string[] subString = frac.Split('/');
                return (double)Int32.Parse(subString[0]) / Int32.Parse(subString[1]);
            }
            else { return 0; }
        }

       


        //Rounds up given (int)inch and (double)fraction values to nearest integer
        private int RoundDimension(int inch, double frac){
            if (frac != 0){
                return inch += (inch & 1);
            }
            else{
                return inch;
            }
        }


        private int CalcArea(int w, int l)
        {
            if ((int)Math.Ceiling((double)(w * l) / 144) > 3) {
                return (int)Math.Ceiling((double)(w * l) / 144);
            }
            else{
                return 3;
            }
        }

        private string ConvertFractionToString(double frac)
        {
            return frac.ToString();

        }

        private string CalcRef(int wI, double wF, int lI, double lF)
        {
            double cRef = ((wI + wF) + (lI + lF)) * 2;

            if ((cRef - Math.Truncate(cRef)) != 0)
            {
                string cRefString = (cRef - Math.Truncate(cRef)).ToString();
                int length = (cRefString.Substring(cRefString.IndexOf(".")).Length - 1);

                string[] subString = cRefString.Split('.');

                int a = Convert.ToInt32(subString[1]);
                int b = (int)Math.Pow(10, (double)length);

                int gcd = GCDRecursive(a, b);

                return Math.Truncate(cRef).ToString() + " " + (a / gcd).ToString() + "/" + (b / gcd).ToString() + "\"";

            }
            else
            {
                return cRef.ToString() + "\"";
            }
         }

        private int GCDRecursive(int a, int b)
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