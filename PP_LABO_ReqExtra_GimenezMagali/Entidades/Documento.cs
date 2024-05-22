using System;
using System.Text;

/*
 La propiedad de NumNormalizado solo debe poder verse desde las clases
 derivadas.
 El estado debe inicializarse como “Inicio”.
 El método ToString() debe usar StringBuilder para mostrar todos los datos del
 documento.
 El método AvanzarEstado() debe pasar al siguiente estado dentro del orden que se
 estableció en el requerimiento. Debe devolver false si el documento ya está
 terminado.
 */

namespace Entidades
{
    public abstract class Documento
    {
        int anio;
        string autor;
        string barcode;
        Paso estado = Paso.Inicio;
        string numNormalizado;
        string titulo;

        public enum Paso { Inicio, Distribuido, EnEscaner, EnRevision, Terminado } //enumerado

        public int Anio { get => anio; }
        public string Autor { get => autor; }
        public string Barcode { get => barcode; }
        public Paso Estado { get => estado; }
        protected string NumNormalizado { get => numNormalizado; }
        public string Titulo { get => titulo; }

        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
        }

        public bool AvanzarEstado()
        {
            if (Estado == Paso.Terminado)
            {
                return false;
            }

            estado++;
            return true;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine($"Título: {this.titulo}");
            retorno.AppendLine($"Autor: {this.autor}");
            retorno.AppendLine($"Año: {this.anio}");
            retorno.AppendLine($"ISBN: {this.numNormalizado}");
            retorno.AppendLine($"Cod de barras: {this.barcode}");
            return retorno.ToString();
        }
    }
}

