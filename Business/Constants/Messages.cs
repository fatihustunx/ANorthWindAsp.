using Core.Entities.Conceretes;
using Entities.Conceretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi!";
        public static string MaintenanceTime = "Sistem bakımda!!";
        public static string ProductsListed = "Ürünler listelendi!";

        public static string ProductNameAlreadyExists = "Ürün ismi zaten var!";

        public static string ProductCountOfCategoryError = "Kategorideki ürün limiti aşıld!";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor!";

        public static string AuthorizationDenied = "Authorization Denied!!";
        public static string UserRegistered = "User Registered!";
        public static string UserNotFound = "User Not Found!!";
        public static string PasswordError = "Password Error!!";
        public static string SuccessfulLogin = "Successful Login!";
        public static string UserAlreadyExists = "User Already Exist!!";
        public static string AccessTokenCreated = "Access Token Created!";
    }
}
