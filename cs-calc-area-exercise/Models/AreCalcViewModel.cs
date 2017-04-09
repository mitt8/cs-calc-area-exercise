using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace cs_calc_area_exercise.Models
{
    //Model for Home Index view
    //includes a glass object and Dimension model for dropdownlist values
    public class AreaCalcViewModel
    {
        
        public cs_calc_area_exercise.Models.Dimension dimensions;
        public cs_calc_area_exercise.Models.Glass glass;

       
        public string SelectedFracWidth { get; set; }
        [Required(ErrorMessage = "Inch value is required ")]
        public int SelectedInchWidth { get; set; }

        public string SelectedFracLength { get; set; }
        [Required(ErrorMessage = "Inch value is required ")]
        public int SelectedInchLength { get; set; }




        public IEnumerable<SelectListItem> FracValue
        {
            get { return new SelectList(dimensions.frac,"frac");}
        }
        public IEnumerable<SelectListItem> InchValue
        {
            get { return new SelectList(dimensions.inch, "inch"); }
        }

        //create dimension model for dropdownlist values
        public  AreaCalcViewModel()
        {
            
            dimensions = new Dimension();
        }
    }
}