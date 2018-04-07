using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba3.Models
{
    public class UserData
    {
        string _Login;
        string _password;
        string _Name;
        string _Email;
        string _age;
        string _Gn;
        DateTime _dateTime;

        public UserData(string Login, string password, string Name, string Email, string age, string Gn, DateTime dateTime)
        {
            _Login = Login ?? throw new ArgumentNullException(nameof(Login));
            _password = password ?? throw new ArgumentNullException(nameof(password));
            _Name = Name ?? throw new ArgumentNullException(nameof(Name));
            _Email = Email ?? throw new ArgumentNullException(nameof(Email));
            _age = age ?? throw new ArgumentNullException(nameof(age));
            _Gn = Gn ?? throw new ArgumentNullException(nameof(Gn));
            _dateTime = dateTime;
        }

        public string Login { get { return _Login; } set{ _Login =value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string Age { get { return _age; } set { _age = value; } }
        public string Gn { get { return _Gn; } set { _Gn = value; } }
        public DateTime DataTime { get { return _dateTime; } set { _dateTime = value; } }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}|",  _Login,
          _password,
          _Name,
          _Email,
          _age,
           _Gn,
           _dateTime);
        }
    }
}
