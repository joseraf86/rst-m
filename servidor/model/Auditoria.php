<?php

/*
* Modelo: "auditoria.php"
*
* Realizado por:
* 	Carlos Calvo
*  	Elisa Conesa
*/

@include_once('EnlaceBD.php');

class Auditoria {
	
	/* Nombre de las Variables del Modelo (INFORMATIVO)
    +-----------+-------------+------+-----+-------------------+-----------------------------+
	| Field     | Type        | Null | Key | Default           | Extra                       |
	+-----------+-------------+------+-----+-------------------+-----------------------------+
	| login     | varchar(16) | NO   | PRI | NULL              |                             |
	| id_evento | int(11)     | NO   | PRI | NULL              |                             |
	| fecha     | timestamp   | NO   | PRI | CURRENT_TIMESTAMP | on update CURRENT_TIMESTAMP |
	+-----------+-------------+------+-----+-------------------+-----------------------------+
	*/
	
	// Variable para los resultados de las Consultas
	private $respuesta;
	
	// Tablas del Modelo
	private $trst_auditoria 		= "rst_auditoria";
	private $trst_evento 			= "rst_evento";
	
	
	// ==============================================================================================
	// 	FUNCION - INSERTAR EVENTO
	// ==============================================================================================
	
	public function insertar ( $id_evento ) {
		$conexion 	= new EnlaceBD;
        $var 		= $conexion->conectar( $_SESSION['db_rst'] );
		
		if ( isset($_SESSION['USER_LOGIN']) ) {
		$sql = "insert into ".$_SESSION['db_rst'].$_SESSION['schema_db'].".$this->trst_auditoria ( login, id_evento ) 
				values ( '".$_SESSION['USER_LOGIN']."', $id_evento )";
		}
		else {
		$sql = "insert into ".$_SESSION['db_rst'].$_SESSION['schema_db'].".$this->trst_auditoria ( login, id_evento ) 
				values ( 'anonimo', $id_evento )";
		}
		
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo agregar el Evento $id_evento del Usuario $login.");
		
		$conexion->desconectar();
		return true;
	}
	
	
	// ==============================================================================================
	// 	FUNCION - CONSULTAR AUDITORIA DE USUARIO
	// ==============================================================================================
	
	public function consultar( $login, $id_evento, $fecha_ini, $fecha_fin ) {
		$conexion 	= new EnlaceBD;
        $var 		= $conexion->conectar( $_SESSION['db_rst'] );
		
		$fmt_fecha 			= $conexion->extraerCampoFecha( 'a.fecha' );
		$fmt_hora 			= $conexion->extraerCampoHora( 'a.fecha' );
		$fmt_fecha_ini 		= $conexion->darFormatoFecha($fecha_ini);
		$fmt_fecha_fin 		= $conexion->darFormatoFecha($fecha_fin);
		
		$sql = "select a.login as login, 
					e.descripcion as descripcion, 
					$fmt_fecha as fecha, 
					$fmt_hora as hora 
				from ".$_SESSION['db_rst'].$_SESSION['schema_db'].".$this->trst_auditoria as a, 
					".$_SESSION['db_rst'].$_SESSION['schema_db'].".$this->trst_evento as e 
				where a.login = '$login' and 
					a.id_evento in ( $id_evento ) and ";
		
		if ( $fecha_ini == $fecha_fin ) {
			$sql = $sql."a.fecha = $fmt_fecha_ini and ";					
		}else{
			$sql = $sql."(a.fecha between $fmt_fecha_ini and $fmt_fecha_fin) and ";
		}
		
		$sql = $sql."a.id_evento = e.id_evento 
				order by a.fecha desc";
		
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo consultar la Auditoria");			
		
		$i = 0;
		while ($temparray = $this->respuesta->buscar_fila()){
			$lista_auditoria[$i][0] = strtoupper($temparray['login']);
			$lista_auditoria[$i][1] = strtoupper($temparray['descripcion']);
			$lista_auditoria[$i][2] = $temparray['fecha'];
			$lista_auditoria[$i][3]	= $temparray['hora'];
			$i++;
		}
		$lista_auditoria[$i][0] = $fecha_ini;
		$lista_auditoria[$i][1] = $fecha_fin;
		
		$conexion->desconectar();
		return $lista_auditoria;
	}
	
	
	// =======================================================================================
	// 	FUNCION - CONSULTAR LA FECHA PARA VALIDAR SI UN PASSWORD ESTA VENCIDO
	// =======================================================================================
	
	public function consultar_fecha_password() {
		$conexion 	= new EnlaceBD;
        $var 		= $conexion->conectar( $_SESSION['db_rst'] );
		
		$fmt_fecha 	= $conexion->extraerCampoFecha('fecha');
		
		$sql = "select max($fmt_fecha) as fecha_max 
				from ".$_SESSION['db_rst'].$_SESSION['schema_db'].".$this->trst_auditoria 
				where login = '".$_SESSION['USER_LOGIN']."' and 
					id_evento = 6";
		
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo consultar la ultima fecha de modificación de Contraseña de Usuario");
		
		$temparray = $this->respuesta->buscar_fila();
		
		$conexion->desconectar();
		return $temparray['fecha_max'];
	}
}
?>