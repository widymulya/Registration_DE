using Registration_DE.Models;

namespace Registration_DE.Repository
{
    public interface IRegisterRepo
    {
        void SaveData(Register data);
        bool Login(LoginData loginData);
        List<Register> GetRegister();

        void UpdateData(Register data);
    }
}
