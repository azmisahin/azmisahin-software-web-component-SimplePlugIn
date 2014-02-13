using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Mail;

namespace @as.Net
{
    public class Mail
    {
        #region Default Tanım
        private string Host { get; set; }
        private int Port { get; set; }
        private string KullaniciAdi { get; set; }
        private string KullaniciSifre { get; set; }
        private string GonderenMail { get; set; }
        private string MailImza { get; set; }
        private bool SSL { get; set; }        
        #endregion

        #region Constractor
        /// <summary>
        /// Yapılandırıcı
        /// Mail("smtp.azmisahin.com","bilgi@azmisahin.com","123","bilgi@azmisahin.com","imza",true);
        /// </summary>
        /// <param name="Host"></param>
        /// <param name="Port"></param>
        /// <param name="KullaniciAdi"></param>
        /// <param name="Sifre"></param>
        /// <param name="GonderenMail"></param>
        /// <param name="MailImza"></param>
        /// <param name="SSL"></param>
        public Mail(string Host, int Port, string KullaniciAdi, string Sifre, string GonderenMail, string MailImza, bool SSL)
        {
            this.Host = Host;
            this.Port = Port;
            this.KullaniciAdi = KullaniciAdi;
            this.KullaniciSifre = Sifre;
            this.GonderenMail = GonderenMail;
            this.MailImza = MailImza;
            this.SSL = SSL;
        }        
        #endregion

        #region Method
        /// <summary>
        /// Tekil Mail Gönder
        /// </summary>
        /// <param name="adres"></param>
        /// <param name="MailKonu"></param>
        /// <param name="MailIcerik"></param>
        /// <returns></returns>
        public string Gonder(string adres, string MailKonu, string MailIcerik)
        {
            string Donen = string.Empty;

            try
            {
                SmtpClient mail = new SmtpClient();
                mail.Host = Host;
                mail.Port = Port;
                mail.Credentials = new System.Net.NetworkCredential(KullaniciAdi, KullaniciSifre);
                mail.EnableSsl = SSL;
                MailMessage mesaj = new MailMessage();
                mesaj.IsBodyHtml = true;
                mesaj.Priority = MailPriority.High;
                mesaj.From = new MailAddress(GonderenMail);
                
                mesaj.To.Add(adres);
                
                mesaj.Subject = MailKonu;
                mesaj.Body = MailIcerik + "<br><br><br>" + MailImza;
                mail.Send(mesaj);
                Donen = "İşlem Tamamlandı";
            }
            catch (Exception ex)
            {
                Donen = "İşlem Gerçekleşmedi" + ex.Message.ToString();

            }

            return Donen;

        }

        /// <summary>
        /// Çoklu Mail Gönder
        /// </summary>
        /// <param name="adresler"></param>
        /// <param name="MailKonu"></param>
        /// <param name="MailIcerik"></param>
        /// <returns></returns>
        public string Gonder(List<string> adresler, string MailKonu, string MailIcerik)
        {
            string Donen = string.Empty;

            try
            {
                SmtpClient mail = new SmtpClient();
                mail.Host = Host;
                mail.Port = Port;
                mail.Credentials = new System.Net.NetworkCredential(KullaniciAdi, KullaniciSifre);
                mail.EnableSsl = SSL;
                MailMessage mesaj = new MailMessage();
                mesaj.IsBodyHtml = true;
                mesaj.Priority = MailPriority.High;
                mesaj.From = new MailAddress(GonderenMail);
                foreach (string adres in adresler)
                {
                    mesaj.To.Add(adres);
                }
                mesaj.Subject = MailKonu;
                mesaj.Body = MailIcerik + "<br><br><br>" + MailImza;
                mail.Send(mesaj);
                Donen = "İşlem Tamamlandı";
            }
            catch (Exception ex)
            {
                Donen = "İşlem Gerçekleşmedi" + ex.Message.ToString();

            }

            return Donen;

        }

        /// <summary>
        /// Çoklu Mail ve Ekli Dosya Gönder
        /// </summary>
        /// <param name="adresler"></param>
        /// <param name="MailKonu"></param>
        /// <param name="MailIcerik"></param>
        /// <param name="dosyalar"></param>
        public void Gonder(List<string> adresler, string MailKonu, string MailIcerik, List<Attachment> dosyalar)
        {
            SmtpClient mail = new SmtpClient();
            mail.Host = Host;
            mail.Port = Port;
            mail.Credentials = new System.Net.NetworkCredential(KullaniciAdi, KullaniciSifre);
            mail.EnableSsl = SSL;
            MailMessage mesaj = new MailMessage();
            mesaj.IsBodyHtml = true;
            mesaj.Priority = MailPriority.High;
            mesaj.From = new MailAddress(GonderenMail);
            foreach (string adres in adresler)
            {
                mesaj.To.Add(adres);
            }
            foreach (Attachment dosya in dosyalar)
            {
                mesaj.Attachments.Add(dosya);
            }
            mesaj.Subject = MailKonu;
            mesaj.Body = MailIcerik + "<br><br><br>" + MailImza;
            mail.Send(mesaj);
        }        

        #endregion

    }
}
