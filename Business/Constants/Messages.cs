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
    }
}
