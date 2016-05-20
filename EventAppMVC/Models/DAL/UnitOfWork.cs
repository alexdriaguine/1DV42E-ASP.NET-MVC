﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventAppMVC.Models.DAL
{
    public class UnitOfWork : IDisposable
    {
        private EventAppContext _context = new EventAppContext();
        private GenericRepository<Event> _eventRepository;
        private GenericRepository<Attendee> _attendeeRepository;

        public GenericRepository<Event> EventRepository
        {
            get
            {
                if (_eventRepository == null)
                {
                    _eventRepository = new GenericRepository<Event>(_context);
                }
                return _eventRepository;
            }
        }

        public GenericRepository<Attendee> AttendeeRepository
        {
            get
            {
                if (_attendeeRepository == null)
                {
                    _attendeeRepository = new GenericRepository<Attendee>(_context);
                }
                return _attendeeRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}