using User_Account.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using User_Account.Services;
using User_Account.Services.Interfaces;
using User_Account.Data;

namespace DataBase.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPersonService _personService;

        public IList<Person> People { get; set; }

        public string AlertMessage { get; set; }

        [BindProperty]
        public Person Person { get; set; }

        public IndexModel(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult OnPost()
        {
            Person.CheckLeapYear();

            Person.DataUpdateTime = DateTime.Now;

            Person.UserName = User.Identity.Name;

            _personService.AddEntry(Person);

            if (!ModelState.IsValid)
            {
                if (Person.LastName == null)
                {
                    AlertMessage = $"Poprawnie przyjęto dane. {Person.DataUpdateTime}";
                }
                else
                {
                    AlertMessage = $"Wprowadzono niepoprawne dane. {Person.DataUpdateTime}";
                }
                return Page();
            }
            else
            {
                AlertMessage = $"Poprawnie przyjęto dane. {Person.DataUpdateTime}";
                return Page();
            }

        }
        public void OnGet()
        {
            People = _personService.GetAllEntries();
        }
    }
}