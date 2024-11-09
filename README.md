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


## Örnek Dapper ile yazılmış CRUD Sorguları. 
![Ekran Görüntüsü (200)](https://github.com/user-attachments/assets/bf1ea409-c08a-49e8-8fb1-de02f770d3da)
![Ekran Görüntüsü (201)](https://github.com/user-attachments/assets/1874c792-6924-4c0f-a4f8-ce091341a90d)
