using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CategoriaRepository : IRepository<Categoria>
    {
        private readonly PosContext _context;
        public CategoriaRepository(PosContext context)
        {
            _context = context;
        }

        public async Task<Categoria> Create(Categoria entity)
        {
            _context.Categorias.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<Categoria> Delete(int? id)
        {

            var categoria = await _context.Categorias.FindAsync(id) ?? throw new KeyNotFoundException("Categoria no encontrado");
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _context.Categorias
                                 .Include(c => c.Productos)
                                 .ToListAsync();
        }


        public async Task<Categoria> GetById(int id)
        {
            return await _context.Categorias.FindAsync(id) ?? throw new KeyNotFoundException("Categoria no encontrado.");
        }


        public async Task<Categoria> Update(Categoria entity)
        {
            var categoria = await _context.Categorias.FindAsync(entity.CategoriaId);

            if (categoria == null)
            {
                throw new KeyNotFoundException("Categoria no encontrado.");
            }

            _context.Entry(categoria).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return categoria;
        }

    }
}