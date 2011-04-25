<?php

@include("../model/Sesion.php");

@session_start();
// http://localhost/rst-m/controller/SessionController.php?login=CECF285319&password=654321&did=12345

$login		= $_POST['login'];
$password	= $_POST['password'];
$did		= $_POST['did'];  //ID del Dispositivo

//variables de sesion
$_SESSION['schema_db'] = '';
$_SESSION['db_rst'] = 'db_rst';
$_SESSION['rol_db'] = 'localhost';
$_SESSION['manejador_db'] = 'mysql';
$_SESSION['usuario_db'] = 'desarrollo';
$_SESSION['password_db'] = '654321';
$_SESSION['db_portal'] = 'portal_inttt';
$_SESSION['id_aplicacion'] = '13';
$_SESSION['USER_LOGIN'] = $login;
//	$parametros	= new Parametros_sistema;
//	$parametros->inicializar_datos_db();
	
$sesion = new Sesion;
$data_sesion = $sesion->IniciarSesion( strtoupper($login), $password, $did );

if ( $data_sesion == 'CONEXION SATISFACTORIA' ) {
	echo 'OK';
}
else
	echo 'ERROR';

echo '<script>parent.location="../view/confirmarAveria.php"</script>';
?>