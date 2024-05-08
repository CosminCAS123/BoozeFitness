using Avalonia.Controls.Templates;
using BoozeFitness.Data;
using BoozeFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BoozeFitness.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly DatabaseContext context;
        public UserRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public UserRepository()
        {
            this.context = new DatabaseContext();
        }

      

        public async Task AddAsync(User entity)
        {
            await Task.Run(() => this.context.Users.Add(entity));
            this.context.SaveChanges();
            
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            await Task.Run(() => this.context?.Users.Remove(user));
            this.context.SaveChanges();
        }

        public async Task DeleteAsync(User entity)
        {
            await Task.Run(() => this.context.Remove(entity));
            this.context.SaveChanges();
        }

        public  IEnumerable<User> GetAll()
        {
            return this.context.Users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await Task.Run(() =>  this.context.Users.Find(id)!);

        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var user = await Task.Run(() => this.context.Users.FirstOrDefault(x => x.Username == username));
            if (user is not null) return user;
            throw new Exception();
        }

        public void DisposeContext() => this.context.Dispose();
     

    }
}
