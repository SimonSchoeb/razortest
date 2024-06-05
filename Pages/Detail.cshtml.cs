using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor.Pages
{
    public class DetailModel : PageModel
    {
        public Person person { get; set; } = new();

        public void OnGet(int id)
        {
            person = Person.list.FirstOrDefault(p => p.Id == id)??new();
        }

        public IActionResult OnPost(Person p)
        {
            Person? u = Person.list.FirstOrDefault(q => q.Id == p.Id);
            if (u != null)
            {
                u.Name = p.Name;
                u.Age = p.Age;
            }
            Person.Save();
            return RedirectToPage("Index");
        }
    }
}
