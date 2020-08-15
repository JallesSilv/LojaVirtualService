using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Config
{
    public class XConfig : XBaseConfig
    {
        public static string DataSouce
        {
            get
            {
                return Get(() => DataSouce);
            }
        }

        public static string Server
        {
            get
            {
                return Get(() => Server);
            }
        }

        public static string UserID
        {
            get
            {
                return Get(() => UserID);
            }
        }

        public static string Password
        {
            get
            {
                return Get(() => Password);
            }
        }

        public static string Uf
        {
            get
            {
                return Get(() => Uf);
            }
        }

        public static string Porta
        {
            get
            {
                return Get(() => Porta);
            }
        }

        public static string StateMode
        {
            get
            {
                return Get(() => StateMode);
            }
        }
    }
}
