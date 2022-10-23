using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTime3
{
    public abstract class Weapon
    {
        public int _damage { get; set; }
        public virtual void GiveDamage() => Console.WriteLine(_damage);
    }
    public abstract class Movement
    {
        public virtual void Move() => Console.WriteLine("Moving");
    }
    public abstract class Dialog
    {
        
    }
    public abstract class Character
    {
        public Weapon _weapon { get; set; }
        public Movement _movement { get; set; }
        public Dialog _dialog { get; set; }
        public abstract Weapon GetWeapon();
        public abstract Movement GetMovement();
        public abstract Dialog GetDialog();
        public Character()
        {
            InvokeCharacter();
        }
        private void InvokeCharacter()
        {
             _weapon = GetWeapon();
             _movement = GetMovement();
             _dialog = GetDialog();
        }
        public virtual void Hit()
        {
            _weapon.GiveDamage();
        }
    }
    public sealed class Elf : Character
    {
        public override Dialog GetDialog()
        {
            return new HappyDialogType();
        }

        public override Movement GetMovement()
        {
            return new FlyMode();
        }

        public override Weapon GetWeapon()
        {
            return new Pistol();
        }
    }
    public sealed class Animal : Character
    {
        public override Dialog GetDialog()
        {
            return new SedDialogType();
        }

        public override Movement GetMovement()
        {
            return new RunMode();
        }

        public override Weapon GetWeapon()
        {
            return new Hand();
        }
    }
    public static class HeroBuilder<T> where T: Character, new()
    {
        public static T CreateHero()
        {
            return new T();
        }
    }

    public sealed class Pistol : Weapon
    {

    }
    public sealed class Hand : Weapon
    {

    }
    public sealed class FlyMode: Movement
    {

    }
    public sealed class RunMode: Movement
    {

    }
    public sealed class SedDialogType: Dialog
    {

    }
    public sealed class HappyDialogType: Dialog
    {

    }
}
