using BoozeFitness.Data;
using BoozeFitness.Models;
using BoozeFitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.Services
{
    public class UserService
    {
        #region UserRepository
        private readonly IRepository<User> userRepository;
        #endregion

        #region Constructors
        public UserService()
        {
            this.userRepository = new UserRepository(new DatabaseContext());
        }
        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }
        #endregion

        #region Methods
        public void AddUser(User user) => this.userRepository.Add(user);

        public void DeleteUserById(int ID) => this.userRepository.Delete(ID);

        public void DeleteUser(User user) => this.userRepository.Delete(user);
        
        public User GetUserById(int ID) => this.userRepository.GetById(ID);
        
        public User GetUserByUsername(string username)
        {
            try
            {
                var user = ((UserRepository)this.userRepository).GetByUsername(username);
                return user;

            }
            catch
            {
                throw new Exception();
                        
            }
        }
       
        public void Dispose() => this.userRepository.DisposeContext();
        #endregion



    }
}
