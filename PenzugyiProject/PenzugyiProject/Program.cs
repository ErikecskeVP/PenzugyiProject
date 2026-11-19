HashSet<string> penznemek = new() {
    "AED", "AFN", "ALL", "AMD", "AOA", "ARS", "AUD", "AWG", "AZN",
    "BAM", "BBD", "BDT", "BHD", "BIF", "BMD", "BND", "BOB", "BRL", "BSD",
    "BTN", "BWP", "BYN", "BZD", "CAD", "CDF", "CHF", "CLP", "CNY", "COP",
    "CRC", "CUP", "CVE", "CZK", "DJF", "DKK", "DOP", "DZD", "EGP", "ERN",
    "ETB", "EUR", "FJD", "FKP", "GBP", "GEL", "GHS", "GIP", "GMD", "GNF",
    "GTQ", "GYD", "HKD", "HNL", "HTG", "HUF", "IDR", "ILS", "INR", "IQD",
    "IRR", "ISK", "JMD", "JOD", "JPY", "KES", "KGS", "KHR", "KMF", "KPW",
    "KRW", "KWD", "KYD", "KZT", "LAK", "LBP", "LKR", "LRD", "LSL", "LYD",
    "MAD", "MDL", "MGA", "MKD", "MMK", "MNT", "MOP", "MRU", "MUR", "MVR",
    "MWK", "MXN", "MYR", "MZN", "NAD", "NGN", "NIO", "NOK", "NPR", "NZD",
    "OMR", "PAB", "PEN", "PGK", "PHP", "PKR", "PLN", "PYG", "QAR", "RON",
    "RSD", "RUB", "RWF", "SAR", "SBD", "SCR", "SDG", "SEK", "SGD", "SHP",
    "SLE", "SOS", "SRD", "SSP", "STN", "SVC", "SYP", "SZL", "THB", "TJS",
    "TMT", "TND", "TOP", "TRY", "TTD", "TWD", "TZS", "UAH", "UGX", "USD",
    "UYU", "UZS", "VED", "VES", "VND", "VUV", "WST", "XAF", "XCD", "XCG",
    "XOF", "XPF", "YER", "ZAR", "ZMW", "ZWG"
};  
Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");
Console.WriteLine("     Pénzügyi Naplózó      ");
Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");
Console.WriteLine();

if (!File.Exists("penznem.txt"))
{
    Console.WriteLine();
    while (true)
    {
        Console.Write("Add meg a használt pénznemed (pl.: HUF, EUR, USD): ");
        string penznem = Console.ReadLine();
        if (penznemek.Contains(penznem.ToUpper()))
        {
            string path1 = "penznem.txt";
            File.WriteAllText(path1, penznem.ToUpper());
            break;
        }
        else
        {
            Console.WriteLine("Nincs ilyen pénznem");
        }

    }
}



if (!File.Exists("egyenleg.txt"))
{
    
    while (true)
    {
        Console.Write("Add meg a kiindulási egyenleged: ");
        string egyen = Console.ReadLine();
        if (int.TryParse(egyen, out int egyenleg))
        {
            string path = "egyenleg.txt";
            File.WriteAllText(path, $"{egyenleg}");
            break;
        }
        else
        {
            Console.Write("Csak egész számot addhatsz meg: ");
        }
    }
}

int globalegyenleg = int.Parse(File.ReadAllText("egyenleg.txt"));
string globalpenznem = File.ReadAllText("penznem.txt");
Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");
Console.WriteLine("         Főmenü           ");
Console.WriteLine("1) Egyenleg megtekintése, ");
Console.WriteLine("2) Tranzakció rögzítése,  ");
Console.WriteLine("3) Tranzakciók böngézése, ");
Console.WriteLine("0) Program bezárása       ");
Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$");

Console.WriteLine();
while (true)
{
    Console.WriteLine();
    Console.Write("Add meg a választott menüpont számát: ");
    string choice = Console.ReadLine();
       if (int.TryParse(choice, out int valasztas))
       {
         if (valasztas == 1)
            {
                Console.WriteLine($"A jelenlegi egyenleged {globalegyenleg} {globalpenznem}");

            }
            if (valasztas == 0)
            {
                break;
            }
        }
        else
        {
            Console.WriteLine("Csak a menüben feltüntetett számokat adhatod meg");
        }
    
}