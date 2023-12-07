using Microsoft.EntityFrameworkCore;
using N5ChallengeWebApiDomain;
using N5ChallengeWebApiInfrastructure.Persistence.Context.Interfaces;
using N5ChallengeWebApiInfrastructure.Persistence.Repositories.Implementations;
using N5ChallengeWebApiInfrastructure.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5ChallengeWebApiInfrastructure.Persistence.Context.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private PermissionRepository _permissionRepository;

        private readonly N5ChallengeDBContext _context;

        private Dictionary<Type, object> _repositories;

        public UnitOfWork(N5ChallengeDBContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IPermissionRepository GetPermissionRepository()
        {
            return _permissionRepository ??= new PermissionRepository(_context);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }

            var repository = new Repository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
