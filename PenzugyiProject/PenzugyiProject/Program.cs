using System.Text;

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
string tranzpath = "tranzakciok.csv";
if (!File.Exists(tranzpath))
{
    File.WriteAllText(tranzpath, $"tranzakció típusa;dátum;idő;összeg;miből/mire;pillanatnyi egyenleg{Environment.NewLine}");
}


int globalegyenleg = int.Parse(File.ReadAllText("egyenleg.txt"));
string globalpenznem = File.ReadAllText("penznem.txt");
Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");
Console.WriteLine("          Főmenü           ");
Console.WriteLine("[1]  Egyenleg megtekintése, ");
Console.WriteLine("[2]  Tranzakció rögzítése,  ");
Console.WriteLine("[3]  Tranzakciók böngézése, ");
Console.WriteLine("[4]  Emlékeztetők szerkesztése, ");
Console.WriteLine("[0]  Program bezárása       ");
Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$");

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

        else if (valasztas == 2)
        {
            Console.Write("Add meg a tranzakció típusát (bevétel/költség): ");
            string tipus = Console.ReadLine();
            Console.Write("Miből jött a jővedelem/Mire költöttél? ");
            string mire = Console.ReadLine();
            DateTime most = DateTime.Now;
            string datumStr = most.ToString("yyyy-MM-dd");
            string idoStr = most.ToString("HH:mm");

            if (tipus.ToLower() == "bevétel" || tipus.ToLower() == "költség")
            {
                Console.Write("Add meg a tranzakció összegét: ");
                string osszeg = Console.ReadLine();
                if (int.TryParse(osszeg, out int tranzosszeg) && tranzosszeg>0)
                {
                    if (tipus.ToLower() == "bevétel")
                    {
                        globalegyenleg += tranzosszeg;
                        using (StreamWriter sw = new StreamWriter(tranzpath, true, Encoding.UTF8))
                        {
                            sw.WriteLine($"{tipus};{datumStr};{idoStr};{tranzosszeg};{mire};{globalegyenleg}");
                        }
                    }
                    else
                    {
                        globalegyenleg -= tranzosszeg;
                        using (StreamWriter sw = new StreamWriter(tranzpath, true, Encoding.UTF8))
                        {
                            sw.WriteLine($"{tipus};{datumStr};{idoStr};{tranzosszeg};{mire};{globalegyenleg}");
                        }
                    }
                    File.WriteAllText("egyenleg.txt", $"{globalegyenleg}");
                }
                else
                {
                    Console.WriteLine("Csak egész számot adhatsz meg");
                }
            }
            else
            {
                Console.WriteLine("Csak bevétel vagy költség lehet a típus");
            }
        }
        else if (valasztas == 3)
        {
            bool benne = false;
            Console.WriteLine();
            Console.WriteLine("Mi alapján keress: [1] Dátum, [2] Tranzakció típusa, [0] Vissza");
            Console.Write("Add meg a választott menüpont számát: ");
            string choice2 = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(choice2, out int valasztas2))
            {
                if (valasztas2 == 1)
                {
                    Console.WriteLine("[1] Két dátum között, [2] Pontos dátum alapján, [0] Vissza");
                    Console.Write("Add meg a választott menüpont számát: ");
                    string choice3 = Console.ReadLine();
                    Console.WriteLine();

                    if (int.TryParse(choice3, out int valasztas3))
                    {
                       if (valasztas3 == 1)
                        {
                            
                            Console.Write("Add meg az első dátumot: ");
                            string dt1 = Console.ReadLine();
                            Console.Write("Add meg a második dátumot: ");
                            string dt2 = Console.ReadLine();
                            if (DateOnly.TryParse(dt1, out DateOnly datum1) && DateOnly.TryParse(dt2, out DateOnly datum2))
                            {
                                foreach (string sor in File.ReadLines(tranzpath).Skip(1))
                                {
                                    string[] adatok = sor.Split(";");
                                    string tipuss = (adatok[0]);
                                    string datum = (adatok[1]);
                                    string ido = (adatok[2]);
                                    string kerossz = (adatok[3]);
                                    string kermire = (adatok[4]);
                                    string keresegyen = (adatok[5]);
                                    


                                    DateOnly alakdatum = DateOnly.Parse(datum);

                                    if (datum2 >= alakdatum && datum1 <= alakdatum || datum1 >= alakdatum && datum2 <= alakdatum)
                                    {
                                        benne = true;
                                        Console.WriteLine();
                                        Console.WriteLine($"A tranzakcó típusa: {tipuss}");
                                        Console.WriteLine($"Dátum: {datum}");
                                        Console.WriteLine($"Idő: {ido}");
                                        Console.WriteLine($"Összege: {kerossz}");
                                        Console.WriteLine($"Mire/Miből: {kermire} {globalpenznem}");
                                    }
                                    
                                }
                                if (!benne)
                                {
                                    Console.WriteLine("Ez a kettő dátum között nincs rögzített tranzakció.");
                                }

                            }
                            
                            else
                            {
                                Console.WriteLine("Hibás Dátum!");
                            }
                    
                        }
                        else if (valasztas3 == 2)
                        {
                            Console.Write("Add meg a dátumot: ");
                            string dt=Console.ReadLine();
                            if (DateOnly.TryParse(dt, out DateOnly date)){
                                foreach (string sor in File.ReadLines(tranzpath).Skip(1))
                                {
                                    string[] adatok = sor.Split(";");
                                    string tipuss = (adatok[0]);
                                    string datum = (adatok[1]);
                                    string ido = (adatok[2]);
                                    string kerossz = (adatok[3]);
                                    string kermire = (adatok[4]);
                                    string keresegyen = (adatok[5]);
                                    DateOnly alkdatum = DateOnly.Parse(datum);

                                    if (date == alkdatum)
                                    {
                                        benne = true;
                                        Console.WriteLine();
                                        Console.WriteLine($"A tranzakcó típusa: {tipuss}");
                                        Console.WriteLine($"Dátum: {datum}");
                                        Console.WriteLine($"Idő: {ido}");
                                        Console.WriteLine($"Összege: {kerossz}");
                                        Console.WriteLine($"Mire/Miből: {kermire} {globalpenznem}");
                                    }
                                }
                                if (!benne)
                                {
                                    Console.WriteLine("Ezzel a dátummal nincs rögzített tranzakció.");
                                }
                            }
                            else { Console.WriteLine("Hibás dátum!"); }

                        }
                        else { Console.WriteLine("Csak a menüben feltüntetett számokat adhatod meg"); }
                    }
                }
                else if (valasztas2 == 2)
                {

                }
                else
                {
                    Console.WriteLine("Csak a menüben feltüntetett számokat adhatod meg");
                }
            }
        }
        else if (valasztas == 4)
        {

        }
        else if (valasztas == 0)
        {
            break;
        }
            
            
        }
        else
        {
            Console.WriteLine("Csak a menüben feltüntetett számokat adhatod meg");
        }
    
}