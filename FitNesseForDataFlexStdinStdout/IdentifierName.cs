using System;

namespace FitNesseForDataFlexStdinStdout
{
    public class IdentifierName
    {
        public string MatchName { get; private set; }
        public string SourceName { get; private set; }

        public IdentifierName(string name)
        {
            SourceName = name;
            MatchName = name.Trim();
        }

        public bool Matches(string name)
        {
            return name.Contains("_")
                ? string.Equals(MatchName.Replace("_", string.Empty), name.Replace("_", string.Empty), StringComparison.OrdinalIgnoreCase)
                : string.Equals(MatchName, name, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() { return MatchName.ToLower(); }
    }
}
