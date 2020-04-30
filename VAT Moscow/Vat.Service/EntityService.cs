using System;
using System.Collections.Generic;

namespace VAT
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        IUnityOfWork _unitOfWork;
        IGenericRepository<T> _repository;

        public EntityService(IUnityOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public IUnityOfWork UnitOfWork { get => _unitOfWork; set => _unitOfWork = value; }
        public IGenericRepository<T> Repository { get => _repository; set => _repository = value; }

        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }   
            _repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
