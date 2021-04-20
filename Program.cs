using System;

namespace Catalogo.Series
{
    class Program
    {
        // Instnciando o repositorio
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            // Variavel
            string opcaoUsuario = Menu(); 
            
            while (opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario){
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                    
                }

                opcaoUsuario = Menu().ToUpper();
                
            }   

            Console.WriteLine("Obrigado por utilizar nosso catálogo de séries.");
            Console.ReadLine();
            Console.WriteLine();
        }

        private static void ListarSerie()
        {
            HeaderMenu("Listar série!");

            // Recebendo Lista
            var Lista = repositorio.Lista();

            // Verificando de lista esta vazia.
            if (Lista.Count == 0)
            {
                Console.WriteLine("Nenhuama série cadastrada.");
                return;
            }

            // Lista séries cadastradas.
            foreach (var serie in Lista)
            {
                Console.WriteLine($"ID {serie.retornaId()} - {serie.retornaTitulo()} {(serie.retornaExcluido() ? " - Excluído" : "")}");
            }

            FooterMenu();
        }

        private static void VisualizarSerie()
        {
            HeaderMenu("Visualizar série!");

            Console.WriteLine("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(idSerie);

            Console.WriteLine(serie);

            FooterMenu();
        }

        private static void AtualizarSerie()
        {
            HeaderMenu("Atualizar série!");
            
            Console.WriteLine("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            // retornando opções da Enum
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
            }

            // Input
            Console.WriteLine();
            Console.WriteLine("Digiteo o genero enre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serieAtualizada = new Serie(id: idSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            // Adicionando a lista de objetos tipo Conta.
            repositorio.Atualiza(idSerie, serieAtualizada);

            FooterMenu();
        }

        private static void ExcluirSerie()
        {
            HeaderMenu("Excluir série!");
   
            Console.WriteLine("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(idSerie);

            FooterMenu();
        }

        private static void InserirSerie()
        {
            HeaderMenu("Inserir nova série");
            
            // retornando opções da Enum
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
            }

            // Input
            Console.WriteLine();
            Console.WriteLine("Digiteo o genero enre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            // Adicionando a lista de objetos tipo Conta.
            repositorio.Insere(novaSerie);

            FooterMenu();
        }

        private static string Menu(){
            HeaderMenu("Bem Vindo ao Catálogo de Séries!");

            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1: Listar séries");
            Console.WriteLine("2: Inserir nova série");
            Console.WriteLine("3: Atualizar série");
            Console.WriteLine("4: Excluir série");
            Console.WriteLine("5: Visualizar série");
            Console.WriteLine("C: Limpar Tela");
            Console.WriteLine("X: Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void HeaderMenu(string mensagem){
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("####################################");
            Console.WriteLine($"  {mensagem.ToUpper()}");
            Console.WriteLine("####################################");
            Console.WriteLine();
        }

        private static void FooterMenu(){
            Console.WriteLine();
            Console.WriteLine("Pressione Enter para continuar... ");
            Console.ReadKey();
        }

    }
}
