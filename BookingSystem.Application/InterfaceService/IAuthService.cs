using BookingSystem.Application.DTOS.AuthDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.InterfaceService
{
    public interface IAuthService
    {
        public Task<string> Login(LoginDto loginDto);
    }
}
