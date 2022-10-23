using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTime3
{
    public abstract class Bullet
    {
        public bool HasTarget { get; set; }
    }
    public sealed class FireBall : Bullet 
    {
        public FireBall()
        {
            Console.WriteLine("Fireball!!");
        }
    }
    public sealed class ToxicWater : Bullet 
    {
        public ToxicWater()
        {
            Console.WriteLine("ToxicWater!!");
        }
    }

    public abstract class Hero
    {
        public int _health { get; set; }
        public abstract Bullet GetBullet();
        public virtual void ShowHero()
        {
            Console.WriteLine(GetBullet().GetType());     
        }
        public Hero(int health)
        {
            _health = health;
        }
    }
    public sealed class Zombie : Hero
    {
        public Zombie(int health) : base(health) { }

        public override Bullet GetBullet()
        {
            return new ToxicWater();
        }
        public override void ShowHero()
        {
            base.ShowHero();
            Console.WriteLine("Its me.. Zombie");
        }
    }
    public sealed class MagicHuman : Hero
    {
        public MagicHuman(int health) : base(health) { }
        public override Bullet GetBullet()
        {
            return new FireBall();
        }
        public override void ShowHero()
        {
            base.ShowHero();
            Console.WriteLine("I am fighting for piece!!");
        }
    }
}
