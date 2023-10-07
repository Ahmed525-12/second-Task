using BLL.Interfaces;
using DAL.Context;
using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositries
{
    public class ProductsRepo : ProductIce
    {
        private readonly ProductsContext productsContext;

        public ProductsRepo(ProductsContext productsContext)
        {
            this.productsContext = productsContext;
        }

        public int AddProduct(Products Product)
        {
            productsContext.Add(Product);
            return productsContext.SaveChanges();
        }

        public int DeleteProduct(Products Product)
        {
            productsContext.Remove(Product);
            return productsContext.SaveChanges();
        }

        public Products ProductGetByID(int ID)
        {
            return productsContext.products.Find(ID);
        }

        public IEnumerable<Products> GetALL()
        {
            return productsContext.products.ToList();
        }

        public void ImportProductsFromJson()
        {
            var json = File.ReadAllText("D:/Work/second Task/products.json");
            var products = JsonConvert.DeserializeObject<List<Products>>(json);

            productsContext.products.AddRange(products);
            productsContext.SaveChanges();
        }

        public int UpdateProduct(Products Product)
        {
            productsContext.Update(Product);
            return productsContext.SaveChanges();
        }
    }
}