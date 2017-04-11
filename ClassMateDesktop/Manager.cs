using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMateDesktop
{
    class Manager
    {
        private String token;
        private static Manager manager;

        private Manager()
        {

        }

        public static Manager getInstance()
        {
            if (manager == null)
            {
                manager = new Manager();
            }
            return manager;
        }

        public void setToken(String token)
        {
            this.token = token;
        }

        public String getToken()
        {
            return this.token;
        }

    }
}
