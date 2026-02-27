# Supplier Registration Page - Integration Guide

## Overview
This document provides instructions for integrating the Supplier Registration page into your Wafra Joint Operations .NET website.

## Files Created

### 1. Backend Files
- **`Models/SupplierModels.cs`** - Data models for supplier registration and inquiries
- **`Pages/SupplierRegistration.cshtml.cs`** - PageModel with form handling logic

### 2. Frontend Files
- **`Pages/SupplierRegistration.cshtml`** - Main Razor page with HTML structure
- **`wwwroot/css/supplier-registration.css`** - Stylesheet with modern design
- **`wwwroot/js/supplier-registration.js`** - JavaScript for interactive features

## Integration Steps

### Step 1: Add to Your ASP.NET Core Project

1. **Copy Files to Your Project**
   - Copy all files to their respective directories in your project
   - Ensure the folder structure matches your existing project structure

2. **Update Namespace** (if needed)
   - Open `Models/SupplierModels.cs`
   - Change `namespace WafraJointOperations.Models` to match your project namespace
   - Open `Pages/SupplierRegistration.cshtml.cs`
   - Change `namespace WafraJointOperations.Pages` to match your project namespace
   - Update the `using` statement to reference your Models namespace

### Step 2: Configure Database Connection

The page currently has placeholder code for database operations. You need to implement actual database connectivity:

#### Option A: Entity Framework Core (Recommended)

1. **Add DbContext**
   ```csharp
   public class ApplicationDbContext : DbContext
   {
       public DbSet<SupplierRegistrationModel> SupplierRegistrations { get; set; }
       public DbSet<InquiryModel> Inquiries { get; set; }
   }
   ```

2. **Update PageModel Constructor**
   ```csharp
   private readonly ApplicationDbContext _dbContext;
   
   public SupplierRegistrationPageModel(ApplicationDbContext dbContext)
   {
       _dbContext = dbContext;
   }
   ```

3. **Uncomment Database Code**
   - In `OnPostRegisterAsync()` method, uncomment:
     ```csharp
     await _dbContext.SupplierRegistrations.AddAsync(Registration);
     await _dbContext.SaveChangesAsync();
     ```
   - In `OnPostInquiryAsync()` method, uncomment:
     ```csharp
     await _dbContext.Inquiries.AddAsync(Inquiry);
     await _dbContext.SaveChangesAsync();
     ```

4. **Run Migrations**
   ```bash
   dotnet ef migrations add AddSupplierRegistration
   dotnet ef database update
   ```

#### Option B: Direct SQL Connection

If you prefer direct SQL queries, implement your own data access layer and call it from the PageModel methods.

### Step 3: Configure Email Service

The page has placeholder code for sending emails. Implement email functionality:

1. **Install Email Package** (if not already installed)
   ```bash
   dotnet add package MailKit
   ```

2. **Create Email Service**
   ```csharp
   public interface IEmailService
   {
       Task SendSupplierConfirmationEmail(string email, string companyName);
       Task SendAdminNotification(SupplierRegistrationModel registration);
       Task SendInquiryToSupport(InquiryModel inquiry);
       Task SendInquiryConfirmation(string email, string name);
   }
   ```

3. **Implement Email Service**
   - Configure SMTP settings in `appsettings.json`
   - Inject `IEmailService` into the PageModel constructor
   - Uncomment email-related code in the PageModel

4. **Update appsettings.json**
   ```json
   {
     "EmailSettings": {
       "SmtpServer": "smtp.your-server.com",
       "SmtpPort": 587,
       "SenderEmail": "noreply@wafrajointops.com",
       "SenderName": "Wafra Joint Operations",
       "AdminEmail": "jopsuppliersmanagers@chevron.com"
     }
   }
   ```

### Step 4: Update Contact Information

1. Open `Pages/SupplierRegistration.cshtml`
2. Find the contact section near the bottom
3. Replace placeholder contact details:
   - Email: `jopsuppliersmanagers@chevron.com`
   - Phone: `+965-23983639`
   - Business hours: 7:00 AM - 3:00 PM

### Step 5: Customize Branding

1. **Update Colors** (optional)
   - Open `wwwroot/css/supplier-registration.css`
   - Modify CSS variables at the top to match your brand colors:
     ```css
     :root {
         --primary-color: #0066cc;  /* Your primary color */
         --secondary-color: #00a86b; /* Your secondary color */
     }
     ```

2. **Add Logo** (optional)
   - Add your company logo to the hero section
   - Modify the hero section in `SupplierRegistration.cshtml`

### Step 6: Add Navigation Link

Add a link to the supplier registration page in your website's navigation:

```html
<a href="/SupplierRegistration">Supplier Registration</a>
```

Or if using Razor syntax:
```html
<a asp-page="/SupplierRegistration">Supplier Registration</a>
```

### Step 7: Configure Routing (if needed)

If you want a custom URL, add routing in `Program.cs` or `Startup.cs`:

```csharp
app.MapRazorPages();
```

For a custom route, add to the page:
```csharp
@page "/suppliers/register"
```

## Testing

### 1. Local Testing
1. Run your application: `dotnet run`
2. Navigate to `/SupplierRegistration`
3. Test the registration form with sample data
4. Test the inquiry form
5. Verify FAQ accordion functionality
6. Test on mobile devices (responsive design)

### 2. Validation Testing
- Test required field validation
- Test email format validation
- Test phone number validation
- Test character limits on text areas

### 3. Form Submission Testing
- Submit registration form and verify data is saved
- Submit inquiry form and verify emails are sent
- Test error handling (disconnect database to test error messages)

## Security Considerations

1. **CSRF Protection** - Already included via ASP.NET Core's built-in anti-forgery tokens
2. **Input Validation** - Server-side validation is implemented with Data Annotations
3. **SQL Injection** - Use parameterized queries (Entity Framework handles this)
4. **XSS Protection** - Razor automatically encodes output

### Additional Security Recommendations:
- Implement rate limiting to prevent spam submissions
- Add CAPTCHA for production (Google reCAPTCHA recommended)
- Enable HTTPS (should already be configured in production)
- Sanitize file uploads if you add document upload functionality

## Production Deployment Checklist

- [ ] Update all placeholder contact information
- [ ] Configure database connection string
- [ ] Configure email SMTP settings
- [ ] Test all forms with real data
- [ ] Verify email notifications are sent
- [ ] Test on multiple browsers (Chrome, Firefox, Safari, Edge)
- [ ] Test responsive design on mobile devices
- [ ] Add CAPTCHA to prevent spam
- [ ] Configure logging for form submissions
- [ ] Set up monitoring for failed submissions
- [ ] Review and update FAQ content
- [ ] Update Terms & Conditions link
- [ ] Enable SSL/HTTPS
- [ ] Configure backup for submitted data

## Customization Options

### Adding File Upload
To add document upload functionality:

1. Add to the model:
   ```csharp
   public IFormFile BusinessRegistration { get; set; }
   public IFormFile InsuranceCertificate { get; set; }
   ```

2. Add to the form:
   ```html
   <input type="file" asp-for="Registration.BusinessRegistration" />
   ```

3. Handle in PageModel:
   ```csharp
   if (Registration.BusinessRegistration != null)
   {
       var filePath = Path.Combine("uploads", Registration.BusinessRegistration.FileName);
       using (var stream = new FileStream(filePath, FileMode.Create))
       {
           await Registration.BusinessRegistration.CopyToAsync(stream);
       }
   }
   ```

### Adding CAPTCHA
To add Google reCAPTCHA:

1. Install package: `dotnet add package reCAPTCHA.AspNetCore`
2. Add to form in `.cshtml`
3. Validate in PageModel before processing

### Customizing FAQ
Edit the `LoadFAQs()` method in `SupplierRegistration.cshtml.cs` to modify questions and answers.

## Support

For technical support or questions about integration:
- Review ASP.NET Core documentation: https://docs.microsoft.com/aspnet/core
- Check Entity Framework Core docs: https://docs.microsoft.com/ef/core

## Version History
- **v1.0** - Initial release with registration form, inquiry form, and FAQ section
