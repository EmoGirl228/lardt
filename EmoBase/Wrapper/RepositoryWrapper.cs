using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using EmoBase.Repositories;
using Domain.Wrapper;

namespace EmoBase.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private EmoBaseContext _repocontext;

        private IUserRepository _user;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = (IUserRepository)new UserRepository(_repocontext);
                }
                return _user;
            }
        }

        public RepositoryWrapper(EmoBaseContext repocontext)
        {
            _repocontext = repocontext;
        }
        public async Task Save()
        {
            await _repocontext.SaveChangesAsync();
        }
    }
}
