<?php

@include_once('EnlaceBD.php');
@include_once('Auditoria.php');

class MobileSenal {

	private $trst_datos_sen = "rst_datos_sen";

	public function registrar( $coord_x, $coord_y, $id_tipo_sen, $id_categ_sen, $id_senal_tra, $id_estad_sen, $id_status_sen, $averia, $cod_estado, 
		$cod_municipio, $cod_parroquia, $login, $observaciones, $desc_image_sen ) {
		
		$conexion 	= new EnlaceBD;
		$var 		= $conexion->conectar( $_SESSION['db_rst'] );		
		$fecha_reg 	= $conexion->getSQLTimeStamp();
		
		$sql = "insert into ".$_SESSION['db_rst'].$_SESSION['schema_db'].".$this->trst_datos_sen 
				( 	coord_x, coord_y, id_tipo_sen, id_categ_sen, id_senal_tra, id_estad_sen, id_status_sen, averia, cod_estado, cod_municipio, 
					cod_parroquia, login, fecha_registro, observaciones, desc_image_sen ) 
				values 
				( 	'$coord_x', '$coord_y', $id_tipo_sen, $id_categ_sen, $id_senal_tra, $id_estad_sen, '$id_status_sen', '$averia', '$cod_estado', '$cod_municipio', 
					'$cod_parroquia', '$login', $fecha_reg, '$observaciones', '$desc_image_sen' )";  
		
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo registrar la Señal de Tránsito");
			
		$conexion->desconectar();
		
		$auditoria 	= new Auditoria;
		$auditoria->insertar( "707" );
	}

} // End Class
?>