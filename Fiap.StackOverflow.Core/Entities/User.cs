﻿using Fiap.StackOverflow.Core.Entities.Base;

namespace Fiap.StackOverflow.Core.Entities
{
    public class User : EntityBase
    {
        public string Name{ get; set;}
        public string Password{ get;set;}
        public string Email{ get;set; }
    }
}