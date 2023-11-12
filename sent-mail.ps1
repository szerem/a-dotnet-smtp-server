param (
    [string] $arg
)
$body = "This is a test message" + (&{If($arg) {" $arg"} Else {""}}) + "."

Send-MailMessage -SmtpServer localhost -Port 25552 -From "from@from.pl" -To "to@to.pl" -Subject "Test email" -Body $body