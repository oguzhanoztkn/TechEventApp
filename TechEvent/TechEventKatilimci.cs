using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechEvent
{
    internal class TechEventKatilimci:TechEventKullanici, ITechEventKatilimci
    {
        public void BirEtkinligeKatilma(Etkinlik etkinlik)
        {
            switch (this.userType)
            {
                case TechEventKullanici.UserType.Katilimci:
                    if (etkinlik.KatilacakKisiler.Count < etkinlik.KatilacakKisiSayisi)
                    {
                        etkinlik.KatilacakKisiler.Add(this);
                    }
                    else
                    {
                        throw new Exception("Etkinliğin kontenjanı dolmuştur");
                    }
                    break;
                default:
                    throw new Exception("Sadece katilimci rolündeki kullanıcılar bir etkinliğe katılabilir");
            }
        }

        public void BiletAl()
        {
            foreach (BiletFirmalari item in TechEventHelper.biletFirmalari)
            {
                if (!item.DataCekildiMi)
                {
                    throw new Exception($"{item.FirmaAdi} firmasında biletler henüz satışa çıkmamıştır");
                }
            }

            Console.WriteLine("Aşağıdaki adreslerden bilet alabilirsiniz");
            TechEventHelper.biletFirmalari.ForEach(firma =>
            {
                Console.WriteLine($"{firma.FirmaAdi} -> {firma.WebSitesi}");
            });
        }
    }
}
