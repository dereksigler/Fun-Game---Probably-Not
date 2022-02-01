//  11/26/21 DS Added to Github
//  11/26/21 DS Added Menu Keys

using System;
using System.Timers;
using System.Collections.Generic;
namespace Fun_Game___Probably_Not
{
    class Program
    {
        public static Timer monsterTimer = new Timer(250);
        public static int floorNumber = 0;
        public static Player exit = new Player();
        public static Player treasure = new Player();
        public static Player playerA = new Player();
        public static Player enemy = new Player();
        public static Timer gametimer = new Timer(1000);
        public static List<Player> monster = new List<Player>();
        public static coordinate location = new coordinate();
        public static bool isAttacking = false;
        public static bool generateMonster = false;
        public static string swordDirection = "down";
        public static DateTime time = DateTime.Now;
        public static TimeSpan interval = TimeSpan.FromSeconds(1);


        public static void Main()
        {
            
            Map map = new Map();
            //playerA.name = "Bob";
            gametimer.AutoReset = true;
            gametimer.Enabled = true;
            gametimer.Start();
            map.MapGenerate();
            generateMonsters(monster, floorNumber, map);
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
            monsterTimer.AutoReset = true;
            //monsterTimer.Elapsed += movemonster;



            while (!exitKey)
            {
               

                Console.SetCursorPosition(0, 1);
                coordinate newpos = new coordinate();
                if (Console.KeyAvailable & isAttacking == false)
                {
                    var info = Console.ReadKey(true);
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
                            if (map.getLocation(newpos) == "open" || map.getLocation(newpos) == "exit" || map.getLocation(newpos) == "monster" || map.getLocation(newpos) == "treasure")
                            {
                                Console.SetCursorPosition(playerA.location.x, playerA.location.y);
                                Console.Write(" ");
                                map.setLocation("open", playerA.location);
                                Console.SetCursorPosition(newpos.x, newpos.y);
                                Console.Write(playerA.character);
                                map.setLocation(playerA.character, newpos);
                                playerA.location = newpos;
                                swordDirection = "up";
                            }
                            break;
                        case 'a':
                            Console.WriteLine("A was pressed");
                            newpos.x = playerA.location.x - 1;
                            newpos.y = playerA.location.y;
                            if (map.getLocation(newpos) == "open" || map.getLocation(newpos) == "exit" || map.getLocation(newpos) == "monster" || map.getLocation(newpos) == "treasure")
                            {
                                Console.SetCursorPosition(playerA.location.x, playerA.location.y);
                                Console.Write(" ");
                                map.setLocation("open", playerA.location);
                                Console.SetCursorPosition(newpos.x, newpos.y);
                                Console.Write(playerA.character);
                                map.setLocation(playerA.character, newpos);
                                playerA.location = newpos;
                                swordDirection = "left";
                            }
                            break;
                        case 's':
                            Console.WriteLine("S was pressed ");
                            newpos.x = playerA.location.x;
                            newpos.y = playerA.location.y + 1;
                            if (map.getLocation(newpos) == "open" || map.getLocation(newpos) == "exit" || map.getLocation(newpos) == "monster" || map.getLocation(newpos) == "treasure")
                            {
                                Console.SetCursorPosition(playerA.location.x, playerA.location.y);
                                Console.Write(" ");
                                map.setLocation("open", playerA.location);
                                Console.SetCursorPosition(newpos.x, newpos.y);
                                Console.Write(playerA.character);
                                map.setLocation(playerA.character, newpos);
                                playerA.location = newpos;
                                swordDirection = "down";
                            }
                            break;
                        case 'd':
                            Console.WriteLine("D was pressed ");
                            newpos.x = playerA.location.x + 1;
                            newpos.y = playerA.location.y;
                            if (map.getLocation(newpos) == "open" || map.getLocation(newpos) == "exit" || map.getLocation(newpos) == "monster" || map.getLocation(newpos) == "treasure")
                            {
                                Console.SetCursorPosition(playerA.location.x, playerA.location.y);
                                Console.Write(" ");
                                map.setLocation("open", playerA.location);
                                Console.SetCursorPosition(newpos.x, newpos.y);
                                Console.Write(playerA.character);
                                map.setLocation(playerA.character, newpos);
                                playerA.location = newpos;
                                swordDirection = "right";
                            }
                            break;
                        case 'l':
                            Console.WriteLine("L was pressed");
                            location = map.getLocation("open");
                            Console.SetCursorPosition(location.x, location.y);
                            Console.Write("X");
                            Console.SetCursorPosition(0, Console.WindowHeight - 1);
                            Console.Write("Valid open space at [{0},{1}]", location.x, location.y);
                            break;
                        case 'e':
                            if (isAttacking == true)
                            {
                                SwordSwing();
                            }
                            break;
                    }
                }
                
                if (map.foundTreasure == true)
                {
                    exit.location = map.getLocation("open");
                    map.setLocation(exit.character, exit.location);
                    Console.SetCursorPosition(exit.location.x, exit.location.y);
                    Console.Write(exit.character);
                    map.foundTreasure = false;

                    
                }
                if (map.foundExit == true)
                {
                    monster.Clear();
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
                    generateMonsters(monster, floorNumber, map);
                    map.foundExit = false;
                }

                if (DateTime.Now > time + interval) 
                {
                    moveMonsters(monster, map);
                    time = DateTime.Now;
                }

            }
        }

        // Specify what you want to happen when the Elapsed event is raised.
   

        private static void MyElapsedMethod()
        {
            
           // playerA.hp = playerA.hp - 2;
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

        public static void  generateMonsters(List<Player> monsters, int level, Map map)
        {
            for (int i = 0; i <= level; i++)
            {
                Player monster = new Player();
                monster.character = "M";
                monster.location = map.getLocation("open");
                map.setLocation(monster.character, monster.location);
                Console.SetCursorPosition(monster.location.x, monster.location.y);
                Console.Write(monster.character);
                monsters.Add(monster);
                

            }

        }
        public static void moveMonsters(List<Player> monsters, Map map)
        {

            for (int i = 0; i < monsters.Count; i++)
            {
                var rng = new Random();
                int direction = rng.Next(4);
                //1 = a    2 = w    3 = d    4 = s
                map.setLocation("open", monsters[i].location);
                Console.SetCursorPosition(monsters[i].location.x, monsters[i].location.y);
                Console.Write(" ");
                coordinate newpos = new coordinate();
                newpos.x = monsters[i].location.x;
                newpos.y = monsters[i].location.y;
                if (direction == 0)
                {
                    newpos.x = monsters[i].location.x - 1;
                    newpos.y = monsters[i].location.y;
                    if (map.getLocation(newpos) == "open")
                    {
                        monsters[i].location.x = monsters[i].location.x - 1;
                    }

                }
                if (direction == 1)
                {
                    newpos.x = monsters[i].location.x;
                    newpos.y = monsters[i].location.y + 1;
                    if (map.getLocation(newpos) == "open")
                    {
                        monsters[i].location.y = monsters[i].location.y + 1;
                    }
                }
                if (direction == 2)
                {
                    newpos.x = monsters[i].location.x + 1;
                    newpos.y = monsters[i].location.y;
                    if (map.getLocation(newpos) == "open")
                    {
                        monsters[i].location.x = monsters[i].location.x + 1;
                    }
                }
                if (direction == 3)
                {
                    newpos.x = monsters[i].location.x;
                    newpos.y = monsters[i].location.y - 1;
                    if (map.getLocation(newpos) == "open")
                    {
                        monsters[i].location.y = monsters[i].location.y - 1;
                    }
                }
                Console.SetCursorPosition(monsters[i].location.x, monsters[i].location.y);
                Console.Write(monsters[i].character);
                map.setLocation(monsters[i].character, monsters[i].location);

            }
        }
        public static void SwordSwing()
        {
            coordinate newpos = new coordinate();
            Map map = new Map();
            if (isAttacking == false)
            {
                switch (swordDirection)
                {
                    case "down":
                        newpos.x = playerA.location.x;
                        newpos.y = playerA.location.y + 1;
                        break;
                    case "up":
                        newpos.x = playerA.location.x;
                        newpos.y = playerA.location.y - 1;
                        break;
                    case "right":
                        newpos.x = playerA.location.x + 1;
                        newpos.y = playerA.location.y;
                        break;
                    case "left":
                        newpos.x = playerA.location.x - 1;
                        newpos.y = playerA.location.y;
                        break;
                }
            }
            if (map.getLocation(newpos) == "open" || map.getLocation(newpos) == enemy.character)
            {
                isAttacking = true;
                Console.SetCursorPosition(newpos.x, newpos.y);
                Console.Write('S');
                System.Threading.Thread.Sleep(500);
                Console.SetCursorPosition(newpos.x, newpos.y);
                Console.Write(' ');
                isAttacking = false;

            }
 

        }
    }
        
}
