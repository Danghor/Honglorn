using System;
using System.Windows.Markup;

namespace HonglornWPF.Extensions
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        readonly Type enumType;

        public EnumBindingSourceExtension(Type enumType)
        {
            this.enumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(enumType);
        }
    }
}