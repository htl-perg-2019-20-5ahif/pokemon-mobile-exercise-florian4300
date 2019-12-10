using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonExplorer.Model
{
    public class PokemonResponse
    {
        public Pokemon[] Results { get; set; }
    }
    public class Pokemon
    {
        public String Name { get; set; }
        public String Url { get; set; }
    }
    public class PokemonDetails
    {
        public String Name { get; set; }
        public String Weight { get; set; }

        public AbilitySlot[] Abilities { get; set; }
        public Sprite Sprites { get; set; }
    }
    public class Sprite
    {
        public Uri front_default { get; set; }

        public Uri back_default { get; set; }
    }

    public class AbilitySlot
    {
        public Ability Ability { get; set; }
    }

    public class Ability
    {
        public String Name { get; set; }
    }
}
