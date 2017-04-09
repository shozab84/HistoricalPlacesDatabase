using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace DatabaseTest.Models
{
    public class HistoricalPlaces
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Location is Required")]
        [Display(Name = "Location")]
        public string State { get; set; }
        [Required(ErrorMessage = "Built is Required")]
        [Display(Name = "Built")]
        public int Year { get; set; }
        public string Picture { get; set; }

        [Required(ErrorMessage = "History is Required")]
        public string History { get; set; }

        [Required(ErrorMessage = "Architecture is Required")]
        public string Architecture { get; set; }

    }

}

    

    
    

