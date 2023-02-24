using Microsoft.AspNetCore.Mvc;

namespace BooksServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookListController : ControllerBase
    {
        private static readonly string[] BookTitles = new[]
        {
            "Moby Dick", "Waldo", "Adventure Time", "American Dream"
        };

        private readonly ILogger<BookListController> _logger;

        public BookListController(ILogger<BookListController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetBookList")]
        public IEnumerable<BookList> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new BookList
            {

                BookTitle = BookTitles[Random.Shared.Next(BookTitles.Length)],
                Rating = Random.Shared.Next(1,5)
            })
            .ToArray();
        }
    }
}