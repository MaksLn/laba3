using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba3.Models
{
    public class UserData
    {
        private string _login;
        private string _password;
        private string _name;
        private string _email;
        private string _age;

        public UserData(string Login, string password, string Name, string Email, string age, string Gn, DateTime dateTime)
        {
            this.Login = Login ?? throw new ArgumentNullException(nameof(Login));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            this.Name = Name ?? throw new ArgumentNullException(nameof(Name));
            this.Email = Email ?? throw new ArgumentNullException(nameof(Email));
            Age = age ?? throw new ArgumentNullException(nameof(age));
            this.Gn = Gn ?? throw new ArgumentNullException(nameof(Gn));
            DataTime = dateTime;
        }

        public string Login
        {
            get { return _login; }
            set
            {
                if (value.Length < 20)
                {
                    _login = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Логин не должен состоять более чем из 20 символов");
                }
            }
        }
        public string Password { get => _password; set  {
                if (value.Length < 20)
                {
                    _password = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Пароль не должен состоять более чем из 20 символов");
                }
            } }
        public string Name { get => _name; set {
                if (value.Length < 20)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Имя не должено состоять более чем из 15 символов");
                }
            } }
        public string Email { get => _email; set {
                if (value.Length < 20)
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Email не должен состоять более чем из 25 символов");
                }
            } }
        public string Age { get => _age; set {
                if (Convert.ToInt32( value) > 0&& Convert.ToInt32(value) < 120)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Некорректный возрост (0-120)");
                }
            } }
        public string Gn { get; set; }
        public DateTime DataTime { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}|", Login,
          Password,
          Name,
          Email,
          Age,
           Gn,
           DataTime);
        }
    }
}
