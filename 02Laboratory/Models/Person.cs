using _02Laboratory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Laboratory.Models
{
    class Person
    {
        private String _firstName;
        private String _lastName;
        private String _email;
        private DateTime _dateOfBirth;

        private bool _isAdult;
        private bool _isBirthday;
        private WestZodiacSigns _sunSign;
        private ChineseZodiacSigns _chineseSign;

        public ChineseZodiacSigns ChineseSign { get { return _chineseSign; } }
        public WestZodiacSigns SunSign { get { return _sunSign; } }

        public bool IsAdult { get { return _isAdult; } }

        public bool IsBirthday { get { return _isBirthday; } }

        public void Proceed()
        {
            _isAdult = WorkWithDate.isAdult(_dateOfBirth);
            _isBirthday = WorkWithDate.isBirthday(_dateOfBirth);
            _chineseSign = WorkWithDate.calculateChineseZodiacSign(_dateOfBirth);
            _sunSign = WorkWithDate.calculateWestZodiacSign(_dateOfBirth);
        }

        public Person() { }
        public Person(String firstName, String lastName) 
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public Person(String firstName, String lastName, String email) :this(firstName,lastName)
        {
            _email = email;
        }
        public Person(String firstName, String lastName, DateTime dateOfBirth, String email = "") : this(firstName,lastName,email)
        {
            _dateOfBirth = dateOfBirth;
        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
    }
}
