namespace backend.Services
{
    public static class Criptografia
    {
        public static string Criptografa(string text)
        {
            return BCrypt.Net.BCrypt.HashPassword(text);
        }
        public static bool Compara(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
