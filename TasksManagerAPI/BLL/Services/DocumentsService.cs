using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelsDTO;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IUnitOfWork _dataBase;
        private readonly IMapper _mapper;
        public DocumentsService(IUnitOfWork _dataBase, IMapper _mapper)
        {
            this._dataBase = _dataBase;
            this._mapper = _mapper;
        }

        public async Task<OperationDetails> CreateDocumentAsync(DocumentModelDTO document)
        {
            if (document == null)
            {
                return new OperationDetails("Document is null!", false);
            }

            _dataBase.TaskModelRepository.Create(_mapper.Map<DocumentModel>(document));
            await _dataBase.SaveAsync();
            return new OperationDetails("Document id created", true);
        }
        public async Task<OperationDetails> DeleteDocumentAsync(int documentDTO)
        {
            
            var document = await _dataBase.TaskModelRepository.GetByIdAsync(documentDTO);
            if (document == null)
            {
                return new OperationDetails("This Document is not found!", false);
            }
            _dataBase.TaskModelRepository.Delete(document);
            await _dataBase.SaveAsync();
            return new OperationDetails("Document id deleted!", true);
        }
        public async Task<OperationDetails> EditDocumentAsync(DocumentModelDTO documentDTO)
        {
            if (documentDTO == null)
            {
                return new OperationDetails("Document is null!", false);
            }
            var document = await _dataBase.TaskModelRepository.GetByIdAsync(documentDTO.DocumetnId);
            if (document == null)
            {
                return new OperationDetails("This Document is not found!", false);
            }
            _dataBase.TaskModelRepository.Update(_mapper.Map(documentDTO, document));
            await _dataBase.SaveAsync();
            return new OperationDetails("Document id updated!", true);
        }
        public async Task<ICollection<DocumentModelDTO>> GetAllDocumentsAsync()
        {
            return _mapper.Map<ICollection<DocumentModelDTO>>(await _dataBase.TaskModelRepository.GetAllAsync());
        }
        public async Task<DocumentModelDTO> GetDocumentByIdAsync(int id)
        {
            return _mapper.Map<DocumentModelDTO>(await _dataBase.TaskModelRepository.GetByIdAsync(id));
        }
        public async Task<ICollection<DocumentModelDTO>> GetAllDocumentsSortByNameAsync()
        {
            return _mapper.Map<ICollection<DocumentModelDTO>>(await _dataBase.TaskModelRepository.GetAllAsync()).OrderBy(x => x.Name).ToList();
        }
        public async Task<ICollection<DocumentModelDTO>> GetAllDocumentsSortByAuthorAsync()
        {
            return _mapper.Map<ICollection<DocumentModelDTO>>(await _dataBase.TaskModelRepository.GetAllAsync()).OrderBy(x => x.Author).ToList();
        }      
        public async Task<OperationDetails> GiveOutADocument(int documentId,int userId) 
        {
            var document = await _dataBase.TaskModelRepository.GetByIdAsync(documentId);
            if (document == null)
            {
                return new OperationDetails("This document is not found", false);
            }
            var user = await _dataBase.UserModelRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return new OperationDetails("This user is not found", false);
            }
            if (document.DocumentStatus == DocumentStatus.OnHandle)
            {
                return new OperationDetails("This document already on handle", false);
            }
           
                var documents = await _dataBase.TaskModelRepository.GetWhereAsync(x => x.UserModel == user);
                if ( documents.Count>=5)
                {
                    return new OperationDetails("This user can no longer borrow books!", false);
                }
                //return new OperationDetails("This user can no longer borrow books!", false);
            
           
            document.DocumentStatus = DocumentStatus.OnHandle;
            document.UserModel = user;
            _dataBase.TaskModelRepository.Update(document);
            await _dataBase.SaveAsync();
            return new OperationDetails("Successfully!", true);
        }
        public async Task<OperationDetails> ReturnDocumetnToTheLibrary(int documentId)
        {
            var document = await _dataBase.TaskModelRepository.GetByIdAsync(documentId);
            if (document == null)
            {
                return new OperationDetails("This document is not found!",false);
            }
            if (document.DocumentStatus == DocumentStatus.InLibrary)
            {
                return new OperationDetails("This document already in library", false);
            }
            document.UserModelId = null;
            document.DocumentStatus = DocumentStatus.InLibrary;
            _dataBase.TaskModelRepository.Update(document);
            await _dataBase.SaveAsync();
            return new OperationDetails("Successfully", true);
        }
        public async Task<ICollection<DocumentModelDTO>> GetDocumentOnHandleOrInLibrary(bool type)
        {
            if (type)
            {
                return _mapper.Map<ICollection<DocumentModelDTO>>(await _dataBase.TaskModelRepository.GetWhereAsync(x => x.DocumentStatus == DocumentStatus.InLibrary));
            }
            else
            {
                return _mapper.Map<ICollection<DocumentModelDTO>>(await _dataBase.TaskModelRepository.GetWhereAsync(x => x.DocumentStatus == DocumentStatus.OnHandle));
            }
        }
        public async Task<ICollection<DocumentModelDTO>> GetDocumentByUser(int userId)
        {
            var user = await _dataBase.UserModelRepository.GetByIdAsync(userId);
            return _mapper.Map<ICollection<DocumentModelDTO>>(await _dataBase.TaskModelRepository.GetWhereAsync(x=>x.UserModel==user));
        }
        public async Task<ICollection<DocumentModelDTO>> GetDocumentByName(string name)
        {
            return _mapper.Map<ICollection<DocumentModelDTO>>(await _dataBase.TaskModelRepository.GetWhereAsync(x => x.Name.Contains(name)));
        }


    }
}
