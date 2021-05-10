using System;
using System.Collections.Generic;
using System.Text;

namespace WillaqTec
{
    public class UserEntity : BaseEntity
    {
        public int UserId { get; set; }
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
