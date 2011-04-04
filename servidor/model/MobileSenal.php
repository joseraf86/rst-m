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
	
		if($cod_estado != ''){
			
			if ($bool == 0)
				$condicion .= 'AND ';
			
			$condicion .= "ds.cod_estado = '$cod_estado' ";
						
			if($cod_municipio != ''){
				$condicion .= "AND ds.cod_municipio = '$cod_municipio' ";
				
				if($cod_parroquia != '')
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
							ds.cod_estado as cod_estado,
							ds.cod_municipio as cod_municipio,
							ds.cod_parroquia as cod_parroquia,
							$fmt_fecha as fecha_registro,
							ds.desc_image_sen as desc_image_sen
						FROM db_rst.rst_datos_sen as ds 
						WHERE $condicion";
		
		$this->respuesta = $conexion->consultar($sql) 
			or die("No se pudo consultar la Señal de Tránsito");
		
		$xml = '<rst>';
		while( $temparray = $this->respuesta->buscar_fila() ) {
			$xml .= '<senal id="'.$temparray['id_senal'].'">'; 
			$xml .= '<x>'.$temparray['coord_x'].'</x>';
			$xml .= '<y>'.$temparray['coord_y'].'</y>';
			$xml .= '<tipo>'.$temparray['id_tipo_sen'].'</tipo>';
			$xml .= '<categoria>'.$temparray['id_categ_sen'].'</categoria>';
			$xml .= '<descripcion>'.$temparray['id_senal_tra'].'</descripcion>';
			$xml .= '<estado>'.$temparray['id_estad_sen'].'</estado>';
			$xml .= '<estatus>'.$temparray['id_status_sen'].'</estatus>';
			$xml .= '<entidad>'.$temparray['cod_estado'].'</entidad>';
			$xml .= '<municipio>'.$temparray['cod_municipio'].'</municipio>';
			$xml .= '<parroquia>'.$temparray['cod_parroquia'].'</parroquia>';
			$xml .= '<averia>'.$temparray['averia'].'</averia>';
			$xml .= '</senal>';
		}
		
		$xml .= '</rst>';
		
		$conexion->desconectar();
		
		$auditoria 	= new Auditoria;
		$auditoria->insertar( "210" );
		
		return $xml;
		
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