using DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LibraryApp.Pages
{
    public class BooksModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public string ErrorMessage { get; set; }
        public IEnumerable<Book>? Books { get; set; }

        public BooksModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("BookController");
            var response = await httpClient.GetAsync("/api/book");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Books = JsonConvert.DeserializeObject<IEnumerable<Book>>(content);
            }
            else
            {
                Books = new List<Book>();
            }

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("BookController");
            var response = await httpClient.DeleteAsync($"/api/book/delete/{id}");
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
    }
}