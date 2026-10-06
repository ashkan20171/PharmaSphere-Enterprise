# PharmaSphere Enterprise

**Enterprise-grade bilingual pharmacy operations platform for Windows — built with C# WinForms, .NET Framework 4.8 and SQL Server.**

PharmaSphere Enterprise is a portfolio-scale desktop system that models the operational workflows of a modern pharmacy: POS, medicine catalog, FEFO batch inventory, purchasing, patients, prescriptions, insurance, returns, alerts, auditing, role-based access, reporting, backup and operational health.

## Why this project stands out
- Transaction-oriented POS with discounts, tax, multiple payment modes, hold/resume and invoice preview
- FEFO-ready batch inventory and expiry/low-stock intelligence
- Patient 360, prescription dispensing foundation and clinical safety checks
- Insurance claim domain with patient-share/coverage workflow
- RBAC for Admin, Pharmacist, Cashier and Inventory roles
- Audit/security foundation, PBKDF2 password hashing and session/security schemas
- Operations Center, Notification Center and system-health monitoring
- Global medicine/patient search from the main shell
- SQL Server persistence, migration/bootstrap foundation and backup workflow
- Persian/English localization with RTL/LTR-aware UI
- Custom WinForms design system: gradients, rounded surfaces, KPI cards and domain workspaces

## Architecture
The solution separates UI, domain models and operational services/repositories. Pricing, FEFO allocation, payments, insurance, patient history, security, notifications and health checks are intentionally kept out of form code where practical. SQL scripts are versioned by platform stage to make the evolution of the schema visible.

## Technology
C# · .NET Framework 4.8 · Windows Forms · SQL Server · ADO.NET · Visual Studio 2022 · PBKDF2 · RTL/LTR localization

## Key modules
POS & Checkout · Medicines · Inventory & Batches · Suppliers & Purchasing · Patients 360 · Prescription Dispensing · Insurance · Returns & Refunds · Reports · Operations Center · Notifications · Users · Permission Matrix · Security Center · Backup & Restore

## Engineering themes
Transactional consistency, least-privilege access, traceability, operational observability, separation of concerns, defensive database access, bilingual UX and maintainable desktop architecture.

## Für Recruiter in Deutschland / DACH
Dieses Projekt demonstriert die Entwicklung einer umfangreichen Desktop-Geschäftsanwendung mit **C#, .NET Framework, WinForms und SQL Server**. Der Schwerpunkt liegt nicht nur auf der Oberfläche, sondern auf nachvollziehbaren Geschäftsprozessen: rollenbasierte Zugriffe, Auditierbarkeit, transaktionale Verkaufsabläufe, FEFO-orientierte Chargenlogik, Patienten- und Versicherungsprozesse, Backup sowie Systemüberwachung.

Besonders relevant sind die klare Trennung von UI und Services/Repositories, die zweisprachige RTL/LTR-Oberfläche und die schrittweise Weiterentwicklung einer realistischen Unternehmensanwendung.

## Portfolio note
This repository is intended as an engineering portfolio project. Clinical warnings are decision-support foundations and must not be treated as medical advice or a certified drug-interaction engine. Insurer integrations are adapter-ready foundations rather than claims of live insurer connectivity.

## Run
Open `AshkanPharmacy.sln` in Visual Studio 2022, restore/build, configure the SQL Server connection string in `App.config`, and run the application. Stage SQL files document optional schema upgrades.

## Suggested GitHub topics
`csharp` `dotnet-framework` `winforms` `sql-server` `pharmacy` `pos` `inventory-management` `fefo` `rbac` `clean-code` `desktop-app` `rtl` `localization` `enterprise-software`
"# PharmaSphere-Enterprise" 
