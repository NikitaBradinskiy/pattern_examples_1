using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTime3
{
    // Visitor Mom => Do everything instead of kids
   // + extra  
   //Visitor is rule how to handle smth
    public interface IVisitor
    {
        void VisitMainPerson(MainPerson person);
        void VisitEnemy(Enemy enemy);
    }
    public class MovementManager : IVisitor
    {
        public void VisitEnemy(Enemy enemy)
        {
            // enemy move
        }

        public void VisitMainPerson(MainPerson person)
        {
            // person move
        }
    }
    public class AnimationManager : IVisitor
    {
        public void VisitEnemy(Enemy enemy)
        {
            
        }

        public void VisitMainPerson(MainPerson person)
        {

        }
    }
    public class ShootManager : IVisitor // Properties
    {
        public static ShootManager Instance = new ShootManager();
        private ShootManager() { }
        public int PlayerBulletAmount = 10;
        public int EnemyBulletAmount = 1000;
        public void VisitEnemy(Enemy enemy)
        {
            Console.WriteLine("Cant");
        }
        public void VisitMainPerson(MainPerson person)
        {
            PlayerBulletAmount--;
            Console.WriteLine("Shoot" + PlayerBulletAmount);
        }
    }
    public class DestroyManager : IVisitor
    {
        public void VisitEnemy(Enemy enemy)
        {
           //
        }
        public void VisitMainPerson(MainPerson person)
        {
            Console.WriteLine("Destroy person");
        }

    }
    public class Run : IVisitor
    {
        public void VisitEnemy(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void VisitMainPerson(MainPerson person)
        {
            Console.WriteLine("Run");
        }
    }
    public interface ICharacterGame
    {
        void Accept(IVisitor visitor);
    }
    public class CharacterManager
    {
        public static CharacterManager Instance = new CharacterManager();
        private CharacterManager() { }
        List<ICharacterGame> characters = new List<ICharacterGame>();
        public void AddCharacters(params ICharacterGame[] heros)
        {
            if(heros != null)
            foreach (var r in heros)
                characters.Add(r);
        }
        public void RemoveCharacters(params ICharacterGame[] heros)
        {
            if (heros != null)
                foreach (var r in heros)
                characters.Remove(r);
        }
        public void AcceptModifier(IVisitor modifier)
        {
            foreach(ICharacterGame character in characters)
            {
                character.Accept(modifier);
            }
        }
    }
    public class MainPerson : ICharacterGame
    {
        public void Accept(IVisitor visitor) => visitor.VisitMainPerson(this);
        public MainPerson(int bulletAmount)
        {
            ShootManager.Instance.PlayerBulletAmount = bulletAmount;
        }

        // data 


    }
    public class Enemy : ICharacterGame
    {
        public void Accept(IVisitor visitor) => visitor.VisitEnemy(this);
    }
}
