using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment.Models;
using Assignment.Repositories;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly UserInfoRepository _userInfoRepository;

        public UserInfoController(UserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        // GET: api/UserInfo
        [HttpGet]
        public ActionResult<IEnumerable<UserInfo>> Get()
        {
            return _userInfoRepository.GetUserInfoList();
        }

        // GET: api/UserInfo/5
        [HttpGet("{id}")]
        public ActionResult<UserInfo> Get(int id)
        {
            var userInfo = _userInfoRepository.GetUserInfoById(id);
            if (userInfo == null)
            {
                return NotFound();
            }
            return userInfo;
        }

        // POST: api/UserInfo
        [HttpPost]
        public ActionResult<UserInfo> Post(UserInfo userInfo)
        {
            _userInfoRepository.AddUserInfo(userInfo);
            return CreatedAtAction(nameof(Get), new { id = userInfo.UserId }, userInfo);
        }

        // PUT: api/UserInfo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, UserInfo userInfo)
        {
            if (id != userInfo.UserId)
            {
                return BadRequest();
            }
            try
            {
                _userInfoRepository.UpdateUserInfo(userInfo);
            }
            catch (Exception)
            {
                if (!_userInfoRepository.UserInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/UserInfo/5
        [HttpDelete("{id}")]
        public ActionResult<UserInfo> Delete(int id)
        {
            var userInfo = _userInfoRepository.DeleteUserInfo(id);
            if (userInfo == null)
            {
                return NotFound();
            }
            return userInfo;
        }
    }
}
