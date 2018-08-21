using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class Person
    {
        private string id;
        private string name;
        private string surname;
        private string contactNo;
        private string email;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Person()
        {

        }

        public Person(string id, string name, string surname, string contactNo, string email)
        {
            _ValidationMethods.ValidateInteger(id, "ID Number", 13);
            _ValidationMethods.ValidateStringWithSpaces(name, "Name", 50);
            _ValidationMethods.ValidateStringWithSpaces(surname, "Surname", 50);
            _ValidationMethods.ValidateInteger(contactNo, "Contact Number", 10);
            _ValidationMethods.ValidateEmail(email, "Email Address", 50);

            if (_ValidationMethods.isValid)
            {
                this.id = id;
                this.name = name;
                this.surname = surname;
                this.contactNo = contactNo;
                this.email = email;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Person))
                {
                    Person person = obj as Person;

                    return ((this.ID == person.ID) && (this.Name == person.Name) && (this.Surname == person.Surname) && (this.ContactNo == person.ContactNo) && (this.Email == person.Email));
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
