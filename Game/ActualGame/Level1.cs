
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActualGame
{
    internal class Level1 : Level
    {
        public Level1(ScreenSquare Start, int offSet, ContentManager Content, int cash, int Lives)
            : base(Start, offSet, Content, cash, Lives)
        {
            Enemies.AddAZombie(0, Start, offSet, Content);
        }
       
    }
}
