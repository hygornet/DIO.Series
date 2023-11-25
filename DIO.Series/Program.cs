using DIO.Series.Classes;
using DIO.Series;
using DIO.Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series
{
    internal class Program
    {

        private static SerieRepositorio serieRepositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = ObterOpcaoUsuario();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {

                    case "1":
                        ClearProgram();
                        ListarSeries();
                        break;

                    case "2":
                        ClearProgram();
                        InserirSerie();
                        break;

                    case "3":
                        ClearProgram();
                        AtualizarSerie();
                        break;

                        case "4":
                        ClearProgram();
                        ExcluirSerie();
                            break;

                    case "c":
                        ClearProgram();
                        break;

                    case "x":
                        Console.ReadKey();
                        break;
                }
                
                opcao = ObterOpcaoUsuario();
                ClearProgram();

            }
            

        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Qual o ID da serie que quer excluir?");
            int IDSerie = int.Parse(Console.ReadLine());

            serieRepositorio.Exclui(IDSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Qual o ID da serie que quer atualizar?");
            int IDSerie = int.Parse(Console.ReadLine());

            Console.Write("Digite o genero da serie: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titutlo da serie: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descricao da serie: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o ano da serie: ");
            int ano = int.Parse(Console.ReadLine());

            Serie serie = new Serie(
                id: IDSerie,
                genero: (Genero)genero,
                titulo: titulo,
                descricao: descricao,
                ano:ano
                );

            serieRepositorio.Atualiza(IDSerie, serie);
        }

        public static void ClearProgram()
        {
            Console.Clear();
        }
        public static void ListarGeneros()
        { 
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine(i+" - "+Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("");
        }

        public static void ListarSeries()
        {
            var lista = serieRepositorio.Lista();

            if(lista.Count ==  0)
            {
                Console.WriteLine("Nenhuma serie cadastrada!\n");
                return;
            }
            
            foreach (var item in lista)
            {
                Console.WriteLine("\n#ID {0}: - {1}", item.retornaID(), item.retornaTitulo()+"\n"+item);
            }
            

        }

        public static void InserirSerie()
        {
            ListarGeneros();

            bool cadastrado = false;

            Console.Write("Digite o genero da serie: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titutlo da serie: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descricao da serie: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o ano da serie: ");
            int ano = int.Parse(Console.ReadLine());

            Serie serie = new Serie(
            id: serieRepositorio.ProximoId(),
            titulo: titulo,
            genero: (Genero)genero,
            descricao: descricao,
            ano: ano
            );

            serieRepositorio.Insere( serie );
            cadastrado = true;

            if (cadastrado)
            {
                Console.WriteLine("Serie cadastrada com sucesso!\n");
            }
            else
            {
                Console.WriteLine("Houve algum erro ao cadastrar a serie!\n");
            }


        }

        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine("DIO Series!\n");
            Console.WriteLine("Informe a opção desejada: \n");

            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Cadastrar nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;


        }
    }
}
