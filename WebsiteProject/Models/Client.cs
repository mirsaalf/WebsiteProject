using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace WebsiteProject.Models

    /// <summary>
    /// Represents a client
    /// </summary>
{
    public class Clients { 
        /// <summary>
        /// identifier for the client
        /// </summary>

        [Key]
        public int ClientID { get; set; }

        /// <summary>
        /// Clients first name
        /// </summary>
       
        [Display(Name = "First Name")]
        [StringLength(25)]
        [Required(ErrorMessage = "Field is required")]

        public string FirstName { get; set; }

        /// <summary>
        /// Clients last name
        /// </summary>

        [StringLength(25)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Field is required")]

        public string LastName { get; set; }

        /// <summary>
        /// Clients date of birth
        /// </summary>

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Field is required")]

        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Clients phone number
        /// </summary>

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Field is required")]

        public string PhoneNumber { get; set; }

        /// <summary>
        /// Clients email address
        /// </summary>

        [Display(Name = " Email Address")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address, Try Again")]
        [Required(ErrorMessage = "Field is required")]

        public string Email { get; set; }
    }
}
