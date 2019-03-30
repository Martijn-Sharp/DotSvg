using System;
using System.Text.RegularExpressions;

namespace DotSvg.Models.DataTypes
{
    public struct Name
    {
        private const string Pattern = "^((?![,()#x20#x9#xD#xA]).)*$";

        public Name(string value)
        {
            var regex = new Regex(Pattern);
            if(!regex.IsMatch(value))
                throw new ArgumentException("Provided value doesn't pass the regex validation", nameof(value));

            Value = value;
        }

        public string Value { get; }

        public static implicit operator Name(string value) => new Name(value);
    }
}
