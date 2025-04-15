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
    public TodoPriority Priority { get; set; }

    //[Required] //Evidenciar de outra forma
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool Done { get; set; }
    public DateTime? DoneDate { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; } 
}
