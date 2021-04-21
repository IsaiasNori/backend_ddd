using System;

namespace Domain.Constants
{
    public static class CoreConstants
    {
        public static Settings Settings { get; private set; }

        public const String InternalKey = "def@@##";

        public static void SetSettings(Settings settings)
        {
            if (settings != null)
            {
                Settings = settings;
            }
        }

    }
}