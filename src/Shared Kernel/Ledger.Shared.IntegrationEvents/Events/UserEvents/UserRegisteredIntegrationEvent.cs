﻿using System;

namespace Ledger.Shared.IntegrationEvents.Events.UserEvents
{
    public class UserRegisteredIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; }
        public string Email { get; }

        public UserRegisteredIntegrationEvent(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
