namespace StringCalculator
{
    public class ParsedInput
    {
        public string Header { get; }
        public string Numbers { get; }

        public ParsedInput(string header, string numbers)
        {
            Header = header;
            Numbers = numbers;
        }
    }
}