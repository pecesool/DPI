# DPI — Diagnostics of Physical Indicators &middot; [![C#](https://img.shields.io/badge/C%23-WinForms-512BD4?logo=csharp)](https://dotnet.microsoft.com/) [![.NET](https://img.shields.io/badge/.NET-Framework-512BD4?logo=dotnet)](https://dotnet.microsoft.com/) [![Database](https://img.shields.io/badge/Database-SQL%20Server-CC2927?logo=microsoftsqlserver)](https://www.microsoft.com/en-us/sql-server) [![Status](https://img.shields.io/badge/Status-Production%20Ready-success)](https://github.com/pecesool/DPI) [![Kazakhstan Copyright](https://img.shields.io/badge/Copyright-№30962-blue)](LICENSE)

> **AI-powered expert system for physical education diagnostics.**  
> A desktop application that automates the workflow of PE teachers, assesses student physical qualities, and provides personalized training recommendations — officially registered with the Kazakhstan Copyright Office (Certificate №30962).

---

## 🎯 What This Project Delivers

**DPI (Diagnostics of Physical Indicators)** is a production-grade Windows desktop application developed in **C# WinForms** backed by **Microsoft SQL Server**. It was built to solve a real-world problem: the manual, error-prone process of tracking student physical development in schools and universities.

Unlike generic fitness trackers or spreadsheet templates, DPI functions as an **intelligent expert system** — it doesn't just store data. It **analyzes** physical indicators against normative tables, **evaluates** student potential across multiple sports disciplines, and **recommends** personalized training programs to improve specific physical qualities.

---

## ✨ Core Features & Engineering Highlights

| Feature | What It Does | Technical Depth |
|---------|-------------|-----------------|
| **Student Database Management** | Full CRUD for student profiles, class groups, and academic years | Normalized SQL Server schema with referential integrity, stored procedures |
| **Physical Indicator Logging** | Record 20+ metrics: strength, endurance, flexibility, speed, coordination | Structured data entry forms with input validation, range checking, and transaction safety |
| **Automated Diagnosis Engine** | Compares raw metrics against age/gender normative tables | Rule-based expert system with configurable threshold logic |
| **Sport Potential Assessment** | Determines aptitude for 10+ sports (athletics, swimming, wrestling, etc.) | Multi-criteria decision algorithm with weighted scoring |
| **Personalized Recommendations** | Generates actionable training plans based on weak areas | Feedback loop system with progress tracking over time |
| **Report Generation** | Export individual and group diagnostics to printable formats | Custom report viewer with PDF-ready layout |
| **Data Visualization** | Radar charts and trend graphs for physical development tracking | GDI+ custom rendering for performance metrics |
| **Multi-User Ready** | Role-based access for teachers and administrators | Session management with credential hashing, concurrent user support |

---

## 🏗️ Architecture & Design Decisions

```
DPI/
├── Forms/              # WinForms UI layer — data entry, reports, dashboards
├── Models/             # Domain entities — Student, Metric, Diagnosis, Recommendation
├── Services/           # Business logic — diagnosis engine, report generator
├── DataAccess/         # SQL Server ADO.NET abstraction layer (upgraded from MS Access)
├── Database/           # SQL scripts — schema, stored procedures, seed data
├── Resources/          # Normative tables, sport criteria matrices, localization
└── App.config          # Connection string management for SQL Server instances
```

### Why This Architecture Works

- **Separation of Concerns**: UI, business logic, and data access are cleanly separated — unusual for WinForms projects of this era, demonstrating architectural discipline
- **SQL Server Backend**: Upgraded from MS Access to SQL Server for enterprise-grade reliability, concurrent multi-user access, and ACID compliance in institutional environments
- **Expert System Pattern**: Diagnosis engine implements forward-chaining inference — rules evaluate metrics in sequence and cascade to recommendations
- **Extensible Criteria**: Sport potential matrices are stored as configurable data, not hardcoded logic — new sports can be added without recompiling
- **Stored Procedures**: Critical data operations encapsulated in SQL Server stored procedures for performance and security

---

## 🛠️ Technology Stack

| Layer | Technology | Rationale |
|-------|-----------|-----------|
| **Language** | C# (.NET Framework) | Native Windows integration, rapid UI development, strong typing for medical/physical data |
| **UI Framework** | Windows Forms | Standard in educational institutions, no runtime dependencies, offline-first with SQL Server sync |
| **Database** | Microsoft SQL Server | Enterprise reliability, concurrent multi-user support, transactional integrity, backup/restore |
| **Data Access** | ADO.NET + Entity Framework / Raw SQL | Direct SQL execution with parameterized queries (SQL injection prevention), stored procedure calls |
| **Visualization** | GDI+ / Custom Controls | Lightweight charting without external dependencies |
| **Reports** | Crystal Reports / PrintDocument | Professional output for parent-teacher conferences |
| **Distribution** | ClickOnce / Standalone EXE | One-click install for non-technical users |

---

## 🚦 Quick Start

### Prerequisites
- Windows 10/11
- .NET Framework 4.7.2+
- Microsoft SQL Server 2019+ (or SQL Server Express)
- SQL Server Management Studio (SSMS) — for initial setup

### Database Setup
```sql
-- Run the initialization script in SSMS
-- Located at: Database/init_schema.sql
-- This creates the DPI database, tables, stored procedures, and seed data
```

### Build & Run
```bash
# Clone repository
git clone https://github.com/pecesool/DPI.git
cd DPI

# Update connection string in App.config to point to your SQL Server instance
# Default: Server=localhost\SQLEXPRESS;Database=DPI;Trusted_Connection=True;

# Open in Visual Studio
start DPI.sln

# Build and run (F5)
```

> **Note**: Ensure the SQL Server service is running and the DPI database has been initialized before launching the application.

---

## 📊 The Expert System in Action

```
Input: Student data (age, gender, height, weight, 12 physical tests)
    ↓
[Normative Comparison Engine] — compares against WHO/Kazakhstan standards
    ↓
[Physical Quality Profile] — strength: 72%, endurance: 58%, flexibility: 81%...
    ↓
[Sport Aptitude Matrix] — Swimming: 89%, Athletics: 74%, Wrestling: 62%...
    ↓
[Recommendation Engine] — "Increase anaerobic endurance: 2x/week interval training"
    ↓
Output: Printable diagnostic card + training plan + progress forecast
```

---

## 🎯 What This Project Demonstrates

> **"This isn't a student assignment. It's a copyrighted product solving a real institutional problem."**

- **Domain Expertise**: Deep understanding of physical education methodology, normative physiology, and sports science — translated into executable logic
- **Full-Product Ownership**: From requirements gathering with PE teachers to deployment in schools, including copyright registration
- **Desktop Engineering**: Mastery of WinForms event-driven architecture, data binding, and GDI+ graphics
- **Database Design**: Enterprise-grade SQL Server schema design with referential integrity, stored procedures, query optimization, and concurrent access handling
- **Algorithmic Thinking**: Multi-criteria scoring, rule-based inference engines, and statistical comparison algorithms
- **Legal Awareness**: Intellectual property protection via official copyright registration (Certificate №30962, Kazakhstan)
- **Infrastructure Upgrade**: Proactive migration from MS Access to SQL Server — demonstrates understanding of scalability and production requirements

---

## 📜 Intellectual Property

This software is officially registered with the **Kazakhstan Copyright Office**.

- **Certificate Number**: №30962
- **Author**: Zhassulan Baimyshev
- **Subject**: Desktop application for automated diagnostics of physical indicators in educational institutions

See [LICENSE](LICENSE) for usage terms.

---

**Author & Maintainer**: [Zhassulan Baimyshev](https://www.linkedin.com/in/zhassulan-baimyshev/)  
*Developed for schools and higher educational institutions of Kazakhstan*
