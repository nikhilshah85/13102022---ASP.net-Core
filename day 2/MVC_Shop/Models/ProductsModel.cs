namespace MVC_Shop.Models
{
    public class ProductsModel
    {
        public int pId { get; set; }
        public string pName { get; set; }
        public string pCategory { get; set; }
        public double pPrice { get; set; }
        public bool pIsInStock { get; set; }


      private static List<ProductsModel> pList = new List<ProductsModel>()
        {
            new ProductsModel(){ pId=101, pName="Pepsi", pCategory="Cold-Drink", pIsInStock=true, pPrice=2},
            new ProductsModel(){ pId=102, pName="Appy", pCategory="Cold-Drink", pIsInStock=true, pPrice=3},
            new ProductsModel(){ pId=103, pName="IPhone", pCategory="Electronics", pIsInStock=false, pPrice=1900},
            new ProductsModel(){ pId=104, pName="AirPods", pCategory="Electronics", pIsInStock=true, pPrice=750},
            new ProductsModel(){ pId=105, pName="Nike", pCategory="Shoe", pIsInStock=false, pPrice=1250},
        };

        public List<ProductsModel> GetAllProducts()
        {
            return pList;
        }
    }
}
