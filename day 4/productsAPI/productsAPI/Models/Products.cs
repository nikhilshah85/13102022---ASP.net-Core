using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Channels;

namespace productsAPI.Models
{
    public class Products
    {
        public int pId { get; set; }
        public string pName { get; set; }
        public string pCategory { get; set; }
        public double pPrice { get; set; }
        public bool pIsInStock { get; set; }

        static List<Products> pList = new List<Products>()
        {
            new Products(){ pId=101, pName="Pepsi", pCategory="Cold-Drink" , pIsInStock=true, pPrice=50},
            new Products(){ pId=102, pName="Iphone", pCategory="Electronic" , pIsInStock=true, pPrice=50},
            new Products(){ pId=103, pName="Appy", pCategory="Cold-Drink" , pIsInStock=false, pPrice=50},
            new Products(){ pId=104, pName="Green-Tea", pCategory="Health-Drink" , pIsInStock=true, pPrice=50},
            new Products(){ pId=105, pName="Maggie", pCategory="Fast-Food" , pIsInStock=true, pPrice=50},
            new Products(){ pId=106, pName="Pasta", pCategory="Fast-Food" , pIsInStock=false, pPrice=50},
        };

        public List<Products> GetAllProducts()
        {
            return pList;
        }

        public Products GetProductById(int id)
        {
            var p = (from pr in pList
                     where pr.pId == id
                     select pr).Single();

            if (p != null)
            {
                return p;
            }
            throw new Exception("Product Not Found");
        }

        public string AddProduct(Products newProduct)
        {
            pList.Add(newProduct);
            return "Product Added Successfully";
        }

        public string updateProduct(Products changes)
        {
            var p = (from pr in pList
                     where pr.pId == changes.pId
                     select pr).Single();
            if (p != null)
            {
                p.pName = changes.pName;
                p.pCategory = changes.pCategory;
                p.pPrice = changes.pPrice;
                p.pIsInStock = changes.pIsInStock;
                return "Product Updated Successfully";
            }
            throw new Exception("Product Not Found");
        }
        public string DeleteProduct(int pid)
        {
            var p = (from pr in pList
                     where pr.pId == pid
                     select pr).Single();
            if (p != null)
            {
                pList.Remove(p);
                return "Product Not Found";
            }
            throw new Exception("Product Not Found");
        }
    }

}
