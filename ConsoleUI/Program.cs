using Business.Conceretes;
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
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("\nHello, World!");
        }
    }
}