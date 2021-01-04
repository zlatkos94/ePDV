using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ePdv
{
    public static class ParametriBaze
    {
        public static string DataSource { get; set; }
        public static string UserID { get; set; }
        public static string Password { get; set; }

        public static int ConnectTimeout { get; set; }

        public static bool IntegratedSecurity { get; set; }

    }
}
