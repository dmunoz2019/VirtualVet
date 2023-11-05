using DAL; // Asegúrate de que el espacio de nombres es correcto
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia del contexto
        using (var context = new virtualvetEntities())
        {
            // Llamar al método GetAllConsultas
            var consultas = context.spObtenerConsultas();

            // Iterar sobre los resultados y mostrarlos
            foreach (var consulta in consultas)
            {
                Console.WriteLine($"Consulta ID: {consulta.ConsultaId}, Descripción: {consulta.Descripcion}, Costo: {consulta.Costo}");
            }
        }

        // Esperar a que el usuario presione una tecla antes de cerrar
        Console.ReadKey();
    }
}
