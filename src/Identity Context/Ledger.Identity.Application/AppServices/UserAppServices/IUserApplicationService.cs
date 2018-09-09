﻿using Ledger.Identity.Domain.Commands;
using Ledger.Identity.Domain.Models.Aggregates.UserAggregate.User;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ledger.Identity.Application.AppServices.UserAppServices
{
    public interface IUserApplicationService
    {
        Task<LedgerIdentityUser> GetById(Guid id);
        Task<LedgerIdentityUser> GetByEmail(string email);
        Task<LedgerIdentityUser> Register(RegisterUserCommand command);
        Task ConfirmEmail(ConfirmUserEmailCommand command);
        Task ForgotPassword(ForgotUserPasswordCommand command);
        Task ResetPassword(ResetUserPasswordCommand command);
        Task ChangePassword(ChangeUserPasswordCommand command);
        Task<ClaimsIdentity> Login(LoginUserCommand command);
    }
}