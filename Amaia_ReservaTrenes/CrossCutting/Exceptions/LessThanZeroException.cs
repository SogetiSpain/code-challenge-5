namespace CrossCutting.Exceptions
{
    using Resources;
    using System;

    public class LessThanZeroException: Exception
    {
        public override string Message
        {
            get
            {
                return ExceptionsMessage.LessThanZeroException;
            }
        }

    }
}