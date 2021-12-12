﻿using System.Collections.Generic;

namespace HospitalClassLibrary.Medicine.Repositories.Interfaces
{
    public interface IGenericRepository<T> 
    {
        List<T> GetAll();
        bool Save(T entity);
        void Delete(T entity);
        bool Update(T entity);
    }
}
