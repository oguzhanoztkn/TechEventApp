using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechEvent
{
    public abstract class TechEventKullanici
    {
        public string ad;
        public string soyad;
        public string kAdi;
        public string sifre;
        public UserType userType;


        public bool Kaydol(TechEventKullanici appUser)
        {
            foreach (TechEventKullanici item in TechEventHelper.kullaniciListesi)
            {
                if (item.kAdi == kAdi)
                {
                    throw new Exception("Bu kullanıcı adı zaten kayıtlı");
                }
            }

            if (sifre.Length < 6 || TechEventHelper.BuyukHarfliSifre(sifre) == false || TechEventHelper.KucukHarfliSifre(sifre) == false)
            {
                throw new Exception("Şifre en az 6 karakterli olmalı ve en az 2 büyük ve küçük harf içermelidir");
            }

            if (!(Convert.ToByte(userType) == 1 || Convert.ToByte(userType) == 2))
            {
                throw new Exception("Organizatör için 1'e, diğer için 2'ye basılması gerekmektedir.");
            }

            return true;
        }
        
        public bool Giris(string kadi, string sifre, List<TechEventKullanici> kullanicilar)
        {
            foreach (TechEventKullanici item in kullanicilar)
            {
                if (item.kAdi == kadi && item.sifre == sifre)
                {
                    return true;
                }
            }

            return false;
        }

        public void HesapKapatma(string kullanici, List<TechEventKullanici> kullaniciListesi)
        {
            foreach (TechEventKullanici item in kullaniciListesi.ToList())
            {
                if (item.kAdi == kullanici)
                {
                    kullaniciListesi.Remove(item);
                }
            }
        }

        public enum UserType
        {
            Organizator=1,    
            Katilimci  
        }
    }
}
