using PrimeiraAPI.Models;
using PrimeiraAPI.Models.Entities.Clientes;

namespace PrimeiraAPI.Repositories
{

    public interface IClientesRepository
    {
        public bool Create(PostClientesRequest cliente);
        public Clientes Read(int id);
        public bool Update(PutClientes cliente);
        public bool Delete(int id);
    }

    public class ClientesRepository : IClientesRepository
    {

        private readonly _DbContext db;

        public ClientesRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostClientesRequest cliente)
        {

            try
            {
                var cliente_db = new Clientes()
                {
                    Nome = cliente.Nome,
                    DataNascimento = cliente.DataNascimento
                };
                db.Clientes.Add(cliente_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Clientes Read(int id)
        {
            try
            {
                var cliente_db = db.Clientes.Find(id);
                var idade = DateTime.Today.Year - cliente_db.DataNascimento.Year;
                cliente_db.Idade = idade.ToString();
                return cliente_db;
                
            }
            catch
            {
                return new Clientes();
            }
        }

        public bool Update(PutClientes cliente)
        {

            try
            {
                var cliente_db = db.Clientes.Find(cliente.Id);
                cliente_db.Nome = cliente.Nome;
                cliente_db.DataNascimento = cliente.DataNascimento;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {

            try
            {
                var cliente_db = db.Clientes.Find(id);
                db.Clientes.Remove(cliente_db);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
