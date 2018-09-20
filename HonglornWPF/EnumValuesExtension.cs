using System;
using System.Windows.Markup;

namespace HonglornWPF
{
    public class EnumValuesExtension : MarkupExtension
    {
        Type EnumType { get; }

        public EnumValuesExtension(Type enumType)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException(nameof(enumType));
            }

            if (!enumType.IsEnum)
            {
                throw new ArgumentException($"Argument {nameof(enumType)} must derive from type {nameof(Enum)}.", nameof(enumType));
            }

            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => Enum.GetValues(EnumType);
    }
}
