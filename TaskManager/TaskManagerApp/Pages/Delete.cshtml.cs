using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Pages.Tasks
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Task Task { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Task = await _context.Tasks.FindAsync(id);

            if (Task == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var taskToDelete = await _context.Tasks.FindAsync(id);

            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
