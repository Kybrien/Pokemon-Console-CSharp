﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using Display;
using SaveEditor;
using InputLoader;
using SoundLoader;
using CombatLoader;

class Program
{
    public static bool quit = false;
    public static int posX = 8;
    public static int posY = 1;
    public static char[,] currentMap = { };
    public static int currentMapIndex = 0;
    public static int NumberOfItem = 0;

    static void Main()
    {
        InitializeConsole();

        // Initialiser la carte actuelle
        currentMap = Map.InitMap1();
        currentMapIndex = 0;
        Save.LoadGame();

        do
        {
            Console.Clear();
            Menu.main_menu();

            Console.Write("Choisissez une option (1-5): ");
            char choice = Console.ReadKey().KeyChar;

            Input.ProcessChoice(choice, currentMap);

        } while (!quit);
    }

    static void InitializeConsole()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.WindowWidth = 60;
            Console.WindowHeight = 20;
        }
    }

    public static void PlayGame()
    {
        Map.AfficherCarte(currentMap);
        Sound.ChangeMusicBasedOnMap(currentMapIndex);

        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            Input.MovePlayer(keyInfo, currentMap);
            Console.Clear();
            Map.AfficherCarte(currentMap);

            if (Combat.APokemonRencontre)
            {
                Combat.AfficherCapacitesJoueur(new Combat.Pokemon("", "", 0, 0, 0, 0, 0, 0, new List<Combat.Capacite>()));
                int choixAttaque = Combat.DemanderChoixCapacite(0);
                // Faites quelque chose avec le choix d'attaque, par exemple, appliquer des dégâts à l'adversaire
            }


        } while (keyInfo.Key != ConsoleKey.Escape);

    }


    public static void PickUpItem(char[,] carte)
    {
        Console.WriteLine("\nAppuyez sur la touche 'E' pour ramasser l'objet ->");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.E)
        {
            Console.WriteLine("\nVous avez ramassé l'objet.");
            carte[posY, posX] = '*';
        }
    }

}