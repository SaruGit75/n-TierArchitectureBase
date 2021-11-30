using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var cat in categoryManager.GetAll().Data)
            {
                Console.WriteLine(cat.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager _productManager = new ProductManager(new EfProductDal(),
                new CategoryManager(new EfCategoryDal()));


            var result = _productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var item in _productManager.GetProductDetails().Data)
                {
                    Console.WriteLine(item.ProductName + " -> " + item.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
