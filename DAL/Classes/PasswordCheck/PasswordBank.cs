using DAL.Classes.Exceptions;

namespace DAL.Classes.PasswordCheck
{
    public class PasswordBank
    {
        int[] _passwords = {1234,11223344 };
        public bool Valid(string code)
        {
            int tmp;
            bool isNum = int.TryParse(code,out tmp);
            if(isNum)
            {
                for (int i = 0; i < _passwords.Length; i++)
                {
                    if (_passwords[i] == tmp) return true;
                }
                return false;
            }
            throw new WrongPassException("Input isn't a number!");
        }
    }
}
