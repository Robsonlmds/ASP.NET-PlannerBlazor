using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.Models;

public enum TodoPriority
{
    Urgent = 1,
    Important = 2,
    Casual = 3
}

public class Todo
{
    //[Key] //Evidenciar de outra forma
    public int Id { get; set; }

    //[Required] //Evidenciar de outra forma
    public DateTime CreationDate { get; set; }
    public TodoPriority Priority { get; set; } = TodoPriority.Casual; /*/// Vir como CASUAL ///*/

    //[Required] //Evidenciar de outra forma
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool Done { get; set; }
    public DateTime? DoneDate { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }


    [NotMapped] /*/// Faz com que esta propiedade nao va para o banco de dados ///*/
    public bool Edit { get; set; }
}
