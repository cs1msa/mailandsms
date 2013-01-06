<html><head><title>unsubscribe from email sms list</title>
<link rel="stylesheet" type="text/css" href="mystyles.css"  /></head>
<body>
<div class="body">
<br><br>
 <CENTER><img src="images/log.jpg">
<br><br><br>
<?php


require_once("db.php");
$dbConnection = connectToDB();
if (isset($_POST['unsubscribe'])){
$id=$_POST["unsubscribe"];
$d="http://83.212.99.225/mailsms/index.php?unsubscribe=$id";
	
$sql1="SELECT random_string
		FROM    subscribed_to_list 
		WHERE random_string ='$d'";
$result=mysql_query($sql1);
$b=mysql_num_rows($result);
if ($b==0)
{ 
echo("<P> Δεν υπαρχει στην λιστα</P>");}
else{
$a=mysql_result($result,0);
if( $a!= $d)	
{ 
echo("<P>Δεν υπαρχει στην λιστα</P>");}
else{
$sql = "Delete from subscribed_to_list where random_string ='$d'";
if (mysql_query($sql)) 
    echo("<P> Διαγραφηκε απο την λιστα</P>");
else 
    echo("<P>ËÜèïò: " . mysql_error() ."</P>");
}}}

?>
</CENTER>
</bïdy>
</html>
