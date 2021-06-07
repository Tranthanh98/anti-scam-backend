using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anti_scam_backend.Services.Helper
{
    public static class StringHelper
    {
        private static Dictionary<string, string> dicBadWords = new Dictionary<string, string>()
        {
            {"địt", "***" },
            {"dit", "***" },
            {"mẹ", "**" },
            {"me", "**" },
            {"lồn", "***" },
            {"lon", "***" },
            {"má", "**" },
            {"đĩ", "***" },
            {"cặc", "***" },
            {"buồi", "****" },
            {"nứng", "****" },
            {"đụ", "**" },
            {"đéo", "***" },
            {"ditme", "*****" },
            {"đjt", "***" },
            {"djt", "***" },
            {"loz", "***" },
            {"dumoa", "*****" },
            {"fuck", "****" },
            {"fucking", "****" },
            {"bitch", "****" },
            {"bitches", "****" },
            {"chó", "****" },
            {"lòn", "****" },
        };

        public static string RemoveBadWord(string str)
        {
            StringBuilder data = new StringBuilder();
            var tempSplit = str.Split(" ");
            foreach(var item in tempSplit)
            {
                if (dicBadWords.ContainsKey(item.ToLower()))
                {
                    string temp;
                    dicBadWords.TryGetValue(item.ToLower(), out temp);
                    if(temp != null)
                    {
                        data.Append($"{temp} ");
                    }
                }
                else
                {
                    data.Append($"{item} ");
                }
            }
            return data.ToString();
        }

        public static string RemoveVietNameTone(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };
    }
}
