<!DOKTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>CalculateInterest</title>
</head>
<body>
<div>
    <?php
    if (isset($_GET['submit'])) {
        $monthInterest = $_GET['interest'] / 12;
        $amount = $_GET['amount'];
        $period = $_GET['period'];
        $resultAmount = $amount * pow(1 + $monthInterest / 100, $period);
        $currency = $_GET['currency'];
        if ($currency === 'usd') {
            $currency = '$';
        }
        echo $currency, ' ', number_format($resultAmount, 2, '.', ''), '<br />';
    }
    ?>
</div>

<form action="03.CalculateInterest.php" method="get">
    <label>Enter Amount</label>
    <input type="text" name="amount"/>

    <div>
        <input type="radio" name="currency" id="usd" value="usd"/>
        <label for="usd">USD</label>
        <input type="radio" name="currency" id="eur" value="eur"/>
        <label for="eur">EUR</label>
        <input type="radio" name="currency" id="bgn" value="bgn"/>
        <label for="bgn">BGN</label>
    </div>
    <div>
        <label>Compound Interest Amount</label>
        <input type="text" name="interest">
    </div>
    <select name="period">
        <option value="6">6 Months</option>
        <option value="12">1 Year</option>
        <option value="24">2 Years</option>
        <option value="60">5 Years</option>
    </select>
    <input type="submit" value="Calculate" name="submit"/>
</form>

</body>
</html>