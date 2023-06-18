using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskhamut.Core.Models;
public class UserEntity
{
    [Key]
    public int UserId {
        get; set;
    }
    public string UserName {
        get; set;
    }
    public string Password {
        get; set;
    }
    public string? DisplayName {
        get; set;
    }
    public string? Email {
        get; set;
    }

    public UserEntity() {
        UserId = 0;
        UserName = "";
        Password = "";
    }
}
