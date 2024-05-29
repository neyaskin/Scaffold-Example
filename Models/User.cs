﻿using System;
using System.Collections.Generic;

namespace ScaffoldTestConsoleApp.Models;

public partial class User
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? IdRole { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }
}
