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
        private readonly UserRepository userRepository;
        #endregion

        #region Constructors
        public UserService()
        {
            this.userRepository = new UserRepository(new DatabaseContext());
        }
        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Workout>> GetWorkoutsAsync(int id)
        {
            var user = await this.userRepository.GetByIdAsync(id);
            return user.Workouts;
        }
        public async Task AddUserAsync(User user) => await this.userRepository.AddAsync(user);

        public async Task DeleteUserByIdAsync(int ID) => await this.userRepository.DeleteAsync(ID);

        public async Task DeleteUserByIdAsync(User user) => await this.userRepository.DeleteAsync(user);
        
        public async Task<User> GetUserByIdAsync(int ID) => await this.userRepository.GetByIdAsync(ID);
        
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            try
            {
                var user = await this.userRepository.GetByUsernameAsync(username);
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
