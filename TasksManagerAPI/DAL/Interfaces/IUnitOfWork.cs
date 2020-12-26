using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserModelRepository UserModelRepository { get; }
        IDocumentModelRepository TaskModelRepository { get; }
        Task SaveAsync();
    }
}
