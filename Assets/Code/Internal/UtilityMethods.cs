using System;

namespace TakeTheSky
{
    public static class UtilityMethods
    {
        public static T RandomEnumValue<T>()
        {
            var enumValues = Enum.GetValues(typeof(T));
            return (T) enumValues.GetValue(new Random().Next(enumValues.Length));
        }
    }
}
