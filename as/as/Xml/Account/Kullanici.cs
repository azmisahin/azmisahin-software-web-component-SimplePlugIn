using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace @as.Xml.Account
{
    public class Kullanici
    {
        public string No { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public string Parola { get; set; }
        public string Mail { get; set; }
        public string Resim { get; set; }
        public bool Oturum { get; set; }
        public int Yetki { get; set; }
        public string Adres { get; set; }
        public string TeslimatAdresi { get; set; }
        public string WebAdresi { get; set; }
        public string StatikIpAdresi { get; set; }

        public Kullanici()
            {
                this.No = Guid.NewGuid().ToString();
                this.Ad = string.Empty;
                this.Soyad = string.Empty;
                this.Parola = string.Empty;
                this.Firma = string.Empty;
                this.Mail = string.Empty;
                this.Resim = string.Empty;
                this.Oturum = false;
                this.Yetki = 3;
                this.Adres = string.Empty;
                this.TeslimatAdresi = string.Empty;
                this.WebAdresi = string.Empty;
                this.StatikIpAdresi = string.Empty;
            }

            public Kullanici(
                string No,
                string Ad,
                string Soyad,
                string Firma,
                string Parola,
                string Mail,
                string Resim,
                bool Online,
                int Yetki,
                string Adres,
                string TeslimatAdresi,
                string WebAdresi,
                string StatikIpAdresi
                )
            {
                this.No = No;
                this.Ad = Ad;
                this.Soyad = Soyad;
                this.Parola = Parola;
                this.Firma = Firma;
                this.Mail = Mail;
                this.Resim = Resim;
                this.Oturum = Online;
                this.Yetki = Yetki;
                this.Adres = Adres;
                this.TeslimatAdresi = TeslimatAdresi;
                this.WebAdresi=WebAdresi;
                this.StatikIpAdresi=StatikIpAdresi;
            }
    }
}