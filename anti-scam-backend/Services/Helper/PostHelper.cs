using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace anti_scam_backend.Services.Helper
{
    public static class PostHelper
    {
        public static string CreateLinkPost(string title)
        {
            var strRemoveCha = Regex.Replace(title, @"(@|&|\(|\)|<|>|\#|\?|\%|\$|\^|\*|_|,|\.|\+|\-)", "");
            var titleRemoveTone = StringHelper.RemoveVietNameTone(strRemoveCha);

            var listStrTitle = titleRemoveTone.Split(" ");
            var link = string.Join("-", listStrTitle);
            return link;
        }
    }
}
