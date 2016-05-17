namespace Amaia_ReservaTrenes
{
    using CrossCutting.Enum;
    using CrossCutting.Resources;
    using System;
    using CrossCutting.Extensions;
    using CrossCutting.Exceptions;
    public class UserConsoleDatas
    {
        public ChoiceMenu AskUserForMainOptions()
        {
            try
            {
                Console.WriteLine(Display.AskoToUserMenu);
                string value = Console.ReadLine();
                return (ChoiceMenu)Enum.Parse(typeof(ChoiceMenu), value.ToUpper());
            }
            catch (Exception)
            {
                Console.WriteLine(ExceptionsMessage.LetterAskException);
                return AskUserForMainOptions();
            }
        }

        public Train AskUserForChooseTrain()
        {
            try
            {
                Console.WriteLine(Display.AskoToUserTrain);
                string value = Console.ReadLine();
                return (Train)Enum.Parse(typeof(Train), value.ToUpper());
            }
            catch (Exception)
            {
                Console.WriteLine(ExceptionsMessage.LetterAskException);
                return AskUserForChooseTrain();
            }
        }

        public int AskUserForHowManySeats()
        {
            try
            {
                Console.WriteLine(Display.AskoToUserSeatsNumber);
                string value = Console.ReadLine();
                return value.ConvertToIntAndBiggerThanZero();
            }
            catch (LessThanZeroException ex)
            {
                Console.WriteLine(ex.Message);
                return AskUserForHowManySeats();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return AskUserForHowManySeats();
            }
        }
    }
}
