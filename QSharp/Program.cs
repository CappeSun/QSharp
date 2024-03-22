﻿using System;

namespace QSharp
{
    internal class Program
    {
        public static void Main()
        {
            Map map = new Map();
            Player player = map.player;
            
            Console.Clear();
            Console.WriteLine("Welcome to QSharp, a port of Q which I wrote in c++ as an exercise.");
            Console.WriteLine("Press [ENTER] to continue...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Your task is to solve the three levels.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Use [WSAD] to move, [I] to list your inventory, [C] to craft an item, [B] to deconstruct an item, [P] to place an item and finally [H] to bring up this text again.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Now then, let's begin!");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine();
            
            while (map.currentRoom < 3)
            {
                Console.WriteLine($"Room {map.currentRoom}");
                map.render();
                player.action();
            }
            Console.WriteLine("\n\n                                                                                                             \n                                                                                                             \n                                     %*+=====+*#*                                                            \n                                  #+======*#                                                                 \n                                *======+%                                                                    \n                              *======*                                                                       \n                             *======#                                                                        \n                            *=====+                                                                          \n                            +=====#                                     %**++==++++***##                     \n                            =====+                                 #++==========+*#                          \n                            +====+                             #+============#                               \n                            %+====#                  *=+    *============+*                                  \n                              +===+                #+===+%*============*                                     \n                               *+===               +======+=========+#                                       \n                                  #+=*          *##========+===========**                                    \n                                     ##%++=================++==============+*#                               \n                                 #*=========================+===================*                            \n                             %*+=============================*===================::=#                        \n                           #+=======+=========================#==================-::::=                      \n                         *========+============================+===============++-:::::::+                   \n                       %+========+:===============+============*================::=::::::::=                 \n                      *========+-::===============#=*===========*=========-:::::::::-::::::::*               \n                     #========+:::::::===========+:=*======--:::-:::::=:::::::::::::::+*-::::::*             \n                    *========+::::::::::::-=====+=:+=========+====+====+-::::::::::::::-#  *=:::=            \n                   #=========::::::-:::::-========:*=+=======**==+:+===++=========-::::::*     +::#          \n                   +=======-::::::=-====+======+:-:==*=======*#==+::+===*======+==========#       =          \n                  #========::-===*====++======+:-::-+*=======*#+=+-::+===*======++=========#                 \n                  +======*======*====+*======+::-:::++=======*%+===+::+==+======+*+========+                 \n                 %======*======++===**+=====+:::=:::+=+======*:*=*+::::+==*======#**========*                \n                 *=====+======**===**#*++*++:::::::::+*======*::+=*:::::+=*+=====+***========                \n                 *=====+=====***==+**+====+-::=*:::::=*=====+*:::=+:::::===*======****+======*               \n                 *====+=====***==+***=====-::::-:=:::-#=====+::::==::::::==#+=====#****+======               \n                 #====+====****=+***+====+::::::::::::+=====+::::=*====-:-+**=====#**%**+=====#              \n                  +==+====*=**#=****====*:::::=:::::::=+====-:::+@@@@@@@@@@+*=====****#**+====*              \n                  +++*===*==***+***+===*::::::-:::::::=+===+:::::%%%%%%::-+=#=====****# **====+              \n                  :::::+*===**+****===+=:::::-::::::::-+===:::::*######:.+:-++====#***#  **===+*             \n                 #::::::*===*#+****==+#::::::::::::::::+==+:::::#####+#:.=:-#*====****#   #+===%             \n                 *::::::-===*******==**=:::::::::::::::+=+::::::*.+#*=#.=::+**===*#***#    #+==%             \n                  :::::-====******+=*#**:-:::::::::::::++-::::::..+*-+*.:::***===*#***#     *==%             \n                  +::---====*-#***++*#**@@@@@@@@*::::::+=::::::::#---#..::+***+=+  ***#      #=%             \n                   :==::=+=+::****++****:::::::=@@@%+::+:::::::::+####::::****+=*  #**        *%             \n                  +::::::::*::*****#**#*===-**=:::::::::::::::::::::::::+:*****+#  #**                       \n                +:::::::::::-:-**********:::::::::::::::::::::=:::::::::::****#+    *#                       \n               :::::::::::-+*-:********#*:::::::::::::::::::::::::::::::::****##    ##                       \n              -:::::::=:::::::=***+******+::::::::::::::::-*++:::::::::::****+#      %                       \n              -::::-::::::::::=#*#+=****#*:::::::::::::=----=*::::::::-******=*                              \n              =::::::::::::-+-:*#**=+****#+::::::::::::=----+::::::-**#*****++#                              \n              -:::::::::=::::::-%**+=+****#***=:::::::::::::::::+*****#*****-+                               \n              #::::::::::::::::=****===****%**#---==+*+==-=+#*******#******+=+                               \n               =::::::::::::::+::=*##===****#**#=-----==#**#**#****#*******==+                               \n                =::::::::::=::::::=*++===****#**#*---===+#*##*****#**#****===+                               \n                 +::::::::::::::::-:**+===+***#***#==-=-=--+***#**=**#***+=-=*                               \n                  #-::::::::::::=....:*+====***%#**##-----==+#*****:##***====*                               \n                 %#::-:::::::::........:+====+**#****#++-----:.*****+#**+====#                               \n                 #::::::::::::*..........*=====+*#***##*---:...:****##*+====+                                \n                *:::::::::::-*:*:.........-=-====+#******:......*******=====+                                \n               #:::::::::::::-*+*.......-...+======*******.......*****+=====#                                \n              #:::::::::::::-::*:*......:-...=======#******......+****=====+.#                               \n              =:::::::::::::=::*-*.......::...:+=====*******:....:***+=====*:.+                              \n\n");
            Console.WriteLine($"gjob! ({player.movesCount} moves)");
        }
    }
}