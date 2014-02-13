using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Xml.Linq;

namespace @as.Xml.Account
{
    public static class Oturum
    {
        #region Method

        #region Kullanici Mail
        public static string KullaniciMail()
        {
            string Donen = string.Empty;
            try
            {

                Donen = (string)HttpContext.Current.Session["KullaniciMail"];
            }
            catch (Exception)
            {

                Donen = string.Empty;
            }
            return Donen;
        }

        public static void KullaniciMail(string i)
        {
            HttpContext.Current.Session["KullaniciMail"] = i;
        }
        #endregion

        #region Kullanici Ad
        public static string KullaniciAd()
        {
            string Donen = string.Empty;
            try
            {
                Donen = (string)HttpContext.Current.Session["KullaniciAd"];
            }
            catch (Exception)
            {

                Donen = string.Empty;
            }
            return Donen;
        }

        public static void Kullanici(string i)
        {
            HttpContext.Current.Session["KullaniciAd"] = i;
        }
        #endregion

        #region Kullanici Soyad
        public static string KullaniciSoyad()
        {
            string Donen = string.Empty;
            try
            {
                Donen = (string)HttpContext.Current.Session["KullaniciSoyad"];
            }
            catch (Exception)
            {

                Donen = string.Empty;
            }
            return Donen;
        }

        public static void KullaniciSoyad(string i)
        {
            HttpContext.Current.Session["KullaniciSoyad"] = i;
        }
        #endregion

        #region Yetki
        public static int Yetki()
        {
            int Donen = 0;
            try
            {
                Donen = (int)HttpContext.Current.Session["Yetki"];
            }
            catch (Exception)
            {

                Donen = 0;
            }
            return Donen;
        }

        public static void Yetki(int i)
        {
            HttpContext.Current.Session["Yetki"] = i;
        }
        #endregion

        #region Yetki li mi ?
        public static bool Yetkilimi()
        {
            bool Donen = false;
            try
            {
                Donen = (bool)HttpContext.Current.Session["Yetkilimi"];
            }
            catch (Exception)
            {

                Donen = false;
            }
            return Donen;
        }

        public static void Yetkilimi(bool i)
        {
            HttpContext.Current.Session["Yetkilimi"] = i;
        }
        #endregion

        #region Domain
        public static string Domain()
        {
            string Donen = new Guid().ToString();
            try
            {
                Donen = (string)HttpContext.Current.Session["Domain"];
            }
            catch (Exception)
            {

                Donen = new Guid().ToString();
            }
            return Donen;
        }

        public static void Domain(string i)
        {
            HttpContext.Current.Session["Domain"] = i;
        }
        #endregion

        #region Guid
        public static string No()
        {
            string Donen = new Guid().ToString();
            try
            {
                Donen = (string)HttpContext.Current.Session["No"];
            }
            catch (Exception)
            {

                Donen = new Guid().ToString();
            }
            return Donen;
        }

        public static void No(string i)
        {
            HttpContext.Current.Session["No"] = i;
        }
        #endregion

        #endregion
    }
}
