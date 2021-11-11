using Logic.Classes.Exceptions;
using System;

namespace Logic.Classes.PasswordCheck
{
    class PasswordBank
    {
        int[] _passwords = {1234,11223344 };
        public bool Valid(string code)
        {
            int tmp = Convert.ToInt32(code);
            if(tmp != -1)
            {
                for (int i = 0; i < _passwords.Length; i++)
                {
                    if (_passwords[i] == tmp) return true;
                }
                return false;
            }
            throw new WrongPassException("input isn't a number.");
        }
    }
}
