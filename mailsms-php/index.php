<html><head><title>unsubscribe from email sms list</title>
<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
<link rel="stylesheet" type="text/css" href="mystyles.css"  /></head>
<body>
<br><br>
 <CENTER><img src="images/log.jpg">
<br><br><br>
<?php


require_once("db.php");
$dbConnection = connectToDB();
if (isset($_GET['unsubscribe'])){
$id=$_GET["unsubscribe"];
	
$d="http://83.212.99.225/mailsms/index.php?unsubscribe=$id";
	
$sql="SELECT random_string
		FROM    subscribed_to_list 
		WHERE random_string ='$d'";

$result=mysql_query($sql);
$b=mysql_num_rows($result);
 
if ($b==0)
{ 
	echo("<P>  Το unsubscribe link δεν υπαρχει στη λιστα</P>");}
else{

	
	echo"<form  method='post' action='delete.php'> ";
	echo"<P>Θελετε να διαγραφειτε απο τη λιστα αποστολης Email/Sms  ";
	echo"<input type='submit' value='   Ναι   ' class='button'/> </P>";
	echo"<input type='hidden' name='unsubscribe' value=\"$id\"/>";
	echo'</form>';
 
}}

?>
 </CENTER>
 
</bïdy>
</html>


