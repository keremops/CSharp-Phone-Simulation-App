# C# Akıllı Telefon Simülasyonu (SmartPhone Simulation)

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-purple?style=for-the-badge&logo=dotnet)
![Language](https://img.shields.io/badge/Language-C%23-blue?style=for-the-badge&logo=csharp)
![IDE](https://img.shields.io/badge/IDE-Visual%20Studio-5C2D91?style=for-the-badge&logo=visual-studio)

## 📋 Proje Hakkında

Bu proje, **Nesne Yönelimli Programlama (OOP)** prensipleri temel alınarak geliştirilmiş, interaktif bir **Windows Forms** uygulamasıdır. Yazılım, sanal bir akıllı telefonun yaşam döngüsünü (şarj yönetimi, aktivite tüketimi ve durum takibi) simüle eder.

Kullanıcı etkileşimlerine dayalı olay güdümlü (event-driven) bir mimariye sahip olan uygulama, dinamik durum yönetimi ve istisna işleme (exception handling) mekanizmalarıyla hataları profesyonelce yönetir.

---

## 🚀 Temel Özellikler

* **Dinamik Nesne Yönetimi:** Kullanıcı girdilerine göre çalışma zamanında (runtime) `Telefon` nesnesi oluşturulması.
* **Enerji Yönetim Modülü:** Şarj seviyesinin mantıksal sınırlar (0-100) içerisinde tutulmasını sağlayan algoritma.
* **Aktivite Simülasyonu:** "Oyun Oyna" fonksiyonu ile batarya tüketimi ve kritik seviye kontrolü.
* **Hata ve İstisna Denetimi:** Yetersiz enerji durumlarında kullanıcıyı bilgilendiren ve işlemi kesen `try-catch` mekanizması.
* **Kullanıcı Dostu Arayüz (UI):** Anlık durum güncellemeleri ve veri giriş validasyonları.

---

## 📸 Ekran Görüntüleri ve Kullanım Senaryoları

### 1. Başlangıç ve Veri Girişi
Kullanıcı, simüle edilecek cihazın marka, model ve başlangıç şarj değerlerini sisteme girer.

![Uygulama Başlangıcı](img/sim1.PNG)

### 2. Nesne Başlatma ve Aktivasyon
"Kaydet" işlemi ile birlikte veriler valide edilir, `Telefon` sınıfı örneklendirilir ve kontrol paneli aktif hale gelir.

![Aktif Arayüz](img/sim2.PNG)

### 3. Durum İzleme
Cihazın anlık parametreleri (Marka, Model, Şarj Durumu) arayüz üzerinden gerçek zamanlı olarak takip edilebilir.

![Durum Gösterimi](img/sim5.PNG)

### 4. İstisna Yönetimi (Exception Handling)
Sistem, batarya seviyesi oyun oynamak için kritik seviyenin (20 birim) altındaysa işlemi yarıda keser veya batarya tamamen bittiyse eylemi engeller.

| Düşük Pil Uyarısı | Batarya Bitti Hatası |
| :---: | :---: |
| ![Düşük Pil](img/sim4.PNG) | ![Şarj Bitti](img/sim3.PNG) |

---

## 🛠 Teknik Mimari

Proje, iş mantığı (Business Logic) ve arayüz (UI) katmanlarını birbirinden ayıran modüler bir yapıya sahiptir.

### `Telefon.cs` Sınıf Yapısı
Sistemin çekirdeğini oluşturan bu sınıf, kapsülleme (encapsulation) ve mantıksal kontrolleri barındırır.

```csharp
public void OyunOyna() 
{
    if (this.tel_sarj >= 20)
    {
        this.tel_sarj -= 20; // Başarılı İşlem
    }
    else
    {
        // Kritik Seviye Kontrolü ve Hata Fırlatma
        throw new Exception("Hata: Şarj yetersiz...");
    }
}
