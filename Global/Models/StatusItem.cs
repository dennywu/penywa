using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Global.Models
{
    public static class StatusItem
    {
        public const string ACTIVE = "Aktif";
        public const string NONACTIVE = "Non Aktif";

        public static string Apply(string status)
        {
            if (status == ACTIVE)
            {
                return ACTIVE;
            }
            else
            {
                return NONACTIVE;
            }
        }
    }
}