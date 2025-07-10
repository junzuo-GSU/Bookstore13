namespace Bookstore.Models
{
    // Storing a Book object in session can cause problems because the JSON 
    // serialization, referenced in SessionExtensionMethods.cs, can create circular references
    // because the serializer tries to follow all the navigation properties defined in Book class. 
    // Although we can decorate the navigation properties with [JsonIgnore], we end up with the attribute
    // everywhere. Another way, as shown here, is to create a DTO utility class with the data 
    // needed for the cart but without navigation properties. 
    
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public double Price { get; set; } 
        public Dictionary<int, string> Authors { get; set; } = new Dictionary<int, string>(); //authorId, FullName

        // default constructor (required for model binding)
        public BookDTO() { }

        // overloaded constructor accepts a Book object
        public BookDTO(Book book){
            BookId = book.BookId;
            Title = book.Title;
            Price = book.Price;
            if (book.Authors?.Count > 0) {
                foreach (Author a in book.Authors) {
                    Authors.Add(a.AuthorId, a.FullName);
                }
            }
            
        }
    }

}
