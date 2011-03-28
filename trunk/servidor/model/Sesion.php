<?php

/*
**@author	Carlos Calvo
**@author	Elisa Conesa	<econesa@gmail.com>
*/

@include_once('EnlaceBD.php');
@include_once('Auditoria.php');

class Sesion {
	
	/* Nombre de las Variables del Modelo (INFORMATIVO)
    // EMPLEADO
	+------------------------+-------------+------+-----+---------+-------+
	| Field                  | Type        | Null | Key | Default | Extra |
	+------------------------+-------------+------+-----+---------+-------+
	| carnet                 | varchar(16) | NO   | PRI | NULL    |       |
	| id_tipo_identificacion | varchar(2)  | NO   |     | NULL    |       |
	| nro_identificacion     | char(15)    | NO   |     | NULL    |       |
	| carnet_jefe            | varchar(16) | YES  |     | NULL    |       |
	| id_grupo               | char(2)     | YES  |     | NULL    |       |
	| id_departamento        | char(2)     | YES  |     | NULL    |       |
	| id_oficina             | char(3)     | NO   |     | NULL    |       |
	| id_entidad             | char(3)     | NO   |     | NULL    |       |
	| login                  | varchar(16) | NO   |     | NULL    |       |
	| estatus                | char(1)     | NO   |     | NULL    |       |
	| email                  | varchar(48) | NO   |     | NULL    |       |
	| fecha_creacion         | datetime    | NO   |     | NULL    |       |
	| nombre                 | varchar(32) | NO   |     | NULL    |       |
	| apellido               | varchar(32) | NO   |     | NULL    |       |
	| telefono               | varchar(12) | NO   |     | NULL    |       |
	| password               | varchar(50) | NO   |     | NULL    |       |
	| fecha_modificacion     | datetime    | YES  |     | NULL    |       |
	+------------------------+-------------+------+-----+---------+-------+
	
	// EMPLEADO_APLICACION
	+---------------+-------------+------+-----+---------+-------+
	| Field         | Type        | Null | Key | Default | Extra |
	+---------------+-------------+------+-----+---------+-------+
	| carnet        | varchar(16) | NO   | PRI | NULL    |       |
	| id_aplicacion | int(11)     | NO   | PRI | NULL    |       |
	| activo        | int(1)      | NO   |     | NULL    |       |
	| permisologia  | text        | NO   |     | NULL    |       |
	+---------------+-------------+------+-----+---------+-------+
	
	// USUARIO
	+-----------------+-------------+------+-----+---------+-------+
	| Field           | Type        | Null | Key | Default | Extra |
	+-----------------+-------------+------+-----+---------+-------+
	| carnet          | varchar(16) | NO   | PRI | NULL    |       |
	| login           | varchar(16) | NO   | PRI | NULL    |       |
	| id_rol          | int(11)     | NO   |     | NULL    |       |
	| id_permisologia | text        | NO   |     | NULL    |       |
	+-----------------+-------------+------+-----+---------+-------+
	*/
	
    // Variable para los resultados de las Consultas
    private $respuesta;
	
	// Tablas del Modelo
	private $templeado 				= "empleado";
	private $templeado_aplicacion 	= "empleado_aplicacion";
	private $trst_usuario 			= "rst_usuario";
	
	
	// ==================================================================================================			
	//	FUNCION - INICIAR SESION DE USUARIO
	// ==================================================================================================
	
	public function IniciarSesion( $login, $password, $did ) {
		$conexion 	= new EnlaceBD;
        $var 		= $conexion->conectar( $_SESSION['db_portal'] );
		
		$sql = "SELECT e.carnet as carnet, 
					e.nro_identificacion as nro_identificacion, 
					e.password as password, 
					e.estatus as estatus 
				FROM ".$_SESSION['db_portal'].$_SESSION['schema_db'].".$this->templeado as e, 
					".$_SESSION['db_portal'].$_SESSION['schema_db'].".$this->templeado_aplicacion as a, 
					".$_SESSION['db_rst'].$_SESSION['schema_db'].".$this->trst_usuario as rst 
				WHERE e.login = '$login' and 
					e.password = '$password' and 
					rst.did = '$did' and
					e.estatus = 'A' and 
					e.carnet = a.carnet and 
					e.login = rst.login and
					a.id_aplicacion = ".$_SESSION['id_aplicacion']." and 
					a.activo = 1";
		 
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo consultar el Usuario $login para Iniciar Sesi&oacute;n.");
		
		$usuario_existe = 'N';
		
		if ( $this->respuesta->nro_filas() > 0 ) {
			$usuario_existe = 'S';
		} else {
			$usuario_existe = 'N';
		}
		
		if ( $usuario_existe == 'S' ) {
			$temparray = $this->respuesta->buscar_fila();
				$carnet				= strtoupper($temparray['carnet']);
				$ced_enc			= $temparray['nro_identificacion'];
				$status_enc			= strtoupper($temparray['estatus']);
		
			$_SESSION['USER_LOGIN']  		= $login;
			$_SESSION['LOGIN']				= $login;
			$_SESSION['PASSWORD']			= $password;
		/*	
			$_SESSION['CARNET_ENC'] 		= $carnet;
			$_SESSION['CEDULA_ENC'] 		= $ced_enc;
			$_SESSION['LOGIN']				= $login;
			$_SESSION['PASSWORD']			= $password;
			$_SESSION['STATUS_ENC'] 		= $status_enc;
			$_SESSION['SessionId'] 			= $_SERVER['REMOTE_ADDR'].session_id();	// Asigna el id de la sesion que se acaba de crear
			$_SESSION["ip"]					= $_SERVER['REMOTE_HOST'];				// Direccion ip del usuario
			*/
			$sesion = 'CONEXION SATISFACTORIA';
				
		} 
		//else 	// USUARIO NO REGISTRADO
			
		$conexion->desconectar();
		return $sesion;
	}
	
	
	// =================================================================================================================
	//	FUNCION - CERRAR SESION DE USUARIO
	// =================================================================================================================
	
	public function CerrarSesion() {
		
		$auditoria 	= new Auditoria;
		$auditoria->insertar( "9999" );
			
		// Borrando los valores de la sesion
		@session_start();
		@session_unset();
		@session_destroy();
	
	}
}
?>