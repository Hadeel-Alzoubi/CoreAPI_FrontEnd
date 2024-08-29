﻿using System;
using System.Collections.Generic;

namespace WepAPICore.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Order? Order { get; set; }
}
