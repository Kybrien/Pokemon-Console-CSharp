﻿using Biblio;

namespace MoveControl
{
    public class Move
    {
        public static void ManageMoveJ(Pokemon attacker, Pokemon defender, Capacite attackAbility)
        {
            Random rand = new Random();
            int randomChance = rand.Next(100);
            string cat = attackAbility.Category;
            Console.WriteLine($"Capacités : {attackAbility.Nom}");
            switch (cat)
            {
                case "Physical":
                    int damage = (attackAbility.Puissance + attacker.Attack) * 5 / defender.Defense + 10;
                    Console.WriteLine($"\n------------\n{attacker.Nom} attaque !");
                    if (randomChance <= attackAbility.Precision)
                    {
                        //if (TypeEffectiveness.IsSuperEffective(attackAbility.Type, defender.Type))
                        {

                        }
                        Console.WriteLine($"{defender.Nom} a subi {damage} dommages.\n------------");
                        defender.TakeDamage(damage);
                    }
                    else
                    {
                        Console.WriteLine("\n[- L'attaque a échoué ! -]\n");
                    }
                    break;
                case "Special":
                    int spe_damage = (attackAbility.Puissance + attacker.SpecialAttack) * 5 / defender.SpecialDefense + 10;
                    Console.WriteLine($"\n------------\n{attacker.Nom} attaque !");
                    if (randomChance <= attackAbility.Precision)
                    {
                        Console.WriteLine($"{defender.Nom} a subi {spe_damage} dommages.\n------------");
                        defender.TakeDamage(spe_damage);
                    }
                    else
                    {
                        Console.WriteLine("\n[- L'attaque a échoué ! -]\n");
                    }
                    break;
                case "Status":
                    int stat = rand.Next(5);
                    switch (stat)
                    {
                        case 1:
                            Console.WriteLine("\n-----\nL'attaque adverse est réduite\n-----");
                            defender.Attack -= 10;
                            break;
                        case 2:
                            Console.WriteLine("\n-----\nLa défense adverse est réduite\n-----");
                            defender.Defense -= 10;
                            break;
                        case 3:
                            Console.WriteLine("\n-----\nL'attaque spéciale adverse est réduite\n-----");
                            defender.SpecialAttack -= 10;
                            break;
                        case 4:
                            Console.WriteLine("\n-----\nLa défense spéciale adverse est réduite\n-----");
                            defender.SpecialDefense -= 10;
                            break;
                        case 5:
                            Console.WriteLine("\n-----\nLa vitesse adverse est réduite\n-----");
                            defender.Speed -= 10;
                            break;
                    }

                    Console.Clear();
                    break;
            }

            Thread.Sleep(2000); // Pause for 2 seconds
        }
        public static void ManageMoveE(Pokemon attacker, Pokemon defender, Capacite attackAbility)
        {
            Random rand = new Random();
            int randomChance = rand.Next(100);
            string cat = attackAbility.Category;
            Console.WriteLine($"Capacités : {attackAbility.Nom}");
            switch (cat)
            {
                case "Physical":
                    int damage = (attackAbility.Puissance + attacker.Attack) * 5 / defender.Defense + 10;
                    Console.WriteLine($"\n------------\n{attacker.Nom} attaque !");
                    if (randomChance <= attackAbility.Precision)
                    {
                        Console.WriteLine($"{defender.Nom} a subi {damage} dommages.\n------------");
                        defender.TakeDamage(damage);
                    }
                    else
                    {
                        Console.WriteLine("\n[- L'attaque a échoué ! -]\n");
                    }
                    break;
                case "Special":
                    int spe_damage = (attackAbility.Puissance + attacker.SpecialAttack) * 5 / defender.SpecialDefense + 10;
                    Console.WriteLine($"{attacker.Nom} attaque !");
                    if (randomChance <= attackAbility.Precision)
                    {
                        Console.WriteLine($"{defender.Nom} a subi {spe_damage} dommages.\n------------");
                        defender.TakeDamage(spe_damage);
                    }
                    else
                    {
                        Console.WriteLine("\n[- L'attaque a échoué ! -]\n");
                    }
                    break;
                case "Status":
                    int stat = rand.Next(5);
                    switch (stat)
                    {
                        case 1:
                            Console.WriteLine("\n-----\nL'attaque adverse est réduite\n-----");
                            defender.Attack -= 10;
                            break;
                        case 2:
                            Console.WriteLine("\n-----\nLa défense adverse est réduite\n-----");
                            defender.Defense -= 10;
                            break;
                        case 3:
                            Console.WriteLine("\n-----\nL'attaque spéciale adverse est réduite\n-----");
                            defender.SpecialAttack -= 10;
                            break;
                        case 4:
                            Console.WriteLine("\n-----\nLa défense spéciale adverse est réduite\n-----");
                            defender.SpecialDefense -= 10;
                            break;
                        case 5:
                            Console.WriteLine("\n-----\nLa vitesse adverse est réduite\n-----");
                            defender.Speed -= 10;
                            break;
                    }



                    break;
            }

            Thread.Sleep(2000); // Pause for 2 seconds
        }
    }
}
