using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Bussines.Interfaces
{
    public interface IUSer
    {
        #region Public Properties

        string Name { get; }

        #endregion Public Properties

        #region Public Methods

        Guid GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();

        #endregion Public Methods
    }
}
