using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskhamut.Core.Models;

/// <summary>
/// Model for Task entity.  Named TaskEntity to not conflict with prominent .NET Task class(es)
/// </summary>
public class TaskEntity
{
    public TaskEntity()
    {
        Categories = new List<CategoryEntity>();
    }

    [Key]
    public int TaskId
    {
        get; set;
    }

    public string TaskName
    {
        get; set;
    } = "";

    public string? Summary
    {
        get; set;
    }

    public string? Detail
    {
        get; set;
    }

    public bool Completed
    {
        get; set;
    }

    public ICollection<CategoryEntity> Categories
    {
        get; set;
    }

    /// <summary>
    /// Create a collection of sample data, which can be used for development either to seed the database, or as an alternate source for Tasks list instead of MyDbContext.Tasks.
    /// </summary>
    /// <returns>A list of TaskEntity objects.</returns>
    public static List<TaskEntity> GenerateSampleData()
    {
        var newId = 1;  
        return new List<TaskEntity>
        {
            new TaskEntity() {TaskId = newId++, TaskName = "Mow front", Summary = "Mow front yard", Detail = "postpone if weather prevents", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Laundry", Summary = "Wash clothes", Detail = "include bedding, towels, dishtowels", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Wash Car", Summary = "", Detail = "Suffer the dish pan hands", Completed= true },
            new TaskEntity() {TaskId = newId++, TaskName = "Do Dishes", Summary = "", Detail = "", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Imperialism", Summary = "Conquer a 3rd world nation", Detail = "", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Pet care", Summary = "Take pet rock for a walk", Detail = "", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Stare at lava lamp", Summary = "There are faces and bodies in there", Detail = "Remember to turn it on.", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Watch Bugs Bunny/Roadrunner", Summary = "Sitting on my ACME sofa...", Detail = "Sooner or later, Wile must win!", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Exercise", Summary = "", Detail = "One more step than yesterday.", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Pay bills", Summary = "", Detail = "", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Watch sports", Summary = "", Detail = "Somebody has to do it!", Completed= false },
            //*for new*   new TaskEntity() {TaskId = newId++, TaskName = "", Summary = "", Detail = "", Completed= false },
        };
    }
}