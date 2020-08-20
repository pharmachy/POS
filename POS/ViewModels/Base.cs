using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace POS.ViewModels
{
    public static class Base
    {
        public static string GetEnumDescription(Enum en)

        {

            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)

            {

                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
                                                                false);

                if (attrs != null && attrs.Length > 0)

                    return ((DescriptionAttribute)attrs[0]).Description;

            }

            return en.ToString();

        }

        public static List<object> GetEnumList<T>()
        {
            var list = new List<object>();

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                list.Add(new { Value = (int)item, Text = GetEnumDescription((Enum)Enum.Parse(typeof(T), item.ToString())) });
            }

            return list;
        }

        internal static string GetEnumDescription(int preferredType)
        {
            throw new NotImplementedException();
        }
    }
    public enum EnumPaymentMethod
    {
        Cash = 1,
        Card,
        BKash,
        Cheque
    }
}
