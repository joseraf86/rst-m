<?php
/*
**
**@author Elisa Conesa <econesa@gmail.com>
**@author Jose Guevara <joserafaelguevara@gmail.com>
**@version v0.9 03/2011
*/

@include_once('../model/MobileSenal.php');

date_default_timezone_set("America/Caracas");
@session_start();

// url de prueba : http://localhost/mobile_rst/controller/mobile_senal_controller.php?coord_x=1&coord_y=2&id_tipo_sen=3&id_categ_sen=20&id_senal_tra=81&id_estad_sen=0&cod_estado=AN&cod_municipio=AN-FM&cod_parroquia=AN-FM-02&login=CECF285319&observaciones=ninguna

$_SESSION['schema_db'] = "";
$_SESSION['db_rst'] = "db_rst";
$_SESSION['rol_db'] = "localhost";
$_SESSION['manejador_db'] = "mysql";
$_SESSION['usuario_db'] = "desarrollo";
$_SESSION['password_db'] = "654321";
/*
$coord_x		= $_GET['coord_x'];
$coord_y		= $_GET['coord_y'];
$id_tipo_sen	= $_GET['id_tipo_sen'];
$id_categ_sen	= $_GET['id_categ_sen'];
$id_senal_tra	= $_GET['id_senal_tra'];
$id_estad_sen	= $_GET['id_estad_sen'];	// 1
$id_status_sen	= $_GET['id_status_sen'];	// 'I'
$averia			= 'N';
$cod_estado		= $_GET['cod_estado'];
$cod_municipio	= $_GET['cod_municipio'];
$cod_parroquia	= $_GET['cod_parroquia'];
$login			= $_GET['login'];
$observaciones	= $_GET['observaciones'];
$desc_image_sen	= '';
*/

$coord_x		= $_POST['coord_x'];
$coord_y		= $_POST['coord_y'];
$id_tipo_sen	= $_POST['id_tipo_sen'];
$id_categ_sen	= $_POST['id_categ_sen'];
$id_senal_tra	= $_POST['id_senal_tra'];
$id_estad_sen	= $_POST['id_estad_sen'];	// 1
$id_status_sen	= $_POST['id_status_sen'];	// 'I'
$averia			= 'N';
$cod_estado		= $_POST['cod_estado'];
$cod_municipio	= $_POST['cod_municipio'];
$cod_parroquia	= $_POST['cod_parroquia'];
$login			= $_POST['login'];
$observaciones	= $_POST['observaciones'];
$desc_image_sen	= '';

$log = date(DATE_RFC822).": ($coord_x,$coord_y,$id_tipo_sen,$id_categ_sen,$id_senal_tra, $id_estad_sen, $id_status_sen, $cod_estado, $cod_municipio, $cod_parroquia, $login)\r\n";
$fp = fopen('log.txt','a' ); 
fwrite($fp,$log);
fclose($fp);

try {

$senal 	= new MobileSenal;
$senal->registrar( $coord_x, $coord_y, $id_tipo_sen, $id_categ_sen, $id_senal_tra, $id_estad_sen, $id_status_sen, $averia, $cod_estado, $cod_municipio, 
					$cod_parroquia, $login, $observaciones, $desc_image_sen );
		
echo "OK";
}
catch (Exception $e){ 
	$fe = fopen('error.txt','w' ); 
	fwrite($fe,$e->getMessage());
	fclose($fe);
}		


?>