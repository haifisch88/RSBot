﻿using System.Collections.Generic;

namespace RSBot.Core.Client.ReferenceObjects
{
    public class RefMagicOptAssign : IReference
    {
        #region Fields

        public byte Race;
        public byte TypeId3;
        public byte TypeId4;
        public List<string> AvailableMagicOptions;

        #endregion Fields

        #region Methods

        public bool Load(ReferenceParser parser)
        {
            if (parser == null) return false;

            parser.TryParseByte(1, out Race);
            parser.TryParseByte(2, out TypeId3);
            parser.TryParseByte(3, out TypeId4);

            AvailableMagicOptions = new List<string>(80);
            for (var i = 4; i < parser.GetColumnCount(); i++)
            {
                if (parser.TryParseString(i, out var option))
                    AvailableMagicOptions.Add(option);
            }

            AvailableMagicOptions.RemoveAll(m => string.IsNullOrEmpty(m) || m == "xxx");

            return true;
        }

        #endregion Methods
    }
}