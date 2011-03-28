<?php

class ResultadoBD {
	
	/*===============================================================================//
	 * Esta clase encapsula operaciones necesarias sobre resultados  
	 * de la base de datos
	 *===============================================================================*/
	
	var $consulta_ID;
	
	
	/*===============================================================================//
		Consulta el Numero de Columnas
	//===============================================================================*/
	
	public function buscar_fila() {
		$temparray = array();
		if ( $this->consulta_ID )
			$temparray = $this->consulta_ID->FetchRow();
		return $temparray;
	}
	
	
	/*===============================================================================//
		Consulta el Numero de Columnas
	//===============================================================================*/
	
	public function nro_columnas() {
		if ( $this->consulta_ID )
			$n = $this->consulta_ID->FieldCount();
		return $n;
	}
	
	
	/*===============================================================================//
		Consulta el Numero de Filas
	//===============================================================================*/
	
	public function nro_filas() {
		if ( !$this->consulta_ID )
			return -1;
		return $this->consulta_ID->RecordCount();
	}
	
	
	/*===============================================================================//
		Constructor
	//===============================================================================*/
	
	public function __construct( $rs ) {
		$this->consulta_ID = $rs;
	}
}
?>