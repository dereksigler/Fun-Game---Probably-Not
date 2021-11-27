//  11/26/21 DS Added to Github
//  11/26/21 DS Added Menu Keys

using System;
using System.Timers;
using System.Collections.Generic;
namespace Fun_Game___Probably_Not
{
    class Program
    {
        public static Player playerA = new Player();
        public static Timer gametimer = new Timer(1000);
        public static List<Player> monster = new List<Player>();
        public static Map map = new Map();
        public static void Main()
        {
            gametimer.Elapsed += MyElapsedMethod;
            gametimer.AutoReset = true;
            gametimer.Enabled = true;
            gametimer.Start();
            map.MapGenerate();
            Boolean exitKey = false;
            while (!exitKey)
            {
                var info = Console.ReadKey(true);
                Console.SetCursorPosition(0, 1);
                switch (info.KeyChar)
                 {
                    case 'q':
                        Console.WriteLine("q was pressed");
                        exitKey = true;
                        break;
                    case 'w':
                        Console.WriteLine("W was pressed");
                        break;
                    case 'a':
                        Console.WriteLine("A was pressed");
                        break;
                    case 's':
                        Console.WriteLine("S was pressed");
                        break;
                    case 'd':
                        Console.WriteLine("D was pressed");
                        break;
                    case 'l':
                        Console.WriteLine("L was pressed");
                        break;
                }
                
            }
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private static void MyElapsedMethod(object source, ElapsedEventArgs e)
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
        private static void drawScreen ()
        {
            Console.Clear();
            Console.WriteLine("HP left :{0}   MonsterCount:{1}", playerA.hp, monster.Count);
            for(int y=0; y < 50; y++) { 
                for (int x=0;x<200; x++)
                { Console.Write(" "); }
                Console.WriteLine(" ");                
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
