using System;

public class ReservaService
{
    private readonly AppDbContext _context;

    public ReservaService(AppDbContext context)
    {
        _context = context;
    }

    public void CrearReserva()
    {
        Console.Write("Cliente ID: ");
        int clienteId = int.Parse(Console.ReadLine());

        Console.Write("Vuelo ID: ");
        int vueloId = int.Parse(Console.ReadLine());

        Console.Write("Cantidad de asientos: ");
        int cantidad = int.Parse(Console.ReadLine());

        var vuelo = _context.Vuelos.Find(vueloId);

        if (vuelo == null)
        {
            Console.WriteLine("Vuelo no existe");
            return;
        }

        if (vuelo.AsientosDisponibles < cantidad)
        {
            Console.WriteLine("No hay suficientes asientos");
            return;
        }

        var reserva = new Reserva
        {
            ClienteId = clienteId,
            VueloId = vueloId,
            CantidadAsientos = cantidad,
            Estado = "PENDIENTE"
        };

        _context.Reservas.Add(reserva);
        _context.SaveChanges();

        Console.WriteLine("Reserva creada correctamente");
    }

    public void ConfirmarReserva()
    {
        Console.Write("Reserva ID: ");
        int id = int.Parse(Console.ReadLine());

        var reserva = _context.Reservas.Find(id);
        var vuelo = _context.Vuelos.Find(reserva.VueloId);

        if (vuelo.AsientosDisponibles < reserva.CantidadAsientos)
        {
            Console.WriteLine("No hay disponibilidad");
            return;
        }

        vuelo.AsientosDisponibles -= reserva.CantidadAsientos;
        reserva.Estado = "CONFIRMADA";

        _context.SaveChanges();

        Console.WriteLine("Reserva confirmada");
    }
}
