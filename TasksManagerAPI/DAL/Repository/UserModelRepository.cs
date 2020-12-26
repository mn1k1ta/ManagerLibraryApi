using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
   public class UserModelRepository:BaseRepository<UserModel>,IUserModelRepository
    {
        public UserModelRepository(DbContext context):base(context)
        {

        }
    }
}
