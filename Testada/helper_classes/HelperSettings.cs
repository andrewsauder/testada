using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testada
{
    class HelperSettings
    {

        public static dynamic get(string key)
        {
            return Properties.Settings.Default[key];
        }

        public static void set(string key, dynamic value)
        {
            Properties.Settings.Default[key] = value;
            Properties.Settings.Default.Save();
        }
    }
}
