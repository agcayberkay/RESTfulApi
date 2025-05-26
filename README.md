# 🚀 RestfulApi

Bu proje, .NET Core ile geliştirilmiş bir RESTful API uygulamasıdır. Temel CRUD işlemleri, JWT Authentication, Middleware yapısı ve katmanlı mimari gibi konuları içermektedir.

## 📌 Özellikler

- Katmanlı Mimari (N-Layer Architecture)
- Entity Framework Core ile veritabanı işlemleri
- CRUD operasyonları (Create, Read, Update, Delete)
- JWT ile kullanıcı kimlik doğrulama (Authentication)
- Yetkilendirme (Authorization)
- Global Exception Handling
- Custom Middleware kullanımı
- Swagger ile API dokümantasyonu
- Dependency Injection (Bağımlılıkların yönetimi)
- Validasyonlar (FluentValidation ile)

## 🛠️ Kullanılan Teknolojiler

- .NET 6 / .NET 7
- Entity Framework Core
- Microsoft SQL Server
- AutoMapper
- Swagger / Swashbuckle
- JWT (System.IdentityModel.Tokens.Jwt)
- FluentValidation
- Serilog (opsiyonel olarak loglama için)
  
## 📁 Proje Yapısı

MyRestfulApi/
│
├── MyRestfulApi.API → API giriş noktası (Controllers, Program.cs)
├── MyRestfulApi.Application → Servisler, DTO'lar, Validasyonlar
├── MyRestfulApi.Domain → Entity'ler, Arayüzler
├── MyRestfulApi.Infrastructure→ Veritabanı işlemleri (EF Context, Repository)
└── MyRestfulApi.Tests → Unit ve Integration Testleri (isteğe bağlı)



## 🚀 Başlangıç

### 
1. Projeyi klonla
git clone https://github.com/kullaniciadi/MyRestfulApi.git
cd MyRestfulApi

2. Bağımlılıkları yükle
dotnet restore

3. Veritabanını oluştur
dotnet ef database update
appsettings.json dosyasındaki connection string’i kendi veritabanı bilgilerinle güncellemeyi unutma.

4. Uygulamayı çalıştır
dotnet run --project MyRestfulApi.API
API https://localhost:5001 üzerinden çalışacaktır.

🔐 Authentication
JWT kullanılarak yetkilendirme yapılmaktadır. Token almak için:

http
POST /api/auth/login
Body:

json
{
  "username": "kullaniciadi",
  "password": "sifre"
}
Gelen token'ı korumalı endpointlerde Authorization başlığı ile gönder:

makefile

Authorization: Bearer <token>
📄 Swagger Dokümantasyonu
Uygulama ayağa kalktığında aşağıdaki linkten Swagger UI'a ulaşabilirsin:

https://localhost:5001/swagger
🧪 Testler
(İsteğe bağlı olarak test projeni buraya dahil edebilirsin.)

🤝 Katkıda Bulunma
Her türlü katkıya açığım! Hataları Issues sekmesinden bildirebilir veya Pull Request göndererek katkı sağlayabilirsin.
---
