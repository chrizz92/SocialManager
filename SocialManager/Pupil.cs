using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SocialManager
{
    /// <summary>
    /// Verwaltet Objekte des Typs Pupil mit ihren Daten
    /// und ihrem Verhalten
    /// </summary>
    public class Pupil
    {
        #region Fields

        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _zipCode;
        private string _city;

        #endregion Fields

        #region Methods

        public string GetFirstName()
        {
            return _firstName;
        }

        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public void SetLastName(string lastName)
        {
            _lastName = lastName;
        }

        public DateTime GetDateOfBirth()
        {
            return _dateOfBirth;
        }

        public void SetDateOfBirth(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
        }

        public string GetZipCode()
        {
            return _zipCode;
        }

        public void SetZipCode(string zipCode)
        {
            _zipCode = zipCode;
        }

        public string GetCity()
        {
            return _city;
        }

        public void SetCity(string city)
        {
            _city = city;
        }

        /// <summary>
        /// Wieviele Jahre ist der Schüler heute alt
        /// </summary>
        public int GetYearsOld()
        {
            /* VARIANTE 1

            DateTime today = DateTime.Today;
            int years = today.Year - _dateOfBirth.Year;
            if (today.AddYears(-years) < _dateOfBirth)
            {
                years--;
            }

             */

            int today = Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd"));
            int dateOfBirth = Convert.ToInt32(_dateOfBirth.ToString("yyyyMMdd"));
            int years = (today - dateOfBirth) / 10000;
            return years;
        }

        /// <summary>
        /// Vor- und Zunamen getrennt durch ein Leerzeichen ausgeben
        /// </summary>
        /// <returns></returns>
        public string GetFullName()
        {
            string _fullName = String.Empty;

            if ((_firstName == "" || _firstName == null) && (_lastName == "" || _lastName == null))
            {
                //Do nothing
            }
            else if ((_firstName == "" || _firstName == null) && _lastName != "")
            {
                _fullName = _lastName;
            }
            else if (_firstName != "" && (_lastName == "" || _lastName == null))
            {
                _fullName = _firstName;
            }
            else
            {
                _fullName = _firstName + " " + _lastName;
            }

            return _fullName;
        }

        /// <summary>
        /// Ist der Schüler heute zumindest 18 Jahre alt
        /// </summary>
        /// <returns></returns>
        public bool IsOfFullAge()
        {
            int age = GetYearsOld();
            bool isFullOfAge;

            if (age >= 18)
            {
                isFullOfAge = true;
            }
            else
            {
                isFullOfAge = false;
            }

            return isFullOfAge;
        }

        /// <summary>
        /// Lebt der Schüler in der Nähe (stimmen die ersten beiden Ziffern der PLZ überein)
        /// und sind die Postleitzahlen gültig?
        /// </summary>
        /// <param name="other">Vergleichsschüler</param>
        /// <returns>lebt in der Nähe</returns>
        public bool LivesNearBy(Pupil other)
        {
            bool digitIsEqual = true;
            bool zipCodeIsLongEnough = true;
            int counter = 0;

            if (other.GetZipCode().Length == 4)
            {
                do
                {
                    if (_zipCode[counter] != other.GetZipCode()[counter])
                    {
                        digitIsEqual = false;
                    }
                    counter++;
                } while (counter < 2 && digitIsEqual);
            }
            else
            {
                zipCodeIsLongEnough = false;
            }

            if (digitIsEqual && zipCodeIsLongEnough)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Methods
    }
}