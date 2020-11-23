using DomainLogic.Interfaces;

using System;

namespace DomainLogic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            if (userRepository == null)
                throw new ArgumentNullException("userRepository");
            _userRepository = userRepository;

        }

        public void UpdateMailAddress(Guid userId, string newMailAddress)
        {
            // update

            var user = _userRepository.GetById(userId);
            _userRepository.Update(user);
        }
    }
}