using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class DocumentModelRepository : BaseRepository<DocumentModel>,IDocumentModelRepository
    {
        public DocumentModelRepository(DbContext context):base(context)
        {

        }
    }
}
