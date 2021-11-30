using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {   //normal bir mesaj icin surekli newleme islemi yapmamak icin *static* olarak tanimladik.
        
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda...";
        public static string ProductsListed = "Urunler Listelendi...";
        public static string ProductCountOfCategoryError = "Bir Kategoride En Fazla On Urun Olabilir.";
        public static string ProductNameAlreadyExists = "Bu isimde zaten baska bir urun var.";
        public static string CategoryLimitExceded = "Kategori Limiti Aşıldığı için yeni ürün eklenemiyor.";
        public static string AuthorizationDenied = "Yetkiniz Yok!";


        public static string UserRegistered = "Kayıt olundu.";
        public static string UserNotFound = "Kullanıcı bulunanmadi.";
        public static string PasswordError = "Parola Hatası!";
        public static string SuccessfulLogin = "Başarılı Giriş.";
        public static string UserAlreadyExists = "Kullanıcı Zaten Var.";
        public static string AccessTokenCreated = "Access Token Oluşturuldu.";
    }
}
