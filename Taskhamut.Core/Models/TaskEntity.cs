using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskhamut.Core.Models;

// Model for the SampleDataService. Replace with your own model.
public class TaskEntity
{
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

    public ICollection<CategoryEntity>? Categories
    {
        get; set;
    }

    public List<TaskEntity> generateSampleData()
    {
        var newId = 1;  
        return new List<TaskEntity>
        {
            new TaskEntity() {TaskId = newId++, TaskName = "Mow front", Summary = "Mow front yard", Detail = "defer if weather prevents", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Laundry", Summary = "Wash clothes", Detail = "include bedding, towels, dishtowels", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Wash Car", Summary = "", Detail = "", Completed= true },
            new TaskEntity() {TaskId = newId++, TaskName = "Do Dishes", Summary = "", Detail = "", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Exercise", Summary = "", Detail = "", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Pay bills", Summary = "", Detail = "", Completed= false },
            new TaskEntity() {TaskId = newId++, TaskName = "Watch sports", Summary = "", Detail = "Somebody has to do it!", Completed= false },
            //new TaskEntity() {TaskId = newId++, TaskName = "", Summary = "", Detail = "", Completed= false },
        };
    }
}