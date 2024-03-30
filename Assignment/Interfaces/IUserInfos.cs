using Assignment.Models;
using System.Collections.Generic;

namespace Assignment.Interfaces
{
    public interface IUserInfos
    {
        List<UserInfo> GetUserInfos();
        UserInfo GetUserInfo(int id);
        void AddUserInfo(UserInfo userInfo);
        void UpdateUserInfo(UserInfo userInfo);
        UserInfo DeleteUserInfo(int id);
        bool UserInfoExists(int id);
    }
}
