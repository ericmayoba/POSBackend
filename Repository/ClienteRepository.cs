using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly PosContext _context;
        public ClienteRepository(PosContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Create(Cliente entity)
        {
            await _context.Clientes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async  Task<Cliente> Delete(int? id)
        {

            var cliente = await _context.Clientes.FindAsync(id) ?? throw new KeyNotFoundException("cliente no encontrado");
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }


        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.FindAsync(id) ?? throw new KeyNotFoundException("Cliente no encontrado.");
        }


        public async Task<Cliente> Update(Cliente entity)
        {
            var existeCliente = await _context.Clientes.FindAsync(entity.ClienteID);

            if (existeCliente == null)
            {
                throw new KeyNotFoundException("Cliente no encontrado.");
            }

            _context.Entry(existeCliente).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return existeCliente;
        }

    }
}