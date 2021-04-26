using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;

namespace BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {

        private readonly ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var UserId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerID == UserId && f.FolloweeID == followingDto.FolloweeID))
                return BadRequest("Following already exist!!");
            var following = new Following()
            {
                FollowerID = UserId,
                FolloweeID = followingDto.FolloweeID
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}