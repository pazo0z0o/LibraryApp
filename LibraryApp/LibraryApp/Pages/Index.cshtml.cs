using DataModels.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Drawing.Printing;
using System.Security.Claims;

namespace LibraryApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        [BindProperty]
        public UserAuth? SampleUser { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void OnGet()
        {

        }

        //[Authorize]
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var correctUser = _config.GetSection("Credentials");//.GetValue<string>("Username");
            //var correctPass = _config.GetSection("Credentials")//.GetValue<string>("Username");


            if (SampleUser.UserName == correctUser.GetValue<string>("Username") && SampleUser.Password == correctUser.GetValue<string>("Password"))
            {
                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, SampleUser.UserName),
                    
                };
                //Initialize Cookie authentication
                var claimsIdentity = new ClaimsIdentity(claim, "Cookie");
                //Add it to the claimsPrincipal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync("Cookie", claimsPrincipal);

                return RedirectToPage("/Books");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();



        }
    }
}
