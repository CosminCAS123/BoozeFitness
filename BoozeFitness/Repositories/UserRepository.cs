using Avalonia.Controls.Templates;
using BoozeFitness.Data;
using BoozeFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

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

        public void Add(User entity)
        {
            this.context.Users.Add(entity);
            this.context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            this.context.Remove(GetById(id));
            this.context.SaveChanges();
        }

        public void Delete(User entity)
        {
            this.context.Remove(entity);
            this.context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return this.context.Users.ToList();
        }

        public User GetById(int id)
        {
            return this.context.Users.Find(id)!;
        }

        public User GetByUsername(string username)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Username == username);
            if (user is not null) return user;
            throw new Exception();
        }

        public void DisposeContext() => this.context.Dispose();
     

    }
}
