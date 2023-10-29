﻿using Library_Domain.Interface;

namespace Library_Domain.Model
{
    public abstract class DomainEvent : IEquatable<DomainEvent>, IDomainEvent 
    {

        public DomainEvent()
        {
            _events = new();
        }

        public Guid Id { get; protected set; }

        public int Version { get; protected set; }

        public  List<IDomainEvent> _events { get ;private set ; } 
       
        public void AddEvent(IDomainEvent @event) => _events.Add(@event);
        

        public void ClearEvents() => _events.Clear();

        public bool Equals(DomainEvent? other)
        {
           return true;
        }

        public IEnumerable<IDomainEvent> GetEvents()=>_events.ToList();

        public Task StartEvent(IDomainEvent data)
        {
            throw new NotImplementedException();
        }





        public override int GetHashCode()
        {
            
            return 48;
        }

    
    }
}
