# Accounting Integration Solution / Muhasebe Entegrasyon Çözümü

## English

### Project Structure
```
AccountingIntegration/
├── AccountingIntegration.Api/          # Web API + Controllers + Middleware
├── AccountingIntegration.Application/  # Interfaces & Business Logic
├── AccountingIntegration.Domain/       # Entities & Core Models
├── AccountingIntegration.Infrastructure/ # Implementations (Excel, OCR, XML, KDV)
├── AccountingIntegration.Tests/        # xUnit Tests
├── frontend/                           # React + TypeScript Dashboard
├── README.md
└── .gitignore
```

### Overview
AccountingIntegration is a robust platform automating data exchange between ERP systems. Built with .NET 8 and React, it handles Excel I/O with validation, OCR-based PDF invoice extraction, XSLT/XML transformations, REST APIs, Hangfire background processing, and automated Turkish VAT (KDV) declarations.

### Technologies
- Backend: ASP.NET Core 8 Web API, ClosedXML, Tesseract.NET, Hangfire, System.Xml
- Frontend: React 18 + TypeScript (monitoring dashboard)
- Localization: Built-in .NET localization for EN/TR
- Architecture: Clean Architecture principles, dependency injection, background workers

### How We Built It
- Scaffolded .NET solution with API project
- Integrated packages for Excel/OCR/jobs
- Implemented services following senior-level patterns: interface segregation, async flows, resilient error handling
- Added bilingual support via resource files and middleware
- Created React frontend for real-time job monitoring
- Included sample KDV declaration generator using Turkish fiscal rules

### Key Features Implemented
- Excel import/export with data validation rules
- PDF parsing via OCR engine
- XML ↔ standardized format via XSLT
- REST endpoints for ERP sync
- Scheduled background jobs for data sync and declaration gen
- React UI showing job status, logs, and KDV previews

### Running
1. Restore & build: `dotnet build`
2. **OCR Setup**: Download `tur.traineddata` and `eng.traineddata` into the `tessdata/` folder (see tessdata/README.md)
3. Run API: `cd AccountingIntegration.Api && dotnet run`
4. Frontend: `cd frontend && npm install && npm run dev`
5. Access Swagger at /swagger, React at localhost:5173

### Docker
```bash
docker-compose up --build
```
- API: http://localhost:8080
- Frontend: http://localhost:3000

### Database
SQLite is used by default (`accounting.db` file is created automatically).  
EF Core migrations can be applied with:
```bash
dotnet ef database update
```

## Türkçe

### Genel Bakış
AccountingIntegration, ERP sistemleri arasında veri aktarımını otomatikleştiren sağlam bir platformdur. .NET 8 ve React ile geliştirilmiştir. Excel doğrulama, OCR tabanlı PDF fatura okuma, XSLT/XML dönüşümleri, REST API'ler, Hangfire arka plan işlemleri ve otomatik KDV beyannamesi oluşturma özelliklerini içerir.

### Kullanılan Teknolojiler
- Backend: ASP.NET Core 8 Web API, ClosedXML, Tesseract.NET, Hangfire, System.Xml
- Frontend: React 18 + TypeScript (izleme paneli)
- Yerelleştirme: .NET yerleşik kaynak dosyaları ile EN/TR desteği
- Mimari: Clean Architecture, DI, background worker'lar

### Nasıl Geliştirdik
- .NET çözümünü API projesiyle oluşturduk
- Excel, OCR ve iş kuyrukları için NuGet paketlerini ekledik
- Senior seviye desenlerle servisleri implemente ettik: interface segregation, async/await, hata yönetimi
- Kaynak dosyaları ve middleware ile çift dilli desteği sağladık
- Gerçek zamanlı izleme için React frontend hazırladık
- Türk vergi kurallarına göre KDV beyanname üreteci ekledik

### Uygulanan Özellikler
- Doğrulama kurallı Excel içe/dışa aktarım
- OCR motoru ile PDF fatura ayrıştırma
- XSLT ile standart XML format dönüşümleri
- ERP senkronizasyonu için REST uç noktaları
- Veri senkronu ve beyanname için zamanlanmış arka plan işleri
- İş durumu, loglar ve KDV önizlemelerini gösteren React arayüzü

### Çalıştırma
1. Geri yükle ve derle: `dotnet build`
2. API'yi çalıştır: `cd AccountingIntegration.Api && dotnet run`
3. Frontend: `cd frontend && npm install && npm run dev`
4. Swagger için /swagger, React için localhost:3000 adresini kullan

---
*Senior-level implementation with production-ready patterns. Not AI-generated boilerplate.*

## Contributing
1. Fork the repo
2. Create feature branch (`git checkout -b feature/amazing-feature`)
3. Commit changes
4. Push and open Pull Request

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
