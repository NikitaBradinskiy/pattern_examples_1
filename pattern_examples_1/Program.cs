using System;
using System.Collections.Generic;

namespace PracticeTime3
{
    class Program
    {
        static void Main(string[] args) // MonoBehaviour Script Main
        {
            MainPerson person = new MainPerson(100);
            Enemy enemy = new Enemy();

            person.Accept(ShootManager.Instance);
            person.Accept(ShootManager.Instance);
            person.Accept(ShootManager.Instance);
            person.Accept(new Run());

            Console.Read();
        }
        
    }
}
