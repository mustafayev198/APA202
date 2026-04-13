using System;

class Program
{
    static void Main()
    {
        // 1. Riyazi əməl metodu yoxlanışı
        Hesabla(10, 2, '+'); // Toplama
        Hesabla(10, 2, '/'); // Bölmə

        // 2. Tək-cüt yoxlanışı
        int[] ededler = { 14, 20, 35, 40, 57, 60, 100 };
        TekCutYoxla(ededler);

        // 3. Bölünmə cəmi yoxlanışı
        BolunmeCemi(ededler);

        // 4. Simvol sayma yoxlanışı
        SimvolSayiTap("Salam, bu gün hava gözəldir", 'a');
    }

    // 1. Şərtlə riyazi əməllər
    static void Hesabla(double n1, double n2, char emel)
    {
        if (emel == '+') Console.WriteLine("Cəm: " + (n1 + n2));
        else if (emel == '-') Console.WriteLine("Fərq: " + (n1 - n2));
        else if (emel == '*') Console.WriteLine("Hasil: " + (n1 * n2));
        else if (emel == '/') Console.WriteLine("Bölmə: " + (n1 / n2));
    }

    // 2. Tək və ya cüt olmasını yoxlayan şərt
    static void TekCutYoxla(int[] massiv)
    {
        foreach (int eded in massiv)
        {
            if (eded % 2 == 0)
                Console.WriteLine(eded + " cütdür");
            else
                Console.WriteLine(eded + " təkdir");
        }
    }

    // 3. Həm 4-ə, həm 5-ə bölünmə şərti
    static void BolunmeCemi(int[] massiv)
    {
        int cem = 0;
        foreach (int eded in massiv)
        {
            if (eded % 4 == 0 && eded % 5 == 0) // "və" şərti
            {
                cem = cem + eded;
            }
        }
        Console.WriteLine("4 və 5-ə bölünənlərin cəmi: " + cem);
    }

    // 4. Simvolun bərabərliyini yoxlayan şərt
    static void SimvolSayiTap(string cumle, char herf)
    {
        int say = 0;
        foreach (char c in cumle)
        {
            if (c == herf) // Şərt: əgər hərflər eynidirsə
            {
                say++;
            }
        }
        Console.WriteLine("Cümlədə '" + herf + "' hərfi " + say + " dəfə var.");
    }
}