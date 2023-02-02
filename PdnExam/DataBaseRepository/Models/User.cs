using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseRepository.Models
{
    public class User : IdentityUser
    {
        public int FullName { get; set; }
    }
}
