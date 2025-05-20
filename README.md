# 🌀 MazeGame – Labirent Ölümcül Kaçış

## 📘 Proje Hakkında

**MazeGame**, bir labirentte karakterin sıralı komutlarla yönlendirilmesini sağlayan, kullanıcıyı hem oyun hem de yazılım mimarisi açısından düşünmeye teşvik eden bir **.NET MVC** projesidir. Bu projede, yazılım tasarım desenlerinden **Interpreter** ve **Visitor** örneklenerek uygulanmıştır.

Oyunun amacı, karakteri yönlendirerek:
1. Canavarı öldürmek
2. Anahtarı almak
3. Kapıyı açarak kaçmak

gibi görevleri tamamlamaktır.



## 🎮 Oyun Ekranları

### 🟦 1. Başlangıç ve Tanıtım Ekranı
Oyuncu, Glade’de uyanır ve ilk talimatları alır. Oyun “Maze’e Gir” butonuyla başlar.


![a9fa076e-c622-4520-a4a2-cb2e7fdf164b](https://github.com/user-attachments/assets/e58a76cb-0c11-44f1-910c-cd4e69e081d9)
---

### 🟦 2. Oyun Arayüzü
Labirent yapısı ve komut butonları burada yer alır. Komutlar sürüklenerek sıraya konur ve “ÇALIŞTIR 🚀” ile karakter hareket ettirilir.

![569df2a9-be87-40a6-baee-7e8e542fd924](https://github.com/user-attachments/assets/e2bbc018-ea9f-4aec-8480-0e66fba4bb92)

---

### 🟥 3. Başarısız Deneme
Komutlar doğru uygulanmazsa karakter canavara yakalanabilir ya da anahtarı almadan kapıya ulaşabilir.

![189605eb-4d1e-4315-a2ad-5e80c5ce43e2](https://github.com/user-attachments/assets/7b6d18b8-1826-444e-9e58-d77638070151)

---

### ✅ 4. Başarı Ekranı
Tüm görevler tamamlandığında oyuncuya başarı mesajı gösterilir.

![d87e6fc7-b271-4773-b278-7b585a9cce03](https://github.com/user-attachments/assets/29a77e48-43ba-44a9-a197-12adbeaa32b6)

---

### ✅ 5. Oyun İçi Ön Gösterimi
Aşağıda oyunun oynanış biçimi yer almaktadır. Bu örnek erpoyu clone eden kullanıcılara rehberlik etmesi amacıyla tasarlanmıştır.

![maze demo](https://github.com/user-attachments/assets/d4d8bc3a-fe77-4266-ba49-936ecdf2ddfc)

---

## 🧠 Kullanılan Tasarım Desenleri

### 🗣️ Interpreter Pattern
Bu desen, kullanıcıdan gelen metin tabanlı komutların analiz edilip çalıştırılmasını sağlar. 
Projedeki örnek komutlar:
- `sağ`, `sol`, `yukarı`, `aşağı`
- `canavarı öldür`, `anahtarı al`, `kapıyı aç`

Her komut, `IExpression` arayüzünü uygular ve `Interpret(Context)` metodu ile yorumlanır.

### 🧳 Visitor Pattern
Visitor deseni ile karakterin farklı nesnelerle (canavar, anahtar, kapı vb.) etkileşimleri soyutlanır. Bu desen sayesinde:
- Nesneler üzerindeki işlemler (`VisitMonster`, `VisitKey`, `VisitDoor`) bir ziyaretçi nesne tarafından gerçekleştirilir.
- Yeni etkileşimler eklemek kolaylaşır.

---

## 🧩 Teknolojiler

- ASP.NET MVC (.NET 9)
- HTML / CSS / JavaScript
- Interpreter & Visitor Design Patterns

---

## 🚀 Kurulum ve Çalıştırma

1. Repoyu klonlayın:
   ```bash
   git clone https://github.com/ayseakbaba/MazeGame.git
