using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Services.Helper
{
    public static class PostHelper
    {
        public static string CreateLinkPost(string title)
        {
            var titleRemoveTone = StringHelper.RemoveVietNameTone(title);

            var listStrTitle = titleRemoveTone.Split(" ");
            var link = string.Join("-", listStrTitle);
            return link;
        }
    }
}
