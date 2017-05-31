<?php
require_once('pay_settings.php');
global $price, $description, $ex_desc;

session_start();
$_SESSION['lastOrderID'] = rand(1000000, 9999999);
$_SESSION['price'] = $price;
$_SESSION['description'] = $description;
$_SESSION['ex_desc'] = $ex_desc;


echo <<<html
<p><h3>Тестовая форма проведения платежа через privat24</h3></p>
<p>Цена товара: <b id="price">{$_SESSION['price']}</b></p>
<p>ID платежа: <b id="id">{$_SESSION['lastOrderID']}</b></p>
<p>Описание платежа: <b id="desc">{$_SESSION['description']}</b></p>
<p>Дополнительное описание платежа: <b id="ex_desc">{$_SESSION['ex_desc']}</b></p>

<form method="POST" action="https://api.privatbank.ua/p24api/ishop">
<input type="hidden" min ="1" max = "99999" name="amt" value="{$_SESSION['price']}" />
<input type="hidden" name="ccy" value="UAH" />
<input type="hidden" name="merchant" value="127100" />
<input type="hidden" name="order" value="{$_SESSION['lastOrderID']}" />
<input type="hidden" name="details" value="{$_SESSION['description']}" />
<input type="hidden" name="ext_details" value="{$_SESSION['ex_desc']}" />
<input type="hidden" name="pay_way" value="privat24" />
<input type="hidden" name="return_url" value="http://bpid-labas.tk/lab5/page_output.php" />
<input type="hidden" name="server_url" value="http://bpid-labas.tk/lab5/api_output.php" />
<button type="submit">Оплатить</button>
</form>
html;

