using System;

namespace ShoppingCartTestLeanOn.Utilities
{
    public static class DecimalManagerUtilities
    {
        private const decimal _roundNumber = 0.05m;

        /// <summary>
        /// Rounds off a decimal value to the nearest 0.05
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal RoundOff(decimal value)
        {
            return Math.Ceiling(value * 20) / 20;

            ////check if the decimal is up to 5
            //int secondDecimal = (int) (Math.Abs(value) * Convert.ToDecimal(Math.Pow(10, 2))) % 10;

            //if(secondDecimal > 5)
            //    return Convert.ToDecimal(value.ToString("F"));


            //return (int)(value / _roundNumber + 0.5m) * 0.05m;
        }

        public static decimal Truncate(decimal value)
        {
            string result = value.ToString("N2"); ;
            return decimal.Parse(result);
        }
    }
}