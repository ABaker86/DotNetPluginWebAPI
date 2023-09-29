using System;

namespace Plugin.Core
{

    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string value, string valueToCompare) =>
            value.Equals(valueToCompare, StringComparison.OrdinalIgnoreCase);
    }

}
