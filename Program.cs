using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizaSerie();
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

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }      

#region OBTER OPCAO DO USUARIO
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opçao desejada.");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Meter o pé");
            Console.WriteLine();

            string opcaoUsuario =  Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
#endregion  

#region LISTAR SERIE
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach(var serie in lista)
            {
                string excluido = serie.retornaExcluido() ? "SIM" : "NÃO";
                Console.WriteLine("#ID {0}: - {1} - Excluido: {2}", serie.retornaId(), serie.retornaTitulo(), excluido);
            }
        }
        
#endregion

#region INSERE SERIE   
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            int entradaGenero, entradaAno;
            string entradaTitulo, entradaDescricao;
            
            PopulaSerie(out entradaGenero, out entradaTitulo, out entradaAno, out entradaDescricao);

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

       
#endregion

#region ATUALIZA SERIE       
        private static void AtualizaSerie()
        {
            Console.WriteLine("Digite o Id série");            
            int indiceSerie = int.Parse(Console.ReadLine());

            int entradaGenero, entradaAno;
            string entradaTitulo, entradaDescricao;

            PopulaSerie(out entradaGenero, out entradaTitulo, out entradaAno, out entradaDescricao);

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
#endregion        
 
 #region EXCLUIR SERIE
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        
#endregion        

#region  VISUALIZA SERIE
    private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.retornaorId(indiceSerie);

            Console.WriteLine(serie);
        }
#endregion
        
#region POPULASERIE
        private static void PopulaSerie(out int entradaGenero, out string entradaTitulo, out int entradaAno, out string entradaDescricao)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o título da série: ");
            entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o ano da série: ");
            entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da série: ");
            entradaDescricao = Console.ReadLine();
        }

#endregion

      
    }
}
