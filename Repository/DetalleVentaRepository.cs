using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DetalleVentaRepository : IRepository<DetalleVenta>
    {
        private readonly PosContext _context;
        public DetalleVentaRepository(PosContext context)
        {
            _context = context;
        }

        public async Task<DetalleVenta> Create(DetalleVenta entity)
        {
            _context.DetalleVentas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<DetalleVenta> Delete(int? id)
        {

            var detalleVenta = await _context.DetalleVentas.FindAsync(id) ?? throw new KeyNotFoundException("Detalle Venta no encontrado");
            _context.DetalleVentas.Remove(detalleVenta);
            _context.SaveChanges();
            return detalleVenta;
        }

        public async Task<List<DetalleVenta>> GetAll()
        {
            return await _context.DetalleVentas.ToListAsync();
        }


        public async Task<DetalleVenta> GetById(int id)
        {
            return await _context.DetalleVentas.FindAsync(id) ?? throw new KeyNotFoundException("Detalle Venta no encontrado.");
        }


        public async Task<DetalleVenta> Update(DetalleVenta entity)
        {
            var existeVenta = await _context.DetalleVentas.FindAsync(entity.DetalleVentaId);

            if (existeVenta == null)
            {
                throw new KeyNotFoundException("Detalle Venta no encontrado.");
            }

            _context.Entry(existeVenta).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return existeVenta;
        }

    }
}