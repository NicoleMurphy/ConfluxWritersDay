using System;
using System.Reflection;

namespace ConfluxWritersDay.Specifications.Infrastructure
{
    public static class MemberInfoExtensions
    {
        public static object GetValue(this MemberInfo member, object obj)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)member).GetValue(obj);

                case MemberTypes.Property:
                    return ((PropertyInfo)member).GetValue(obj);

                default:
                    throw new NotSupportedException(string.Format("MemberType {0} is not supported.", member.MemberType));
            }
        }

        public static void SetValue(this MemberInfo member, object obj, object value)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    ((FieldInfo)member).SetValue(obj, value);
                    return;

                case MemberTypes.Property:
                    ((PropertyInfo)member).SetValue(obj, value, null);
                    return;

                default:
                    throw new NotSupportedException(string.Format("MemberType {0} is not supported.", member.MemberType));
            }
        }

        public static Type ValueType(this MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;

                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;

                default:
                    throw new NotSupportedException(string.Format("MemberType {0} is not supported.", member.MemberType));
            }
        }

    }
}
