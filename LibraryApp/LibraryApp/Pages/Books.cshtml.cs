using DataModels.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Data.SqlClient;
using Z.Dapper.Plus;


namespace LibraryApp.Pages
{
    public class BooksModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;
        //bound ErrorMessage to the model for exhibition to the page 
        public string? ErrorMessage { get; set; }
        //bound for pagination: keep track and initialize 
        public int CurrentPage { get; set; } =1; //
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;

        public IEnumerable<Book>? Books { get; set; }

        public BooksModel(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<IActionResult> OnGet()
        {
            //pass the default values to the model -- Could Also take the model's initialization at the start of the page
            var currentPage = int.TryParse(HttpContext.Request.Query["pageNumber"], out var pageNumber) ? pageNumber : 1;
            var pageSize = int.TryParse(HttpContext.Request.Query["pageSize"], out var size) ? size : 10;
            CurrentPage = currentPage;
            PageSize = pageSize;

            var httpClient = _httpClientFactory.CreateClient("BookController");
            var response = await httpClient.GetAsync($"/api/book?pageNumber={currentPage}&pageSize={pageSize}");
            //TotalPages = (int)Math.Ceiling( Convert.ToDecimal(response.Headers.GetValues("X-Total-Count").FirstOrDefault()) / PageSize);

            //TotalPages = int.Parse(response.Headers.GetValues("X-Total-Count").FirstOrDefault()) / pageSize;

            if (response.Headers.TryGetValues("X-Total-Count", out var headerValues))
            {
                var totalCount = headerValues.FirstOrDefault();
                if (totalCount != null)
                {
                    TotalPages = (int)Math.Ceiling(Convert.ToDecimal(totalCount) / pageSize);
                }
            }

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Books = JsonConvert.DeserializeObject<IEnumerable<Book>>(content);
                if (!Books.Any())
                {
                    ErrorMessage = "No books found";
                }             
            }
            else
            {
                ErrorMessage = "Failed to fetch books.";
                Books = new List<Book>();
            }
                return Page();

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("BookController");
            var response = await httpClient.DeleteAsync($"/api/book/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage(); //Refresh
            }
            else
            {
                ErrorMessage = "Failed to delete book.";
                return Page();
            }


        }

        public async Task<IActionResult> OnPostGenerateBogusBooks()
        {
            try
            {
                var bogusBooks = new BogusBooks();
                var books = bogusBooks.GenerateBooks(15);  

                using (var connection = new SqlConnection(_config.GetConnectionString("GuestConnection")))
                {
                    connection.BulkInsert(books);
                }

                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error generating books: {ex.Message}";
                return Page();
            }

        }
    }
}