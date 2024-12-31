using StackExchange.Redis;

class Program
{
    static void Main(string[] args)
    {
        // Defina a string de conexão (pode incluir a senha se necessário)
        string redisConnectionString = "localhost:6379"; // Substitua com seu endereço Redis
        try
        {
            // Conectar ao Redis
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnectionString);

            // Obter o banco de dados do Redis
            IDatabase db = redis.GetDatabase();

            // Exemplo de operação no Redis: salvar uma chave
            db.StringSet("mykey", "Hello, Redis!");

            // Exemplo de leitura de uma chave
            string value = db.StringGet("mykey");
            Console.WriteLine($"Valor de 'mykey': {value}");

            // Fechar a conexão com o Redis
            redis.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao conectar no Redis: {ex.Message}");
        }
    }
}
