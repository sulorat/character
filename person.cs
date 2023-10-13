using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character
{
    internal class person
    {
        List<person>persons = new List<person>();
        private string name;
        private int x;
        private int y;
        private bool relationships = true;
        private int quantity_lifes;
        private int hp;
        private int damage;
        private int max_hp;
        private string fraction = "neutral";
        Random rand = new Random();

        public person(string name, int x, int y, int quantity_lifes, int damage, int hp, string fraction)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.quantity_lifes = quantity_lifes;
            this.damage = damage;
            this.hp = hp;
            this.max_hp = hp;
            this.fraction = fraction;
            persons.Add(this);
        }
        public int get_x() 
        { 
            return x;
        }
        public int get_y() 
        { 
            return y;
        }

        public void printInfo()
        {
            Console.WriteLine("name:" + this.name);
            Console.WriteLine("X: " + x);
            Console.WriteLine("Y: " + y);
            Console.WriteLine("Relationships: " + relationships);
            Console.WriteLine("Quanitity of lifes:" + quantity_lifes);
            Console.WriteLine("Health: " + hp);
            Console.WriteLine("Damage: " + damage);
            Console.WriteLine("Max health:" + max_hp);
        }
        public void movex(int x)
        {
            this.x += x;
        }
        public void movey(int y)
        {
            this.y += y;
        }
        public void del()
        {
            hp = 0;
            quantity_lifes = 0;
            x = -1;
            y = -1;
        }
        public int get_quantity_lifes()
        {
            return quantity_lifes;
        }
        public void uron(int uron)
        {
            hp -= uron;
            if (hp <= 0)
                hp = 0;
        }
        public void doc(int doc)
        {
            hp += doc;
            if (hp >= max_hp)
            {
                hp = max_hp;
            }
        }
        public void vost()
        {
            hp = max_hp;
        }
        public void respawn()
        {
            quantity_lifes -= 1;
        }
        public string get_fraction()
        {
            return fraction;
        }
        public int get_damage()
        {
            return damage;
        }
        public void change_fraction(string fraction)
        {
            this.fraction = fraction;
        }
        public int get_hp()
        {
            return hp;
        }
        public int taken_damage(int damage)
        {
            this.hp -= damage;
            if (this.hp < 0)
                hp = 0;
            return hp;
        }
    }
}
