using System;
using System.Threading.Tasks;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Domain.Models;
using Actio.Services.Identity.Domain.Repositories;
using Actio.Services.Identity.Domain.Services;
namespace Actio.Services.Identity.Services
{
    public class UserService : IUserService
    {
         private readonly IUserRepository _repository;
         private readonly IEncrypter _encryptor;

         public UserService(IUserRepository repository,
            IEncrypter encryptor)
         {
            _repository = repository;
            _encryptor = encryptor;
         }
        
         public async Task RegisterAsync(string email, string password, string name)
         {
             var user1 = _repository.GetAsync(email);
             if(user1 == null)
             {
                 throw new ActioException("email_in_use",
                    $"Email: '{email} already in use. ");
             }
             User user = new User(email,name);
             user.SetPassword(password, _encryptor);
             await _repository.AddAsync(user);
         }    
    
        
         public async Task LoginAsync(string email, string password)
         {
             var user = await _repository.GetAsync(email);
             if(user == null)
             {
                 throw new ActioException("invalid_credentials",
                 $"Invalid credentials.");
             }
            if(!user.ValidatePassword(password, _encryptor))
            {
                throw new ActioException("invalid_credentials",
                 $"Invalid credentials.");
            }

         }; 
    }
}