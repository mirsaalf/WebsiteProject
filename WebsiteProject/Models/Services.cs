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
        /// Title of the services being offered        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Price of the service 
        /// </summary>
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
    }
}
