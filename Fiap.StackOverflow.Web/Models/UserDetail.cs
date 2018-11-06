﻿using System;

namespace Fiap.StackOverflow.Web.Models
{
    public class UserDetail
    {
        public int QuestionCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime FirstTimeLogged { get; set; }
        public DateTime LastTimeLogged { get; set; }
    }
}
