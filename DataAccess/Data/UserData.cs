using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;
        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<IEnumerable<UserModel>> GetUsers() =>
            _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spGetAllUser", new { });

        public async Task<UserModel?> GetUser(int id)
        {
            var results = await _db.LoadData<UserModel, dynamic>(
                storedProcedure: "",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertUser(UserModel user) =>
            _db.SaveData(storedProcedure: "", new { user.FirstName, user.LastName });

        public Task UpdateUser(UserModel user) =>
            _db.SaveData(storedProcedure: "", user);

        public Task DeleteUser(int id) =>
            _db.SaveData(storedProcedure: "", new { Id = id });
    }
}
