using Blazor.back.Models;
using Blazor.back.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Blazor.back.Services
{
    public class ClienteService
    {
        private readonly MyContext MyDbContext;
        public ClienteService(MyContext _MyDbContext)
        {
            MyDbContext = _MyDbContext;
        }

        public async  Task<List<Cliente>> Listar()
        {
            
            return await MyDbContext.cliente.ToListAsync();
        }

        public async  Task<Cliente> Pesquisar(int id)
        {    
            var cl = await MyDbContext.cliente.FirstOrDefaultAsync<Cliente>(x => x.Id == id);
            return cl;        
            
        }

        public async Task<bool> Salvar(Cliente cliente)
        {
            await MyDbContext.cliente.AddAsync(cliente);
            await MyDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Deletar(int id)
        {
            var cl = MyDbContext.cliente.Find(id);
            MyDbContext.cliente.Remove(cl);
            await MyDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<string> Imprimir(int id)
        {
             string pathDownload = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("HOME"), "Downloads");
            var cl = MyDbContext.cliente.FirstOrDefault<Cliente>(x => x.Id == Convert.ToInt32(id));
            StringBuilder stg = new StringBuilder();
            stg.AppendFormat("Data={0}\n",cl.Data);
            stg.AppendFormat("Nome={0}\n",cl.Nome);
            stg.AppendFormat("Telefone={0}\n",cl.Telefone);
            stg.AppendFormat("Email={0}\n",cl.Email);
            stg.AppendFormat("Cep={0}\n",cl.Cep);
            using (StreamWriter esc = new StreamWriter($"{pathDownload}/{cl.Nome}.txt"))
            {
                esc.WriteLine(stg.ToString(),true,Encoding.UTF8);
                
            }
            return cl.Nome;

        }
        public async Task<bool> Editar(int id,Cliente cl){
            
            var c = await MyDbContext.cliente.FirstOrDefaultAsync<Cliente>(x => x.Id == id);
            c.Nome = cl.Nome;
            c.Telefone = cl.Telefone;
            c.Email = cl.Email;
            c.Cep = cl.Cep;
            MyDbContext.SaveChanges();
            return true;
        }



    }
}