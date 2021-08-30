using System;

namespace DigitalInovation.Net._2
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
                       ActualizarSerie();
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
                    case "":
                    Console.WriteLine();
                    Console.WriteLine("===================================");
                    Console.WriteLine("= Por favor seleccione una opcion =");
                    Console.WriteLine("===================================");
                    Console.WriteLine();
                    break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
             Console.WriteLine("===========================================");
             Console.WriteLine("| Saliendo del catalogo, nos vemos pronto |");
             Console.WriteLine("===========================================");
             Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Escriba el id de la serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Escriba el ID de la serie a ser excluida: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }

        private static void ActualizarSerie()
        {
           Console.Write(" Escriba el identificador ID de la serie: ");
           int indiceSerie = int.Parse(Console.ReadLine());

           foreach (int i in Enum.GetValues(typeof(Genero)))
           {
               Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
           }
           {
               Console.WriteLine("Escriba el genero de acuerdo a las opciones superiores: ");
               int entradaGenero = int.Parse(Console.ReadLine());
           
               Console.WriteLine("Escriba el Titulo de la serie: ");
               string entradaTitulo = Console.ReadLine();

               Console.WriteLine("Escriba el ano de inicio de la serie: ");
               int entradaAno = int.Parse(Console.ReadLine());

               Console.WriteLine("Escriba la descripcion de la serie: ");
               string entradaDescripcion = Console.ReadLine();

               Serie atualizaSerie = new Serie(id: indiceSerie,genero: (Genero)entradaGenero,titulo: entradaTitulo,
               ano: entradaAno,descripcion: entradaDescripcion);

               repositorio.Atualiza(indiceSerie,atualizaSerie);
           }
        }

        private static void InserirSerie()
        {
           Console.WriteLine("=============================================");
           Console.WriteLine("|  Registrar una nova serie en el catalogo  |");
           Console.WriteLine("=============================================");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Escriba el genero de los opciones superiores: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Escriba el titulo de la serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Escriba el Ano de inicio de la serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Escriba la descripcion de la serie: ");
            string entradaDescripcion = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descripcion: entradaDescripcion);
            repositorio.Insere(novaSerie);

        }

        private static void ListarSeries()
        {
           Console.WriteLine(" Listado de Series: ");
           var lista = repositorio.Lista();
           if (lista.Count == 0)
           {
               Console.WriteLine(" Ninguna serie registrada en el catalogo ");
               return;
           }
           foreach (var serie in lista)
           {
               var excluido = serie.retornaExcluido();
               Console.WriteLine("#ID {0}: - Titulo: {1}- Ano: {2}- Excluido: {3}", serie.retornaId(), serie.retornaTitulo(), serie.retornaAno(), (excluido ? "*Si*" : "No"));
           }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("->-");
            Console.WriteLine("======================================================");
            Console.WriteLine("||              Catalogo de series DIO              ||");
            Console.WriteLine("||            Informa la opcion deseada:            ||");
            Console.WriteLine("======================================================");
            Console.WriteLine("======================================================");
            Console.WriteLine("||               1- Listar las Series               ||");
            Console.WriteLine("||            2- Ingresar una nueva serie           ||");
            Console.WriteLine("||               3- Actualizar serie                ||");
            Console.WriteLine("||              4- Eliminar una serie               ||");
            Console.WriteLine("||             5- Visualizar las series             ||");
            Console.WriteLine("||               c- Limpiar Pantalla                ||");
            Console.WriteLine("||                    x- Salir                      ||");
            Console.WriteLine("======================================================");
            Console.WriteLine("->-");
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
