namespace BLL;
using BOL;
using DAL;


public class catalog
{
     public List<products> GetAllProducts(){
        List<products> allProducts = new List<products>();
        allProducts=DBManager.GetAllProducts();
        return allProducts; 
     }

}
