namespace DI_Demo.Models
{
    public class Products
    {
        public int pId { get; set; }
        public string pName { get; set; }
        public string pCategory { get; set; }
        public int pPrice { get; set; }
        public bool pIsInStock { get; set; }

        static List<Products> pList = new List<Products>()
        {
            new Products(){ pId=101, pName="Pepsi", pCategory="Cold-Drink", pPrice=50, pIsInStock=true},
            new Products(){ pId=102, pName="IPhone", pCategory="Cold-Drink", pPrice=50, pIsInStock=true},
            new Products(){ pId=103, pName="Appy", pCategory="Cold-Drink", pPrice=50, pIsInStock=true},
            new Products(){ pId=104, pName="Air Pods", pCategory="Cold-Drink", pPrice=50, pIsInStock=true},
            new Products(){ pId=105, pName="Dell", pCategory="Cold-Drink", pPrice=50, pIsInStock=true},
            new Products(){ pId=106, pName="Surface Pro", pCategory="Cold-Drink", pPrice=50, pIsInStock=true},
            new Products(){ pId=107, pName="Seltos", pCategory="Cold-Drink", pPrice=50, pIsInStock=true},
        };

        public List<Products> GetAllProducts()
        {
            return pList;
        }
    }
}




