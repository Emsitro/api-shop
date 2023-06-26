namespace Shop.models
{
    public class Product
    {
            public int id { get; set; }     
            public string Name { get; set; } = string.Empty; 
            public int Price { get; set; }  = 0;                    
            public string ProductCategory { get; set; } = string.Empty;
    }
}
