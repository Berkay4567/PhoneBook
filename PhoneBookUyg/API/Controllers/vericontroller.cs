
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VeriTabaniIslemleri;

namespace API.Controllers
{
    public class VeriController : ApiController
    {
        Islemler i = new Islemler();
        [HttpGet]
        public List<VeriTip> TumTelGetir()
        {
            return i.TumTelGetir();
        }
        [HttpGet]
        public VeriTip KisiGetirIDyeGore(int KisiID)
        {
            return i.KisiGetirIDyeGore(KisiID);
        }
        [HttpGet]
        public VeriTip KisiGetirTeleGore(int Tel)
        {
            return i.KisiGetirTeleGore(Tel);
        }
        [HttpGet]
        public List<VeriTip> VeriSilID(int id)
        {
            return i.VeriSilID(id);
        }
        [HttpPost]
        public List<VeriTip> KullaniciEkle(Veri veri)
        {
            return i.KullaniciEkle(veri);
        }
        [HttpPost]
        public bool KullaniciGuncelle(Veri yeni)
        {
            return i.KullaniciGuncelle(yeni);
        }
    }
}