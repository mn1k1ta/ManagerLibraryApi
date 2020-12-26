using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TasksManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase 
    {
        private readonly IDocumentsService service;
        public DocumentController(IDocumentsService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("CreateDocument")]
        public async Task<IActionResult> CreateDocumentAsync(DocumentModelDTO document)
        {
            var serviceActionResult = await service.CreateDocumentAsync(document);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }
        [HttpPut]
        [Route("UpdateDocument")]
        public async Task<IActionResult> UpdateDocumentAsync(DocumentModelDTO document)
        {
            var serviceActionResult = await service.EditDocumentAsync(document);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }
        [HttpDelete]
        [Route("DeleteDocument")]
        public async Task<IActionResult> DeleteDocumentAsync(int document)
        {
            var serviceActionResult = await service.DeleteDocumentAsync(document);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpGet]
        [Route("GetAllDocuments")]
        public async Task<IActionResult> GetAllDocumentsAsync()
        {
            return Ok(await service.GetAllDocumentsAsync());
        }
        [HttpGet]
        [Route("GetDocumentById")]
        public async Task<IActionResult> GetDocumentByIdAsync(int id)
        {
            return Ok(await service.GetDocumentByIdAsync(id));
        }
        [HttpGet]
        [Route("GetAllDocumentsSortByName")]
        public async Task<IActionResult> GetAllDocumentsSortByNameAsync()
        {
            return Ok(await service.GetAllDocumentsSortByNameAsync());
        }
        [HttpGet]
        [Route("GetAllDocumentsSortByAuthor")]
        public async Task<IActionResult> GetAllDocumentsSortByAuthor()
        {
            return Ok(await service.GetAllDocumentsSortByAuthorAsync());
        }

        [HttpGet]
        [Route("GiveOutADocument")]
        public async Task<IActionResult> GiveOutADocument(int documentId,int userId)
        {
            var serviceActionResult = await service.GiveOutADocument(documentId,userId);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpGet]
        [Route("ReturnDocumetnToTheLibrary")]
        public async Task<IActionResult> ReturnDocumetnToTheLibrary(int documentId)
        {
            var serviceActionResult = await service.ReturnDocumetnToTheLibrary(documentId);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpGet]
        [Route("GetDocumentOnHandleOrInLibrary")]
        public async Task<IActionResult> GetDocumentOnHandleOrInLibrary(bool type)
        {
            return Ok(await service.GetDocumentOnHandleOrInLibrary(type));
        }
        [HttpGet]
        [Route("GetDocumentByName")]
        public async Task<IActionResult> GetDocumentByUser(string name)
        {
            return Ok(await service.GetDocumentByName(name));
        }

        [HttpGet]
        [Route("GetDocumentByUser")]
        public async Task<IActionResult> GetDocumentByUser(int id)
        {
            return Ok(await service.GetDocumentByUser(id));
        }
    }
}
