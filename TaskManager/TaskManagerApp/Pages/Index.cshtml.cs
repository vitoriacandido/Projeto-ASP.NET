using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Task> Tasks { get; set; } = new List<Task>();

        public async Task OnGetAsync()
        {
            Tasks = await _context.Tasks.AsNoTracking().ToListAsync();
        }
    }
}


@page
@model TaskManagerApp.Pages.Tasks.IndexModel
@{
    ViewData["Title"] = "Tarefas";
}

<h1>Tarefas</h1>

<p>
    <a asp-page="Create">Criar Nova Tarefa</a>
</p>

<table class="table">
    <thead>
        <tr>
            <th>Título</th>
            <th>Descrição</th>
            <th>Concluída</th>
            <th>Ações</th>
        </tr>
    </thead>
    <tbody>
    @foreach (var task in Model.Tasks)
    {
        <tr>
            <td>@task.Title</td>
            <td>@task.Description</td>
            <td>@(task.IsCompleted ? "Sim" : "Não")</td>
            <td>
                <a asp-page="Edit" asp-route-id="@task.Id">Editar</a> |
                <a asp-page="Delete" asp-route-id="@task.Id">Excluir</a>
            </td>
        </tr>
    }
    </tbody>
</table>

