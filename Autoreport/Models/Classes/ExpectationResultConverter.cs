using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Autoreport.Models.Classes
{
    class ExpectationResultConverter<T> : EnumConverter
    {
        public ExpectationResultConverter()
            : base(
                typeof(T))
        { }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value,
            Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                foreach (var memberInfo in typeof(T).GetMembers())
                {
                    DescriptionAttribute[] list = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>().ToArray();
                    
                    if (list.Length > 0 && memberInfo.Name == value.ToString())
                    {
                        return list[0].Description;
                    }
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
