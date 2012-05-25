//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace VideoStore.Business.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(OrderItem))]
    [KnownType(typeof(User))]
    public partial class Order: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'Id' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private int _id;
    
        [DataMember]
        public System.DateTime OrderDate
        {
            get { return _orderDate; }
            set
            {
                if (_orderDate != value)
                {
                    _orderDate = value;
                    OnPropertyChanged("OrderDate");
                }
            }
        }
        private System.DateTime _orderDate;
    
        [DataMember]
        public string Warehouse
        {
            get { return _warehouse; }
            set
            {
                if (_warehouse != value)
                {
                    _warehouse = value;
                    OnPropertyChanged("Warehouse");
                }
            }
        }
        private string _warehouse;
    
        [DataMember]
        public string Store
        {
            get { return _store; }
            set
            {
                if (_store != value)
                {
                    _store = value;
                    OnPropertyChanged("Store");
                }
            }
        }
        private string _store;
    
        [DataMember]
        public int Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        private int _status;
    
        [DataMember]
        public string ExternalId
        {
            get { return _externalId; }
            set
            {
                if (_externalId != value)
                {
                    _externalId = value;
                    OnPropertyChanged("ExternalId");
                }
            }
        }
        private string _externalId;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<OrderItem> OrderItems
        {
            get
            {
                if (_orderItems == null)
                {
                    _orderItems = new TrackableCollection<OrderItem>();
                    _orderItems.CollectionChanged += FixupOrderItems;
                }
                return _orderItems;
            }
            set
            {
                if (!ReferenceEquals(_orderItems, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_orderItems != null)
                    {
                        _orderItems.CollectionChanged -= FixupOrderItems;
                    }
                    _orderItems = value;
                    if (_orderItems != null)
                    {
                        _orderItems.CollectionChanged += FixupOrderItems;
                    }
                    OnNavigationPropertyChanged("OrderItems");
                }
            }
        }
        private TrackableCollection<OrderItem> _orderItems;
    
        [DataMember]
        public User Customer
        {
            get { return _customer; }
            set
            {
                if (!ReferenceEquals(_customer, value))
                {
                    var previousValue = _customer;
                    _customer = value;
                    FixupCustomer(previousValue);
                    OnNavigationPropertyChanged("Customer");
                }
            }
        }
        private User _customer;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            OrderItems.Clear();
            Customer = null;
            FixupCustomerKeys();
            FixupVideoStoreEntityModel_DeliveryOrder_DeliveryKeys(null, true);
        }

        #endregion
        #region Association Fixup
    
        private void FixupCustomer(User previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Orders.Contains(this))
            {
                previousValue.Orders.Remove(this);
            }
    
            if (Customer != null)
            {
                if (!Customer.Orders.Contains(this))
                {
                    Customer.Orders.Add(this);
                }
    
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Customer")
                    && (ChangeTracker.OriginalValues["Customer"] == Customer))
                {
                    ChangeTracker.OriginalValues.Remove("Customer");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Customer", previousValue);
                }
                if (Customer != null && !Customer.ChangeTracker.ChangeTrackingEnabled)
                {
                    Customer.StartTracking();
                }
                FixupCustomerKeys();
            }
        }
    
        private void FixupCustomerKeys()
        {
            const string IdKeyName = "Customer.Id";
    
            if(ChangeTracker.ExtendedProperties.ContainsKey(IdKeyName))
            {
                if(Customer == null ||
                   !Equals(ChangeTracker.ExtendedProperties[IdKeyName], Customer.Id))
                {
                    ChangeTracker.RecordOriginalValue(IdKeyName, ChangeTracker.ExtendedProperties[IdKeyName]);
                }
                ChangeTracker.ExtendedProperties.Remove(IdKeyName);
            }
        }
    
        private void FixupOrderItems(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (OrderItem item in e.NewItems)
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("OrderItems", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (OrderItem item in e.OldItems)
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("OrderItems", item);
                    }
                }
            }
        }
    
        internal void FixupVideoStoreEntityModel_DeliveryOrder_DeliveryKeys(Delivery value, bool forceRemove)
        {
            const string IdKeyName = "Navigate(VideoStoreEntityModel.DeliveryOrder.Delivery).Id";
    
            if (ChangeTracker.ChangeTrackingEnabled &&
                ChangeTracker.ExtendedProperties.ContainsKey(IdKeyName))
            {
                if (forceRemove ||
                    !Equals(ChangeTracker.ExtendedProperties[IdKeyName], value == null ? null : (object)value.Id))
                {
                    ChangeTracker.RecordOriginalValue(IdKeyName, ChangeTracker.ExtendedProperties[IdKeyName]);
                    if (value == null)
                    {
                        ChangeTracker.ExtendedProperties.Remove(IdKeyName);
                    }
                    else
                    {
                        ChangeTracker.ExtendedProperties[IdKeyName] = value.Id;
                    }
                }
            }
        }

        #endregion
    }
}
