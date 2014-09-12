using System;
class BankAccountData
{
    static void Main()
    {
        Console.WriteLine(new string ('=', 50));
        string firsName = "Gosho";
        string midleName = "Peshov";
        string lastName = "Geshov";
        object fullName = firsName + " " + midleName + " " + lastName;
        Console.WriteLine("Presonal Information:");
        Console.WriteLine();
        Console.WriteLine("Full Name: {0}", fullName);
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("Account Information:");
        decimal bankBalance = 20000;
        string bankName = "SportBank";
        string iban = "BG80 BNSB 8812 2332 11111 78";
        Console.WriteLine();
        Console.WriteLine("Bank : {0}, Balance :{1} BGN, IBAN : {2}", bankName, bankBalance, iban);
        Console.WriteLine(new string('=', 50));
        long creditCard1 = 45643765765768897;
        long creditCard2 = 62456265786788943;
        long creditCard3 = 13531765898700044;
        Console.WriteLine("Credit cards informathion: ");
        Console.WriteLine();
        Console.WriteLine("Card 1: {0} \nCard 2: {1} \nCard 3: {2}", creditCard1, creditCard2, creditCard3);
        Console.WriteLine(new string('=', 50));
        Console.WriteLine();
    }
}

