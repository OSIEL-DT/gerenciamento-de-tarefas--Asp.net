using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Models;

namespace TaskManagerApp.Data
{
    // Classe de contexto do banco de dados que gerencia o modelo TaskItem
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Tabela de tarefas
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
