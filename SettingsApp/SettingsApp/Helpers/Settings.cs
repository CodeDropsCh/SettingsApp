using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SettingsApp.Helpers
{
    public class Settings : BaseModel
    {
        static ISettings AppSettings => CrossSettings.Current;

        static Settings settings;
        public static Settings Current =>
          settings ?? (settings = new Settings());

        string AvisoDefault = "";

        public string Aviso
        {
            get => AppSettings.GetValueOrDefault(nameof(Aviso), AvisoDefault);
            set
            {
                var original = Aviso;
                if (AppSettings.AddOrUpdateValue(nameof(Aviso), value))
                    SetProperty(ref original, value);

            }
        }

    }
}
