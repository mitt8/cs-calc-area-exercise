using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cs_calc_area_exercise.Models
{
    public class Dimension
    {
        public readonly List<int> inch;
        public readonly List<string> frac;



        public Dimension()
        {
           
            inch = setInchValues(3,120);
            frac = setFrachValues();
        }

        private List<int> setInchValues(int lowerLimit,int upperLimit)
        {
            List<int> values = new List<int>();
            for (int i = lowerLimit; i <= upperLimit; i++)
            {
                values.Add(i);
            }
            return values;

        }
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