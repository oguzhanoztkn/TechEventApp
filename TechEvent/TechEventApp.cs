using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TechEvent.TechEventKullanici;

namespace TechEvent
{
    internal class TechEventApp
    {
        public void Start()
        {
            Console.WriteLine("TechEvent uygulamasına hoş geldiniz.");
            Console.WriteLine();
            Console.WriteLine("1. Kayıt Ol");
            Console.WriteLine("2. Giriş Yap");

            int x = int.Parse(Console.ReadLine());
            if (x == 1)
            {
                bool isSuccess;
                do
                {
                    isSuccess = AddUser();
                } while (!isSuccess);
            }

            TechEventKullanici result=null;
            do
            {
                result = LoginUser();
            } while (result == null);

            switch (result.userType)
            {
                case TechEventKullanici.UserType.Organizator:
                    TechEventOrganizator organizator = new TechEventOrganizator();
                    organizator = (TechEventOrganizator)result;
                    LoadOperationsOrganizator(organizator);
                    break;
                case TechEventKullanici.UserType.Katilimci:
                    TechEventKatilimci katilimci = new TechEventKatilimci();
                    katilimci = (TechEventKatilimci)result;
                    LoadOperationsKatilimci(katilimci);
                    break;
                default:
                    throw new Exception("Organizatör için 1'e, diğer için 2'ye basılması gerekmektedir.");
            }
        }
        void LoadOperationsOrganizator(TechEventOrganizator user)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("1. Etkinlik Oluştur");
                Console.WriteLine("2. Hesabini Kapat");

                int y = int.Parse(Console.ReadLine());
                switch (y)
                {
                    case 1:
                        Create(user);
                        break;
                    case 2:
                        user.HesapKapatma(user.kAdi, TechEventHelper.kullaniciListesi);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void LoadOperationsKatilimci(TechEventKatilimci user)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("1. Etkinliğe Katıl");
                Console.WriteLine("2. Bilet Al");
                Console.WriteLine("3. Hesabini Kapat");

                int y = int.Parse(Console.ReadLine());
                switch (y)
                {

                    case 1:
                        Join(user);
                        break;
                    case 2:
                        Sale(user);
                        break;
                    case 3:
                        user.HesapKapatma(user.kAdi, TechEventHelper.kullaniciListesi);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

     
        void Sale(TechEventKatilimci user)
        {
            try
            {
                user.BiletAl();
            }
            catch (Exception ex)
            {
                foreach (BiletFirmalari item in TechEventHelper.biletFirmalari)
                {
                    item.EtkinlikleriXMLOlarakAlir();
                    item.EtkinlikleriJSONOlarakAlir();
                }

                user.BiletAl();
            }
        }

        void Join(TechEventKatilimci user)
        {
            Console.WriteLine("Katılmak istediğiniz etkinliği seçin");
            foreach (Etkinlik item in TechEventHelper.etkinlikListesi)
            {
                Console.WriteLine("1. " + item.EtkinlikAdi);
            }

            int z = int.Parse(Console.ReadLine());
            Etkinlik @event = TechEventHelper.etkinlikListesi[z - 1];

            try
            {
                user.BirEtkinligeKatilma(@event);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void Create(TechEventOrganizator user)
        {
            Console.Write("Etkinlik adı : ");
            string name = Console.ReadLine();
            Console.Write("Açıklama : ");
            string description = Console.ReadLine();
            Console.Write("Tarih : ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Kişi Sayısı : ");
            int count = int.Parse(Console.ReadLine());
            Console.Write("Hangi şehir : ");
            string city = Console.ReadLine().ToUpper();
            Console.Write("Biletli mi (E\\H) : ");
            char answer = char.Parse(Console.ReadLine());

            try
            {
                user.OrganizatorKullanicisiIcinEtkinlikOlustur(name, date, city, description, count, (answer == 'E'));
                Console.WriteLine("Etkinlik Oluşturuldu");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        TechEventKullanici LoginUser()
        {
            Console.Write("Kullanıcı adı : ");
            string user = Console.ReadLine();
            Console.Write("Şifre : ");
            string password = Console.ReadLine();
            Console.Write("Organizatör için 1'e, diğer için 2'ye basın");
            //int type = int.Parse(Console.ReadLine());

            byte i = Convert.ToByte(Console.ReadLine());
            TechEventKullanici.UserType userType;
            userType = (TechEventKullanici.UserType)i;

            TechEventKullanici appUser = null;
            switch (userType)
            {
                case TechEventKullanici.UserType.Organizator:
                    appUser = new TechEventOrganizator();
                    break;
                case TechEventKullanici.UserType.Katilimci:
                    appUser = new TechEventKatilimci();
                    break;
                default:
                    throw new Exception("Organizatör için 1'e, diğer için 2'ye basılması gerekmektedir.");
            }
            bool result = appUser.Giris(user, password, TechEventHelper.kullaniciListesi);
            if (result)
            {
                Console.WriteLine("Giriş başarılı");
                appUser = TechEventHelper.kullaniciListesi.SingleOrDefault(a => a.kAdi == user && a.sifre == password);
                return appUser;
            }
            else
            {
                Console.WriteLine("Giriş başarısız");
                return null;
            }
        }

        bool AddUser()
        {
            Console.Write("Ad : ");
            string name = Console.ReadLine();
            Console.Write("Soyad : ");
            string surname = Console.ReadLine();
            Console.Write("Kullanıcı adı : ");
            string user = Console.ReadLine();
            Console.Write("Şifre : ");
            string password = Console.ReadLine();
            Console.Write("Organizatör için 1'e, diğer için 2'ye basın");
            byte i = Convert.ToByte(Console.ReadLine());
          

            try
            {
                TechEventKullanici appUser = null;
                TechEventKullanici.UserType userType;
                userType = (TechEventKullanici.UserType)i;
                switch (userType)
                {
                    case TechEventKullanici.UserType.Organizator:
                        appUser = new TechEventOrganizator();
                        break;
                    case TechEventKullanici.UserType.Katilimci:
                        appUser = new TechEventKatilimci();
                        break;
                    default:
                        throw new Exception("Organizatör için 1'e, diğer için 2'ye basılması gerekmektedir.");
                }

                appUser.ad=name;
                appUser.soyad=surname;
                appUser.userType=userType;
                appUser.kAdi=user;
                appUser.sifre=password;
                bool result = appUser.Kaydol(appUser);
                if (result)
                {
                    TechEventHelper.kullaniciListesi.Add(appUser);
                    return true;
                }
                else
                {
                    Console.WriteLine("Kayıt başarısız");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
