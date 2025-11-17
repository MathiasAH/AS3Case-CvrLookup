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
    }
}