using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using HonglornBL.Models.Entities;

namespace HonglornWPF
{
    class CompetitionDisciplineValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = ValidationResult.ValidResult;

            BindingGroup bindingGroup = value as BindingGroup;

            if (bindingGroup != null)
            {
                foreach (var bindingSource in bindingGroup.Items)
                {
                    CompetitionDiscipline discipline = bindingSource as CompetitionDiscipline;

                    StringBuilder validationMessageBuilder = new StringBuilder();

                    if (string.IsNullOrWhiteSpace(discipline.Name))
                    {
                        validationMessageBuilder.AppendLine("The name of the discipline must not be empty.");
                    }

                    if (string.IsNullOrWhiteSpace(discipline.Unit))
                    {
                        validationMessageBuilder.AppendLine("The unit of the discipline must not be empty.");
                    }

                    if (validationMessageBuilder.Length > 0)
                    {
                        result = new ValidationResult(false, validationMessageBuilder.ToString());
                    }
                }
            }
            return result;
        }
    }
}
