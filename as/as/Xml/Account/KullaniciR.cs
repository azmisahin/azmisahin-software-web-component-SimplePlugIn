using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;

namespace @as.Xml.Account
{
    /// <summary>
    /// Test Versiyon
    /// Xml Based Data and User Control
    /// </summary>
    public class KullaniciR : iKullanici
    {

        private List<Kullanici> Bellek;
        private XDocument Veri;
        public static string VeriYolu = "";
        //VeriYolu = HttpContext.Current.Server.MapPath(@"~/App_Data/Kullanicilar.xml");

        public KullaniciR()
        {
            Bellek = new List<Kullanici>();
            Veri = XDocument.Load(VeriYolu);

            var secilen = from sec in Veri.Descendants("Kullanici")
                          select new Kullanici(
                              (string)sec.Element("No"),
                              (string)sec.Element("Ad"),
                              (string)sec.Element("Soyad"),
                              (string)sec.Element("Firma"),
                              (string)sec.Element("Parola"),
                              (string)sec.Element("Mail"),
                              (string)sec.Element("Resim"),
                              (bool)sec.Element("Oturum"),
                              (int)sec.Element("Yetki"),
                              (string)sec.Element("Adres"),
                              (string)sec.Element("TeslimatAdresi"),
                              (string)sec.Element("WebAdresi"),
                              (string)sec.Element("StatikIpAdresi")
                              );
            Bellek.AddRange(secilen.ToList<Kullanici>());

        }

        public void Yeni(Kullanici model)
        {

            Veri.Root.Add(
                            new XElement
                                (
                                    "Kullanici",
                                        new XElement("No", model.No),
                                        new XElement("Ad", model.Ad),
                                        new XElement("Soyad", model.Soyad),
                                        new XElement("Firma", model.Firma),
                                        new XElement("Parola", model.Parola),
                                        new XElement("Mail", model.Mail),
                                        new XElement("Resim", model.Resim),
                                        new XElement("Oturum", model.Oturum),
                                        new XElement("Yetki", model.Yetki),
                                        new XElement("Adres", model.Adres),
                                        new XElement("TeslimatAdresi", model.TeslimatAdresi),
                                        new XElement("WebAdresi", model.WebAdresi),
                                        new XElement("StatikIpAdresi", model.StatikIpAdresi)
                                )
                );

            Kaydet();
        }

        public void Duzelt(Kullanici model)
        {

            XElement element = Bul(model.No);

            element.SetElementValue("Mail", model.Mail);
            element.SetElementValue("Parola", model.Parola);

            element.SetElementValue("Ad", model.Ad);
            element.SetElementValue("Soyad", model.Soyad);
            element.SetElementValue("Firma", model.Firma);



            element.SetElementValue("Adres", model.Adres);
            element.SetElementValue("TeslimatAdresi", model.TeslimatAdresi);

            element.SetElementValue("WebAdresi", model.WebAdresi);
            element.SetElementValue("StatikIpAdresi", model.StatikIpAdresi);

            Kaydet();
        }

        public void Sil(string no)
        {
            Veri.Root.Elements("Kullanici").Where(e => (string)e.Element("No") == no).Remove();
        }

        public void Kaydet()
        {
            Veri.Save(VeriYolu);
        }

        public Kullanici Bilgi(string no)
        {
            return Bellek.Find(b => b.No == no);
        }

        public XElement Bul(string no)
        {
            XElement element = Veri.Root.Elements("Kullanici").Where(e => (string)e.Element("No") == no).FirstOrDefault();
            return element;
        }

        public IEnumerable<Kullanici> Liste()
        {
            return Bellek;
        }

        public Kullanici Kontrol(Kullanici model)
        {
            return Bellek.Find(b => b.Mail == model.Mail && b.Parola == model.Parola);
        }

        public bool Varmi(Kullanici model)
        {
            bool Donen = false;
            Kullanici k = Kontrol(model);
            if (k != null)
            {
                Donen = true;
                GirisBasarili(k);

            }
            else
            {
                Donen = false;
                GirisBasarisiz();
            }

            return Donen;
        }

        public bool Varmi(string Mail, string Parola)
        {
            bool Donen = false;
            Kullanici k = new Kullanici();
            k.Mail = Mail;
            k.Parola = Parola;
            k = Kontrol(k);

            if (k != null)
            {
                Donen = true;

                GirisBasarili(k);
            }
            else
            {
                Donen = false;
                GirisBasarisiz();
            }

            return Donen;
        }

        private void GirisBasarili(Kullanici model)
        {
            Oturum.KullaniciMail(model.Mail);
            Oturum.Kullanici(model.Ad);
            Oturum.KullaniciSoyad(model.Soyad);
            Oturum.No(model.No);

            Oturum.Yetki(model.Yetki);
            Oturum.Yetkilimi(true);
        }

        private void GirisBasarisiz()
        {
            Oturum.Yetkilimi(false);
        }



    }
}
