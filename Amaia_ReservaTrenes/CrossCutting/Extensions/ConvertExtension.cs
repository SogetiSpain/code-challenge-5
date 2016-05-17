using CrossCutting.Exceptions;

namespace CrossCutting.Extensions
{
    public static class ConvertExtension
    {
        public static int ConvertToIntAndBiggerThanZero(this string value)
        {
            //TODO Cuando sea menos que 0 saltar la custom exception (LessThanZeroException)
            try
            {
                var converted = int.Parse(value);

                if (converted <= 0)
                {
                    throw new LessThanZeroException();
                }
                return converted;
            }
            catch (System.Exception)
            {

                throw new LessThanZeroException();
            }
        }
    }
}
