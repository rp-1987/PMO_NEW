using PMO.Models.Shared;

namespace PMO.DataAccess.Engines
{
    public interface IUserEngine
    {
        PmoUser AuthenticateUser(string empId, string passkey);
    }
}