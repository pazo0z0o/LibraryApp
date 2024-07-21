using DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace LibraryApp.Pages
{
    public class PostEditModel : PageModel
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public string ErrorMessage { get; set; }

        public PostEditModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public Book? Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                Book = new();
                return Page();
            }

            var httpClient = _httpClientFactory.CreateClient("BookController");
            var response = await httpClient.GetAsync($"api/book/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Book = JsonConvert.DeserializeObject<Book>(content);
                return Page();
            }

            return NotFound();
        }


        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var httpClient = _httpClientFactory.CreateClient("BookController");
            HttpResponseMessage response;

            // id == 0 :meaning the book was not created yet
            if (Book.Id == 0)
            {
                response = await httpClient.PostAsJsonAsync("api/book", Book);
            }
            else
            {
                response = await httpClient.PutAsJsonAsync($"api/book/{Book.Id}", Book);
            }

            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = "Failed to create book.";
                return RedirectToPage("/Books");
            }
            else 
            {
                return RedirectToPage("/Books");
            }

        
        }
    }
}
