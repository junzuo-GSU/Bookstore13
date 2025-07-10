namespace Bookstore.Models
{
    // When storing CartItem data to the persistent cookie, use a DTO to store the 
    // minimal amount of data required for restoration later from database.

    public class CartItemDTO
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
