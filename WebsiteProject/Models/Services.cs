using System.ComponentModel.DataAnnotations;

namespace WebsiteProject.Models
{
    /// <summary>
    /// Represents a single service available for purchase
    /// </summary>
    public class Services
    {
        /// <summary>
        /// The Unique Identifier for each service
        /// </summary>
        [Key]
        public int ServiceID { get; set; }

        /// <summary>
        /// Title of the services being offered
        /// </summary>

        [Display(Name = "Service Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Field is required")]
        public string ServiceName { get; set; }

        /// <summary>
        /// Price of the service 
        /// </summary>
        [Range(0, double.MaxValue)]
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Field is required")]
        public double ServicePrice { get; set; }

        [Display(Name = "Description")]
        [StringLength(300)]
        [Required(ErrorMessage = "Field is required")]

        public string ServiceDescription { get; set; }
    }
}
