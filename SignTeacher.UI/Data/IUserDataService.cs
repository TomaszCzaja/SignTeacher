using System.Collections.Generic;
using SignTeacher.Model;

namespace SignTeacher.UI.Data
{
    public interface IUserDataService
    {
        IEnumerable<User> GetAll();
    }
}