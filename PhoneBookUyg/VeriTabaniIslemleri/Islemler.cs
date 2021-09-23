using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace VeriTabaniIslemleri
{
    public class Islemler
    {

        PhoneEntities1 _ent = new PhoneEntities1();
        [HttpGet]
        public List<VeriTip> TumTelGetir()
        {
            return _ent.Veri.Select(p => new VeriTip()
            {
                KisiID = p.KisiID,
                Isim = p.Isim,
                Soyisim = p.Soyisim,
                Tel = p.Tel,
                Cinsiyet = p.Cinsiyet
            }).ToList();
        }
        [HttpPost]
        public List<VeriTip> KullaniciEkle(Veri veri)
        {
            try
            {
                _ent.Veri.Add(veri);
                _ent.SaveChanges();
                return TumTelGetir();
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpGet]
        public VeriTip KisiGetirIDyeGore(int KisiID)
        {
            return _ent.Veri.Where(p => p.KisiID == KisiID).Select(p => new VeriTip()
            {
                KisiID = p.KisiID,
                Isim = p.Isim,
                Soyisim = p.Soyisim,
                Tel = p.Tel,
                Cinsiyet = p.Cinsiyet
            }).FirstOrDefault();
        }
        [HttpGet]
        public VeriTip KisiGetirTeleGore(int Tel)
        {
            return _ent.Veri.Where(p => p.Tel == Tel).Select(p => new VeriTip()
            {
                KisiID = p.KisiID,
                Isim = p.Isim,
                Soyisim = p.Soyisim,
                Tel = p.Tel,
                Cinsiyet = p.Cinsiyet
            }).FirstOrDefault();
        }
        [HttpGet]
        public List<VeriTip> VeriSilID(int id)
        {
            Veri silinecek = _ent.Veri.Find(id);
            _ent.Veri.Remove(silinecek);
            _ent.SaveChanges();
            return TumTelGetir();
        }
        [HttpPost]
        public bool KullaniciGuncelle(Veri yeni)
        {
            try
            {
                Veri eski = _ent.Veri.Find(yeni.KisiID);
                eski.Isim = yeni.Isim;
                eski.Soyisim = yeni.Soyisim;
                eski.Tel = yeni.Tel;
                eski.Cinsiyet = yeni.Cinsiyet;
                _ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

    public class VeriTip
    {
        public int KisiID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public double Tel { get; set; }
        public string Cinsiyet { get; set; }
    }
}
