using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechEvent
{
    internal class TechEventOrganizator : TechEventKullanici, ITechEventOrganizator
    {
        public void OrganizatorKullanicisiIcinEtkinlikOlustur(string etkinlikAdi, DateTime etkinlikTarihi, string etkinliginOlduguSehir, string aciklama, int katilacakKisiSayisi, bool biletliMi)
        {
            switch (this.userType)
            {
                case UserType.Organizator:
                    try
                    {
                        Etkinlik etkinlik = new Etkinlik(etkinlikAdi, etkinlikTarihi, etkinliginOlduguSehir, aciklama, katilacakKisiSayisi, biletliMi);
                        TechEventHelper.etkinlikListesi.Add(etkinlik);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    throw new Exception("Sadece organizatör rolündeki kullanıcılar etkinlik oluşturabilir");
            }
        }
    }
}
