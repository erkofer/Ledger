﻿using Ledger.Shared.Commands;
using System;

namespace Ledger.Activations.Domain.Commands
{
    public class RegisterActivationCommand : Command
    {
        public Guid CompanyId { get; set; }

        public override void Validate()
        {
        }
    }
}
