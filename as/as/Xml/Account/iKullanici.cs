using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;

namespace @as.Xml.Account
{
    interface iKullanici
    {
        void Yeni(Kullanici model);
        void Duzelt(Kullanici model);
        void Sil(string no);
        void Kaydet();
        Kullanici Bilgi(string no);
        XElement Bul(string no);
        IEnumerable<Kullanici> Liste();
        Kullanici Kontrol(Kullanici model);
        bool Varmi(Kullanici model);
        bool Varmi(string Mail, string Parola);
    }
}
