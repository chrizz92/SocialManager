using SocialManager;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        /// <summary>
        /// A private method that creates a new instances of the class pupil and calls the 5 Set-Methods of the created object.
        /// </summary>
        /// <returns>The created pupil object</returns>
        private static Pupil CreateNewPupil()
        {
            Console.Clear();
            Pupil pupil = new Pupil();
            Console.Write("Bitte Vornamen eingeben:{0,19}", " ");
            pupil.SetFirstName(Console.ReadLine());
            Console.Write("Bitte Nachnamen eingeben:{0,18}", " ");
            pupil.SetLastName(Console.ReadLine());
            Console.Write("Bitte Geburtstag eingeben:{0,17}", " ");
            pupil.SetDateOfBirth(Convert.ToDateTime(Console.ReadLine()));
            Console.Write("Bitte Postleitzahl des Wohnortes eingeben:{0,1}", " ");
            pupil.SetZipCode(Console.ReadLine());
            Console.Write("Bitte Name des Wohnortes eingeben:{0,9}", " ");
            pupil.SetCity(Console.ReadLine());
            return pupil;
        }

        /// <summary>
        /// A private method that asks for an integer to set the size of an array of pupil
        /// </summary>
        /// <returns>The size of an array of pupil</returns>
        private static int SetSizeOfPupilArray()
        {
            Console.Write("Bitte maximale Anzahl der Schüler eingeben: ");
            int arraySize = Convert.ToInt32(Console.ReadLine());
            return arraySize;
        }

        private static void Main(string[] args)
        {
            string firstNameToLookFor = "";
            int maxPupils = SetSizeOfPupilArray();
            Pupil[] pupils = new Pupil[maxPupils];

            //Fill array with pupils
            for (int i = 0; i < maxPupils; i++)
            {
                pupils[i] = CreateNewPupil();
            }

            //Look for pupil, where the firstname equals a lookup name and print them to console
            do
            {
                Console.Write("Welcher Vorname ist gesucht <# zum Beenden>: ");
                firstNameToLookFor = Console.ReadLine().Trim().ToLower();

                for (int i = 0; i < maxPupils; i++)
                {
                    if (pupils[i].GetFirstName().ToLower() == firstNameToLookFor)
                    {
                        Console.WriteLine("{0}, {1} Jahre", pupils[i].GetFullName(), pupils[i].GetYearsOld());
                    }
                }
                Console.Write("Bitte beliebige Taste zum Fortsetzen");
                Console.ReadKey();
                Console.Clear();
            } while (firstNameToLookFor != "#");
        }
    }
}