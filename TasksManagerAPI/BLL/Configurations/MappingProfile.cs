using AutoMapper;
using BLL.ModelsDTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Configurations
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, UserModelDTO>().ReverseMap();
            CreateMap<DocumentModel, DocumentModelDTO>().ReverseMap();
        }
    }
}
