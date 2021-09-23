var app = angular.module('phone', []);


app.controller('islemler', function ($scope, $http) {
    $http.get("http://localhost:58760/api/Veri/TumTelGetir")
        .then(function (response) {
            $scope.veriler = response.data;
        });
    $scope.verisil = function (silinecekID) {
        $http.get("http://localhost:58760/api/Veri/VeriSilID", { params: { id: silinecekID } })
            .then(function (response) {
                $scope.veriler = response.data;
            });
    }
    $scope.idyegoregetir = function (sayi) {
        $http.get("http://localhost:58760/api/Veri/KisiGetirIDyeGore", { params: { KisiID: sayi } })
            .then(function (response) {
                $scope.idyegoregelen = response.data;
            });
    }
    $scope.telegoregetir = function (tel) {
        $http.get("http://localhost:58760/api/Veri/KisiGetirTeleGore", { params: { Tel: tel } })
            .then(function (response) {
                $scope.idyegoregelen = response.data;
            });
    }
    $scope.kullaniciekle = function (veri) {
        $http.post("http://localhost:58760/api/Veri/KullaniciEkle", veri)
            .then(function (response) {
              
                $scope.veriler = response.data;
                $scope.veri = {};
            });
    }
    $scope.kullaniciguncelle = function (veri)
    {
        $scope.veri = veri;
    }
    $scope.guncelle = function (yeni)
    {
        $http.post("http://localhost:58760/api/Veri/KullaniciGuncelle", yeni)
            .then(function (response) {
                if (response.data ==true) {
                    $http.get("http://localhost:58760/api/Veri/TumTelGetir")
                        .then(function (response) {
                            $scope.veriler = response.data;
                            alert("Guncelleme islemi basariyla tamamlandi");
                        });
                }
                else alert("Kullanici guncelleme islemi sirasinde bir hata olustu");
                $scope.veri = {};
            });
    }
});