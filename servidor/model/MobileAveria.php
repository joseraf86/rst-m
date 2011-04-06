<?php

@include_once('EnlaceBD.php');
@include_once('Auditoria.php');

class MobileAveria {

	private $trst_datos_ave = "rst_datos_ave";

	public function consultar( $id_senal, $id_status ) {
		//El valor '0' representa la opcion TODOS
		$conexion 	= new EnlaceBD;
		
		$var 		= $conexion->conectar( $_SESSION['db_rst'] );
		//$conexion->activarModoDebug();
		$fmt_fecha 	= $conexion->extraerCampoFechaHora('ds.fecha_registro'); // '%d/%m/%Y %H:%i:%s'

		$sql	= "SELECT 	ds.id_senal as id_senal,
							ds.id_averia as id_averia,
							$fmt_fecha as fecha_registro
						FROM db_rst.rst_datos_ave as rave
						WHERE id_senal = '$id_senal'";
		
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo consultar la Señal de Tránsito");
		
		//while( $temparray = $this->respuesta->buscar_fila() ) {
		
		//}
		
		$conexion->desconectar();
		
		//$auditoria 	= new Auditoria;
		//$auditoria->insertar( "210" );
		
	}
	
	public function registrar( $id_senal, $id_motiv_ave, $observaciones, $login ) {
		
		$conexion 	= new EnlaceBD;
		$var 		= $conexion->conectar( $_SESSION['db_rst'] );		
		
		$fmt_fecha_ave	= $conexion->darFormatoFecha($fecha_averia);
		$fecha_actual 	= $conexion->getSQLTimeStamp();
		
		$sql = "insert into ".$_SESSION['db_rst'].$_SESSION['schema_db'].".$this->trst_datos_ave ( id_senal, fecha_averia, login_registro, fecha_registro, id_motiv_ave, id_status_ave, observaciones ) 
				values ( $id_senal, $fmt_fecha_ave, '$login', $fecha_actual, $id_motiv_ave, 1, '".strtoupper($observaciones)."' )";
		
		$fp = fopen('sql.txt','a' ); 
		fwrite($fp,$sql."\r\n");
		fclose($fp);
		
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo registrar la Señal de Tránsito");
			
		$conexion->desconectar();
		
		$auditoria 	= new Auditoria;
		$auditoria->insertar( "707" );
	}

} // End Class
?>