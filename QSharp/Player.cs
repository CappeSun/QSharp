using System;

namespace QSharp
{
    public class Player
    {
        private Map map;
        public int x, y;
        public int[] inventory;
        public int movesCount;

        public Player(Map cMap)
        {
            map = cMap;
            
            x = 0;
            y = 0;
            
            inventory = new int[4];       //0: Stone, 1: Stick, 2: Pathway Stone, 3: Hammer

            movesCount = 0;
        }

        public void action()
        {
            char input = (Console.ReadLine()+"q").ToLower()[0];
            Console.Clear();
            switch (input)
            {
                case 'w':
                    move(0,-1);
                    break;
                case 's':
                    move(0,1);
                    break;
                case 'a':
                    move(-1,0);
                    break;
                case 'd':
                    move(1,0);
                    break;
                case 'i':
                    listInventory();
                    break;
                case 'c':
                    crafting();
                    break;
                case 'b':
                    breaking();
                    break;
                case 'p':
                    place();
                    break;
                case 'h':
                    help();
                    break;
                default:
                    Console.WriteLine("feck off");
                    break;
            }
        }

        private void move(int mX, int mY)
        {
            Console.WriteLine();
            
            if (x + mX < 0 || x + mX > 6 || y + mY < 0 || y + mY > 4)
            {
                return;
            }

            if (map.obstructed(mX, mY))
            {
                return;
            }

            map.item(mX, mY);

            x += mX;
            y += mY;
            
            movesCount++;
        }

        private void listInventory()
        {
            Console.Clear();
            Console.WriteLine($"(o) Stones: {inventory[0]}");
            Console.WriteLine($"(/) Sticks: {inventory[1]}");
            Console.WriteLine($"(0) Pathway Stones: {inventory[2]}");
            Console.WriteLine($"(p) Hammers: {inventory[3]}");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine();
        }

        private void crafting()
        {
            Console.WriteLine($"(o) Stones: {inventory[0]}");
            Console.WriteLine($"(/) Sticks: {inventory[1]}");
            Console.WriteLine($"(0) Pathway Stones [2]: {inventory[2]}. Craft using 1 stone and 1 stick.");
            Console.WriteLine($"(p) Hammers [3]: {inventory[3]}. Craft using 1 stone and 1 stick.");
            
            switch ((Console.ReadLine()+"q")[0])
            {
                case '0':
                    Console.Clear();
                    Console.WriteLine("Not craftable");
                    break;
                case '1':
                    Console.Clear();
                    Console.WriteLine("Not craftable");
                    break;
                case '2':
                    if (inventory[0] > 0 || inventory[1] > 0)
                    {
                        inventory[2]++;
                        inventory[0]--;
                        inventory[1]--;
                        
                        Console.Clear();
                        Console.WriteLine("Pathway stone crafted");
                        
                        movesCount++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enough items");
                    }
                    break;
                case '3':
                    if (inventory[0] > 0 || inventory[1] > 0)
                    {
                        inventory[3]++;
                        inventory[0]--;
                        inventory[1]--;
                        
                        Console.Clear();
                        Console.WriteLine("Hammer crafted");
                        
                        movesCount++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enough items");
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Not an item");
                    break;
            }
        }

        private void breaking()
        {
            Console.WriteLine($"(o) Stones: {inventory[0]}");
            Console.WriteLine($"(/) Sticks: {inventory[1]}");
            Console.WriteLine($"(0) Pathway Stones [2]: {inventory[2]}. Deconstruct into 1 stone and 1 stick.");
            Console.WriteLine($"(p) Hammers [3]: {inventory[3]}. Deconstruct into 1 stone and 1 stick.");
            
            switch ((Console.ReadLine()+"q")[0])
            {
                case '0':
                    Console.Clear();
                    Console.WriteLine("Not deconstructable");
                    break;
                case '1':
                    Console.Clear();
                    Console.WriteLine("Not deconstructable");
                    break;
                case '2':
                    if (inventory[2] > 0)
                    {
                        inventory[2]--;
                        inventory[0]++;
                        inventory[1]++;
                        
                        Console.Clear();
                        Console.WriteLine("Pathway stone deconstructed");
                        
                        movesCount++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enough");
                    }
                    break;
                case '3':
                    if (inventory[3] > 0)
                    {
                        inventory[3]--;
                        inventory[0]++;
                        inventory[1]++;
                        
                        Console.Clear();
                        Console.WriteLine("Hammer deconstructed");
                        
                        movesCount++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enough");
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Not an item");
                    break;
            }
        }

        private void place()
        {
            Console.WriteLine($"(o) Stones [0]: {inventory[0]}");
            Console.WriteLine($"(/) Sticks [1]: {inventory[1]}");
            Console.WriteLine($"(0) Pathway Stones [2]: {inventory[2]}");
            Console.WriteLine($"(p) Hammers [3]: {inventory[3]}");
            
            switch ((Console.ReadLine()+"q")[0])
            {
                case '0':
                    if (inventory[0] > 0)
                    {
                        map.mapData[map.currentRoom, y, x] = 'o';
                        inventory[0]--;
                        
                        Console.Clear();
                        Console.WriteLine("Stone placed");
                        
                        movesCount++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enough");
                    }
                    break;
                case '1':
                    if (inventory[1] > 0)
                    {
                        map.mapData[map.currentRoom, y, x] = '/';
                        inventory[1]--;
                        
                        Console.Clear();
                        Console.WriteLine("Stick placed");
                        
                        movesCount++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enough");
                    }
                    break;
                case '2':
                    if (inventory[2] > 0)
                    {
                        map.mapData[map.currentRoom, y, x] = '0';
                        inventory[2]--;
                        
                        Console.Clear();
                        Console.WriteLine("Pathway stone placed");
                        
                        movesCount++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enough");
                    }
                    break;
                case '3':
                    if (inventory[3] > 0)
                    {
                        map.mapData[map.currentRoom, y, x] = 'p';
                        inventory[3]--;
                        
                        Console.Clear();
                        Console.WriteLine("Hammer placed");
                        
                        movesCount++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enough");
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Not an item");
                    break;
            }
        }

        private void help()
        {
            Console.Clear();
            Console.WriteLine("Use [WSAD] to move, [I] to list your inventory, [C] to craft and item, [B] to deconstruct and item, [P] to place an item and finally [H] to bring up this text again.");
        }
    }
}