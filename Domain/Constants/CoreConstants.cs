namespace Domain
{
    public static class CoreConstants
    {
        public static Settings Settings { get; private set; }

        public static void SetSettings(Settings settings)
        {
            if (settings != null)
            {
                Settings = settings;
            }
        }

    }
}