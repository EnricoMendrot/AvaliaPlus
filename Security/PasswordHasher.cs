using BCrypt.Net;

namespace WebApplication2.Security
{
    public static class PasswordHasher
    {
        // Gera o hash da senha (com salt automático)
        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Senha não pode estar vazia");

            // WorkFactor 11 ou 12 é um bom equilíbrio entre segurança e performance
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        // Verifica se a senha digitada corresponde ao hash salvo
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hashedPassword))
                return false;

            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}