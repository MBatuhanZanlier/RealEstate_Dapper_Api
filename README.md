# Dapperın Tarihcesi 
**Dapper**, **Stack Overflow** ekibi tarafından geliştirilmiştir. Stack Overflow'un kurucularından olan **Jeff Atwood** ve **Joel Spolsky**'nin liderliğindeki ekip, veritabanı işlemleri için daha hızlı ve verimli bir çözüm arayışına girmiştir. Sonuç olarak, **Sam Saffron** ve **Marc Gravell** gibi Stack Overflow geliştiricileri, Dapper'ı yaratmışlardır. 

Dapper, ilk olarak 2011 yılında açık kaynak olarak yayımlanmıştır ve hızla popülerlik kazanmıştır. Geliştiriciler, Dapper'ın minimal yapısı ve performans avantajları sayesinde onu sıkça tercih etmeye başlamışlardır.
# Dapper Nedir?
Dapper, .NET dünyası için basit bir Mikro ORM’dir. Veritabanı işlemleri için herhangi bir .NET projesine eklenebilen bir NuGet kitaplığıdır. ORM (Object Relational Mapping), Nesne İlişkisel Eşleme anlamına gelir. Yani tüm veritabanı, class’lar, interface’ler vb. açısından çalıştırılabilir. ORM, sınıflar açısından bir “sanal veritabanı” oluşturur ve bu sınıflarla çalışmak için yöntemler sağlar. Dapper ise veritabanı şeması oluşturmak, veritabanı şemasını değiştirmek, değişikleri izlemek gibi işlemler yerine veritabanı tablolarıyla çalışmak gibi önemli görevlere odaklanmak üzere tasarlanmış bir Mikro ORM’dir. 

# Neden Dapper Kullanmalıyız?
- Dapper bir NuGet kitaplığıdır. Oldukça hafif ve yüksek performanslıdır.
- Veritabanı erişim kodunu büyük ölçüde azaltır.
- ORM’nin tüm görevleri yerine veritabanı görevlerine odaklanır.
- Herhangi bir veritabanı ile çalışabilir. SQL Server, Oracle, SQLite, MySQL, PoestgreSQL.

1. Yüksek Performans
2. Daha Az Kaynak Tüketimi.
3. Basitlik ve Kolay Kullanı


### Dapper ve Entity Framework (EF) Arasındaki Farklar

| Özellik                     | **Dapper**                               | **Entity Framework (EF)**                |
|-----------------------------|------------------------------------------|------------------------------------------|
| **Soyutlama Seviyesi**      | Düşük (SQL'e yakın)                      | Yüksek (Veri modeli üzerinden)          |
| **Performans**              | Daha hızlı (özellikle büyük veri setlerinde) | Genelde daha yavaş (ama EF Core hızlanmıştır) |
| **Kolaylık ve Hız**         | Basit SQL ve daha az özellik             | Kolay kullanım, çok sayıda özellik      |
| **Veritabanı Yönetimi**     | Manuel yönetim                           | Otomatik migrasyon ve şema yönetimi     |
| **Özellikler**              | Basit veritabanı işlemleri                | Veri doğrulama, ilişkiler, lazy loading, eager loading |
| **Karmaşık İlişkiler**      | Zor, manuel yönetim                      | Kolayca yönetilebilir (eşleme, ilişkiler vb.) |
| **Kullanım Alanı**          | Performans ve basit sorgu odaklı projeler | Büyük projeler, veri modelleme ve ORM avantajları isteyenler |

---

Dapper ve Entity Framework (EF) Arasındaki Farkı kısaca şizlere şöyle açıklayabiilirim:  
Dapper da sorgular direk Sql sorgularla çalıştığı için  Entity Framework göre daha hızlı çalışır. Ef ormsi ile yazdığımız sorgular arka planda sql sorgulara çevrildiği için aradaki hız farkı bu sepepten oluşuyor ama  Entity Framework Core  iyleştirmeler yapıldığı için  hız farkı daha aza düşürülmüştür.  


## Örnek Dapper ile yazmış olduğum CRUD Sorguları. 
![Ekran Görüntüsü (200)](https://github.com/user-attachments/assets/bf1ea409-c08a-49e8-8fb1-de02f770d3da)
![Ekran Görüntüsü (201)](https://github.com/user-attachments/assets/1874c792-6924-4c0f-a4f8-ce091341a90d)

# Real Estate Projesi Hakkında 
**Emlak İlanları Yönetim ve Listeleme Sistemi**

Bu proje, ASP.NET Core 8.0 ve Web API kullanarak geliştirilmiştir ORM olarak Dapper  veri tabanı olarak MsSql kullanılarak geliştirilmiş bir projedir. Projenin genel amacı kullanıcıların **lokasyon** ve **kategori** bazında emlak ilanlarını aramalarına ve görüntülemelerine olanak sağlar. İlanlar, **ev**, **villa** gibi farklı emlak türlerine göre kategorize edilerek kolayca filtrelenebilir. Kullanıcılar, istedikleri kriterlere uygun ilanları hızlıca listeleyebilirler.

## Teknolojiler ve Araçlar:
- .NET Core 8.0
- Dapper
- MVC (Model-View-Controller)
- API
- MS SQL Server
- SLUG
- JWT
  ## SLug Nedir?
  Benimde bu projede kullanmış olduğum slug un ne işe yaradığını kısaca anlatmak istiyorum.
  Yazılımda slug terimi, özellikle web geliştirme ve SEO (Arama Motoru Optimizasyonu) bağlamında, URL'lerde kullanılan ve genellikle içerik başlıklarından türetilen bir metin parçasını ifade eder. Slug, bir web sayfasının benzersiz ve açıklayıcı bir adresini oluşturmak için kullanılır.
  ### Slugun Önemi
  1. Slug'lar genellikle sayfanın içeriğini kısaca anlatacak şekilde oluşturulur.
  2. Slug'lar, sayfa içeriğini açıklayacak anahtar kelimeleri içermelidir. Bu, arama motorları tarafından sayfanın daha kolay bulunmasını sağlar.
  3. Slug'lar genellikle sadece harfler (küçük harf), sayılar ve tirelerden (-) oluşur. Boşluklar ve özel karakterler yerine tireler kullanılır.
  ### Örnek slug kullanımı
https://www.example.com/article?id=98765 — İçeriği açıklamayan, rastgele bir parametre içerir. 
https://www.example.com/blog/how-to-build-a-react-application — Başlık ve anahtar kelimelerle uyumlu, SEO'ya uygun ve kullanıcı dostu. 
## Projemdeki Slug Kullanımı 
![Ekran Görüntüsü (199)](https://github.com/user-attachments/assets/44897dc3-d03d-42b4-b26d-54deb22c3d3d)

Projemdeki Urldeki Slug uygulanmıştır.
## Proje Göreselleri  
![Ekran Görüntüsü (185)](https://github.com/user-attachments/assets/3c214b7d-2182-4165-8604-6e7d3e0bbc79)
![Ekran Görüntüsü (186)](https://github.com/user-attachments/assets/4261ab55-8ada-4f54-8272-1a16caff895c)
![Ekran Görüntüsü (187)](https://github.com/user-attachments/assets/1adc198d-4cca-43ba-94f7-6b56482e3d7f)
![Ekran Görüntüsü (188)](https://github.com/user-attachments/assets/189bef35-d809-4ad2-9f26-30e26c94735f)
![Ekran Görüntüsü (189)](https://github.com/user-attachments/assets/ec8612f1-6340-42fe-bb4f-811f58c482c8)
![Ekran Görüntüsü (190)](https://github.com/user-attachments/assets/909ea0f9-548e-4ba7-9bbe-3e126d865796)
![Ekran Görüntüsü (191)](https://github.com/user-attachments/assets/a182f3ac-37b9-4e0a-91b1-d05fe7be004f)
![Ekran Görüntüsü (192)](https://github.com/user-attachments/assets/f7a040cc-0a4f-4c24-bf3b-5bc59550d441)
![Ekran Görüntüsü (194)](https://github.com/user-attachments/assets/02b08fb8-4ce1-40d6-aee6-f544ba651204)
![Ekran Görüntüsü (195)](https://github.com/user-attachments/assets/5ec7765a-36a7-4e4c-a05b-e03d83065c26)
![Ekran Görüntüsü (196)](https://github.com/user-attachments/assets/894ed004-ad3e-41e7-9173-b45766bd6113)
![Ekran Görüntüsü (197)](https://github.com/user-attachments/assets/f20e501b-8b7a-47ee-bbfa-0302aae6d732)
![Ekran Görüntüsü (198)](https://github.com/user-attachments/assets/60b79abf-073c-4d55-ac8e-84dbd90c9e7c)
