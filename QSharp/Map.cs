using System;

namespace QSharp
{
    public class Map
    {
        public int currentRoom;
        public char[,,] mapData;

        public Player player;

        public Map()
        {
            player = new Player(this);
            
            currentRoom = 0;
            mapData = new char[,,]
            {
                {
                    { '#', '#', '#', '#', '#', '#', '#' },
                    { '#', '#', 'X', 'X', 'X', '#', '#' },
                    { '#', '#', '#', '0', 'X', '#', '#' },
                    { '#', '#', 'X', 'X', 'X', '#', '#' },
                    { '#', '#', '#', '#', '#', '#', '#' }
                },
                {
                    { '#', '#', '#', '#', '#', '#', '#' },
                    { '#', '#', 'X', 'X', 'X', '#', '#' },
                    { '#', '#', 'o', '#', 'X', '/', '#' },
                    { '#', '#', '#', '#', 'X', '#', '#' },
                    { '#', '#', '#', '#', '#', '#', '#' }
                },
                {
                    { '#', '#', '#', '#', '#', '#', '#' },
                    { '#', '#', '#', '#', '#', '#', '#' },
                    { '#', '#', '#', '#', '#', '#', '#' },
                    { '#', '#', '#', '#', 'p', '#', '#' },
                    { '#', '#', '#', '#', '#', '#', '#' }
                }
            };
        }
        
        public void render()
        {
            char[,] renderData = new char[5,7];
            for (int i = 0; i < 5; i++)
            {
                for (int ii = 0; ii < 7; ii++)
                {
                    renderData[i,ii] = mapData[currentRoom,i,ii];
                }
            }

            renderData[player.y, player.x] = 'Q';
            
            for (int i = 0; i < 5; i++)
            {
                for (int ii = 0; ii < 7; ii++)
                {
                    Console.Write(renderData[i,ii]);
                }
                Console.WriteLine();
            }
        }

        public bool obstructed(int x, int y)
        {
            if (mapData[currentRoom, player.y + y, player.x + x] == 'X')
            {
                return true;
            }

            return false;
        }

        public void item(int x, int y)
        {
            switch (mapData[currentRoom, player.y + y, player.x + x])
            {
                case '0':
                    currentRoom++;
                    break;
                case 'o':
                    player.inventory[0]++;
                    mapData[currentRoom, player.y + y, player.x + x] = '#';
                    break;
                case '/':
                    player.inventory[1]++;
                    mapData[currentRoom, player.y + y, player.x + x] = '#';
                    break;
                case 'p':
                    player.inventory[3]++;
                    mapData[currentRoom, player.y + y, player.x + x] = '#';
                    break;
            }
        }
    }
}