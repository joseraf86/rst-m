<?php

@include_once('EnlaceBD.php');
@include_once('Auditoria.php');

class MobileSenal {

	private $trst_datos_sen = "rst_datos_sen";

	public function consultar( $id_tipo_sen, $id_categ_sen, $id_senal_tra, $cod_estado, $cod_municipio, $cod_parroquia ) {
		//El valor '0' representa la opcion TODOS
		$conexion 	= new EnlaceBD;
		
		$var 		= $conexion->conectar( $_SESSION['db_rst'] );
		//$conexion->activarModoDebug();
		$fmt_fecha 	= $conexion->extraerCampoFechaHora('ds.fecha_registro'); // '%d/%m/%Y %H:%i:%s'
		
		$tipo_sen = "";
		$categ_sen = "";
		$senal_tra = "";
		$estado = "";
		$municipio = "";
		$parroquia = "";
		$bool = 1;
		$condicion = "";
		
		if($id_tipo_sen != '0') {
			$condicion .= "ds.id_tipo_sen = $id_tipo_sen ";
			
			if($id_categ_sen != '0') {
				$condicion .= "AND ds.id_categ_sen = $id_categ_sen ";
			
				if($id_senal_tra != '0')
					$condicion .= "AND ds.id_senal_tra = $id_senal_tra ";
			
			}
			$bool = 0;
		}
	
		if($cod_estado != '0'){
			
			if ($bool == 0)
				$condicion .= 'AND ';
			
			$condicion .= "ds.cod_estado = '$cod_estado' ";
						
			if($cod_municipio != '0'){
				$condicion .= "AND ds.cod_municipio = '$cod_municipio' ";
				
				if($cod_parroquia != '0')
					$condicion .= "AND ds.cod_parroquia = '$cod_parroquia' ";					
			}
		}

		$sql	= "SELECT 	ds.id_senal as id_senal,
							ds.coord_x as coord_x,
							ds.coord_y as coord_y,
							ds.id_tipo_sen as id_tipo_sen,
							ds.id_categ_sen as id_categ_sen, 
							ds.id_senal_tra as id_senal_tra,
							ds.id_estad_sen as id_estad_sen,
							ds.id_status_sen as id_status_sen, 
							ds.averia as averia, 
							$fmt_fecha as fecha_registro,
							ds.desc_image_sen as desc_image_sen
						FROM db_rst.rst_datos_sen as ds 
						WHERE $condicion";
		
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo consultar la Señal de Tránsito");
		/*
		while( $temparray = $this->respuesta->buscar_fila() ) {
			echo $temparray['id_senal']." ".$temparray['coord_x']." ".$temparray['coord_y']." ".$temparray['averia']."<br/><h1>XXX</h1>";
		}
		*/
		$conexion->desconectar();
		
		$auditoria 	= new Auditoria;
		$auditoria->insertar( "210" );
	}
	
	public function registrar( $coord_x, $coord_y, $id_tipo_sen, $id_categ_sen, $id_senal_tra, $id_estad_sen, $id_status_sen, $averia, $cod_estado, 
		$cod_municipio, $cod_parroquia, $login, $observaciones, $desc_image_sen ) {
		
		$conexion 	= new EnlaceBD;
		$var 		= $conexion->conectar( $_SESSION['db_rst'] );		
		$fecha_reg 	= $conexion->getSQLTimeStamp();
		
		$sql = "INSERT INTO ".$_SESSION['db_rst'].$_SESSION['schema_db'].".$this->trst_datos_sen 
				( 	coord_x, coord_y, id_tipo_sen, id_categ_sen, id_senal_tra, id_estad_sen, id_status_sen, averia, cod_estado, cod_municipio, 
					cod_parroquia, login, fecha_registro, observaciones, desc_image_sen ) 
				VALUES 
				( 	'$coord_x', '$coord_y', $id_tipo_sen, $id_categ_sen, $id_senal_tra, $id_estad_sen, '$id_status_sen', '$averia', '$cod_estado', '$cod_municipio', 
					'$cod_parroquia', '$login', $fecha_reg, '$observaciones', '$desc_image_sen' )";  
		
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