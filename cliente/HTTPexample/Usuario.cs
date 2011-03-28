using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace rst
{
    class Usuario
    {
        private string login;
        private string password;
        private string did;
        private string server;
        private static Usuario instance;

        private Usuario() {
            
        }

        public static Usuario GetInstance() {
            if (instance == null)
                instance = new Usuario();
            return instance;
        }

        public void SetLogin(string login) {
            this.login = login;
        }

        public void SetServer(string server)
        {
            this.server = server;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public void SetDID(string did)
        {
            this.did = did;
        }

        public string GetLogin() {
            return login;
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetDID()
        {
            return did;
        }

        public string GetServer()
        {
            return server;
        }
    }
}
