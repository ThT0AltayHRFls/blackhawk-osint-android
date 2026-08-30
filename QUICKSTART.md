# 🚀 BlackHawk OSINT - Hızlı Başlama Rehberi

## 5 Dakikada Başlayın

### Adım 1: Dosyaları Hazırla
```bash
git clone https://github.com/yourusername/BlackHawk.git
cd BlackHawk
```

### Adım 2: Visual Studio'da Aç
- Visual Studio 2022'yi aç
- `BlackHawk.csproj` dosyasını aç
- Nuget packages otomatik yüklenecek

### Adım 3: Konfigüre Et
```bash
cp config.example.json config.json
# config.json'u düzenle ve NewsAPI anahtarını ekle
```

### Adım 4: Çalıştır (Debug)
- Visual Studio'da F5 tuşuna bas
- Android emulator açılacak
- Uygulama yüklenecek

### Adım 5: APK Derle (Release)
```bash
dotnet publish BlackHawk/BlackHawk.csproj -f net8.0-android -c Release
# APK: BlackHawk/bin/Release/net8.0-android/*.apk
```

## Ekranları Test Et

1. **Dashboard** - Ana sayfa
2. **Ara** - Haber araması yap
3. **Hava** - Hava durumu göster
4. **Uyarılar** - Son dakika uyarıları
5. **Haberler** - Breaking news

## Ayarlar

- **Dil**: Türkçe / İngilizce / Arapça
- **Tema**: Koyu Mod (Default)
- **Bildirimler**: Günlük 4 bildirim
- **Offline**: İnternet kesildiyse cache kullan

## Hata Çözümleri

**"API anahtarı bulunamadı"** 
→ config.json dosyasını kontrol et

**"Veritabanı hatası"**
→ Uygulama verilerini sil ve yeniden başlat

**"Derleme hatası"**
→ `dotnet restore` komutu çalıştır

---

**Başarı ile başladığını görmek için uygulama açılırsa ve ana sayfa yüklenirse, tüm sistemi doğru şekilde ayarlamışsın demektir!** ✅

