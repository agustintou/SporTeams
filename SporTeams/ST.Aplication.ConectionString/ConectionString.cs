namespace ST.Aplication.ConectionString
{
    public static class ConectionString
    {
        const string BaseDatos = "Repositorio";

        const string Servidor = @"DESKTOP-I9AA7DR\SQLEXPRESS";

        public static string GetWithWindows => $"Data Source={Servidor}; " +
                $"Initial Catalog={BaseDatos}; " +
                $"Integrated Security = true;";
    }
}
