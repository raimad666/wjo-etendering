# Supplier Registration Page - Wafra Joint Operations

A comprehensive, production-ready supplier registration page built with ASP.NET Core.

## 🚀 Quick Start

### Option 1: Preview Demo (Immediate)

1. **Open the demo file in your browser:**
   - Double-click `demo.html` to open in your default browser
   - Or right-click → Open with → Your preferred browser

2. **Test the features:**
   - Fill out the registration form
   - Try the inquiry form
   - Click FAQ questions to expand/collapse
   - Test on mobile by resizing your browser

> **Note:** The demo is for preview only. Forms will not save data or send emails.

---

### Option 2: Integrate with .NET Project

#### Prerequisites
- .NET 6.0 or higher
- Visual Studio 2022 or VS Code
- SQL Server (or your preferred database)

#### Integration Steps

1. **Add files to your ASP.NET Core project:**
   ```
   YourProject/
   ├── Models/
   │   └── SupplierModels.cs
   ├── Pages/
   │   ├── SupplierRegistration.cshtml
   │   └── SupplierRegistration.cshtml.cs
   └── wwwroot/
       ├── css/
       │   └── supplier-registration.css
       └── js/
           └── supplier-registration.js
   ```

2. **Update namespaces:**
   - Open `Models/SupplierModels.cs`
   - Change `namespace WafraJointOperations.Models` to your project namespace
   - Open `Pages/SupplierRegistration.cshtml.cs`
   - Update namespace and using statements

3. **Configure database (Entity Framework):**
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet ef migrations add AddSupplierRegistration
   dotnet ef database update
   ```

4. **Update contact information:**
   - Edit `Pages/SupplierRegistration.cshtml`
   - Replace placeholder email and phone numbers

5. **Run your project:**
   ```bash
   dotnet run
   ```
   Navigate to: `https://localhost:XXXX/SupplierRegistration`

---

## 📁 Project Structure

```
new project/
├── demo.html                          # Standalone demo (open in browser)
├── README.md                          # This file
├── INTEGRATION_GUIDE.md               # Detailed integration instructions
│
├── Models/
│   └── SupplierModels.cs             # Data models with validation
│
├── Pages/
│   ├── SupplierRegistration.cshtml    # Razor view
│   └── SupplierRegistration.cshtml.cs # PageModel (backend logic)
│
└── wwwroot/
    ├── css/
    │   └── supplier-registration.css  # Styles
    └── js/
        └── supplier-registration.js   # Interactive features
```

---

## ✨ Features

- ✅ **Supplier Registration Form** - Comprehensive with validation
- ✅ **Step-by-Step Guide** - Visual 4-step process
- ✅ **Inquiry Form** - For supplier questions
- ✅ **FAQ Section** - 10 questions with accordion
- ✅ **Responsive Design** - Mobile, tablet, desktop
- ✅ **Professional UI** - Modern corporate design
- ✅ **Form Validation** - Client and server-side
- ✅ **Accessibility** - WCAG compliant

---

## 🔧 Configuration Required

Before deploying to production:

### 1. Database Connection
Update `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;..."
  }
}
```

### 2. Email Service
Configure SMTP settings:
```json
{
  "EmailSettings": {
    "SmtpServer": "smtp.your-server.com",
    "SmtpPort": 587,
    "SenderEmail": "noreply@wafrajointops.com",
    "AdminEmail": "jopsuppliersmanagers@chevron.com"
  }
}
```

### 3. Contact Information
Update in `SupplierRegistration.cshtml`:
- Email: `jopsuppliersmanagers@chevron.com`
- Phone: `+965-23983639`
- Business hours: `7:00 AM - 3:00 PM`

---

## 📖 Documentation

- **[INTEGRATION_GUIDE.md](INTEGRATION_GUIDE.md)** - Complete integration instructions
- **[Walkthrough](C:/Users/ramie/.gemini/antigravity/brain/19a2a296-491f-4dd4-a6a1-7b94a188de18/walkthrough.md)** - Feature overview and design previews

---

## 🧪 Testing

### Test the Demo
1. Open `demo.html` in a browser
2. Fill out forms with sample data
3. Test FAQ accordion
4. Resize browser to test responsive design

### Test .NET Integration
1. Run project: `dotnet run`
2. Navigate to `/SupplierRegistration`
3. Submit forms with test data
4. Verify database entries
5. Check email notifications

---

## 🎨 Customization

### Change Brand Colors
Edit `wwwroot/css/supplier-registration.css`:
```css
:root {
    --primary-color: #0066cc;    /* Your primary color */
    --secondary-color: #00a86b;  /* Your secondary color */
}
```

### Update FAQ Content
Edit `LoadFAQs()` method in `SupplierRegistration.cshtml.cs`

### Add Logo
Add your logo to the hero section in `SupplierRegistration.cshtml`

---

## 🔒 Security

- ✅ CSRF protection (built-in)
- ✅ Input validation (server-side)
- ✅ SQL injection prevention (EF Core)
- ✅ XSS protection (Razor encoding)
- ⚠️ Add CAPTCHA for production
- ⚠️ Enable HTTPS in production

---

## 📞 Support

For questions or issues:
- Review the [INTEGRATION_GUIDE.md](INTEGRATION_GUIDE.md)
- Check ASP.NET Core docs: https://docs.microsoft.com/aspnet/core

---

## 📝 License

This code is provided for Wafra Joint Operations. Customize as needed for your requirements.

---

## 🚀 Next Steps

1. ✅ Preview the demo (`demo.html`)
2. ⬜ Integrate into your .NET project
3. ⬜ Configure database connection
4. ⬜ Set up email service
5. ⬜ Update contact information
6. ⬜ Customize branding
7. ⬜ Test thoroughly
8. ⬜ Deploy to production

**Need help?** See [INTEGRATION_GUIDE.md](INTEGRATION_GUIDE.md) for detailed instructions.
