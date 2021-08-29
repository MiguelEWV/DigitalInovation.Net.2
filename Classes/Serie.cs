using System;

namespace DigitalInovation.Net._2
{
    public class Serie :EntidadeBase
    {
        //Atributos

        private Genero Genero {get;set;}
        private string Titulo { get; set;}
        private string Descripcion {get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;}
        //Metodos

        public Serie(int id, Genero genero, string titulo, string descripcion, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = Titulo;
            this.Descripcion = descripcion;
            this.Ano = ano;
            this.Excluido = false;
        }

        //public Series()
       // {
        //}

        public override string ToString()
        {// Enviroment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descripcion: " + this.Descripcion + Environment.NewLine;
            retorno += "Ano de inicio: " + this.Ano;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public void Excluir()
        {
        this.Excluido = true;
        }
    }
}