﻿using DataAccess.Abstracts;
using Entities.Conceretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conceretes.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15 },
                new Product { Id = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product { Id = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product { Id = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 },
                new Product { Id = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // LINQ -> Language Integrated Query, Lamda Func.
            Product productToDelete = _products.SingleOrDefault(p => p.Id == product.Id);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=> p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.Id == product.Id);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}