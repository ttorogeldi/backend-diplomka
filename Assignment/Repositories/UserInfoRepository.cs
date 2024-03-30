using Assignment.Models;
using Assignment.DataBaseAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Repositories
{
    public class UserInfoRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserInfoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserInfo> GetUserInfoList()
        {
            return _dbContext.UserInfos.ToList();
        }

        public UserInfo GetUserInfoById(int id)
        {
            return _dbContext.UserInfos.FirstOrDefault(u => u.UserId == id);
        }

        public void AddUserInfo(UserInfo userInfo)
        {
            userInfo.CreatedDate = DateTime.UtcNow;
            _dbContext.UserInfos.Add(userInfo);
            _dbContext.SaveChanges();
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            _dbContext.Entry(userInfo).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public UserInfo DeleteUserInfo(int id)
        {
            var userInfo = _dbContext.UserInfos.Find(id);
            if (userInfo != null)
            {
                _dbContext.UserInfos.Remove(userInfo);
                _dbContext.SaveChanges();
            }
            return userInfo;
        }

        public bool UserInfoExists(int id)
        {
            return _dbContext.UserInfos.Any(u => u.UserId == id);
        }
    }
}
