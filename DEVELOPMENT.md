# BlackHawk OSINT - Geliştirme Rehberi

## Proje Yapısı

Bu rehber geliştirici olarak BlackHawk OSINT projesinde nasıl çalışılacağını açıklar.

### Klasör Hiyerarşisi

```
BlackHawk/
├── Views/              # UI - XAML ve Code-Behind
├── ViewModels/         # MVVM - ViewModel sınıfları
├── Services/           # İş Mantığı - API, Database vb.
├── Models/             # Veri Modelleri
├── Helpers/            # Yardımcı Sınıflar
├── Utils/              # Utility Sınıfları
├── Resources/          # Resimler, Stiller
├── Constants/          # Sabitler
├── Converters/         # Value Converters
├── Behaviors/          # XAML Behaviors
├── Effects/            # Custom Effects
└── Logging/            # Logging Sistemi
```

## Geliştirme Adımları

### 1. Yeni Sayfa Oluşturma

```csharp
// Views/Pages/YeniSayfa.xaml.cs
public partial class YeniSayfa : ContentPage
{
    public YeniSayfa()
    {
        InitializeComponent();
    }
}
```

### 2. ViewModel Bağlama

```csharp
// ViewModels/YeniViewModel.cs
public class YeniViewModel : BaseViewModel
{
    public YeniViewModel()
    {
        Title = "Yeni Sayfa";
    }
}
```

### 3. Code Guidelines

- MVVM pattern kullan
- Async/await ile asynchronous işlemler
- Try-catch ile hata yönetimi
- Dependency Injection kullan
- Clean Code prensipleri izle

## API Entegrasyonu

### NewsAPI
```csharp
var service = new NewsApiService();
var results = await service.SearchAsync("Türkiye");
```

### Reddit
```csharp
var service = new RedditApiService();
var results = await service.SearchAsync("teknoloji");
```

## Hata Ayıklama

### Logging
```csharp
Logger.Info("Bilgi mesajı");
Logger.Error("Hata", exception);
Logger.Debug("Debug mesajı");
```

### Database
```csharp
var results = await App.Database.GetSearchResultsByQueryAsync("sorgu");
```

## Derleme ve Yayınlama

### Debug Modunda Çalıştırma
```bash
dotnet build BlackHawk/BlackHawk.csproj -f net8.0-android -c Debug
```

### Release APK
```bash
dotnet publish BlackHawk/BlackHawk.csproj -f net8.0-android -c Release
```

## Test Etme

1. SearchBar'a metin yazın
2. Arama yapın
3. Sonuçların gelip gelmediğini kontrol edin
4. Rapor oluşturun
5. Offline mode'u test edin

## İş Akışı

1. Branch oluştur: `git checkout -b feature/yeni-ozellik`
2. Değişiklikleri yap
3. Commit et: `git commit -am 'Açıklama'`
4. Push et: `git push origin feature/yeni-ozellik`
5. Pull Request aç

## Performance Optimizasyonu

- Resim boyutlarını küçült
- Async işlemler kullan
- Cache'i etkin kullan
- Database query'lerini optimize et
- UI thread'i bloke etme

---

**Son Güncelleme**: Ağustos 2024
