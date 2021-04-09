using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        public FirePotion()
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health -= 20;
                if (character.Health == 0)
                {
                    character.IsAlive = false;
                }
            }
            else
            {
                base.AffectCharacter(character);
            }
        }
    }
}
