using System;
using System.Collections.Generic;

namespace BlightnautsDialogue
{
    public static class ProjectManager
    {
        public class Actor
        {
            public readonly string ClassName;
            public readonly string RealName;
            public readonly int SkinIndex;
            public string IndexedName { get => ClassName.ToLower() + GetIndexString(SkinIndex); }
            private string GetIndexString(int index)
            {
                string result = "00";
                if (index > 9)
                {
                    result = "0";
                }
                else if (index > 99)
                {
                    result = string.Empty;
                }
                return result + index.ToString();
            }

            public Actor(string className, string realName)
            {
                ClassName = className;
                RealName = realName;
                SkinIndex = 1;
            }

            public Actor(string className, string realName, int skinIndex)
            {
                ClassName = className;
                RealName = realName;
                if (skinIndex < 2)
                    skinIndex = 999;
                SkinIndex = skinIndex;
            }
        }

        public readonly static Actor[] Characters = new Actor[]
        {
            new Actor("Assassin", "Penny Fox"),
            new Actor("Assassin", "Desperado Penny", 2),
            new Actor("Assassin", "Cheerleader Penny", 3),

            new Actor("Bird", "Vinnie & Spike"),
            new Actor("Bird", "Pirate Vinnie", 2),
            new Actor("Bird", "Cynical Vinnie", 3),

            new Actor("Blazer", "Coco Nebulon"),
            new Actor("Blazer", "Hawai Coco", 2),
            new Actor("Blazer", "Coco McFly", 3),
            new Actor("Blazer", "Cyber Coco", 4),
            new Actor("Blazer", "Wicked Coco", 5),

            new Actor("Blinker", "Nibbs"),
            new Actor("Blinker", "Battle Nibbs", 2),
            new Actor("Blinker", "Unicorn Nibbs", 3),

            new Actor("Boizor", "Max Focus"),
            new Actor("Boizor", "Malicious Max", 2),

            new Actor("Brute", "Skolldir"),
            new Actor("Brute", "Honeydew Skolldir", 2),
            new Actor("Brute", "Demon Skolldir", 3),
            new Actor("Brute", "Jotun Skolldir", 4),

            new Actor("Butterfly", "Genji"),
            new Actor("Butterfly", "Kage Genji", 2),
            new Actor("Butterfly", "Genji the Gray", 3),
            new Actor("Butterfly", "Grim Genji", 4),

            new Actor("Captain", "Admiral Swiggins"),
            new Actor("Captain", "Abyssal Swiggins", 2),
            new Actor("Captain", "Admiral Swiggins, PHD", 3),

            new Actor("Chameleon", "Leon Chameleon"),
            new Actor("Chameleon", "Leon Musketeer", 2),
            new Actor("Chameleon", "Leon Pirate", 3),
            new Actor("Chameleon", "Ghosts Leon", 4),

            new Actor("Commando", "Ted McPain"),
            new Actor("Commando", "Titanium Ted", 2),
            new Actor("Commando", "Party Boy McPain", 3),
            new Actor("Commando", "Captain McPain", 4),

            new Actor("Cowboy", "Sheriff Lonestar"),
            new Actor("Cowboy", "Officer Lonestar", 2),
            new Actor("Cowboy", "Private Mels", 3),
            new Actor("Cowboy", "Loninator", 4),

            new Actor("Crawler", "Ksenia"),
            new Actor("Crawler", "Huntres Ksenia", 2),

            new Actor("Crumple", "Deadlift"),
            new Actor("Crumple", "Bullbarian", 2),

            new Actor("Dasher", "Froggy G"),
            new Actor("Dasher", "Grand Master Splash", 2),
            new Actor("Dasher", "Pimpy G", 3),
            new Actor("Dasher", "Digital G", 4),

            new Actor("Ellipto", "Professor Yoolip"),
            new Actor("Ellipto", "Clockwork Yoolip", 2),
            new Actor("Ellipto", "8 bit Yoolip", 3),

            new Actor("Gantlet", "Qi'Tara"),
            new Actor("Gantlet", "Masquerade Qi'Tara", 2),

            new Actor("Gladiator", "Snork Gunk"),
            new Actor("Galdiator", "Bozo Gunk", 2),

            new Actor("Heavy", "Derpl Zork"),
            new Actor("Heavy", "Hotrod Derpl", 2),
            new Actor("Heavy", "Aarhpl", 3),

            new Actor("Hunter", "Raelynn"),
            new Actor("Hunter", "Ravishing Raelynn", 2),
            new Actor("Hunter", "Bionic Raelynn", 3),
            new Actor("Hunter", "Huntress Raelynn", 4),

            new Actor("Hyper", "Chucho Krokk"),
            new Actor("Hyper", "Skull-Chopper Chucho", 2),

            new Actor("Jetter", "Yuri"),
            new Actor("Jetter", "Astronaut Yuri", 2),
            new Actor("Jetter", "Double-O Yuri", 3),

            new Actor("Maw", "Gnaw"),
            new Actor("Maw", "Bumble Gnaw", 2),
            new Actor("Maw", "Gnabot", 3),
            new Actor("Maw", "Gnariachi", 4),

            new Actor("Paladin", "Scoop of Justice"),
            new Actor("Paladin", "Scoop of Doom", 2),
            new Actor("Paladin", "Roboscoop", 3),
            new Actor("Paladin", "FF7 Scoop", 4),
            new Actor("Paladin", "Helgo Scoop", 5),

            new Actor("Poacher", "Smiles"),
            new Actor("Poacher", "Pyromancer Smiles", 2),

            new Actor("Rascal", "Dizzy"),
            new Actor("Rascal", "Cringe Dizzy", 2),

            new Actor("Shaman", "Skree"),
            new Actor("Shaman", "Skreeletor", 2),
            new Actor("Shaman", "Cloud Skree", 3),

            new Actor("Shifter", "Ix the Interloper"),
            new Actor("Shifter", "Steel Seraph Ix", 2),

            new Actor("Spy", "Sentry"),
            new Actor("Spy", "Sentorii", 2),
            new Actor("Spy", "Setnry mosnter", 3),

            new Actor("Summoner", "Voltar the Omniscient"),
            new Actor("Summoner", "Disco Voltar", 2),
            new Actor("Summoner", "Aztec Voltar", 3),
            new Actor("Summoner", "Voltar Bonaparte", 4),

            new Actor("Tank", "Clunk"),
            new Actor("Tank", "Expendable Clunk", 2),
            new Actor("Tank", "Creeper Clunk", 3),
            new Actor("Tank", "Cluck", 4),

            new Actor("Vampire", "Ayla"),
            new Actor("Vampire", "Shaolin Ayla", 2),
            new Actor("Vampire", "Teddy Ayla", 3),
            new Actor("Vampire", "Commander Ayla", 4),

            new Actor("Wakuwaku", "Commander Rocket"),
            new Actor("Wakuwaku", "Commander Cook-it", 2),

            new Actor("Warrior", "Jimmy & the Lux5000"),
            new Actor("Warrior", "Sir Jimmy", 2),

            new Actor("Wozzle", "Rocco"),
            new Actor("Wozzle", "Shinobi Rocco", 2),
            new Actor("Wozzle", "Supersonic Rocco", 3)
    };

        public static Actor GetDefaultSkin(Actor actor)
        {
            foreach (Actor character in Characters)
            {
                if (character.ClassName == actor.ClassName && character.SkinIndex == 0)
                    return character;
            }
            return null;
        }

        public static string Path { get; private set; }
        public static List<Area> Areas { get; private set; }

        public static void LoadProject()
        {
            // No arguments for now.
            Areas = new List<Area>();
            Areas.Add(new Area("test_area"));
            Areas[0].GetCharacter("blinker001").SoloDialogue.Add(new Area.Dialogue
            (
                "ClementH doesn't like me :(",
                "IconCharacterBlinker",
                2,
                0
            ));
            Areas[0].GetCharacter("blinker001").TeamDialogue.Add(new Area.Dialogue
            (
                "If ClementH likes me one day, I still won't forgive him!",
                "IconCharacterBlinker",
                3,
                0
            ));
            Areas[0].GetCharacter("cowboy001").SoloDialogue.Add(new Area.Dialogue
            (
                "This be an interestin' experiment, partner! This fella right here's trying somethin' fancy with \"Delays\" or somethin'.",
                "IconCharacterCowboy",
                4,
                2
            ));
            Areas[0].GetCharacter("assassin001").SoloDialogue.Add(new Area.Dialogue
            (
                "Pah! You think that's interesting?! Then let me show you something much cooler!",
                "IconCharacterAssassin",
                4,
                0
            ));
            Areas[0].GetCharacter("assassin001").SoloDialogue.Add(new Area.Dialogue
            (
                "You see, my internal name has not one but two bad words in a row: Ass Ass In!",
                "IconCharacterAssassin",
                Convert.ToDecimal(3.5f),
                1
            ));
        }
    }
}
