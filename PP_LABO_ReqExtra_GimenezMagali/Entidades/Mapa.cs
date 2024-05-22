using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {

        int ancho;
        int alto;

        public int Alto { get => alto; }
        public int Ancho { get => ancho; }
        public int Superficie { get => alto * ancho; }

        public Mapa(string titulo, string autor, int anio, string numNormalizado, string barCode, int ancho, int alto)
                    :base(titulo, autor, anio, numNormalizado, barCode)
        {
            this.alto = alto;
            this.ancho = ancho;
        }

        public static bool operator ==(Mapa m1, Mapa m2)
        {

            return m1.Barcode == m2.Barcode ||
                (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie);
        }

        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2);
        }

        /*eliminar advertencias*/
        public override bool Equals(object? obj)
        {
            if (obj is Mapa mapa)
            {
                return this.Barcode == mapa.Barcode ||
                    (this.Titulo == mapa.Titulo && this.Autor == mapa.Autor && this.Anio == mapa.Anio && this.Superficie == mapa.Superficie);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Barcode, Titulo, Autor, Anio, Superficie);
        }

        public override string ToString() //override pq mira la base de tostring que es un metodo.
                                          //Uso polimorfismo con ese metodo que viene x default
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine($"Título: {this.Titulo}");
            retorno.AppendLine($"Autor: {this.Autor}");
            retorno.AppendLine($"Año: {this.Anio}");
            retorno.AppendLine($"Cod de barras: {this.Barcode}");
            retorno.AppendLine($"Superficie: {this.alto} * {this.ancho}: {Superficie} cm2");
            return retorno.ToString();
        }

    }
}
