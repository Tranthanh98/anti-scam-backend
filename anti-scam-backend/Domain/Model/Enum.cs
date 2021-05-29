using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Model
{
    public enum EKindOf : int
    {
        Undefined = 0,
        [Display(Description = "Uy tín")]
        Reputation = 1,
        [Display(Description ="Lừa đảo")]
        Cheat = 2,
    }
}
