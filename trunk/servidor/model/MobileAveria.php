<?php

@include_once('EnlaceBD.php');
@include_once('Auditoria.php');

class MobileAveria {

	private $trst_datos_ave = "rst_datos_ave";

	public function consultar( $id_senal ) {
		//El valor '0' representa la opcion TODOS
		$conexion 	= new EnlaceBD;
		
		$var 		= $conexion->conectar( $_SESSION['db_rst'] );
		//$conexion->activarModoDebug();
		$fmt_fecha 	= $conexion->extraerCampoFechaHora('fecha_registro'); // '%d/%m/%Y %H:%i:%s'

		$sql	= "SELECT 	id_senal as id_senal,
							id_averia as id_averia,
							$fmt_fecha as fecha_registro,
							id_motiv_ave as id_motivo,
							login_registro as login_registro
						FROM db_rst.rst_datos_ave as rave
						WHERE id_senal = '$id_senal'";
		
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo consultar la Se�al de Tr�nsito");
		
		$xml = '<rst>';
		while( $temparray = $this->respuesta->buscar_fila() ) {
			$xml .= '<averia id="'.$temparray['id_averia'].'">'; 
			$xml .= '<senal>'.$temparray['id_senal'].'</senal>';
			$xml .= '<motivo>'.$temparray['id_motivo'].'</motivo>';
			//$xml .= '<fecha>'.$temparray['fecha_registro'].'</fecha>';
			$xml .= '<login>'.$temparray['login_registro'].'</login>';
			$xml .= '</averia>';
		}
		$xml .= '</rst>';
		
		$conexion->desconectar();
		
		//$auditoria 	= new Auditoria;
		//$auditoria->insertar( "210" );
		return $xml;
	}
	
	public function registrar( $id_senal, $id_motiv_ave, $observaciones, $login, $fecha_averia ) {
		
		$conexion 	= new EnlaceBD;
		$var 		= $conexion->conectar( $_SESSION['db_rst'] );		
		
		$fmt_fecha_ave	= $conexion->darFormatoFecha($fecha_averia);
		$fecha_actual 	= $conexion->getSQLTimeStamp();
		
		$sql = "INSERT INTO ".$_SESSION['db_rst'].$_SESSION['schema_db'].".$this->trst_datos_ave ( id_senal, fecha_averia, login_registro, fecha_registro, id_motiv_ave, id_status_ave, observaciones ) 
				VALUES ( $id_senal, $fmt_fecha_ave, '$login', $fecha_actual, $id_motiv_ave, 1, '".strtoupper($observaciones)."' )";
		
		$fp = fopen('sql.txt','a' ); 
		fwrite($fp,$sql."\r\n");
		fclose($fp);
		
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo registrar la Se�al de Tr�nsito");
		
		
		
		$conexion->desconectar();
		
		$auditoria 	= new Auditoria;
		$auditoria->insertar( "707" );
	}
	
	public function actualizar ( $id_averia, $login, $fecha, $id_motivo ) {
	
		$conexion 	= new EnlaceBD;
		$var 		= $conexion->conectar( $_SESSION['db_rst'] );		
		
		$fmt_fecha	= $conexion->darFormatoFecha($fecha_reparacion);
		$fecha_modificacion  = $conexion->getSQLTimeStamp();
				
		$sql = "UPDATE ".$_SESSION['db_rst'].$_SESSION['schema_db'].".$this->trst_datos_ave SET 
					login_registro = '$login_reparacion',
					fecha_averia = $fmt_fecha,
					id_motiv_ave = $id_motivo
				WHERE id_averia = '$id_averia'";				
		
		$fp = fopen('sql.txt','a' ); 
		fwrite($fp,$sql."\r\n");
		fclose($fp);
		
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo registrar la Se�al de Tr�nsito");
		
		$conexion->desconectar();
		
		$auditoria 	= new Auditoria;
		$auditoria->insertar( "708" );
	
	}
	
	public function reparar ( $id_averia, $login_reparacion, $fecha_reparacion	) {
	
		$conexion 	= new EnlaceBD;
		$var 		= $conexion->conectar( $_SESSION['db_rst'] );		
		
		$fmt_fecha_rep	= $conexion->darFormatoFecha($fecha_reparacion);
		$fecha_modificacion  = $conexion->getSQLTimeStamp();
				
		$sql = "UPDATE ".$_SESSION['db_rst'].$_SESSION['schema_db'].".$this->trst_datos_ave SET 
					login_reparacion = '$login_reparacion',
					fecha_reparacion = $fmt_fecha_rep
				WHERE id_averia = '$id_averia'";				
		
		$fp = fopen('sql.txt','a' ); 
		fwrite($fp,$sql."\r\n");
		fclose($fp);
		
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo registrar la Se�al de Tr�nsito");
		
		$conexion->desconectar();
		
		$auditoria 	= new Auditoria;
		$auditoria->insertar( "708" );
	
	}
} // End Class
?>