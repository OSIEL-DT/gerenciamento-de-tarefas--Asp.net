using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o contexto do banco de dados via injeção de dependência
        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para exibir a lista de tarefas
        public async Task<IActionResult> Index()
        {
            var tasks = await _context.TaskItems.ToListAsync();
            return View(tasks);
        }

        // Método GET para criar uma nova tarefa
        public IActionResult Create()
        {
            return View();
        }

        // Método POST para salvar uma nova tarefa no banco de dados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }

        // Método GET para editar uma tarefa existente
        public async Task<IActionResult> Edit(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            return View(taskItem);
        }

        // Método POST para salvar as alterações da tarefa editada
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskItem taskItem)
        {
            if (id != taskItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(taskItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }

        // Método para remover uma tarefa
        public async Task<IActionResult> Delete(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem != null)
            {
                _context.TaskItems.Remove(taskItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
