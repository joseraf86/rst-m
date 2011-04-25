using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using RSTmobile.view;

namespace RSTmobile.controller
{
    class RSTApp
    {

        private FMain fmain;
        private FMenu fmenu;
        private FConsultarSenal fconsultars;
        private FRegistrarSenal fregistrars;
        private FSenal fsenal;
        private FSenales fsenales;
        private FAveria faveria;
        private static RSTApp instance;
        

        private RSTApp() { }

        public void Closing()
        {
            if (fmain != null)
                fmain.Dispose();
            if (fmenu != null)
                fmenu.Dispose();
            if (fconsultars != null)
                fconsultars.Dispose();
        }

        public static RSTApp GetInstance() {
            if (instance == null)
                instance = new RSTApp();
            return instance;
        }

        public void SetSenales(FSenales fsenales)
        {
            this.fsenales = fsenales;
        }

        public FMain GetMain() {
            if (fmain == null)
                fmain = new FMain();
            return fmain;
        }

        public FMenu GetMenu()
        {
            if (fmenu == null)
                fmenu = new FMenu();
            return fmenu;
        }

        public FConsultarSenal GetConsultarSenal()
        {
            if (fconsultars == null)
                fconsultars = new FConsultarSenal();
            return fconsultars;
        }
        public FRegistrarSenal GetRegistrarSenal()
        {
            if (fregistrars == null)
                fregistrars = new FRegistrarSenal();
            return fregistrars;
        }
        public FSenal GetSenal()
        {
            if (fsenal == null)
                fsenal = new FSenal();
            return fsenal;
        }
        public FSenales GetSenales()
        {
            if (fsenales == null)
                fsenales = new FSenales();
            return fsenales;
        }
        public FAveria GetAveria()
        {
            if (faveria == null)
                faveria = new FAveria();
            return faveria;
        }
    }
}
