﻿using Microsoft.AspNetCore.Identity;

namespace TimeTracker.Models
{
    public class User : IdentityUser
    {
        public DateTime Created { get; set; }
    }
}
