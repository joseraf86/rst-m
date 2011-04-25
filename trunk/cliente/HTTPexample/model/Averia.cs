using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using RST;

namespace Transito
{
    public class Averia
    {
        private string id;
        private SenalTransito senal;
        private string fechaAveria;
        private string loginRegistro;
       // private string fechaRegistro;
        private string loginReparacion;
        private string fechaReparacion;
        private Celda motivo;
        private Celda status;
        private string idMotivo; // es de tipo numeric en la bd
        private string idStatus;
        private string observaciones;
        private string rutaImg1;
        private string rutaImg2;
        private string rutaImg3;

        public Averia( Transito.SenalTransito senal )
        {
            this.senal = senal;
            fechaAveria = DateTime.Now.ToString("dd/MM/yyyy");
            loginRegistro = "";
            loginReparacion = "";
            fechaReparacion = "";
            idMotivo = "";
            idStatus = "";
            observaciones = "";
            rutaImg1 = "";
            rutaImg2 = "";
            rutaImg3 = "";
        }

        public void SetID(string id){
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

        public void SetMotivo(string idMotivo, string descripcion)
        {
            this.motivo.id = idMotivo;
            this.motivo.descripcion = descripcion;
        }

        public void SetIDMotivo(string idMotivo)
        {
            this.idMotivo = idMotivo;
        }

        public void SetStatus(string id, string descripcion)
        {
            this.status.id = id;
            this.status.descripcion = descripcion;
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
        public string GetID()
        { 
            return this.id; 
        }

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
            return this.motivo.id;
        }

        public string GetMotivo()
        {
            return this.motivo.descripcion;
        }

        public string GetIDStatus()
        {
            return this.status.id;
        }

        public string GetStatus()
        {
            return this.status.descripcion;
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
