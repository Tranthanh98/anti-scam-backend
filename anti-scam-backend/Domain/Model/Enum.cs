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

    public enum EStatusPost : int
    {
        Undefined = 0,
        [Display(Description = "Chờ duyệt")]
        WatingAccept = 1,
        [Display(Description = "Đã duyệt")]
        Accepted = 2,
        [Display(Description = "Từ chối duyệt")]
        Denied = 3
    }

    public enum EStatusAdmin : int
    {
        Undefined = 0,
        [Display(Description = "Hoạt động")]
        Acitve = 1,
        [Display(Description = "Ngừng hoạt động")]
        InActive = 2,
    }
}
