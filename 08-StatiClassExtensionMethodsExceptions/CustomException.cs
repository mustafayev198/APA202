using System;

public class InvalidUsernameException : Exception
{
    public InvalidUsernameException() : base("Username bos ola bilmez ve minimum 3 simvol olmalidir.") { }
    public InvalidUsernameException(string message) : base(message) { }
}

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException() : base("Password bos ola bilmez ve minimum 6 simvol olmalidir.") { }
    public InvalidPasswordException(string message) : base(message) { }
}

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("İstifadeçi tapilmadi.") { }
    public UserNotFoundException(string username) : base($"'{username}' adli istifadeçi sistemde mövcud deyil.") { }
}

public class IncorrectPasswordException : Exception
{
    public int AttemptsLeft { get; }
    public IncorrectPasswordException(int attemptsLeft)
        : base($"sifre yanlisdir! Cehd haqqiniz: {attemptsLeft}")
    {
        AttemptsLeft = attemptsLeft;
    }
}

public class AccountLockedException : Exception
{
    public AccountLockedException() : base("Hesabiniz ardicil 3 uğursuz cehde göre bloklanib.") { }
}