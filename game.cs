using System.Reflection.Metadata.Ecma335;

namespace character
{
    class program
    {
        static void Main(string[] args)
        {
            List<person> persons = new List<person>();
            List<npc> npcs = new List<npc>();
            Random rand = new Random();
            string npc_name="";
            int npc_x=0;
            int npc_y=0;
            int npc_damage=0;
            int npc_hp=0;
            int x = 0; 
            int y = 0; 
            int quantity_lifes = 0;
            int hp = 0 ;
            int damage = 0; ;
            string name = "";
            int person_counter = 0;
            int npc_counter = 0;

            Console.WriteLine("Enter how many persons you will have. Max = 10");
            int person_num = int.Parse(Console.ReadLine());
            if (person_num >= 10)
            {
                Console.WriteLine("Max persons = 10");
                return;
            }
            Console.WriteLine("Enter how many npc will be on map. Max 10");
            int npc_num = int.Parse(Console.ReadLine());
            if (npc_num >10)
            {
                Console.WriteLine("Max mps count = 10");
                return;
            }
            for (int i = 0; i < person_num; i++)
            {
                Console.WriteLine($"Enter name for person " + (i+1));
                name = Console.ReadLine();
                Console.WriteLine("Enter coordinat X for person " + (i + 1)+"(6x6)");
                x = int.Parse(Console.ReadLine());
                if ((x > 6) || (x < 0))
                {
                    Console.WriteLine("Playground is 6x6");
                    return;
                }
                Console.WriteLine("Enter coordinat Y for person " + (i + 1)+" (6x6)");
                y = int.Parse(Console.ReadLine());
                if((y > 6) || (y < 0))
                {
                    Console.WriteLine("Playground is 6x6");
                    return;
                }
                Console.WriteLine("Enter quantity of lifes for person " + (i + 1));
                quantity_lifes = int.Parse(Console.ReadLine());
                damage = rand.Next(10, 20);
                hp = rand.Next(40, 60);
                string fraction = "Neutral";
                if (name.Length > 0)
                {
                    if ((x <= 0) || (x > 6))
                    {
                        Console.WriteLine("Playground is 6x6");
                    }
                    if ((y <= 0) || (y > 6))
                    {
                        Console.WriteLine("Playground is 6x6");
                    }
                    persons.Add(new person(name, x, y, quantity_lifes,damage, hp, fraction));
                    person_counter++;
                    Console.Clear();
                    continue;
                }

            }
            for (int i = 0; i < npc_num; i++)
            {
                npc_name = "npc " + i + 1;
                npc_damage = rand.Next(5, 25);
                npc_hp = rand.Next(25, 70);
                npc_x = rand.Next(1, 7);
                npc_y = rand.Next(1,7);
                npcs.Add(new npc(npc_name, npc_x, npc_y,npc_damage, npc_hp));
                npc_counter++;
            }
            Console.WriteLine("Choose your character. You have: "+ person_num);
            int selected_character = int.Parse(Console.ReadLine());
            if ((selected_character<= 0) || (selected_character > person_num))
            {
                Console.WriteLine("You doesn't have this character");
                Console.WriteLine("Press any button to exit");
                Console.ReadKey();
                return;
            }
            int j = 0;
            while (true)
            {
                try
                {
                    Console.Clear();
                    for (j = 0; j < npcs.Count - 1; j++)
                    {
                        
                        if (npc_counter == 0)
                        {
                            Console.WriteLine("My congratulations. You WIN");
                            Console.ReadLine();
                            return;
                        }
                        if (persons[selected_character-1].get_hp() == 0)
                        {
                            Console.WriteLine("Character is dead");
                            if (persons[selected_character - 1].get_quantity_lifes() == 1)
                            {
                                person_counter--;
                                if (person_counter == 0)
                                {
                                    Console.WriteLine("You lose");
                                    Console.ReadLine();
                                    return;
                                }
                            }
                            if (persons[selected_character-1].get_quantity_lifes()>1)
                            {
                                Console.WriteLine("You have " + persons[selected_character - 1].get_quantity_lifes() + " lifes. Want to continue?(y/n)");
                                string y_n = Console.ReadLine();
                                switch (y_n)
                                {
                                    case "y":
                                        persons[selected_character - 1].vost();
                                        persons[selected_character - 1].respawn();
                                        Console.WriteLine("Your healt: "+persons[selected_character - 1].get_hp());
                                        Console.WriteLine("Press any button to continue");
                                        Console.ReadKey();
                                        break;
                                    case "n":
                                        persons[selected_character - 1].del();
                                        Console.WriteLine("Character is dead");
                                        person_counter--;
                                        break;
                                } 
                            }              
                            Console.ReadLine();
                            break;
                        }
                        if (persons[selected_character-1].get_x() == npcs[j].get_x_npc() && (persons[selected_character-1].get_y() == npcs[j].get_y_npc()))
                        {                          
                                                        
                        while ((npcs[j].get_hp_npc() > 0) &&(persons[selected_character-1].get_hp() > 0))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You on the same coordinates with character");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Q - to get info about character\nW - to hit character\nE - to get out from this coordinates\nR - to take fracture this character");
                            if (npcs[j].get_hp_npc() == 0)
                            {
                                Console.WriteLine("You kill him");
                                npcs[j].death_npc();
                                npc_counter--;
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                break;
                            }
                            ConsoleKey select_key = Console.ReadKey().Key;
                            Console.WriteLine();
                            switch (select_key)
                            {
                            case ConsoleKey.Q:
                                npcs[j].printInfo();
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                break;
                            case ConsoleKey.W:
                                if (persons[selected_character - 1].get_fraction() == npcs[j].get_fraction_npc())
                                {
                                    Console.WriteLine("You from the same faction");
                                    Console.WriteLine("Press any button to continue");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.WriteLine("HP enemy character: " + npcs[j].taken_damage_npc(persons[selected_character - 1].get_damage()));
                                Console.WriteLine("You were attacked in response");
                                Console.WriteLine("HP your character: " + persons[selected_character - 1].taken_damage(npcs[j].get_damage_npc()));
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                break;
                                case ConsoleKey.E:
                                if ((persons[selected_character-1].get_x()+1) > 6)
                                {
                                    Console.WriteLine("Playground 6x6");
                                    continue;
                                }
                                persons[selected_character - 1].movex(1);
                                Console.WriteLine("X now:" + persons[selected_character - 1].get_x());
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                break;
                            case ConsoleKey.R:
                                persons[selected_character - 1].change_fraction(npcs[j].get_fraction_npc());
                                Console.WriteLine("Fraction: " + npcs[j].get_fraction_npc());
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                break;
                            }     
                            Console.Clear();
                            break;
                            }
                        }
                    }
                    Console.WriteLine("A - to bring out info about character\nS - to move for X\nD - to move for Y\nF - to kill character\nG - to damage yourself\nH - to heal yourself\nJ - to get full health\nK - to swap character\n");
                    ConsoleKey need_button = Console.ReadKey().Key;
                    int for_x = 0;
                    int for_y = 0;
                    int damage_deal;
                    int heal = 0;
                    Console.WriteLine();
                    switch (need_button)
                    {                        
                        case ConsoleKey.A:
                            persons[selected_character-1].printInfo();
                            Console.WriteLine("Press any button to continue");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.S:
                            Console.WriteLine("Specify how much the character must pass for X: ");
                            for_x = int.Parse(Console.ReadLine());
                            if ((for_x < -6)|| (for_x > 6))
                            {
                                Console.WriteLine("Playground is 6x6");
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                break;
                            }
                            if (((persons[selected_character-1].get_x() + for_x) > 6) || (persons[selected_character-1].get_x()+for_x) <0)
                            {
                                Console.WriteLine("Playground is 6x6");
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                break;
                            }
                            persons[selected_character-1].movex(for_x);
                            break;
                        case ConsoleKey.D:
                            Console.WriteLine("Specify how much the character must pass for Y: ");
                            for_y = int.Parse(Console.ReadLine());
                            if (((persons[selected_character-1].get_y() + for_y) > 6)|| (persons[selected_character - 1].get_y() + for_x) < 0)
                            {
                                Console.WriteLine("Playground is 6x6");
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                break;
                            }
                            if ((for_y < -6) || (for_y > 6))
                            {
                                Console.WriteLine("Playground is 6x6");
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                break;
                            }
                            
                            persons[selected_character-1].movey(for_y);
                            break;
                        case ConsoleKey.F:
                            persons[selected_character-1].del();
                            Console.WriteLine("Character is dead. Take another one");
                            Console.WriteLine("Press any button to continue");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.G:
                            Console.WriteLine("Are you sure? How many damage should be done");
                            damage_deal = int.Parse(Console.ReadLine());
                            persons[selected_character-1].uron(damage_deal);
                            break;
                        case ConsoleKey.H:
                            Console.WriteLine("How many healtpoints need to regen?");
                            heal = int.Parse(Console.ReadLine());
                            persons[selected_character-1].doc(heal);
                            Console.WriteLine("HP now: " + persons[selected_character-1].get_hp());
                            Console.WriteLine("Press any button to continue");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.J:
                            persons[selected_character-1].vost();
                            Console.WriteLine("HP now: " + persons[selected_character-1].get_hp());
                            Console.WriteLine("Press any button to continue");
                            Console.ReadKey();
                            break;
                        case ConsoleKey.K:
                            Console.WriteLine("Which character you want to take?");
                            selected_character = int.Parse(Console.ReadLine());
                            if(selected_character > person_num)
                            {
                                Console.WriteLine("You doesn't have this character");
                                Console.WriteLine("Press any button to continue");
                                Console.ReadKey();
                                break;
                            }
                            Console.WriteLine("Now you " + selected_character + " character");
                            Console.WriteLine("Press any button to continue");
                            Console.ReadKey();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Something went wrong");
                    Console.WriteLine("Press any button to continue");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}