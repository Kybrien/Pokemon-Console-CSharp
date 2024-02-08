﻿using System;
using System.Reflection.Metadata.Ecma335;
using LoadingScreen;

namespace Display
{
    public class Map
    {
        public static char[,] ChangeMap(char[,] carte)
        {
            char[,] newMap = carte;
            return newMap;
        }

        static bool AreEqual(char[,] array1, char[,] array2)
        {
            if (array1.GetLength(0) != array2.GetLength(0) || array1.GetLength(1) != array2.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    if (array1[i, j] != array2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void AfficherCarte(char[,] carte)
        {
            for (int i = 0; i < carte.GetLength(0); i++)
            {
                for (int j = 0; j < carte.GetLength(1); j++)
                {
                    if (i == Program.posY && j == Program.posX)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("O ");
                    }
                    else
                    {
                        // Couleur marron pour les murs
                        if (carte[i, j] == '#')
                        {
                            if (Program.currentMapIndex == 0 || Program.currentMapIndex == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            else if (Program.currentMapIndex == 2 || Program.currentMapIndex == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                        }
                        // Couleur verte pour les hautes herbes
                        else if (carte[i, j] == 'H')
                        {
                            if (Program.currentMapIndex == 0 || Program.currentMapIndex == 1 || Program.currentMapIndex == 2 || Program.currentMapIndex == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            
                        }
                        else if (carte[i, j] == '►' || carte[i, j] == '◄')
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (carte[i, j] == '~')
                        {
                            if (Program.currentMapIndex == 0 || Program.currentMapIndex == 1 ||Program.currentMapIndex == 2 || Program.currentMapIndex == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            }
                        }
                        else if (carte[i, j] == '┼')
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        else if (carte[i, j] == '*')
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (carte[i, j] == '[' || carte[i, j] == '=' || carte[i, j] == ']')
                        {
                            if (Program.currentMapIndex == 0 || Program.currentMapIndex == 1 || Program.currentMapIndex == 2 || Program.currentMapIndex == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }

                        }
                        else
                        {
                            Console.ResetColor();
                        }

                        Console.Write(carte[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }

            // On reset la couleur
            Console.ResetColor();
        }
        public static void ChangeMap()
        {
            ResetPlayerPosition();
            switch (Program.currentMapIndex)
            {
                case 0:
                    Program.currentMap = Map.InitMap1();
                    Console.WriteLine(Program.currentMapIndex);
                    break;
                case 1:
                    Program.currentMap = Map.InitMap2();
                    Console.WriteLine(Program.currentMapIndex);
                    break;
                case 2:
                    Program.currentMap = Map.InitMap3();
                    Console.WriteLine(Program.currentMapIndex);
                    break;
                case 3:
                    Program.currentMap = Map.InitMap4();
                    Console.WriteLine(Program.currentMapIndex);
                    break;
                case 4:
                    Program.currentMap = Map.InitMap5();
                    Console.WriteLine(Program.currentMapIndex);
                    break;
                case 5:
                    Program.currentMap = Map.InitMap6();
                    Console.WriteLine(Program.currentMapIndex);
                    break;
            }
            
            Map.AfficherCarte(Program.currentMap); // Afficher la nouvelle carte
        }

        private static void ResetPlayerPosition()
        {
            if (Program.currentMap[Program.posY, Program.posX] == '►')
            {
                Program.posX = 1;
                Program.posY = 9;
            }
            else if (Program.currentMap[Program.posY, Program.posX] == '◄')
            {
                Program.posX = 18;
                Program.posY = 9;
            }
        }

        public static char[,] InitMap1()
        {
            char[,] carte =
            {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', '~', '~', '~', 'H', ' ', 'H', '#', ' ', ' ', ' ', ' ', '#', 'H', 'H', '~', '~', '~', '~', '#'},
            {'#', '~', '~', 'H', 'H', ' ', 'H', '#', 'H', 'H', ' ', ' ', '#', 'H', 'H', 'H', '~', '~', '~', '#'},
            {'#', '~', 'H', 'H', ' ', ' ', 'H', '#', '#', '#', ' ', ' ', '#', ' ', 'H', 'H', '~', '~', '~', '#'},
            {'#', 'H', 'H', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'H', 'H', '#', '~', ' ', '#'},
            {'#', 'H', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'H', '#', ' ', '┼', '#'},
            {'#', ' ', ' ', ' ', '#', ' ', 'H', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#'},
            {'#', ' ', ' ', '#', '#', ' ', 'H', 'H', 'H', 'H', 'H', 'H', 'H', ' ', ' ', ' ', '#', 'H', 'H', '#'},
            {'#', ' ', ' ', 'H', '#', ' ', 'H', 'H', 'H', 'H', '┼', 'H', 'H', ' ', ' ', ' ', '#', 'H', 'H', '#'},
            {'#', ' ', 'H', 'H', '#', ' ', ' ', 'H', 'H', 'H', 'H', 'H', 'H', ' ', ' ', ' ', '#', ' ', ' ', '►'},
            {'#', ' ', 'H', 'H', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '►'},
            {'#', ' ', 'H', 'H', '#', ' ', '#', 'H', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', '#', 'H', 'H', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', '#', 'H', 'H', 'H', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', 'H', 'H', ' ', '#', '#', '#', '#', 'H', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', '~', '~', '~', 'H', 'H', '#', ' ', '┼', '#', '~', '~', ' ', '#', '#', '#', '#', ' ', ' ', '#'},
            {'#', '~', '~', '~', '~', '~', '~', ' ', 'H', '#', '~', '~', ' ', 'H', 'H', 'H', 'H', ' ', ' ', '#'},
            {'#', '~', '~', '~', '~', '~', '~', ' ', ' ', '#', '~', '~', ' ', 'H', 'H', 'H', 'H', ' ', ' ', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };

            return carte;
        }
        public static char[,] InitMap2()
        {
            Loading_Screen.Big_Woods();
            char[,] carte =
            {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', 'H', 'H', 'H', 'H', 'H', '#', 'H', 'H', '#', '#', '#', '#', '~', '~', '~', '~', '~', '~', '#'},
            {'#', 'H', 'H', 'H', 'H', '┼', '#', ' ', ' ', 'H', 'H', '#', '#', 'H', 'H', 'H', '~', '~', '~', '#'},
            {'#', 'H', 'H', '#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', 'H', 'H', '~', '~', '#'},
            {'#', 'H', 'H', 'H', 'H', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'H', 'H', '~', '#'},
            {'#', 'H', 'H', 'H', 'H', ' ', ' ', ' ', ' ', ' ', ' ', 'H', 'H', ' ', ' ', ' ', ' ', 'H', 'H', '#'},
            {'#', '#', 'H', 'H', ' ', ' ', ' ', ' ', ' ', 'H', 'H', 'H', 'H', ' ', ' ', ' ', '#', ' ', 'H', '#'},
            {'#', 'H', 'H', ' ', ' ', ' ', ' ', ' ', '#', '#', 'H', 'H', 'H', ' ', ' ', ' ', '#', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', '~', '#', '#', '#', '┼', 'H', 'H', ' ', '#', '#', '#', ' ', ' ', '#'},
            {'◄', ' ', ' ', ' ', ' ', '~', '~', '~', '#', '#', '#', 'H', 'H', ' ', ' ', 'H', '#', '#', ' ', '►'},
            {'◄', ' ', ' ', ' ', ' ', ' ', '~', '~', '~', '#', '#', 'H', ' ', ' ', ' ', 'H', '#', ' ', ' ', '►'},
            {'#', 'H', ' ', ' ', ' ', ' ', ' ', '~', '~', '~', '~', 'H', ' ', ' ', 'H', 'H', '#', 'H', ' ', '#'},
            {'#', 'H', 'H', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'H', 'H', '#', 'H', 'H', '#'},
            {'#', 'H', 'H', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '~', 'H', '#', 'H', 'H', '#'},
            {'#', 'H', 'H', 'H', ' ', '#', '#', '#', ' ', '#', '#', ' ', ' ', ' ', '~', '~', '#', '#', '#', '#'},
            {'#', 'H', 'H', 'H', ' ', ' ', ' ', ' ', ' ', '#', 'H', 'H', 'H', ' ', ' ', '~', '~', '~', '~', '#'},
            {'#', '~', 'H', 'H', 'H', ' ', ' ', ' ', ' ', '#', 'H', 'H', 'H', 'H', ' ', ' ', '~', '~', 'H', '#'},
            {'#', '~', '~', 'H', 'H', 'H', ' ', ' ', 'H', '#', 'H', 'H', 'H', 'H', ' ', ' ', '~', 'H', '┼', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };

            return carte;
        }
        public static char[,] InitMap3()
        {
            Loading_Screen.Sipra_Beach();
            char[,] carte =
            {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', '~', '~', 'H', 'H', 'H', '┼', 'H', 'H', 'H', 'H', 'H', '~', '~', '~', '~', '~', 'H', 'H', '#'},
            {'#', '~', '~', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', '~', '~', '~', '~', '~', '~', '~', 'H', '#'},
            {'#', '~', '~', '~', 'H', 'H', 'H', 'H', 'H', 'H', '~', '~', '~', '~', '~', '~', '~', '~', '~', '#'},
            {'#', '~', '~', '~', '~', 'H', 'H', 'H', 'H', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '#'},
            {'#', '~', '~', '~', '~', '~', 'H', 'H', '~', '~', '~', '~', '~', '~', 'H', 'H', 'H', '~', '~', '#'},
            {'#', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', 'H', 'H', 'H', '~', '#'},
            {'#', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', '~', '~', '~', '~', '~', '~', '~', '~', 'H', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'◄', ' ', ' ', ' ', '~', '~', '~', '~', '~', '~', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '►'},
            {'◄', ' ', ' ', ' ', ' ', ' ', '~', '~', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '►'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '~', '~', '#'},
            {'#', '~', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '~', '~', '~', '~', '~', '#'},
            {'#', '~', '~', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'H', '~', '~', '~', '~', '~', 'H', '#'},
            {'#', '~', '~', '~', 'H', 'H', ' ', ' ', ' ', 'H', 'H', 'H', '~', '~', '~', '~', '~', 'H', 'H', '#'},
            {'#', '~', '~', '~', '~', 'H', 'H', 'H', 'H', 'H', 'H', '~', '~', '~', '~', '~', 'H', 'H', 'H', '#'},
            {'#', 'H', '~', '~', '~', '~', 'H', 'H', '┼', 'H', '~', '~', '~', '~', '~', 'H', 'H', '┼', 'H', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };

            return carte;
        }
        public static char[,] InitMap4()
        {
            Loading_Screen.Oykot_Beach();
            char[,] carte =
            {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', '~', '~', '~', '~', '~', ' ', 'H', 'H', 'H', 'H', '~', '~', '~', '~', '~', '~', '~', '~', '#'},
            {'#', '~', '~', '~', '~', ' ', ' ', ' ', 'H', 'H', 'H', '~', '~', '~', '~', '~', '~', '~', 'H', '#'},
            {'#', '~', '~', '~', ' ', ' ', ' ', ' ', ' ', 'H', '~', '~', '~', '~', '~', '~', '~', ' ', 'H', '#'},
            {'#', '~', '~', ' ', ' ', ' ', ' ', ' ', ' ', '~', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', '#'},
            {'#', '~', ' ', ' ', 'H', 'H', ' ', ' ', ' ', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', 'H', '#'},
            {'#', ' ', ' ', 'H', '┼', 'H', ' ', ' ', '~', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', ' ', '#'},
            {'#', ' ', ' ', 'H', 'H', ' ', ' ', ' ', '~', '~', '┼', '~', '~', '~', '~', 'H', 'H', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', '~', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', ' ', ' ', '#'},
            {'◄', ' ', ' ', ' ', ' ', ' ', '~', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', ' ', ' ', ' ', '►'},
            {'◄', ' ', ' ', ' ', ' ', '~', '~', '~', '~', '~', '~', '~', '~', '~', 'H', ' ', ' ', ' ', ' ', '►'},
            {'#', ' ', ' ', ' ', '[', '=', '=', '=', '=', '=', '=', '=', ']', 'H', ' ', ' ', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', 'H', 'H', 'H', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '~', '#'},
            {'#', ' ', ' ', ' ', ' ', 'H', 'H', 'H', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '~', '~', '#'},
            {'#', ' ', 'H', '[', '=', '=', '=', '=', '=', '=', ']', ' ', ' ', ' ', ' ', ' ', '~', '~', '~', '#'},
            {'#', 'H', '~', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', ' ', ' ', ' ', '~', '~', '~', '~', '#'},
            {'#', '~', '~', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', 'H', 'H', '~', '~', '~', '~', '~', '#'},
            {'#', '~', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', 'H', '┼', '~', '~', '~', '~', '~', '~', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };

            return carte;
        }
        public static char[,] InitMap5()
        {
            Loading_Screen.Lava_Fields();
            char[,] carte = 
            {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', 'H', 'H', 'H', '#'},
            {'#', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', 'H', 'H', '┼', 'H', '#'},
            {'#', 'H', 'H', 'H', '[', '=', '=', '=', '=', '=', '=', '=', ']', 'H', 'H', 'H', 'H', 'H', 'H', '#'},
            {'#', 'H', 'H', 'H', 'H', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'H', 'H', 'H', ' ', ' ', 'H', 'H', '#'},
            {'#', 'H', 'H', 'H', 'H', '[', '=', '=', '=', '=', '=', ']', 'H', 'H', ' ', ' ', ' ', ' ', 'H', '#'},
            {'#', 'H', 'H', 'H', 'H', 'H', '~', '~', '~', '~', '~', 'H', 'H', 'H', ' ', ' ', ' ', ' ', 'H', '#'},
            {'#', 'H', ' ', ' ', 'H', 'H', '~', '~', '~', '~', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', ' ', ' ', ' ', ' ', 'H', 'H', '~', '~', '~', '#', '#', '#', ' ', ' ', ' ', ' ', 'H', 'H', '#'},
            {'◄', ' ', ' ', ' ', ' ', ' ', 'H', 'H', '~', 'H', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', 'H', '►'},
            {'◄', ' ', ' ', ' ', ' ', ' ', ' ', 'H', 'H', 'H', '#', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', '►'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'H', ' ', '#', ' ', ' ', '#', 'H', 'H', ' ', ' ', ' ', '#'},
            {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '┼', 'H', ' ', ' ', ' ', '#'},
            {'#', 'H', 'H', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', 'H', 'H', ' ', ' ', ' ', '#'},
            {'#', 'H', 'H', 'H', 'H', ' ', ' ', ' ', ' ', ' ', '#', ' ', '~', '~', '#', 'H', ' ', ' ', '~', '#'},
            {'#', 'H', 'H', 'H', 'H', 'H', ' ', ' ', ' ', ' ', '#', '~', '~', '~', '#', 'H', 'H', '~', '~', '#'},
            {'#', '~', '┼', 'H', 'H', 'H', 'H', ' ', ' ', ' ', '#', '#', '~', '~', '#', 'H', 'H', '~', '#', '#'},
            {'#', '~', '~', 'H', 'H', 'H', 'H', 'H', 'H', 'H', '#', '#', '#', '~', '#', 'H', 'H', '#', '#', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };

            return carte;
        }
        public static char[,] InitMap6()
        {
            Loading_Screen.Lava_Core();
            char[,] carte =
            {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', ' ', ' ', '#', 'H', 'H', 'H', '~', '~', '~', '~', 'H', 'H', '┼', 'H', '~', '~', '~', '~', '#'},
            {'#', ' ', '#', 'H', 'H', 'H', 'H', '~', '~', '~', '~', 'H', 'H', 'H', 'H', '~', '~', '~', '~', '#'},
            {'#', ' ', '#', ' ', 'H', 'H', '~', '~', '~', '~', '~', '~', '~', 'H', '~', '~', '~', '~', '~', '#'},
            {'#', ' ', '#', ' ', ' ', 'H', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '#'},
            {'#', ' ', ' ', ' ', '#', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '#'},
            {'#', ' ', ' ', ' ', '#', '~', '~', '~', '#', 'H', '~', '~', '~', '~', '~', '~', '~', '~', '#', '#'},
            {'#', ' ', ' ', ' ', '#', '~', '~', '~', '#', 'H', '~', '~', '~', '~', '~', '~', '~', '#', 'H', '#'},
            {'#', ' ', ' ', ' ', '#', '~', '~', '#', 'H', 'H', '~', '~', '~', '~', '~', '~', '#', 'H', 'H', '#'},
            {'◄', ' ', ' ', ' ', '#', '~', '~', '#', 'H', 'H', 'H', '~', '~', '~', '~', '~', '#', 'H', '┼', '#'},
            {'◄', ' ', ' ', ' ', '#', '~', '~', '#', '┼', 'H', 'H', 'H', '~', '~', '~', '#', 'H', 'H', 'H', '#'},
            {'#', ' ', ' ', ' ', '#', '~', '~', '~', '#', '#', '#', '#', '~', '~', '~', 'H', 'H', 'H', 'H', '#'},
            {'#', '#', ' ', ' ', '#', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', '~', 'H', 'H', 'H', '#'},
            {'#', '#', '#', 'H', '#', '~', '~', '~', '~', '~', '~', '~', '~', '#', '~', '~', '~', '~', 'H', '#'},
            {'#', '#', 'H', 'H', 'H', '#', '~', '~', '~', '~', '~', '~', '#', 'H', 'H', '~', '~', '~', '~', '#'},
            {'#', 'H', 'H', '┼', 'H', 'H', '~', '~', '~', '~', '~', '~', '#', 'H', 'H', 'H', '#', '~', '~', '#'},
            {'#', 'H', 'H', 'H', 'H', 'H', 'H', '~', '~', '~', '~', '#', 'H', 'H', 'H', '#', 'H', 'H', '~', '#'},
            {'#', 'H', 'H', 'H', 'H', 'H', 'H', '~', '~', '~', '~', '#', 'H', 'H', '┼', '#', 'H', 'H', 'H', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };
            return carte;
        }
    }

    public class Menu
    {
        public static void main_menu()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine("║          Menu          ║");
            Console.WriteLine("╠════════════════════════╣");
            Console.WriteLine("║ 1.  Lancer             ║");
            Console.WriteLine("║ 2.  Supprimer Partie   ║");
            Console.WriteLine("║ 2.  Difficulte         ║");
            Console.WriteLine("║ 3.  Quitter            ║");
            Console.WriteLine("╚════════════════════════╝");
        }

        public static void difficulty_menu()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine("║       Difficulte       ║");
            Console.WriteLine("╠════════════════════════╣");
            Console.WriteLine("║ 1.  Facile             ║");
            Console.WriteLine("║ 2.  Moyen              ║");
            Console.WriteLine("║ 3.  Difficile          ║");
            Console.WriteLine("║ 4.  --RETOUR--         ║");
            Console.WriteLine("╚════════════════════════╝");
        }
        public static void ShowLoadingScreen(string message, int durationMilliseconds)
        {
            Console.Clear();
            Console.WriteLine(message);

            Thread.Sleep(durationMilliseconds);
        }
    }
    public class TextDisplay
    {
        // Fonction pour afficher progressivement du texte dans la console
        public static void Sleeping(string text, int delayMilliseconds)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMilliseconds); // Attendre avant d'afficher le prochain caractère
            }
        }
    }

    
}

// ▲     ┌─┐ ┴  ┤
//◄ ►    │ │        ┼
// ▼     └─┘ ┬  ├