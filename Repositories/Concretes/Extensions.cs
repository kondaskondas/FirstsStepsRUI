using System;

namespace FirstsStepsRUI.Repositories
{
    public static class Extensions
    {
        public static bool IsValid(this string value)
        {
            return !value.IsInvalid();
        }

        public static bool IsInvalid(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }
    }
}
