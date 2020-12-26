using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDTO
{
    public class DocumentModelDTO
    {
        public int DocumetnId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public UserModelDTO UserModel { get; set; }
        public DocumentStatusDTO DocumentStatus { get; set; }
    }
}
