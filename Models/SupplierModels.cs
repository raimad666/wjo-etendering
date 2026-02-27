using System.ComponentModel.DataAnnotations;

namespace WafraJointOperations.Models
{
    public class SupplierRegistrationModel
    {
        [Required(ErrorMessage = "Company name is required")]
        [StringLength(200)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Registration number is required")]
        [StringLength(100)]
        public string RegistrationNumber { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(100)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(200)]
        public string City { get; set; }

        [StringLength(20)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Business category is required")]
        public string BusinessCategory { get; set; }

        [Required(ErrorMessage = "Please describe your services")]
        [StringLength(1000)]
        public string ServicesOffered { get; set; }

        [StringLength(500)]
        public string Website { get; set; }

        [Range(1, 10000, ErrorMessage = "Please enter number of employees")]
        public int? NumberOfEmployees { get; set; }

        [Required(ErrorMessage = "You must accept the terms and conditions")]
        public bool AcceptTerms { get; set; }

        public DateTime SubmittedDate { get; set; } = DateTime.Now;
    }

    public class InquiryModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [StringLength(200)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(200)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(2000)]
        public string Message { get; set; }

        public DateTime SubmittedDate { get; set; } = DateTime.Now;
    }

    public class FAQItem
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
