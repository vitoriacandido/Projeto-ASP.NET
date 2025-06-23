using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Task Task { get; set; } = new Task();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Tasks.Add(Task);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}


@page
@model TaskManagerApp.Pages.Tasks.CreateModel
@{
    ViewData["Title"] = "Criar Tarefa";
}

<h1>Criar Tarefa</h1>

<form method="post">
    <div class="mb-3">
        <label asp-for="Task.Title" class="form-label"></label>
        <input asp-for="Task.Title" class="form-control" />
        <span asp-validation-for="Task.Title" class="text-danger"></span>
    </div>
    <div class="mb-3">
        <label asp-for="Task.Description" class="form-label"></label>
        <textarea asp-for="Task.Description" class="form-control"></textarea>
        <span asp-validation-for="Task.Description" class="text-danger"></span>
    </div>
    <div class="form-check mb-3">
        <input asp-for="Task.IsCompleted" class="form-check-input" />
        <label asp-for="Task.IsCompleted" class="form-check-label"></label>
    </div>
    <button type="submit" class="btn btn-primary">Salvar</button>
    <a asp-page="Index" class="btn btn-secondary">Cancelar</a>
</form>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
