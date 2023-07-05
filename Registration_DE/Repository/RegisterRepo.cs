using Microsoft.EntityFrameworkCore;
using Registration_DE.DBContext;
using Registration_DE.Models;

namespace Registration_DE.Repository
{
    public class RegisterRepo : IRegisterRepo
    {
        private readonly RegisterContext _dbContext;

        public RegisterRepo(RegisterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Register> GetRegister()
        {
            return _dbContext.Registers.Where(a => a.IsApproved == 0).ToList();
        }

        public bool Login(LoginData loginData)
        {
            var data = _dbContext.Registers.ToList().Where(a => a.Email == loginData.Email && a.Password == loginData.Password && a.IsApproved == 1);
            return data.Any();
        }

        public void SaveData(Register data)
        {
            _dbContext.Add(data);
            _dbContext.SaveChanges();
        }

        public void UpdateData(Register data)
        {
            _dbContext.Entry(data).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
