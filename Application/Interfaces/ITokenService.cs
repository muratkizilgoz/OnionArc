using System;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(ApplicationUser appUser);
    }
}

