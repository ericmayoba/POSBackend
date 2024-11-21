using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductoRepository : IRepository<Producto>
    {
        private readonly PosContext _context;

        public ProductoRepository(PosContext context)
        {
            _context = context;
        }

        public async Task<Producto> Create(Producto entity)
        {
            _context.Productos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<Producto> Delete(int? id)
        {

            var producto = await _context.Productos.FindAsync(id) ?? throw new KeyNotFoundException("Producto no encontrado");
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return producto;
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _context.Productos
                                 .Include(p => p.Categoria)
                                 .ToListAsync();
        }


        public async Task<Producto> GetById(int id)
        {
            return await _context.Productos.FindAsync(id) ?? throw new KeyNotFoundException("Producto no encontrado.");
        }


        public async Task<Producto> Update(Producto entity)
        {
            var existeProducto = await _context.Productos.FindAsync(entity.ProductoId);

            if (existeProducto == null)
            {
                throw new KeyNotFoundException("Producto no encontrado.");
            }

            _context.Entry(existeProducto).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return existeProducto;
        }

    }
}