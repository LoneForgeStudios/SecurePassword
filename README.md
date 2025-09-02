# 🔐 SecurePassword — Генератор безопасных паролей / Secure Password Generator

---

### 📌 Описание

Консольное приложение для генерации безопасных паролей с настраиваемой длиной, процентом цифр и спецсимволов. Пароль автоматически копируется в буфер обмена.

### 🚀 Возможности

- Настраиваемая длина пароля
- Процент цифр и спецсимволов
- Безопасная генерация с использованием System.Security.Cryptography
- Копирование пароля в буфер обмена (через [TextCopy](https://www.nuget.org/packages/TextCopy))

### 🛠 Установка и запуск

```bash
git clone https://github.com/LoneForgeStudios/SecurePassword.git
cd SecurePasswordGen
dotnet restore
dotnet run
