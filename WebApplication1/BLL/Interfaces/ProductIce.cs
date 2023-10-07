using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ProductIce
    {
        public void ImportProductsFromJson();

        IEnumerable<Products> GetALL();

        Products ProductGetByID(int ID);

        int AddProduct(Products Product);

        int DeleteProduct(Products Product);

        int UpdateProduct(Products Product);
    }
}