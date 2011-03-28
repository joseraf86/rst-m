<?php

@session_start();

@include("../../publico/librerias/adodb/adodb.inc.php");
@include("../../publico/librerias/adodb/drivers/adodb-sybase.inc.php");
@include("../../publico/librerias/adodb/drivers/adodb-sybase_ase.inc.php");
@include_once('ResultadoBD.php');

class EnlaceBD {
	
	/*===============================================================================//
	 * Esta clase se encarga de la persistencia en PHP como abstraccion de la  
	 * comunicacion con la base de datos 
	 *===============================================================================*/
	
	var $bd;
	var $servidor;
	var $usuario;
	var $clave;
	var $manejador_BD;
	var $conexion_ID	= 0;
	var $consulta_ID	= 0;
	var $mensaje		= '';
	
	/*===============================================================================//
		Obtiene una Conexion a la Base de Datos
	//===============================================================================*/
	
	public function conectar( $bd = "" ) {
		
		$this->bd			= $bd;
		$this->servidor		= $_SESSION['rol_db'];
		$this->manejador_BD	= $_SESSION['manejador_db'];
		$this->usuario		= $_SESSION['usuario_db'];
		$this->clave		= $_SESSION['password_db'];
		
		/*
		ADOLoadCode($manejador_BD);
		$this->conexion_ID = &ADONewConnection();		
		$this->conexion_ID->PConnect( $this->servidor, $this->usuario, $this->clave, $this->bd );
		*/
		
		$dsn = $this->manejador_BD."://".$this->usuario.":".$this->clave."@".$this->servidor."/".$this->bd;
		$this->conexion_ID = ADONewConnection($dsn);
		
		$this->conexion_ID->debug = false;
		return $this->conexion_ID;
	}
	
	
	/*===============================================================================//
		Cierra una Conexion de la Base de Datos
	//===============================================================================*/
	
	public function desconectar() {
		$this->conexion_ID->Close();
	}
	
	
	/*===============================================================================//
		Ejecuta un Query en la Base de Datos de Conexion
	//===============================================================================*/
	
	public function consultar( $sql = "" ) {
		if ( $sql == "" ) {
			return 0;
		} else {
			$consulta = $sql;
		}
		
		$this->consulta_ID = $this->conexion_ID->Execute( $consulta );
		$rs = new ResultadoBD( $this->consulta_ID );
		return $rs;
	}
	
	
	/*===============================================================================//
		Obtener el Formato de una Fecha en Fecha (dd/mm/YYYY)
	//===============================================================================*/
	
	public function extraerCampoFecha( $campo, $formato = 'd/m/Y' ) {
		return $this->conexion_ID->SQLDate($formato, $campo);
	}
	
	
	/*===============================================================================//
		Obtener el Formato de una Fecha en Hora (HH:ii:ss)
	//===============================================================================*/
	
	public function extraerCampoHora( $campo, $formato = 'H:i:s' ) {
		return $this->conexion_ID->SQLDate($formato, $campo);
	}
	
	
	/*===============================================================================//
		Obtener el Formato de una Fecha en Fecha Hora (dd/mm/YYYY HH:ii:ss)
	//===============================================================================*/
	
	public function extraerCampoFechaHora( $campo, $formato = 'd/m/Y H:i:s' ) {
		return $this->conexion_ID->SQLDate($formato, $campo);
	}
	
	
	/*===============================================================================//
		Dar formato a FECHA para UPDATE, INSERT o clausura WHERE de sentencias SELECT
	//===============================================================================*/
	
	public function darFormatoFecha( $fecha ) { //, $formato = 'd/m/Y'
		//$this->conexion_ID->fmtDate = $formato;
		$separador = '/';
		
		$dia 	= substr( $fecha, 0, 2 );
		$mes	= substr( $fecha, 3, 2 );
		$anyo 	= substr( $fecha, 6, 4 );
		$hora 	= substr( $fecha, 10 );
		
		return $this->conexion_ID->DBDate($anyo.$separador.$mes.$separador.$dia.$hora); 
	}
	
	
	/*===============================================================================//
		Dar formato a HORA para UPDATE, INSERT o clausura WHERE de sentencias SELECT
	//===============================================================================*/
	
	public function darFormatoHora( $hora, $formato = 'H:i:s' ) {
		$this->conexion_ID->fmtDate = $formato;
		return $this->conexion_ID->DBDate($hora);
	}
	
	
	/*===============================================================================//
		Obtener el ultimo Mensaje de Error
	//===============================================================================*/
	
	public function getLastMessage() {
		return $this->conexion_ID->ErrorMsg();
	}
	
	
	/*===============================================================================//
		Obtener el TimeStamp del Servidor de Base de Datos
	//===============================================================================*/
	
	public function getSQLTimeStamp() {
		if ( $_SESSION['manejador_db'] == 'sybase') {
			return "getDate()";
		} else if ( $_SESSION['manejador_db'] == 'mysql') {
			return $this->conexion_ID->sysTimeStamp;
		}
	}
	
	
	/*===============================================================================//
		Activar el Debug
	//===============================================================================*/
	
	public function activarModoDebug() {
		return $this->conexion_ID->debug = true;
	}
	
	
	/*===============================================================================//
		Desactivar el Debug
	//===============================================================================*/
	
	public function desactivarModoDebug() {
		return $this->conexion_ID->debug = false;
	}
}
?>