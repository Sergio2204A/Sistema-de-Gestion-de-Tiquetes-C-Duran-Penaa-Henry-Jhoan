using System;

public class TiqueteService
{
    private readonly AppDbContext _context;

    public TiqueteService(AppDbContext context)
    {
        _context = context;
    }

    public void EmitirTiquete()
    {
        Console.Write("Reserva ID: ");
        int id = int.Parse(Console.ReadLine());

        var reserva = _context.Reservas.Find(id);

        if (reserva.Estado != "CONFIRMADA")
        {
            Console.WriteLine("Reserva no confirmada");
            return;
        }

        var tiquete = new Tiquete
        {
            ReservaId = id,
            Codigo = Guid.NewGuid().ToString()
        };

        _context.Tiquetes.Add(tiquete);
        _context.SaveChanges();

        Console.WriteLine("Tiquete emitido");
    }
}
