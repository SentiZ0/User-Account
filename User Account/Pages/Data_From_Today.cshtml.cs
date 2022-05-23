using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using User_Account.Models;
using User_Account.Services.Interfaces;
using Newtonsoft.Json;

namespace User_Account.Pages
{
    public class Saved_In_SessionModel : PageModel
    {
        private readonly IPersonService _personService;

        public List<Person> Persons { get; set; }

        public Saved_In_SessionModel(IPersonService personService)
        {
            _personService = personService;
        }

        public void OnGet()
        {
            Persons = _personService.GetEntriesFromToday();
        }
    }
}
