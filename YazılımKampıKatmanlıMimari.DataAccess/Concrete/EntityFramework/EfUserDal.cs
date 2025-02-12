﻿using System;
using System.Collections.Generic;
using System.Text;
using YazılımKampıKatmanlıMimari.Core.DataAcess.EntityFramework;
using YazılımKampıKatmanlıMimari.Core.Entities.Concrete;
using YazılımKampıKatmanlıMimari.DataAccess.Abstract;
using System.Linq;

namespace YazılımKampıKatmanlıMimari.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

    }
}
