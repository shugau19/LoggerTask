using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logger;
using NLog;

namespace Check1.Pages
{
    public class IndexModel : PageModel
    {
        
        public IndexModel()
        {
        
        }

        public void OnGet()
        {
            Class1.Write(LogLevel.Error, new Exception("This is the exception"), "Testing Nlog");
        }
    }
}
