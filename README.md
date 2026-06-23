# DPI — Diagnostics of Physical Indicators

C# WinForms application for recording and diagnosing physical indicators

Maintainer: Zhassulan Baimyshev — https://www.linkedin.com/in/zhassulan-baimyshev/

Summary

DPI is a feature-rich Windows Forms application with multiple forms and a bundled MS Access database (`dpi1.mdb`). It includes UI forms for data entry, reports, and visualization.

Tech & files of interest

- C# WinForms project: `DPI.csproj`
- UI files: `Form1.*`, many Designer and resource files
- Local DB: `dpi1.mdb`

How to run

1. Clone the repo and open the solution in Visual Studio.
2. Build and run. Ensure the app can read/write the `dpi1.mdb` file.

Notes

- Large Designer/auto-generated files are included; consider removing `bin/obj` and adding `.gitignore` entries if you want a cleaner repo.
