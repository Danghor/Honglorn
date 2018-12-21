using System;
using System.Configuration;
using HonglornBL;
using System.ComponentModel;

namespace HonglornWPF
{
    static class HonglornApi
    {
        public static Honglorn Instance => Lazy.Value;

        static readonly Lazy<Honglorn> Lazy = new Lazy<Honglorn>(() =>
        {
#if DEBUG
            Honglorn result;

            string[] cmdArgs = Environment.GetCommandLineArgs();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || cmdArgs.Length >= 2 && cmdArgs[1] == "memory")
            {
                result = new Honglorn(Effort.DbConnectionFactory.CreateTransient());
            }
            else
            {
                result = new Honglorn(ConfigurationManager.ConnectionStrings["HonglornDb"]);
            }

            return result;
#else
            return new Honglorn(ConfigurationManager.ConnectionStrings["HonglornDb"]);
#endif
        });
    }
}
