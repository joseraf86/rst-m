<?php
/*
**
**@author Elisa Conesa <econesa@gmail.com>
**@author Jose Guevara <joserafaelguevara@gmail.com>
**@version v0.9 04/2011
*/

//@include_once('../model/MobileSenal.php');
@include_once('../model/MobileAveria.php');

date_default_timezone_set("America/Caracas");
@session_start();

// url de prueba : http://localhost/mobile_rst/controller/mobile_senal_controller.php?coord_x=1&coord_y=2&id_tipo_sen=3&id_categ_sen=20&id_senal_tra=81&id_estad_sen=0&cod_estado=AN&cod_municipio=AN-FM&cod_parroquia=AN-FM-02&login=CECF285319&observaciones=ninguna

$_SESSION['schema_db'] = "";
$_SESSION['db_rst'] = "db_rst";
$_SESSION['rol_db'] = "localhost";
$_SESSION['manejador_db'] = "mysql";
$_SESSION['usuario_db'] = "desarrollo";
$_SESSION['password_db'] = "654321";

$_SESSION['db_portal'] 		= 'portal_inttt';
$_SESSION['id_aplicacion'] 	= '13';

//******************************************
$id_op			= $_POST['id_op'];

switch ($id_op) {

	case 1: // Consultar averia
	  
		$id_senal	= $_POST['id_senal'];
		$login		= $_POST['login'];
		
		$senal 	= new MobileAveria;
		echo $senal->consultar( $id_senal );
	
	break;
	case 2: // Notificar Averia
		$id_senal		= $_POST['id_senal'];
		$fecha_averia	= $_POST['fechaAveria'];
		$login_registro	= $_POST['loginRegistro'];	// 1
		//$login_reparac	= $_POST['loginReparacion'];
		//$fecha_reparac	= $_POST['fechaReparacion'];
		$id_motivo		= $_POST['idMotivo'];
		//$id_status		= $_POST['idStatus'];
		$observaciones	= $_POST['observaciones'];
		
		$averia = new MobileAveria;
		$averia->registrar( $id_senal, $id_motivo, $observaciones, $login_registro, $fecha_averia);
		
		echo "OK";
		
	break;
	case 3: //actualizar averia
		echo 'OK';
	break;
	default:
    break;  
}

?>