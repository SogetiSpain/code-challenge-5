namespace CrossCutting.Extensions
{
    public static class ConvertExtension
    {
        public static int ConvertToIntAndBiggerThanZero(this string value)
        {
            return 1;
            //TODO Cuando sea menos que 0 saltar la custom exception (LessThanZeroException)
            //try
            //{
            //    var converted = int.Parse(value);

            //    if (converted <= 0)
            //    {
            //        throw 
            //    }

            //}
            //catch (System.Exception)
            //{

            //    throw;
            //}
           
        }
    }
}
