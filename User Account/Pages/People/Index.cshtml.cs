#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using User_Account.Data;
using User_Account.Models;
using Microsoft.AspNetCore.Authorization;
using User_Account.Services;
using User_Account.Services.Interfaces;


namespace User_Account.Pages.People
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IPersonService _personService;

        public IndexModel(IPersonService personService)
        {
            _personService = personService;
        }

        public string UserName { get; set; }


        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = _personService.GetAllEntries();
            UserName = User.Identity.Name;
        }
    }
}
