using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

public class UserAccount
{
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
}

public class UserAccountManager
{

    private List<UserAccount> userAccounts = new()
    {
        new UserAccount
        {
            Email = "user1@example.com",
            PasswordHash = DataEncryption.Encrypt("password1")
        },
        new UserAccount
        {
            Email = "user2@example.com",
            PasswordHash = DataEncryption.Encrypt("password2")
        }
    };

    private HashSet<string> usedCaptchaValues = new HashSet<string>();
    private DateTime lockoutEndTime = DateTime.MinValue;
    public bool VerifyLogin(string email, string password, string captchaResponse)
    {
        if (!VerifyCaptcha(captchaResponse))
        {
            return false;
        }

        UserAccount user = userAccounts.FirstOrDefault(u => u.Email == email);

        if (user != null && DataEncryption.VerifyPassword(password, user.PasswordHash))
        {
            return true;
        }

        return false;
    }

    internal string GenerateRandomCaptchaValue()
    {
        Random random = new Random();
        const string chars = "0123456789";
        return new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    private bool VerifyCaptcha(string captchaResponse)
    {
        if (usedCaptchaValues.Contains(captchaResponse))
        {
            return false;
        }

        usedCaptchaValues.Add(captchaResponse);
        return true;
    }

    public void RunLogin()
    {
        int loginAttempts = 0;

        while (loginAttempts < 3)
        {
            Console.CursorLeft = 20;
            Console.Write("Enter your username (email): ");
            string username = Console.ReadLine();

            Console.CursorLeft = 20;
            Console.Write("Enter your password: ");
            string password = ReadPassword();

            Console.CursorLeft = 20;
            string captchaValue = GenerateRandomCaptchaValue();
            Console.WriteLine("Captcha: " + captchaValue);

            Console.CursorLeft = 20;
            Console.Write("Enter Captcha response: ");
            string captchaResponse = Console.ReadLine();

            if (VerifyLogin(username, password, captchaResponse))
            {
                Console.CursorLeft = 20;
                Console.WriteLine("Login successful. Welcome!");
                // Proceed with the application logic for a successful login.
                break;
            }
            else
            {
                Console.CursorLeft = 20;
                Console.WriteLine("Login failed. Please try again.");
                loginAttempts++;

                if (loginAttempts >= 3)
                {
                    Console.CursorLeft = 20;
                    Console.WriteLine("Login attempts exceeded. Please try again after 15 minutes.");
                    lockoutEndTime = DateTime.Now.AddMinutes(15);
                    // Add logic to lock the login process for 15 minutes.
                    break;
                }
            }
        }
    }

    private string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, (password.Length - 1));
                Console.Write("\b \b");
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                password += keyInfo.KeyChar;
                Console.Write("*");
            }
        } while (keyInfo.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }
}

public static class DataEncryption
{
    public static byte[] Encrypt(string input)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = GetEncryptionKey();
            aesAlg.IV = GetEncryptionIV();

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(input);
                    }
                }

                return msEncrypt.ToArray();
            }
        }
    }

    public static string Decrypt(byte[] cipherText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = GetEncryptionKey();
            aesAlg.IV = GetEncryptionIV();

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }

    private static byte[] GetEncryptionKey()
    {
        return new byte[]
        {
            0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef,
             0xfe, 0xdc, 0xba, 0x98, 0x76, 0x54, 0x32, 0x10
        };
    }

    private static byte[] GetEncryptionIV()
    {
        return new byte[]
        {
            0xfe, 0xdc, 0xba, 0x98, 0x76, 0x54, 0x32, 0x10,
            0x01, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef
        };
    }

    public static bool VerifyPassword(string input, byte[] hashedPassword)
    {
        string decryptedPassword = Decrypt(hashedPassword);
        return input == decryptedPassword;
    }
}
