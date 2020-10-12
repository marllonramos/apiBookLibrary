namespace bookLibrary.Infra.Contexts
{
    public class EstudoDbSqlAdoContext
    {
        // Esses são os dois namespaces que precisamos para trabalhar com o Sql Server
        // System.Data          -> representa a arquitetura do ADO.Net. É o namespace que utilizamos para trabalhar com qualquer banco de dados em nosso projeto.
        // System.Data.Client   -> é o namespace que possui os objetos que precisamos para trabalhar com o Sql Server.

        // SqlConnection            -> é a classe utilizada para se conectar com o banco de dados Sql Server
        // SqlCommand               -> executa comandos no banco de dados, tais como: INSERT, UPDATE, DELETE e SELECT, StoredProcecdures, Views e etc...
        // SqlDataReader            -> Lê registros obtidos de consultas. Qualquer instrução sql do tipo SELECT deve retornar os seus resultados para um SqlDataReader
        // SqlParameterCollection   -> classe que representa uma coleção de parâmetros onde podemos adicionar vários parâmetros nela
        // SqlParameter             -> classe que representa os parâmetros(nome das colunas) no Sql Server. Nessa classe nós passamos o nome do parâmetro(coluna da tabela) e o seu valor
        // SqlDataAdapter           -> ele serve para converter os dados que vem de uma consulta do banco de dados para uma linguagem que o nosso código C# entenda
        // DataTable                -> é uma tabela de dados criada em memória com as informações que passamos para ela

        // Usando SqlParameterCollection e SqlParameter
        /*  ...
            private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameter;     -> iniciando a coleção de parâmetros vazia

            public void LimparParametros()
            {
                sqlParameterCollection.Clear(); -> caso eu utilize o 'sqlParameterCollection' de forma global na minha classe, eu precisarei limpá-la para quando for utilizá-la novamente.
            }

            public void AdicionarParametros(string nomeParametro, object valorParametro)
            {
                sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
            }
            ...
        */

        // Criando um método para executar algum comando no BD
        /*  ...
            // Persistência - Insert, Update, Delete
            public void ExecutarComando(CommandType commandType, string nomeStoredProcecdureOuTextoSql)
            {
                try
                {
                    // Criando e abrindo conexão
                    SqlConnection conn = CriarConexao();
                    conn.Open();

                    // Criando o comando para executar no banco.
                    // Peço a minha conexão para criar um comando.
                    SqlCommand command = conn.CreateCommand();
                    // Montando o comando
                    command.CommandType = commandType;
                    command.CommandText = nomeStoredProcecdureOuTextoSql;
                    command.CommandTimeout = 60; (normalmente essa informação fica no '.config'. Tempo em segundos)

                    // Adicionamos os parâmetros ao comando que será enviado ao banco.
                    foreach(SqlParameter parameter in sqlParameterCollection)
                    {
                        sqlCommand.Parameters.Add(new Parameter(parameter.ParameterName, parameter.Value));
                    }

                    // ExecuteScalar -> executa o comando no banco de dados e retorna a primeira linha da execução.
                    return sqlCommand.ExecuteScalar();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            ...
        */

        // Executar consulta no banco de dados com 'DataTable'
        /*  ...
            public DataTable ExecutarConsulta(CommandType commandType, string nomeStoredProcecdureOuTextoSql)
            {
                // Cria e abre conexão
                SqlConnection conn = CriarConexao();
                conn.Open();

                // Cria e monta o comando com os parâmetros
                SqlCommand command = conn.CreateCommand();
                command.CommandType = commandType;
                command.CommandText = nomeStoredProcecdureOuTextoSql;

                foreach(var parameter in sqlParameterCollection)
                    command.Parameters.Add(new Parameter(parameter.ParameterName, parameter.Value));

                // Executa no banco de dados o comando, mas antes...

                // Criamos um Adaptador(SqlDataAdapter)
                // O adaptador funciona da seguinte forma: 
                // ele recebe um comando onde será enviado ao banco de dados e será executado. 
                // Após a execução do comando o adaptador converge as informações que vieram do banco
                // para uma linguagem que o nosso programa em C# entenda e passa essas informações já 
                // tratadas para um 'DataTable'.
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                
                DataTable = dt = new DataTable();
                
                // É aqui que o adapter vai até o banco de dados, executa os comandos e retorna com as informações
                // tratadas e preenche(Fill()) em um 'DataTable'.
                sqlDataAdapter.Fill(dt);

                return dt;
            }
            ...
        */
    }
}