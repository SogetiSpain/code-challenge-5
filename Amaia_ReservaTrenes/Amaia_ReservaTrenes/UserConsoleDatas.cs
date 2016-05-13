namespace Amaia_ReservaTrenes
{
    using CrossCutting.Enum;
    using CrossCutting.Resources;
    using System;

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
                Console.WriteLine(Exceptions.LetterAskException);
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
                Console.WriteLine(Exceptions.LetterAskException);
                return AskUserForChooseTrain();
            }
        }

        public int AskUserForHowManySeats()
        {
            try
            {
                Console.WriteLine(Display.AskoToUserSeatsNumber);
                string value = Console.ReadLine();
                return int.Parse(value);
            }
            catch (Exception)
            {
                Console.WriteLine(Exceptions.LetterAskException);
                return AskUserForHowManySeats();
            }
        }
    }
}
