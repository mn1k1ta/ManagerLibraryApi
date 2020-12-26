using BLL.Helpers;
using BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDocumentsService
    {
        Task<OperationDetails> CreateDocumentAsync(DocumentModelDTO document);
        Task<OperationDetails> DeleteDocumentAsync(int documentDTO);
        Task<OperationDetails> EditDocumentAsync(DocumentModelDTO documentDTO);
        Task<ICollection<DocumentModelDTO>> GetAllDocumentsAsync();
        Task<DocumentModelDTO> GetDocumentByIdAsync(int id);
        Task<ICollection<DocumentModelDTO>> GetAllDocumentsSortByNameAsync();
        Task<ICollection<DocumentModelDTO>> GetAllDocumentsSortByAuthorAsync();
        Task<OperationDetails> GiveOutADocument(int documentId, int userId);
        Task<OperationDetails> ReturnDocumetnToTheLibrary(int documentId);
        Task<ICollection<DocumentModelDTO>> GetDocumentOnHandleOrInLibrary(bool type);
        Task<ICollection<DocumentModelDTO>> GetDocumentByUser(int userId);
        Task<ICollection<DocumentModelDTO>> GetDocumentByName(string name);
    }
}
