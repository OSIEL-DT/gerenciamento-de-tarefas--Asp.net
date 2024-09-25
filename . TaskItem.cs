using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.Models
{
    // Classe que representa uma tarefa
    public class TaskItem
    {
        // Identificador único da tarefa
        [Key]
        public int Id { get; set; }

        // Título da tarefa, campo obrigatório
        [Required]
        public string Title { get; set; }

        // Descrição opcional da tarefa
        public string Description { get; set; }

        // Data de criação da tarefa
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Indica se a tarefa está concluída
        public bool IsCompleted { get; set; }
    }
}
