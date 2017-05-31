<?php
//ЗДЕСЬ ПИШЕМ КОД ДЛЯ ОТОБРАЖЕНИЯ ИНФОРМАЦИИ ПОСЛЕ ОПЛАТЫ
require_once('pay_settings.php');
global $merchant_password;
session_start();

function parse_query($query){
    $items=explode("&", $query);
    $ar=array();
    foreach($items as $it){
        $key=""; $value="";
        list($key, $value)=explode("=", $it, 2);
        $ar[$key]=$value;
    }
    return $ar;
}

if(isset($_POST['payment'])) {
	  $pb_payment = parse_query($_POST['payment']);
	  $request_data = $_POST;
	  $signature = sha1(md5($request_data['payment'] . $merchant_password));
	  echo <<<htmlecho
	  <p>Высчитанная сигнатура: <b>{$signature}</b></p>
htmlecho;
	  if ($request_data['signature'] == $signature){
		echo <<<htmlecho
	    <p>Ожидаемая сигнатура: <b>{$request_data['signature']}</b></p>
htmlecho;
		  if ($pb_payment['amt'] == $_SESSION['price'] && $pb_payment['order'] == $_SESSION['lastOrderID']) {
			  echo <<<htmlecho
			  <p>Оплата платежа <b>{$_SESSION['lastOrderID']}</b> успешно выполнена!</p>
			  <p>Скоре всего какая-то информация должна была быть отправлена на email и в базе ваш платеж пометился как оплачен, но это просто тестовый платёж!</p>
htmlecho;
			  
		  } else {
			  die("<br>Ошибка в проверке цены или id платежа");
		  }
	  } else {
		  die("<br>Сигнатура не совпадает");
	  }
}