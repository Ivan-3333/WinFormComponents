using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormComponents.Utilities
{
    internal class Utility
    {
        public static IList<T> Search<T>(IList<T> original, string txt)
        {
            if (original != null && original.Count > 0 && !string.IsNullOrEmpty(txt))
            {
                try
                {
                    return original.Where(x => x.GetType().GetProperties().Any(p =>
                    {
                        var value = p.GetValue(x, null);
                        return value != null && value.ToString().ToLower().Contains(txt.ToLower());
                    })).ToList();
                }
                catch { }
            }
            return original;
        }
    }
}
