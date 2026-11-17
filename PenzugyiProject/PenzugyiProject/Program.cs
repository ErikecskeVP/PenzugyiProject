Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
Console.WriteLine("$$      Pénzügyi Naplózó      $$");
Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");

Console.WriteLine();

if (!File.Exists("egyenleg.txt"))
{
    Console.Write("Add meg a kiindulási egyenleged: ");
    while (true)
    {
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

File.ReadAllText("egyenleg.txt");