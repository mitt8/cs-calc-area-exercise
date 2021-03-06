﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cs_calc_area_exercise.Models
{
    //Glass class
    //calculates area(integer) and circumference(string) values for given glass dimensions
    public class Glass
    {
        
        private readonly int width;
        private readonly int length;

        public readonly int area;
        public readonly string cRef;

        //Glass consturctor takes 4 arguments, inch(integer) and fraction(string) for both width and length
        //fraction variable format should match with Dimension class's frac List ex: 1/2, 1/8, 3/8 etc.
        public Glass(int wI, string wF, int lI, string lF)
        {
            double wFrac = ConvertFractionToDouble(wF);
            double lFrac = ConvertFractionToDouble(lF);


            width = RoundDimension(wI, wFrac);
            length = RoundDimension(lI, lFrac);

            area = CalcArea(width, length);
            cRef = CalcRef(wI, wFrac, lI, lFrac);

            

        }

        // Returns passed fraction string's double value
        private double ConvertFractionToDouble(string frac)
        {
            if (frac.Contains('/'))
            {
                string[] subString = frac.Split('/');
                return (double)Int32.Parse(subString[0]) / Int32.Parse(subString[1]);
            }
            else { return 0; }
        }

       


        //Rounds up given (int)inch and (double)fraction values to even integer
        private int RoundDimension(int inch, double frac){
            if (frac != 0){
                inch++;
            }
            if (inch % 2 == 0){
                    return inch;
            }
            else{
                    return RoundDimension(inch+1, 0);
                }
        }

        //Calculates area for given width and length integer
        // min returned area is 3sq. ft per requirement
        private int CalcArea(int w, int l)
        {
            if ((int)Math.Ceiling((double)(w * l) / 144) > 3) {
                return (int)Math.Ceiling((double)(w * l) / 144);
            }
            else{
                return 3;
            }
        }

        
        //Circumference calculation for given inch(integer) and fraction(double) values for both width and length
        //returns 
        private string CalcRef(int wI, double wF, int lI, double lF)
        {
            //raw circumference value 
            double cRef = ((wI + wF) + (lI + lF)) * 2;

            //if the result has fraction part we need to convert it to string representation 
            if ((cRef - Math.Truncate(cRef)) != 0)
            {
                return Math.Truncate(cRef).ToString() + " " + Dimension.convertFractionDoubleToString(cRef - Math.Truncate(cRef)) + "\"";
            }
            else
            {
                return cRef.ToString() + "\"";
            }
         }


    }




}