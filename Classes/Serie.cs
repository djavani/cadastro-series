using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        //ATRIBUTOS
        
        private Genero Genero {get; set; }

        private string  Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private bool Excluido {get; set;}
        

        // MÉTODOS
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Ano = ano;
            this.Excluido = false;            
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public override string ToString()
        {
            string retorno = "";
            
            /*retorno += String.Concat( "Gênero: " , this.Genero + Environment.NewLine);
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido; */

            retorno += String.Concat( "Gênero: " , this.Genero + Environment.NewLine);
            retorno += String.Concat("Titulo: " , this.Titulo + Environment.NewLine);
            retorno += String.Concat("Descrição: " , this.Descricao + Environment.NewLine);
            retorno += String.Concat("Ano de Início: " , this.Ano + Environment.NewLine);
            retorno += String.Concat("Excluido: " , this.Excluido);
            
            return retorno;
        }
    }
}