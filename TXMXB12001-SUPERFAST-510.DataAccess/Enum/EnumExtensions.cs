using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace TXMXB12001_SUPERFAST_510
{
    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            object[] attributes = type.GetField(name).GetCustomAttributes(false);
            if (attributes.Length < 1)
            {
                throw new Exception("Attribute Not Found in Enum value.");
            }
            foreach (object attribute in attributes)
            {
                if (attribute is TAttribute)
                {
                    return (TAttribute)attribute;
                }
            }
            throw new Exception("Attribute Not Found in Enum value.");
        }
    }
}
