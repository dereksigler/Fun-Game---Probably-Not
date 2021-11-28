// 11/27/21 HS Added multiple deminsional array

using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fun_Game___Probably_Not
{

    

	class Map
	{
		    
			static Random Rng;

			public static string[,] chart = new string[Console.WindowWidth,Console.WindowHeight];

             public void MapGenerate()
			{
				// Settings
				const int MINROOMS = 3;
				const int MAXROOMS = 7;
				const int MINROOMSIZE = 3;
				const int MAXROOMSIZE = 10;

				// Init
				Console.CursorVisible = false;
				Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);
				Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

				Rng = new Random();

				FillScreen('█');

				// Random rooms
				var rooms = new List<Rect>();
				var nrrooms = Rng.Next(MINROOMS, MAXROOMS);
				for (int i = 0; i < nrrooms; i++)
				{
					int width = Rng.Next(MINROOMSIZE, MAXROOMSIZE);
					int height = Rng.Next(MINROOMSIZE, MAXROOMSIZE);
					int x = Rng.Next(0, Console.WindowWidth - width - 1);
					int y = Rng.Next(0, Console.WindowHeight - height - 1);

					var rect = new Rect(x, y, width, height);
					rooms.Add(rect);
				}

				for (int r = 0; r < rooms.Count; r++)
				{
					FillRect(rooms[r], ' ');

					if (r == 0) continue;

					int previousRoomCenterX = rooms[r - 1].CenterX;
					int previousRoomCenterY = rooms[r - 1].CenterY;
					int currentRoomCenterX = rooms[r].CenterX;
					int currentRoomCenterY = rooms[r].CenterY;

					if (Rng.Next(0, 2) == 0)
					{
						HorizontalTunnel(previousRoomCenterX, currentRoomCenterX, previousRoomCenterY);
						VerticalTunnel(previousRoomCenterY, currentRoomCenterY, currentRoomCenterX);
					}
					else
					{
						VerticalTunnel(previousRoomCenterY, currentRoomCenterY, previousRoomCenterX);
						HorizontalTunnel(previousRoomCenterX, currentRoomCenterX, currentRoomCenterY);
					}
				}

				//Console.ReadKey();
			}

			static void FillScreen(char c)
			{
				for (int top = 0; top < Console.WindowHeight; top++)
				{
					string line = string.Empty;
					for (int left = 0; left < Console.WindowWidth; left++)
					{
					    chart[left, top] = "wall";
						line += c;
					}

					Console.SetCursorPosition(0, top);
					Console.Write(line);
				}
			}

			static void FillRect(Rect r, char c)
			{
				Console.SetCursorPosition(r.Left, r.Top);

				for (int top = r.Top; top < r.Top + r.Height; top++)
				{
					for (int left = r.Left; left < r.Left + r.Width; left++)
					{
						chart[left, top] = "open";
						Console.SetCursorPosition(left, top);
						Console.Write(c);
					}
				}
			}

			static void HorizontalTunnel(int xStart, int xEnd, int y)
			{
				for (int x = Math.Min(xStart, xEnd); x <= Math.Max(xStart, xEnd); x++)
				{
					chart[x, y] = "open";
					Console.SetCursorPosition(x, y);
					Console.Write(' ');
				}
			}

			static void VerticalTunnel(int yStart, int yEnd, int x)
			{
				for (int y = Math.Min(yStart, yEnd); y <= Math.Max(yStart, yEnd); y++)
				{
					chart[x, y] = "open";
					Console.SetCursorPosition(x, y);
					Console.Write(' ');
				}
			}
		}

		public class Rect
		{
			public int Left { get; set; }
			public int Top { get; set; }
			public int Width { get; set; }
			public int Height { get; set; }
			public int CenterX { get { return (Left + (Width / 2)); } }
			public int CenterY { get { return (Top + (Height / 2)); } }

			public Rect(int l, int t, int w, int h)
			{
				Left = l;
				Top = t;
				Width = w;
				Height = h;
			}
		}
	}


