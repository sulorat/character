using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character
{
    internal class npc
    {
        List<npc>npcs = new List<npc>();
        private string npc_name;
        private int npc_x;
        private int npc_y;
        private bool npc_relationships;
        private string npc_fraction;
        private int npc_damage;
        private int npc_hp;
        Random rand = new Random();
        public npc(string nps_name, int nps_x, int nps_y, int nps_damage, int nps_hp)
        {
            this.npc_name = nps_name;
            this.npc_x = nps_x;
            this.npc_y = nps_y;
            this.npc_damage = nps_damage;
            this.npc_hp = nps_hp;
            relationships_();
            npcs.Add(this);
        }

        private void relationships_()
        {
            int relationships_num = rand.Next(0, 3);
            if (relationships_num == 0)
            {
                npc_relationships = true;
                npc_fraction = "Gnomes";
            }
            if (relationships_num == 1)
            {
                npc_relationships = true;
                npc_fraction = "Elves";
            }
            if (relationships_num == 2)
            {
                npc_relationships = false;
                npc_fraction = "Orcs";
                
            }      
        }
        public int get_x_npc()
        {
            return npc_x;
        }
        public int get_y_npc()
        {
            return npc_y;
        }
        //public void info(string name, int x, int y,int hp, int damage )
        //{
        //    this.npc_name = name;
        //    this.npc_x = x;
        //    this.npc_y = y;
        //    this.npc_hp = hp;
        //    this.npc_damage = damage;
        //}
        public void printInfo()
        {
            
            Console.WriteLine("name:" + this.npc_name);
            Console.WriteLine("X: " + npc_x);
            Console.WriteLine("Y: " + npc_y);         
            Console.WriteLine("Relationships: " + npc_relationships);
            Console.WriteLine("Fraction:" + npc_fraction);
            Console.WriteLine("Health: " + npc_hp);
            Console.WriteLine("Damage: " + npc_damage);
        }
        public int taken_damage_npc(int damage)
        {
            this.npc_hp -= damage;
            if (this.npc_hp < 0)
                npc_hp = 0;
            return npc_hp;
        }
        public string get_fraction_npc()
        {
            return npc_fraction;
        }
        public int get_hp_npc()
        {
            return npc_hp;
        }
        public int get_damage_npc()
        {
            return npc_damage;
        }
        public void death_npc()
        {
            if (npc_hp <= 0)
            {
                npc_x = -10;
                npc_y = -10;
            }
        }
    }
}
