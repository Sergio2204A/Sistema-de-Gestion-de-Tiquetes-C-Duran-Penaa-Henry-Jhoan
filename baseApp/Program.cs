using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var context = new AppDbContext();
        context.Database.EnsureCreated();

        var reservaService = new ReservaService(context);
        var tiqueteService = new TiqueteService(context);

        while (true)
        {
            Console.WriteLine("\n--- SISTEMA DE TIQUETES ---");
            Console.WriteLine("1. Crear reserva");
            Console.WriteLine("2. Confirmar reserva");
            Console.WriteLine("3. Emitir tiquete");
            Console.WriteLine("4. Ver vuelos");
            Console.WriteLine("0. Salir");

            var op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    reservaService.CrearReserva();
                    break;

                case "2":
                    reservaService.ConfirmarReserva();
                    break;

                case "3":
                    tiqueteService.EmitirTiquete();
                    break;

                case "4":
                    var vuelos = context.Vuelos.ToList();
                    foreach (var v in vuelos)
                    {
                        Console.WriteLine($"ID: {v.Id} | {v.Codigo} | Asientos: {v.AsientosDisponibles}");
                    }
                    break;

                case "0":
                    return;
            }
        }
    }
}
