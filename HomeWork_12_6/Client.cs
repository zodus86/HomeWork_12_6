using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_12_6
{
    public class Client
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public decimal TelephonNumber { get; set; }
        public string Pasport { get; set; }

        private DateTime DateOfChange;
        private string TextChange;
        private TypeOfChangesEnum TypeOfChanges;
        private Users UserChange;

        /// <summary>
        /// версифицирование объекта по последнему изменению
        /// </summary>
        /// <returns></returns>
        public string GetChange()
        {
            return $"{DateOfChange} _ {TextChange}. " +
                $"Тип изменений - {TypeOfChanges}. " +
                $"Пользователь  - {UserChange}";
        }

        /// <summary>
        /// спрячем пустой конструктор
        /// </summary>
        private Client()
        {
        }

        public override string ToString()
        {
            return $"{FirstName, 15} {LastName, 15} {MiddleName, 15} {TelephonNumber, 15} {"** ** ******", 15}";
        }

        /// <summary>
        /// Клиент
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="middleName"></param>
        /// <param name="telephonNumber"></param>
        /// <param name="pasport"></param>
        public Client(string firstName, string lastName, string middleName, decimal telephonNumber, string pasport)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            TelephonNumber = telephonNumber;
            Pasport = pasport;
        }

        /// <summary>
        /// сделать отметку изменений
        /// </summary>
        /// <param name="textChange"></param>
        /// <param name="typeOfChanges"></param>
        /// <param name="user"></param>
        public void SetChange(string textChange, TypeOfChangesEnum typeOfChanges, Users user)
        {
            DateOfChange = DateTime.Now;
            TextChange = textChange;
            TypeOfChanges = typeOfChanges;
            UserChange = user;
        }
    }
}
