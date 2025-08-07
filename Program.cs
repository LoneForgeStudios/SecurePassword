using System;
using SecurePasswordGenerator;
class Program
{
    static void Main()
    {
        Console.WriteLine("SecurePassword — Генератор Безопасностных паролей");

        Console.Write("Введите длину пароля: ");
        if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
        {
            Console.WriteLine(" Некорректная длина.");
            return;
        }

        Console.Write("Введите процент цифр (0–100): ");
        if (!int.TryParse(Console.ReadLine(), out int percentDigits) || percentDigits < 0 || percentDigits > 100)
        {
            Console.WriteLine(" Некорректный процент цифр.");
            return;
        }

        Console.Write("Введите процент спецсимволов (0–100): ");
        if (!int.TryParse(Console.ReadLine(), out int percentSpecials) || percentSpecials < 0 || percentSpecials > 100)
        {
            Console.WriteLine(" Некорректный процент спецсимволов.");
            return;
        }

        if (percentDigits + percentSpecials > 100)
        {
            Console.WriteLine(" Сумма процентов не должна превышать 100%");
            return;
        }

        string password = SecurePassword.Generate(length, percentDigits, percentSpecials);
        Console.WriteLine($"\n Сгенерированный пароль:\n{password}");

        try
        {
            TextCopy.ClipboardService.SetText(password);
            Console.WriteLine(" Пароль скопирован в буфер обмена.");
        }
        catch
        {
            Console.WriteLine(" Не удалось скопировать в буфер.");
        }
    }
}
