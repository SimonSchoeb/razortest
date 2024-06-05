using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public String Message { get; set; }
    public List<Person> person { get; set; } = Person.list;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Message = "";
    }

    public IActionResult OnGet()
    {
        Message = DateTime.Now.ToString();
        // foreach (var h in HttpContext.Request.Headers)
        // {
        //     Console.WriteLine($"{h.Key} : {h.Value}");
        // }
        string? ah = HttpContext.Request.Headers["Authorization"];
        if (ah == null)
        {
            HttpContext.Response.Headers.Append("WWW-Authenticate", "Basic realm=\"my demo\"");
            return Unauthorized();  // 401 Response
        } else {
            string[] ahv = ah.Split(' ');
            string? upw = Encoding.UTF8.GetString(Convert.FromBase64String(ahv[1]));
            System.Console.WriteLine(upw);
            string[]ua = upw.Split(':');
            if (ua[0] != "admin" || ua[1] != "hello123-0")
            {
                return Unauthorized();  // 401 Response
            }
            return Page();          // 200 Response
        }
    }
}

