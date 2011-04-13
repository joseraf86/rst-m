using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Transito
{
    class Averia
    {
        private int id;
        private SenalTransito senal;
        private string fechaAveria;
        private string loginRegistro;
       // private string fechaRegistro;
        private string loginReparacion;
        private string fechaReparacion;
        private string idMotivo; // es de tipo numeric en la bd
        private string idStatus;
        private string observaciones;
        private string rutaImg1;
        private string rutaImg2;
        private string rutaImg3;

        public void SetID(int id){
            this.id = id;
        }
        public void SetSenal(SenalTransito senal){
            this.senal = senal;
        }
        public void SetFechaAveria(string fechaAveria ){
            this.fechaAveria = fechaAveria;
        }
        public void SetLoginRegistro(string loginRegistro ){
            this.loginRegistro = loginRegistro;
        }
        public void SetFechaReparacion(string fechaReparacion ){
            this.fechaReparacion = fechaReparacion;
        }
        public void SetLoginReparacion(string loginReparacion){
            this.loginReparacion = loginReparacion;
        }
        public void SetIDMotivo(string idMotivo)
        {
            this.idMotivo = idMotivo;
        }
        public void SetIDStatus(string idStatus)
        {
            this.idStatus = idStatus;
        }
        public void SetObservaciones(string observaciones ){
            this.observaciones = observaciones;
        }
        public void SetRutaIMG1(string ruta ){
            this.rutaImg1 = ruta;
        }
        public void SetRutaIMG2(string ruta ){
            this.rutaImg2 = ruta;
        }
        public void SetRutaIMG3(string ruta) {
            this.rutaImg3 = ruta;
        }

        //********* GETTERS ************
        public int GetID() { return this.id; }
        public SenalTransito GetSenal()
        {
            return this.senal;
        }
        public string GetFechaAveria()
        {
            return this.fechaAveria;
        }
        public string GetLoginRegistro()
        {
            return this.loginRegistro;
        }
        public string GetFechaReparacion()
        {
            return this.fechaReparacion;
        }
        public string GetLoginReparacion()
        {
            return this.loginReparacion;
        }
        public string GetIDMotivo()
        {
            return this.idMotivo;
        }
        public string GetIDStatus()
        {
            return this.idStatus;
        }
        public string GetObservaciones()
        {
            return this.observaciones;
        }
        public string GetRutaIMG1()
        {
            return this.rutaImg1;
        }
        public string GetRutaIMG2()
        {
            return this.rutaImg2;
        }
        public string GetRutaIMG3()
        {
            return this.rutaImg3;
        }
    }
}
