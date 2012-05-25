﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore.Services.Interfaces;
using VideoStore.Business.Components.Interfaces;
using Microsoft.Practices.ServiceLocation;
using VideoStore.Business.Entities;
using Bank.Business.Entities;

namespace VideoStore.Services
{
    public class OrderService : IOrderService
    {

        private IOrderProvider OrderProvider
        {
            get
            {
                return ServiceFactory.GetService<IOrderProvider>();
            }
        }

        public void SubmitOrder(Business.Entities.Order pOrder)
        {
            OrderProvider.SubmitOrder(pOrder);
        }

        public void UpdateOrder(Business.Entities.Order pOrder)
        {
            OrderProvider.UpdateOrder(pOrder);
        }

        public Order GetOrderByExternalId(String pId) 
        {
            return OrderProvider.GetOrderByExternalId(pId);
        }
    }
}
