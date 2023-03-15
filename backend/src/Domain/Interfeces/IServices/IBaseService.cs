﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfeces.IServices
{
    public interface IBaseService<T> where T : class
    {
        List<T> FindAll();
        Task<T> FindById(int id);

        Task<T> FindByIdPerson(int id);
        Task<int> Save(T entityDTO);
        Task<int> Update(T entityDTO);
        Task<int> Delete(int id);
    }
}
