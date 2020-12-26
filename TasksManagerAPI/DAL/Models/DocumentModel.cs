using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class DocumentModel
    {
        [Key]
        public int DocumetnId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int? UserModelId { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public UserModel UserModel { get; set; }
    }
}
