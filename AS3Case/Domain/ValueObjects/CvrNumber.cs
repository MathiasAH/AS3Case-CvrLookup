namespace AS3Case.Domain.ValueObjects
{
    public sealed class CvrNumber
    {
        public string Value { get; set; }
        private CvrNumber(string value)
        {
            Value = value;
        }
        public static bool TryParse(string input, out CvrNumber? cvr)
        {
            cvr = null;
            
            if (input is null || !input.All(char.IsDigit) || input.Length != 8)
            {  
                return false; 
            }

            cvr = new CvrNumber(input);
            return true;
        }
        public static CvrNumber Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("CVR number cannot be empty.");

            if (!input.All(char.IsDigit))
                throw new ArgumentException("CVR number must contain only digits.");

            if (input.Length != 8)
                throw new ArgumentException("CVR number must be 8 digits long.");

            return new CvrNumber(input);
        }
    }
}