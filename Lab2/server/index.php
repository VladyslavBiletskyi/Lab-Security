<?php

require_once('Crypt/RSA_XML.php');
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

session_start();

if (isset($_SESSION['key_private']) && isset($_SESSION['key_public'])) { 
	if (isset($_POST['data'])) { 
	
		$dataEncrypted = $_POST['data'];
		$rsa = new Crypt_RSA_XML();
		$rsa->setEncryptionMode(CRYPT_RSA_ENCRYPTION_PKCS1);
		$rsa->setPrivateKeyFormat(CRYPT_RSA_PRIVATE_FORMAT_XML);
        $rsa->setPublicKeyFormat(CRYPT_RSA_PUBLIC_FORMAT_XML);
		$rsa->loadKeyfromXML(base64_decode($_SESSION['key_private']));
		$decrypted = $rsa->decrypt(base64_decode($dataEncrypted));
		echo "Your message: " . $decrypted;
	}
} else { 

  $rsa = new Crypt_RSA_XML();
  $rsa->setEncryptionMode(CRYPT_RSA_ENCRYPTION_PKCS1);
  $rsa->setPrivateKeyFormat(CRYPT_RSA_PRIVATE_FORMAT_XML);
  $rsa->setPublicKeyFormat(CRYPT_RSA_PUBLIC_FORMAT_XML);
  $key_arrays = $rsa->createKey(1024);
  $publickey = base64_encode($key_arrays['publickey']);
  $privatekey = base64_encode($key_arrays['privatekey']);
  
  $_SESSION['key_private'] = $privatekey;
  $_SESSION['key_public'] = $publickey;
 
  echo $publickey;
  
} 














  // $privateKey = base64_decode("PFJTQUtleVZhbHVlPg0KICA8TW9kdWx1cz5BS3NWblhndWFobjE1dndwWENCWVJDV0tPWDNjSFRnME82VU9RWFpYOXhVUkxHbEdSSFpFN1Z3enhyV2UzdlVzOVdIZGVWekhlcnVtZzdPdEtzbSsyZmY1a3RQNXRvV242TldIQ1pqemlESDlUV3NTb2xudVJzTzUwaHVRZWxoaHJGcVlTcmRtUzNsVC9VTHhHaDR1bWFkU05WRlZEQ0Y5Mnd0V3I0ZnZKRXhEPC9Nb2R1bHVzPg0KICA8RXhwb25lbnQ+QVFBQjwvRXhwb25lbnQ+DQogIDxQPkFMUGxwTlBhRlNNRHpmdHZkZS91SzhiTmtYakZ1alU3aURQaExwQ0lZT0c5RHBDTXJxOVUyV0hhV0RDVm14SFJuWFBnVld1OE9HOG1sVWdvTzQ3OEp4VT08L1A+DQogIDxRPkFQTjFsdXlCN1FlUzV0bjdkQUw1UkJZUHJNUU1aWHE0UU1UTnFwMEVqVzM1eHRhakxNQ0tXYmJZbmhTNUpHVmIzUEc2Mmk5cWtZOGs5dTVRcEJPbCsvYz08L1E+DQogIDxEUD5BS3E4c1lzLzEvKzdoS3UyUmNESjAxS0RtQ1YveEJMeHhYczNwUElYL1p0Qnk2ajFYSFdibWhWOUhXWS9GMFg2SSszdVpDUTBKM3VXcXVncEJ4M1Z3MkU9PC9EUD4NCiAgPERRPkNSNnppNktHVlkxTU5vZ3ozVlNuRjBoNUNWTUpqaUpPMHRCOWZxcEgvZ0dvVUN3R3BpUEluby9ZeEIvM1hCQ240eXBEdUJqKzRPVGFseXpRS0toRUd3PT08L0RRPg0KICA8SW52ZXJzZVE+UEJvM2l4MWwyQ2lwVlFKZkxCRGlOQ2FnNVIwc2lxZ2NCbkFnelR2aTkzR1FwejI4bm9OWUpMZ1lNeGlBWEMzRTZsMStEYi9zR3dXcVE1c01IcVRqN0E9PTwvSW52ZXJzZVE+DQogIDxEPkFJeFhMdFZuUGFJT0ZXekVnTTRIbWQ4eGcvZTZtRDJDbTJyS1J1ak5QK0lJTkdZblBnSEdpTzhaaWVkeWEzS3picGJaRnJVRTdha0E3d2gxQktSNTZsSWxIM1cvbG9CR1RSaUVtNmJ5M094aHI2TVh3YmdGYUF4S1lxSVNoSzUrRE9rMVh0TVJVY0JLNHFnQ1JORnRwVTgweHpyalF6NkRaVExqT2ZMVXovRT08L0Q+DQo8L1JTQUtleVZhbHVlPg==");
  // $publicKey = base64_decode("PFJTQUtleVZhbHVlPg0KICA8TW9kdWx1cz5BS3NWblhndWFobjE1dndwWENCWVJDV0tPWDNjSFRnME82VU9RWFpYOXhVUkxHbEdSSFpFN1Z3enhyV2UzdlVzOVdIZGVWekhlcnVtZzdPdEtzbSsyZmY1a3RQNXRvV242TldIQ1pqemlESDlUV3NTb2xudVJzTzUwaHVRZWxoaHJGcVlTcmRtUzNsVC9VTHhHaDR1bWFkU05WRlZEQ0Y5Mnd0V3I0ZnZKRXhEPC9Nb2R1bHVzPg0KICA8RXhwb25lbnQ+QVFBQjwvRXhwb25lbnQ+DQo8L1JTQUtleVZhbHVlPg==");
 // // //$publicKey = "<RSAKeyValue><Modulus>AJyE7YfTYHQzaJDyFAa+gjhwJHGpeN23vOAjeogDZvgN2BwE2P3JVNYxEfhO/xgjoJuRslWvUskGGcRrQKI2L6KIh4WDylR1AL2Z4hZXsncJhfIKRqrB0OVsJGY1ySe7M5VjBcMFSNcG4YmyQtgqtrINPJfuBxBtjWZ+jtFabkvR</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
 // // //$privateKey = "<RSAKeyValue><Modulus>AJyE7YfTYHQzaJDyFAa+gjhwJHGpeN23vOAjeogDZvgN2BwE2P3JVNYxEfhO/xgjoJuRslWvUskGGcRrQKI2L6KIh4WDylR1AL2Z4hZXsncJhfIKRqrB0OVsJGY1ySe7M5VjBcMFSNcG4YmyQtgqtrINPJfuBxBtjWZ+jtFabkvR</Modulus><Exponent>AQAB</Exponent><P>AONfA3ljbUZX0sn2SbrL7Wpk+/OhGGcugsQE2UFlW2Kc5CPzUsr1RURYo6oQvaC7YS0z/14mnnvT4tM220qVzgs=</P><Q>ALA6GpbMWKKdRfpkr6RMaZFQWn1ELvjOYztYN/+eVN7GKhGVTl9nkEcsjORyUlA0JPSmH3gZz5m6T9f87JO9oxM=</Q><DP>ANN6YCTbkZvHu8sVRGZ1npFC9AUaZTQzUnU3fUsSFvmVq6y0eOFFV/PF7hQUFgwVvMDqiC7uBKJv5Z1GfJjW1Rk=</DP><DQ>JppTwLy6ncR907/CiecDKQXFDLOm5nGvYwyMF76DMNmP1ZIzPMre2/hyVIiGZ3NEtSK+ufxNcYtSeim5WROtaQ==</DQ><InverseQ>W70MgQiytb8uup68c+Afu+sXzUQJT41t8KokPvq4xk38SMPGlS4y6AaAQiIys/mICe2lDCPh8quGj8reFAaTPA==</InverseQ><D>SpLG/XUHurWXt5+vTPtN3ggIRSNi0/isA/rDcbR1RfCKq+bfYCOhyR++GRnCTsUCy7xiRJLxFZhThJM5S1AX509rm1yoIgy1q4aVBoeoH2eVod01Wn2M3WD9pAuvXdprMUzKFuxQj/AvssTmpkZpEBLpaxqZ6FWW4SFteZpozRU=</D></RSAKeyValue>";
 


   // $rsa = new Crypt_RSA_XML();
   // $rsa->setEncryptionMode(CRYPT_RSA_ENCRYPTION_PKCS1);
   // $rsa->setPrivateKeyFormat(CRYPT_RSA_PRIVATE_FORMAT_XML);
   // $rsa->setPublicKeyFormat(CRYPT_RSA_PUBLIC_FORMAT_XML);
   
  // // $rsa->loadKeyfromXML($publicKey);
  // // $encrypted = base64_encode($rsa->encrypt("hello"));
  // // echo $encrypted;

  // $rsa->loadKeyfromXML($privateKey);
  // $decrypted = $rsa->decrypt(base64_decode("VgeHBL4Bqgxf2dVW46E1EgiJCSsJoqXsbp3xNuczCdtRn3sFzzfhm3Ppn5v1+XjPBBKgU2cJIjUqiOpGXLB7F1FJojhZYgif7L7qQKG5cP5wSocYe5OP0lbCj19mtkkVPpVpa6zF/zqJl8SMI7i5LTRR3OVdwH8kmZ3sFiI9Ey0="));
  // echo "\r\n" . $decrypted;



 // $key_arrays = $rsa->createKey(1024);
 // $publickey = base64_encode($key_arrays['publickey']);
 // $privatekey = base64_encode($key_arrays['privatekey']);
 
  // echo "public key:". $publickey . "\r\n" . "privatekey:" . $privatekey . "\r\n";
  // $rsa->loadKeyfromXML(base64_decode($publickey));
  // $encrypted = base64_encode($rsa->encrypt("hello"));
  // echo $encrypted;

  // $rsa->loadKeyfromXML(base64_decode($privatekey));
  // $decrypted = $rsa->decrypt(base64_decode($encrypted));
  // echo "\r\n" . $decrypted;

