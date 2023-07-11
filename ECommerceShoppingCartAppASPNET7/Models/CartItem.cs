namespace ECommerceShoppingCartAppASPNET7.Models
{
   public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
    }
}
