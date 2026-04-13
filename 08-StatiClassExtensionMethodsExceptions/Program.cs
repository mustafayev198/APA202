class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        LoginSystem system = new LoginSystem();

        while (true)
        {
            try
            {
                Console.WriteLine("\n--- Login Paneli ---");
                Console.Write("Username: ");
                string uname = Console.ReadLine();

                Console.Write("Password: ");
                string pass = Console.ReadLine();

                if (system.Login(uname, pass))
                {
                    break; 
                }
            }
            catch (InvalidUsernameException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            catch (InvalidPasswordException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine("Məsləhət: 'admin', 'student' və ya 'teacher' istifadə edin.");
            }
            catch (IncorrectPasswordException ex)
            {
                Console.WriteLine("WARNING: " + ex.Message);
            }
            catch (AccountLockedException ex)
            {
                Console.WriteLine("CRITICAL: " + ex.Message);
                Console.WriteLine("Zəhmət olmasa administratorla əlaqə saxlayın (Contact Admin).");
                break; // Bloklandıqda proqramı dayandır
            }
            catch (Exception ex)
            {
                Console.WriteLine("UNEXPECTED ERROR: " + ex.Message);
            }
        }

        Console.WriteLine("\nProqram başa çatdı. Çıxış üçün hər hansı düyməyə basın...");
        Console.ReadKey();
    }
}