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
            List<string> values = new List<string>();

            //temp solution
            values.Add("0");
            values.Add("1/8");
            values.Add("1/4");
            values.Add("3/8");
            values.Add("1/2");
            values.Add("5/8");
            values.Add("3/4");
            values.Add("7/8");

            return values;

        }

    }
}