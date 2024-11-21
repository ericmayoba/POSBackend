using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class VentaRepository : IRepository<Venta>
    {
        private readonly PosContext _context;

        public VentaRepository(PosContext context)
        {
            _context = context;
        }

        public async Task<Venta> Create(Venta entity)
        {
            _context.Ventas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<Venta> Delete(int? id)
        {

            var venta = await _context.Ventas.FindAsync(id) ?? throw new KeyNotFoundException("Venta no encontrado");
            _context.Ventas.Remove(venta);
            _context.SaveChanges();
            return venta;
        }

        public async Task<List<Venta>> GetAll()
        {
            return await _context.Ventas
                                 .Include(dv => dv.Detalle)
                                 .ToListAsync();
        }


        public async Task<Venta> GetById(int id)
        {
            return await _context.Ventas.FindAsync(id) ?? throw new KeyNotFoundException("Venta no encontrado.");
        }


        public async Task<Venta> Update(Venta entity)
        {
            var existeVenta = await _context.Ventas.FindAsync(entity.VentaId);

            if (existeVenta == null)
            {
                throw new KeyNotFoundException("Venta no encontrado.");
            }

            _context.Entry(existeVenta).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return existeVenta;
        }

    }
}