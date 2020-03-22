using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolPortal.Models
{
    public class Teacher
    {

      
        public int TeacherId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter Teachers's First Name")]
        [StringLength(12, ErrorMessage = "Maximum Length Of Characters Allowed Is 12")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please Enter Teachers's  Surname")]
        [StringLength(12, ErrorMessage = "Maximum Length Of Characters Allowed Is 12")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please Select Teacher's Email Address")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Please Enter Teacher's Date Of Birth")]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please Enter Teacher's Employment Start Date")]
        [Display(Name = "Employment Start Date")]
        public DateTime EmploymentStartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        [Required]
        [Display(Name = "House Name or House Number")]
        public string HouseNumberOrName { get; set; }

        [Required]
        [Display(Name = "First Line Of Address")]
        public string FirstLineofAdd { get; set; }

        [Required]
        [Display(Name = "Second Line Of Address")]
        public string SecondLineofAdd { get; set; }

        [Required]
        [Display(Name = "Area")]
        public string Area { get; set; }


        public virtual ICollection<Student> Students { get; set; }




        //relationship Navigation Properties for viewmodels
        [Display(Name = "Class")]
        [Required(ErrorMessage = "Please Select Teacher's Class")]
        public int YearId { get; set; }
        public virtual Year Year { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage ="Please Select Teacher's Title")]
        public int TitleId { get; set; }
        public virtual Title Title { get; set; }


        


    }
}