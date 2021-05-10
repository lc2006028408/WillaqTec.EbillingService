using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillaqTec.Models
{
    public class PersonUser
    {
        public PersonEntity person { get; set; }
        public UserEntity user { get; set; }
    }
}
