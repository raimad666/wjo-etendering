using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WafraJointOperations.Models;
using System.Collections.Generic;

namespace WafraJointOperations.Pages
{
    public class SupplierRegistrationPageModel : PageModel
    {
        [BindProperty]
        public SupplierRegistrationModel Registration { get; set; }

        [BindProperty]
        public InquiryModel Inquiry { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public List<FAQItem> FAQs { get; set; }

        public void OnGet()
        {
            LoadFAQs();
        }

        public async Task<IActionResult> OnPostRegisterAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadFAQs();
                ErrorMessage = "Please correct the errors in the registration form.";
                return Page();
            }

            try
            {
                // TODO: Save to database
                // Example:
                // await _dbContext.SupplierRegistrations.AddAsync(Registration);
                // await _dbContext.SaveChangesAsync();

                // TODO: Send confirmation email
                // await _emailService.SendSupplierConfirmationEmail(Registration.Email, Registration.CompanyName);

                // TODO: Notify admin team
                // await _emailService.SendAdminNotification(Registration);

                SuccessMessage = $"Thank you, {Registration.CompanyName}! Your registration has been submitted successfully. Our team will review your application and contact you within 3-5 business days.";
                
                // Clear form
                ModelState.Clear();
                Registration = new SupplierRegistrationModel();
                
                LoadFAQs();
                return Page();
            }
            catch (Exception ex)
            {
                // TODO: Log error
                // _logger.LogError(ex, "Error processing supplier registration");
                
                ErrorMessage = "An error occurred while processing your registration. Please try again or contact us directly.";
                LoadFAQs();
                return Page();
            }
        }

        public async Task<IActionResult> OnPostInquiryAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadFAQs();
                ErrorMessage = "Please correct the errors in the inquiry form.";
                return Page();
            }

            try
            {
                // TODO: Save inquiry to database
                // await _dbContext.Inquiries.AddAsync(Inquiry);
                // await _dbContext.SaveChangesAsync();

                // TODO: Send inquiry email to support team
                // await _emailService.SendInquiryToSupport(Inquiry);

                // TODO: Send confirmation to inquirer
                // await _emailService.SendInquiryConfirmation(Inquiry.Email, Inquiry.Name);

                SuccessMessage = $"Thank you, {Inquiry.Name}! Your inquiry has been received. We will respond to your question within 24-48 hours.";
                
                // Clear form
                ModelState.Clear();
                Inquiry = new InquiryModel();
                
                LoadFAQs();
                return Page();
            }
            catch (Exception ex)
            {
                // TODO: Log error
                // _logger.LogError(ex, "Error processing inquiry");
                
                ErrorMessage = "An error occurred while submitting your inquiry. Please try again or contact us directly.";
                LoadFAQs();
                return Page();
            }
        }

        private void LoadFAQs()
        {
            FAQs = new List<FAQItem>
            {
                new FAQItem
                {
                    Question = "What are the requirements to become a supplier for Wafra Joint Operations?",
                    Answer = "To become a supplier, you must have a valid business registration, provide proof of insurance, meet our quality standards, and comply with all applicable regulations. You'll need to complete the registration form above and submit required documentation for review."
                },
                new FAQItem
                {
                    Question = "How long does the registration process take?",
                    Answer = "The initial review of your registration typically takes 3-5 business days. Once approved, you'll be contacted by our procurement team to complete the onboarding process, which may take an additional 1-2 weeks depending on your business category."
                },
                new FAQItem
                {
                    Question = "What documents do I need to provide?",
                    Answer = "Required documents include: Business registration certificate, Tax registration, Insurance certificates (liability and workers' compensation), Company profile, Financial statements (last 2 years), Quality certifications (if applicable), and References from previous clients."
                },
                new FAQItem
                {
                    Question = "Can international companies register as suppliers?",
                    Answer = "Yes, we welcome international suppliers. However, you must be able to operate legally in our jurisdiction and meet all local regulatory requirements. Additional documentation may be required for international companies."
                },
                new FAQItem
                {
                    Question = "What business categories do you accept?",
                    Answer = "We work with suppliers across various categories including: Construction & Engineering, Oil & Gas Services, IT & Technology, Logistics & Transportation, Catering & Hospitality, Safety Equipment, Office Supplies, Consulting Services, and more."
                },
                new FAQItem
                {
                    Question = "Is there a fee to register as a supplier?",
                    Answer = "No, there is no registration fee. The supplier registration process is completely free of charge."
                },
                new FAQItem
                {
                    Question = "How will I know if my registration is approved?",
                    Answer = "You will receive an email notification at the address provided in your registration form. Our procurement team will contact you directly to discuss next steps and provide access to our supplier portal."
                },
                new FAQItem
                {
                    Question = "What happens after I'm approved?",
                    Answer = "Once approved, you'll receive access to our supplier portal where you can view tender opportunities, submit quotations, track orders, and manage invoices. You'll also be assigned a procurement contact person for ongoing support."
                },
                new FAQItem
                {
                    Question = "Can I update my company information after registration?",
                    Answer = "Yes, you can update your information through the supplier portal once you're registered. For major changes, please contact our procurement team directly."
                },
                new FAQItem
                {
                    Question = "Who can I contact if I have additional questions?",
                    Answer = "You can submit your questions using the inquiry form on this page, or contact our procurement team directly at jopsuppliersmanagers@chevron.com or call +965-23983639 during business hours (Sunday-Thursday, 7:00 AM - 3:00 PM)."
                }
            };
        }
    }
}
