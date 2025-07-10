using System.Text.Json.Serialization;

namespace Bookstore.Models
{
    public class BookGridData : GridData
    {
        // set initial sort field in constructor
        public BookGridData() => SortField = nameof(Book.Title);

        // sort flags. Helping method so no need for serialization.
        [JsonIgnore]
        public bool IsSortByGenre =>
            SortField.EqualsNoCase(nameof(Genre));
        [JsonIgnore]
        public bool IsSortByPrice =>
            SortField.EqualsNoCase(nameof(Book.Price));
    }
}
