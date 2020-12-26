using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelsDTO
{
    public class UserModelDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        public ICollection<DocumentModelDTO> DocumentModels { get; set; }
    }
}
