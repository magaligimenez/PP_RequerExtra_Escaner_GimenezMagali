using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {

        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;

        public enum Departamento { nulo, mapoteca, procesosTecnicos }
        public enum TipoDoc { libro, mapa }

        public List<Documento> ListaDocumentos { get => listaDocumentos; }
        public Departamento Locacion { get => locacion; }
        public string Marca { get => marca; }
        public TipoDoc Tipo { get => tipo; }

        public Escaner(string marca, TipoDoc tipo)
        {
            listaDocumentos = new List<Documento>();
            this.marca = marca;
            this.tipo = tipo;
            locacion = tipo == TipoDoc.mapa ? Departamento.mapoteca : Departamento.procesosTecnicos;
        }

        public bool CambiarEstadoDocumento(Documento d)
        {
            foreach (Documento documentoEnLista in listaDocumentos)
            {
                if (documentoEnLista == d)
                {
                    documentoEnLista.AvanzarEstado();
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(Escaner e, Documento d)
        {
            foreach (Documento doc in e.listaDocumentos)
            {
                if (doc == d)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        /* para eliminar las advertencias */
        public override bool Equals(object? obj)
        {
            if (obj is Escaner escaner)
            {
                return this == escaner;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), listaDocumentos, locacion, marca, tipo);
        }

        public static bool operator +(Escaner e, Documento d)
        {
            if (d.Estado != Documento.Paso.Inicio)
            {
                return false;
            }

            if ((e.Tipo == TipoDoc.libro && d is Mapa) || (e.Tipo == TipoDoc.mapa && d is Libro))
            {
                return false;
            }

            foreach (Documento doc in e.listaDocumentos)
            {
                if ((doc is Libro libroDoc && d is Libro libro) && (libroDoc == libro))
                {
                    throw new DocumentoDuplicadoException("Error!!. El libro ya existe en la lista de documentos."); //agrego excepcion controlada
                }
                else if ((doc is Mapa mapaDoc && d is Mapa mapa) && (mapaDoc == mapa))
                {
                    throw new DocumentoDuplicadoException("Error!!. El mapa ya existe en la lista de documentos."); //agrego excepcion controlada
                }
            }

            d.AvanzarEstado();
            e.ListaDocumentos.Add(d);
            return true;
        }

    }
}
