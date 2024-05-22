using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        int numPaginas;

        public int NumPaginas { get => numPaginas; }
        public string ISBN { get { return NumNormalizado; } }

        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas) 
            : base (titulo, autor, anio, numNormalizado, barcode)
        {
            this.numPaginas = numPaginas;
        }

        public static bool operator ==(Libro l1, Libro l2)
        {

            return l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN || 
                (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor);
        }

        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

        /* para eliminar las advertencias: */ 
        public override bool Equals(object? obj)
        {
            if (obj is Libro)
            {
                return this == (Libro)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Barcode, ISBN, Titulo, Autor);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString()); //agrega los datos de la clase base

            sb.Append($"Número de páginas: {numPaginas}.");

            return sb.ToString();
        }
    }
}
