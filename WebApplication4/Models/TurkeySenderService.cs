using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class TurkeySenderService : ISmsSender
    {
        public string SendSMS()
        {
            // do SMS operations for Turkey
            return "Turkcell";
        }
    }
}