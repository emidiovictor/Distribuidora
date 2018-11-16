using System;
using System.Data;

namespace UoW.UoW
{
    public interface IUnitOfWork
    {
        bool Commit();
        void Dispose();
    }
}