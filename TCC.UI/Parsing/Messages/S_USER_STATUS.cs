﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tera.Game;
using Tera.Game.Messages;

namespace TCC.UI
{
    public class S_USER_STATUS : ParsedMessage
    {
        public bool isInCombat;
        public ulong id;

        public S_USER_STATUS(TeraMessageReader reader) : base(reader)
        {
            id = reader.ReadUInt64();
            if(reader.ReadInt32() == 1)
            {
                isInCombat = true;
                Console.WriteLine("Combat");
            }
            else
            {
                isInCombat = false;
                Console.WriteLine("Out of combat");
            }
        }
    }
}