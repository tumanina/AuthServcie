﻿using System;

namespace AuthService.Common.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
