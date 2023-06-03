using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskhamut.Models;

// Model for the SampleDataService. Replace with your own model.
public class TaskEntity
{
    public int TaskID
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
}