using GitHubTools.CoreApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UnitTests.Mocks
{
    class FakeUnitOfWork : IUnitOfWork
    {

        public FakeUnitOfWork()
        {
        }

        public IRepRepository RepRepository
        {
            get => MockIRepRepository.GetMock().Object;
        }

        public IOwnerRepository OwnerRepository
        {
            get => MockIOwnerRepository.GetMock().Object;
        }


        public async Task Commit()
        {
            await Task.CompletedTask;
        }

        public async Task Rollback()
        {
            await Task.CompletedTask;
        }

        public async Task Clear()
        {
            await Task.CompletedTask;
        }

        public void Dispose()
        {

        }
    }
}
