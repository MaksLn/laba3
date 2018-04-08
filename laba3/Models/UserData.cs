using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba3.Models
{
    public class UserData
    {
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

        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Gn { get; set; }
        public DateTime DataTime { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}|",  Login,
          Password,
          Name,
          Email,
          Age,
           Gn,
           DataTime);
        }
    }
}
