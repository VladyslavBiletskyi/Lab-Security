<?php
//ЗДЕСЬ ПИШЕМ КОД ДЛЯ ДОБАВЛЕНИЯ В БАЗУ, ЭТОТ ЗАПРОС БУДЕТ ВЫПОЛНЕН 1 РАЗ
function iterate_data($query){
    $items=explode("&", $query);
    $ar=array();
    foreach($items as $it){
        $key=""; $value="";
        list($key, $value)=explode("=", $it, 2);
        $ar[$key]=$value;
    }
    return $ar;
}
function iterate_params($input) {
	$output = "";
	foreach($input as $query_string_variable => $value) {
	   $output .= "{$query_string_variable}={$value},";
	}
	return $output;
}
$aaa = iterate_params($_POST);
$date = "[" . date('d.m.Y H:i:s', time()) . "] ";
file_put_contents('logged_api.txt', $date . $aaa . "\n", FILE_APPEND);
