using DIO.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Classes
{
    public class Serie : EntidadeBase
    {
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            ID = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        private Genero Genero {  get; set; }    
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano {  get; set; }
        private bool Excluido { get; set; }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: "+this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descricao: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaID()
        {
            return this.ID;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }

    }
}
