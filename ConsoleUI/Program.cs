﻿using Business.Conceretes;
using DataAccess.Abstracts;
using DataAccess.Conceretes;
using DataAccess.Conceretes.EntityFramework;
using DataAccess.Conceretes.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // IoC !!
            ProductTest();
            //CategoryTest();
            Console.WriteLine("\nHello, World!");
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName + " --> " + product.CategoryName);
            }
        }
    }
}