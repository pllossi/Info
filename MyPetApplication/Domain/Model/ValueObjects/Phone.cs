using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Phone
    {
        public string Value { get; init; }
        public Phone(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone number cannot be null or empty.", nameof(value));
            // Simple phone format validation (you can enhance this as needed)
            if (!value.All(c => char.IsDigit(c) || c == '+' || c == '-' || c == ' '))
                throw new ArgumentException("Invalid phone number format.", nameof(value));
            Value = value;
        }
        public override string ToString() => Value;
    }
}
