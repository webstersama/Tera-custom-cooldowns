﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tera.Game;
using Tera.Game.Messages;

namespace TCC.Parsing.Messages
{
    public class S_ABNORMALITY_REFRESH : ParsedMessage
    {
        ulong target;
        uint id;
        int duration, stacks;

        public ulong TargetId { get => target; }
        public uint AbnormalityId { get => id; }
        public int Duration { get => duration; }
        public int Stacks { get => stacks; }

        public S_ABNORMALITY_REFRESH(TeraMessageReader reader) : base(reader)
        {
            target = reader.ReadUInt64();
            id = reader.ReadUInt32();
            duration = reader.ReadInt32();
            reader.Skip(4);
            stacks = reader.ReadInt32();
        }
    }
}
