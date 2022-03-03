using System;
using System.Collections.Generic;
using System.Text;

namespace TXMXB12001_SUPERFAST_510
{
    public class File510MapValidationAttribute : Attribute
    {
        public File510MapValidationAttribute(string nameValidation, bool isRequired)
        {
            NameValidation = nameValidation;
            IsRequired = isRequired;
        }

        public File510MapValidationAttribute(string nameValidation, bool isRequired, int integers, int decimals)
        {
            NameValidation = nameValidation;
            IsRequired = isRequired;
            Integers = integers;
            Decimals = decimals;
        }

        public File510MapValidationAttribute(string nameValidation)
        {
            NameValidation = nameValidation;
        }
        public File510MapValidationAttribute(string nameValidation, string validValues)
        {
            NameValidation = nameValidation;
            ValidValues = validValues;
        }
        public File510MapValidationAttribute(string nameValidation, string validValues, bool defaultValueIsWhiteSpace)
        {
            NameValidation = nameValidation;
            ValidValues = validValues;
            DefaultValueIsWhiteSpace = defaultValueIsWhiteSpace;
        }


        public string NameValidation { get; set; }

        public bool IsRequired { get; set; }

        public int Integers { get; set; }

        public int Decimals { get; set; }

        public bool DefaultValueIsWhiteSpace { get; set; }

        public string ValidValues { get; set; }
    }
}
