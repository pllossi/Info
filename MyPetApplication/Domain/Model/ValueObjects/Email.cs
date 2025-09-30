using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Email
    { 
        public string Value { get; init; }
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be null or empty.", nameof(value));
            // Simple email format validation
            if (!value.Contains("@") || !value.Contains("."))
                throw new ArgumentException("Invalid email format.", nameof(value));
            Value = value;
        }
        public override string ToString() => Value;
    }
}
