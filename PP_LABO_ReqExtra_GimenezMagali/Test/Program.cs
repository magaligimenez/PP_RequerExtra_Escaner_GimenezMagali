using Entidades;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            //posible funcionalidad para la excepcion 
            //creo un escáner para libros
            Escaner escanerLibros = new Escaner("aleph", Escaner.TipoDoc.libro);
            Libro libro1 = new Libro("SilviaRus", "profeSilvia", 2023, "005", "00001", 100);
            Libro libro2 = new Libro("SilviaRus", "profeSilvia", 2023, "005", "00001", 100); //libro igual para probar la excepción

            try
            {
                //agregar el primer libro
                if (escanerLibros + libro1)
                {
                    Console.WriteLine("Libro1 agregado exitosamente.");
                }

                //intentar agregar el libro duplicado
                if (escanerLibros + libro2)
                {
                    Console.WriteLine("Libro2 agregado exitosamente.");
                }
            }
            catch (DocumentoDuplicadoException ex) //llamo al nombre de la clase de la excepcion que cree
            {
                Console.WriteLine(ex.Message);
            }

            //intento cambiar el estado del libro
            if (escanerLibros.CambiarEstadoDocumento(libro1))
            {
                Console.WriteLine("El estado del libro se cambio.");
            }
            else
            {
                Console.WriteLine("No se encontro el libro en la lista para cambiar el estado.");
            }

            //crear un escáner para mapas
            Escaner escanerMapas = new Escaner("Rivadavia", Escaner.TipoDoc.mapa);
            Mapa mapa1 = new Mapa("hola", "Magali", 2023, "", "0002", 100, 200);
            Mapa mapa2 = new Mapa("hola", "Magali", 2023, "", "0002", 100, 200); //mapa igual para probar la excepción

            try
            {
                //agregar el primer mapa
                if (escanerMapas + mapa1)
                {
                    Console.WriteLine("mapa1 agregado exitosamente.");
                }

                //intentar agregar el mapa duplicado
                if (escanerMapas + mapa2)
                {
                    Console.WriteLine("mapa2 agregado exitosamente.");
                }
            }
            catch (DocumentoDuplicadoException ex) //llamo de nuevo a mi excepcion
            {
                Console.WriteLine(ex.Message);
            }

            //intentar cambiar el estado del mapa
            if (escanerMapas.CambiarEstadoDocumento(mapa2)) //intento cambiar el mapa2.
            {
                Console.WriteLine("El estado del mapa se cambio.");
            }
            else
            {
                Console.WriteLine("No se encontro el mapa en la lista para cambiar el estado.");
            }
        }
    }
}