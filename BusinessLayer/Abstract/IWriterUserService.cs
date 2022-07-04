using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWriterUserService : IGenericService<WriterUser>
    {
        List<UserDto> GetUser();
    }
}
