using System.Collections.Generic;

namespace StringCalculator
{
    public class Separators
    {
        private List<string> Value { get; } = new List<string>() { ",", "\n" };

        public void Add(string newSeparator) {
            if(!string.IsNullOrWhiteSpace(newSeparator))
                Value.Add(newSeparator);
        }

        public void Add(List<string> newSeparators) {
            newSeparators.ForEach(Add);
        }

        public string[] ToArray() {
            return Value.ToArray();
        }
    }
}