# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a **Supplier Registration Page** for Wafra Joint Operations (a Chevron/KGOC joint venture). It is built as an ASP.NET Core Razor Pages component intended to be dropped into an existing .NET project.

The `index.html` file at the root is a standalone browser-previewable demo that requires no server.

## Integration into a .NET Project

The namespace used throughout is `WafraJointOperations`. When integrating into another project, update:
- `Models/SupplierModels.cs` — namespace declaration
- `Pages/SupplierRegistration.cshtml.cs` — namespace and using statements

### Required .NET setup
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet ef migrations add AddSupplierRegistration
dotnet ef database update
dotnet run
```

Navigate to `/SupplierRegistration` after running.

## Architecture

- **[Models/SupplierModels.cs](Models/SupplierModels.cs)** — Three models: `SupplierRegistrationModel`, `InquiryModel`, `FAQItem`. All validation is via data annotations.
- **[Pages/SupplierRegistration.cshtml](Pages/SupplierRegistration.cshtml)** — Razor view with the registration form, inquiry form, FAQ accordion, and 4-step process guide.
- **[Pages/SupplierRegistration.cshtml.cs](Pages/SupplierRegistration.cshtml.cs)** — PageModel with `OnPostRegisterAsync` and `OnPostInquiryAsync` handlers. Database save and email sending are stubbed with `TODO` comments.
- **[wwwroot/css/supplier-registration.css](wwwroot/css/supplier-registration.css)** — All styles. Brand colors are CSS variables at the top (`--primary-color`, `--secondary-color`).
- **[wwwroot/js/supplier-registration.js](wwwroot/js/supplier-registration.js)** — Client-side validation, FAQ accordion, and form interactivity.
- **[wwwroot/images/](wwwroot/images/)** — Three logos: `chevron-logo.svg`, `kgoc-logo.svg`, `wafra-logo.svg`.

## Key TODOs Before Production

The PageModel has stubbed-out sections that must be implemented:
1. Database persistence (`_dbContext.SupplierRegistrations.AddAsync(...)`)
2. Confirmation email to supplier
3. Admin notification email to `jopsuppliersmanagers@chevron.com`

Contact info hardcoded in the view: phone `+965-23983639`, hours `7:00 AM - 3:00 PM`.

SMTP config goes in `appsettings.json` under `EmailSettings`. DB connection string goes under `ConnectionStrings.DefaultConnection`.
