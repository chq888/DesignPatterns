using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatterns.Pattern.GangOfFour.Creational
{
    public class AbstractFactory
    {
    }

    public interface IRepository
    {
        void Add();
    }

    public class MsSqlRepository : IRepository
    {
        public void Add()
        {

        }
    }

    public class MySqlRepository : IRepository
    {
        public void Add()
        {

        }
    }


    public interface IUnitOfWork
    {
        void Save();
    }

    public class MsSqlUnitOfWork : IUnitOfWork
    {
        public void Save()
        {

        }
    }

    public class MySqlUnitOfWork : IUnitOfWork
    {
        public void Save()
        {

        }
    }

    /// <summary>
    /// abstract factory
    /// </summary>
    public interface IDAOFactory
    {
        IRepository GetRepository();
        IUnitOfWork GetUnitOfWork();
    }

    /// <summary>
    /// factory
    /// </summary>
    public class MsSqlFactory : IDAOFactory
    {
        public IRepository GetRepository()
        {
            return new MsSqlRepository();
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return new MsSqlUnitOfWork();
        }
    }

    /// <summary>
    /// factory
    /// </summary>
    public class MySqlFactory : IDAOFactory
    {
        public IRepository GetRepository()
        {
            return new MySqlRepository();
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return new MySqlUnitOfWork();
        }
    }

    /// <summary>
    /// client
    /// </summary>
    public class DAOHelper
    {
        private IDAOFactory _IDAOFactory;
        public DAOHelper(IDAOFactory factory)
        {
            _IDAOFactory = factory;
        }

        public void Save()
        {
            _IDAOFactory.GetUnitOfWork().Save();
        }

    }
}