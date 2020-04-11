using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;
using WebApplication4.Models.Dependencies;

namespace WebApplication4.Controllers
{

    public class SendsController : ApiController
    {
        private ISmsSender _smsSender;

        [HttpGet]
        public string Get(string country)
        {
            //assign interface that implemented class for country code
            _smsSender = IoCUtil.Resolve<ISmsSender>(country);

            //controller never know anything about country
            return _smsSender.SendSMS();
        }
    }
}
