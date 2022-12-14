# TechEventApp
Coding Principles in C# Bootcamp

TechEventKullanici class'ında HesapKapatma methodunda alınan hatanın sebebi bir koleksiyon iterasyon sıranında koleksiyonun değişmesidir. Bunu engellemek için ToList methodu kullanıldı. ToList kullanıldığında orjinal koleksiyon iterasyon işleminde kullanılmaz bunun yerine kopyası kullanılır.

TechEventKullanici class'ında kullanıcı tipini tutan alan için UserType adında Enum oluşturuldu. Kullanıcı tipi int türü bir değişken yerine tanımladığımız Enum'da tutulacak.

TechEventKullanici class'ı her iki kullanıcı tipine ait ortak özellikleri barındıracak şekilde düzenlendi. Böylelikle katilimci tipindeki kullanıcı organizatör kullanıcısının methodlarına erişemeyecek. Aynı şekilde organizatör kullanıcısı katılımcı kullanıcının methodlarına erişemeyecek.

TechEventKullanici abstract class haline getirildi. Organizator ve Katilimci için farklı classlar oluşturacağız ve TechEventKullanici classı bu classlara kalıtım verecek. TechEventKullanici class'ından instance alınmasını istemediğimiz için abstract class olarak tanımladık. (Bir kullanici ya organizatördür yada katılımcıdır, kullanıcı olamaz.)

Organizatör kullanıcısı için TechEventOrganizator classı ve ITechEventOrganizator interface oluşturuldu. Bu classta sadece organizatör kullanıcısına ait metotlar bulunacak ve metotlar ITechEventOrganizator'de tanımlayıp TechEventOrganizator classına implemente edilecek. Girilen UserType'a göre bu classtan nesne üretilecek.

Katılımcı kullanıcısı için TechEventKatilimci classı ve ITechEventKatilimci interface oluşturuldu. Bu classta sadece katılımcı kullanıcısına ait metotlar bulunacak ve bu özellikleri ITechEventKatilimci'da tanımlayıp TechEventKatilimci classına implemente edilecek.Girilen UserType'a göre bu classtan nesne üretilecek.

TechEventApp'de userTypea göre farklı kullanıcılara ait işlemler için LoadOperationsKatilimci ve LoadOperationsOrganizator metotları eklendi.

Kaydol ve Giris metotlarında kullanıcı tipinin 1 veya 2 dışında olması durumunda yapılan hata kontrolü silindi. Bu kontrol UserType kontrolü yaptığımız switch-case deyiminin default alanına eklendi.

Create methodunda kullanıcıdan Şehir ismi aldığımız yere ToUpper methodu eklendi. EtkinlikSehriniKontrolEt methodunda oluşturduğumuz sehirler dizisinin elemanları büyük harfe çevrildi. (Kullanıcı ANKARA girdiğinde dizide bulunan alan Ankara olduğu için hata veriyordu, bunu engelledik.)
