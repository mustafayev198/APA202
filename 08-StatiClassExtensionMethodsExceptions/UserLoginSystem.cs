public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsLocked { get; set; }
    public int FailedAttempts { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
        IsLocked = false;
        FailedAttempts = 0;
    }
}

public class LoginSystem
{
    private User[] users;
    private const int MaxAttempts = 3;

    public LoginSystem()
    {
        users = new User[]
        {
            new User("admin", "admin123"),
            new User("student", "student123"),
            new User("teacher", "teacher123")
        };
    }

    public void ValidateUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
            throw new InvalidUsernameException();
    }

    public void ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            throw new InvalidPasswordException();
    }

    private User FindUser(string username)
    {
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i].Username.ToLower() == username.ToLower())
                return users[i];
        }
        return null;
    }

    public bool Login(string username, string password)
    {
        ValidateUsername(username);
        ValidatePassword(password);

        User user = FindUser(username);

        if (user == null)
            throw new UserNotFoundException(username);

        if (user.IsLocked)
            throw new AccountLockedException();

        if (user.Password == password)
        {
            user.FailedAttempts = 0;
            Console.WriteLine($"\nLogin successful! Welcome, {user.Username}!");
            return true;
        }
        else
        {
            user.FailedAttempts++;
            int attemptsLeft = MaxAttempts - user.FailedAttempts;

            if (attemptsLeft > 0)
            {
                throw new IncorrectPasswordException(attemptsLeft);
            }
            else
            {
                user.IsLocked = true;
                throw new AccountLockedException();
            }
        }
    }
}