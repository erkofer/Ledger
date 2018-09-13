﻿using Ledger.Activations.Domain.Context;
using Ledger.CrossCutting.Data.UnitOfWork;
using Ledger.CrossCutting.ServiceBus.Abstractions;
using Ledger.Shared.IntegrationEvents.Events;
using Ledger.Shared.Notifications;

namespace Ledger.Activations.Application.AppServices
{
    public abstract class BaseApplicationService
    {
        private readonly IDomainNotificationHandler _domainNotificationHandler;
        private readonly IIntegrationServiceBus _integrationBus;
        private readonly IUnitOfWork<ILedgerActivationDbAbstraction> _unitOfWork;

        public BaseApplicationService(IDomainNotificationHandler domainNotificationHandler, IUnitOfWork<ILedgerActivationDbAbstraction> unitOfWork, IIntegrationServiceBus integrationBus)
        {
            _domainNotificationHandler = domainNotificationHandler;
            _unitOfWork = unitOfWork;
            _integrationBus = integrationBus;
        }

        public bool AddNotifications(IDomainNotifier notifier)
        {
            if (notifier.HasNotifications())
            {
                _domainNotificationHandler.AddNotifications(notifier);
                return true;
            }

            return false;
        }

        public void AddNotification(string title, string description)
        {
            _domainNotificationHandler.AddNotification(title, description);
        }

        public bool Commit()
        {
            return _unitOfWork.Commit().Success;
        }

        public void Publish<TIntegrationEvent>(TIntegrationEvent integrationEvent) where TIntegrationEvent : IntegrationEvent
        {
            _integrationBus.Publish(integrationEvent);
        }
    }
}
