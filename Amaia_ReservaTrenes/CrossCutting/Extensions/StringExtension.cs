namespace CrossCutting.Extensions
{
    using CrossCutting.Exceptions;
    using Resources;
    using System;
    public static class StringExtension
    {
        public static int ConvertToIntAndBiggerThanZero(this string value)
        {
            try
            {
                var converted = int.Parse(value);

                if (converted <= 0)
                {
                    throw new LessThanZeroException();
                }
                return converted;
            }
            catch (LessThanZeroException)
            {
                throw new LessThanZeroException();
            }
            catch (Exception)
            {
                throw new Exception(ExceptionsMessage.InvalidNumberException);
            }
        }
    }
}
