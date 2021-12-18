//  11/26/21 DS Added to Github
//  11/26/21 DS Added Menu Keys

using System;
using System.Timers;
using System.Collections.Generic;
namespace Fun_Game___Probably_Not
{
    class Program
    {
        public static int floorNumber = 0;
        public static Player exit = new Player();
        public static Player treasure = new Player();
        public static Player playerA = new Player();
        public static Player enemy = new Player();
        public static Timer gametimer = new Timer(1000);
        public static List<Player> monster = new List<Player>();
        public static coordinate location = new coordinate();
        public static bool generateMonster = false;
        
        public static void Main()
        {
            
            Map map = new Map();
            //playerA.name = "Bob";
            gametimer.AutoReset = true;
            gametimer.Enabled = true;
            gametimer.Start();
            map.MapGenerate();
            playerA.character = "☺";
            treasure.character = "T";
            exit.character = "O";
            enemy.character = "M";
            playerA.location = map.getLocation("open");
            map.setLocation(playerA.character, playerA.location);
            Console.SetCursorPosition(playerA.location.x, playerA.location.y);
            Console.Write(playerA.character);
            map.setLocation(playerA.character, playerA.location);
            Boolean exitKey = false;
            treasure.location = map.getLocation("open");
            map.setLocation(treasure.character, treasure.location);
            Console.SetCursorPosition(treasure.location.x, treasure.location.y);
            Console.Write(treasure.character);
           
            while (!exitKey)
            {
                var info = Console.ReadKey(true);
                Console.SetCursorPosition(0, 1);
                coordinate newpos = new coordinate();
                switch (info.KeyChar)
                 {
                    case 'q':
                        Console.WriteLine("q was pressed");
                        exitKey = true;
                        break;
                    case 'w':
                        Console.WriteLine("W was pressed");
                        newpos.x = playerA.location.x;
                        newpos.y = playerA.location.y - 1;
                        if (map.getLocation(newpos) == "open" || map.getLocation(newpos) == "exit")
                        {
                            Console.SetCursorPosition(playerA.location.x, playerA.location.y);
                            Console.Write(" ");
                            map.setLocation("open", playerA.location);
                            Console.SetCursorPosition(newpos.x, newpos.y);
                            Console.Write(playerA.character);
                            map.setLocation(playerA.character, newpos);
                            playerA.location = newpos;
                        }
                        break;
                    case 'a':
                        Console.WriteLine("A was pressed");
                        newpos.x = playerA.location.x - 1;
                        newpos.y = playerA.location.y;
                        if (map.getLocation(newpos) == "open" || map.getLocation(newpos) == "exit")
                        {
                            Console.SetCursorPosition(playerA.location.x, playerA.location.y);
                            Console.Write(" ");
                            map.setLocation("open", playerA.location);
                            Console.SetCursorPosition(newpos.x, newpos.y);
                            Console.Write(playerA.character);
                            map.setLocation(playerA.character, newpos);
                            playerA.location = newpos;
                            
                        }
                        break;
                    case 's':
                        Console.WriteLine("S was pressed ");
                        newpos.x = playerA.location.x;
                        newpos.y = playerA.location.y + 1;
                        if (map.getLocation(newpos) == "open" || map.getLocation(newpos) == "exit")
                        {
                            Console.SetCursorPosition(playerA.location.x, playerA.location.y);
                            Console.Write(" ");
                            map.setLocation("open", playerA.location);
                            Console.SetCursorPosition(newpos.x, newpos.y);
                            Console.Write(playerA.character);
                            map.setLocation(playerA.character, newpos);
                            playerA.location = newpos;
                        }
                        break;
                    case 'd':
                        Console.WriteLine("D was pressed ");
                        newpos.x = playerA.location.x + 1;
                        newpos.y = playerA.location.y;
                        if (map.getLocation(newpos) == "open" || map.getLocation(newpos) == "exit")
                        {
                            Console.SetCursorPosition(playerA.location.x, playerA.location.y);
                            Console.Write(" ");
                            map.setLocation("open", playerA.location);
                            Console.SetCursorPosition(newpos.x, newpos.y);
                            Console.Write(playerA.character);
                            map.setLocation(playerA.character, newpos);
                            playerA.location = newpos;
                        }
                    break;
                    case 'l':
                        Console.WriteLine("L was pressed");
                        location = map.getLocation("open");
                        Console.SetCursorPosition(location.x, location.y);
                        Console.Write("X");  
                        Console.SetCursorPosition(0, Console.WindowHeight-1);
                        Console.Write("Valid open space at [{0},{1}]", location.x, location.y);
                        break;
                }
                
                if (map.foundTreasure == true)
                {
                    exit.location = map.getLocation("open");
                    map.setLocation(exit.character, exit.location);
                    Console.SetCursorPosition(exit.location.x, exit.location.y);
                    Console.Write(exit.character);
                    map.foundTreasure = false;

                    
                }
                if (generateMonster == true)
                {
                    MyElapsedMethod();
                    generateMonster = false;
                }
                if (map.foundExit == true)
                {
                    Console.Clear();
                    Console.WriteLine("GG Level Clear");
                    floorNumber++;
                    Console.WriteLine("Floor:{0}", floorNumber);
                    System.Threading.Thread.Sleep(2000);
                    map.MapGenerate();
                    gametimer.AutoReset = true;
                    gametimer.Enabled = true;
                    gametimer.Start();
                    map.MapGenerate();
                    playerA.character = "☺";
                    treasure.character = "T";
                    exit.character = "O";
                    playerA.location = map.getLocation("open");
                    map.setLocation(playerA.character, playerA.location);
                    Console.SetCursorPosition(playerA.location.x, playerA.location.y);
                    Console.Write(playerA.character);
                    map.setLocation(playerA.character, playerA.location);
                    treasure.location = map.getLocation("open");
                    map.setLocation(treasure.character, treasure.location);
                    Console.SetCursorPosition(treasure.location.x, treasure.location.y);
                    Console.Write(treasure.character);
                    map.foundExit = false;

                }

            }
        }

        // Specify what you want to happen when the Elapsed event is raised.
        public static void GenerateMonsters()
        {
            Map map = new Map();
            while(floorNumber > 0)
            {
                enemy.location = map.getLocation("open");
                map.setLocation(enemy.character, enemy.location);
                Console.SetCursorPosition(enemy.location.x, enemy.location.y);
                Console.Write(enemy.character);
            }
        }

        private static void MyElapsedMethod()
        {
            
            playerA.hp = playerA.hp - 2;
 //           Console.WriteLine("HP left :{0}   MonsterCount:{1}", playerA.hp, monster.Count);
            //create random number
            //if matches 1 or something generate monster  (add monster)
            var rand = new Random();
            Console.SetCursorPosition(0, 0);
            Console.Write("████████████████████████");
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Random : {0}\t Monster Count:{1}", rand.Next(15), monster.Count);
            if (monster.Count < 10)
            {


                if (rand.Next(15) == 1 )
                {
//                    Console.WriteLine("Oh no! A monster appeared!");
                    Player tempMonster = new Player();
                    monster.Add(tempMonster);

                }
            }

        }


        private static void locationmap()
        {
            int x= 0;
            int y =0;
            char tile;
            gametimer.Stop();
            Console.SetCursorPosition(0, 0);
            Console.Write("████████████████████████");
            Console.SetCursorPosition(0, 0);
            Console.Write("X:");
        //    x = (Int32.Parse(Console.ReadLine()));
            Console.Write("████████████████████████");
            Console.SetCursorPosition(0, 0);
            Console.Write("Y:");
       //     y = (Int32.Parse(Console.ReadLine()));
            Console.Write("████████████████████████");
            Console.SetCursorPosition(0, 0);
            Console.Write("Checking location[{0},{1}]", x, y);
            gametimer.Start();

        }

    }
}
