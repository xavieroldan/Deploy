using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoginDeploy1.Data;
using LoginDeploy1.Models;

namespace LoginDeploy1
{
    public class IndexModel : PageModel
    {
        private readonly LoginDeploy1.Data.Context _context;

        public IndexModel(LoginDeploy1.Data.Context context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
