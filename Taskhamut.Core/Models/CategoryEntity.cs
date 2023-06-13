using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskhamut.Core.Models;
public class CategoryEntity {
    public int CategoryId {
        get; set;
    }

    public string? CategoryName {
        get; set;
    }

    public string? CategoryDescription {
        get; set;
    }

}
