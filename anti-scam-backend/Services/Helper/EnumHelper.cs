using anti_scam_backend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace anti_scam_backend.Services.Helper
{
    public class IsSystemAttribute : Attribute
    {
    }
    public static class EnumHelper
    {
        public static IEnumerable<T> GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Where(i => i.GetAttribute<IsSystemAttribute>() == null);
        }

        public static string GetDescription(this Enum value)
        {
            var attribute = GetDisplayAttribute(value);
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static List<Selectable> GetSelectableOptions<T>(bool ignoreUnderfined = true) where T : Enum
        {
            var a = GetValues<T>();
            if (ignoreUnderfined)
            {
                a = a.Where(i => (int)(object)i != 0);
            }
            return a.Select(i =>
            {
                int i_value = (int)(object)i;
                Selectable x = new Selectable(i_value.ToString(), GetDescription(i));
                return x;
            }).ToList();
        }

        public static List<string> GetDescriptions<T>() where T : Enum
        {
            return GetValues<T>().Select(i =>
            {
                int i_value = (int)(object)i;
                string x = GetDescription(i);
                return x;
            }).ToList();
        }
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var attribute = value.GetType()
                .GetRuntimeField(value.ToString())
                .GetCustomAttributes(typeof(T), false)
                .SingleOrDefault() as T;
            return attribute;
        }

        private static DisplayAttribute GetDisplayAttribute(Enum value)
        {
            return GetAttribute<DisplayAttribute>(value);
        }
    }
}
