using System.Collections.Generic;
using SignTeacher.Model;

namespace SignTeacher.UI.Data
{
    public class UserDataService : IUserDataService
    {
        public IEnumerable<User> GetAll()
        {
            yield return new User { FirstName = "Thomas", LastName = "Huber" };
            yield return new User { FirstName = "Andreas", LastName = "Boehler" };
            yield return new User { FirstName = "Julia", LastName = "Huber" };
            yield return new User { FirstName = "Chrissi", LastName = "Egin" };
        }
    }
}