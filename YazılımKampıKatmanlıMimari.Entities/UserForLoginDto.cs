﻿using System;
using System.Collections.Generic;
using System.Text;
using YazılımKampıKatmanlıMimari.Core.Entities;

namespace YazılımKampıKatmanlıMimari.Entities
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
