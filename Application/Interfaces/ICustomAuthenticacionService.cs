﻿using Application.Models.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICustomAuthenticacionService
    {
        User? ValidateUser(AuthenticacionRequest authenticationRequest);
        string Autenticar(AuthenticacionRequest authenticationRequest);
    }
}
