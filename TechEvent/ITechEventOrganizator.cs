using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechEvent
{
    internal interface ITechEventOrganizator
    {
        public void OrganizatorKullanicisiIcinEtkinlikOlustur(string etkinlikAdi, DateTime etkinlikTarihi, string etkinliginOlduguSehir, string aciklama, int katilacakKisiSayisi, bool biletliMi);
    }
}
