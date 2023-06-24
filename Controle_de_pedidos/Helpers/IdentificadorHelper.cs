namespace Controle_de_pedidos.Helpers
{
    public static class IdentificadorHelper
    {
        public static string GetNextPatternValue()
        {
            int nextNumber = GetNextSequentialNumber();
            char nextLetter = GetNextSequentialLetter();
            string patternValue = $"P_{nextLetter}{nextNumber:D3}_C";
            return patternValue;
        }

        private static int GetNextSequentialNumber()
        {
            int lastNumber = 1;
            int nextNumber = lastNumber + 1;
            return nextNumber;
        }

        private static char GetNextSequentialLetter()
        {
            char lastLetter = 'A';
            char nextLetter = (char)(lastLetter + 1);
            return nextLetter;
        }
    }
}
