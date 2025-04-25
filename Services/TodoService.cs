using Microsoft.EntityFrameworkCore;
using Planner.Models;
using PlannerBlazor.Models;
using System.Threading.Tasks;

namespace PlannerBlazor.Services;

public class TodoService
{
    /// var nao pode ser modificada, exceto construtor
    private readonly TodoContext _context;

    #region Construtores

    /// <summary>   
    /// Construtor  
    /// <summary>   
    public TodoService(TodoContext _context)
    {
        this._context = _context;
    }
    #endregion

    #region Métodos CRUD

    /// <summary>   
    /// "GetActivesTodos" Método que lista os Todos
    /// <summary>   
    public async Task<List<Todo>> GetActivesTodosAsync() {
        var list = await _context.Todos
            .Where(x => !x.Done) // Adição de "!" == a not -> não está feito
            .OrderByDescending(x => x.Priority > 0) // Fazendo os com prioridades fiquem na frente dos sem status de prioridade
            .ThenBy(x => x.Priority) // Deixando os mais urgentes primeiro
            .ToListAsync();
        return list;
    }

    /// <summary>   
    /// "NewTodo" Método que Cria um Todo
    /// <summary>   
    public async Task NewTodoAsync() {
        await _context.Todos.AddAsync (new Todo
        {
            Title = $"Nova Tarefa, criada em {DateTime.Now}",
            Description = $"Tarefa {DateTime.Now}",
            CategoryId = 1,
        });
        await _context.SaveChangesAsync();
    }

    /// <summary>   
    /// "UpdateTodo" Método que atualiza um Todo
    /// <summary>   
    public async Task<Todo> UpdateAsync(Todo todo) {
        _context.Update(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    /// <summary>   
    /// "DeleteTodo" Método que deleta um Todo
    /// <summary>   
    public async Task DeleteAsync(Todo todo)
    {
        _context.Remove(todo);
        await _context.SaveChangesAsync();
    }

    #endregion 
}
