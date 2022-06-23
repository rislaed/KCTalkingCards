namespace KCTalkingCards.util
{
    public static class MenuChecker
    {
        public static bool InMenu { get; private set; } = false;

        public static void InMenuToFalse()
        {
            InMenu = false;
        }

        public static void InMenuToTrue()
        {
            InMenu = true;
        }
    }
}