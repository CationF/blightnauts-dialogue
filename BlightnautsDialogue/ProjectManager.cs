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

            new Actor("Bird", "Vinnie and Spike"),
            new Actor("Bird", "Cap'n Vinnie & Seadog Spike", 2),
            new Actor("Bird", "Cynical Vinnie and Total Spike", 3),

            new Actor("Blazer", "Coco Nebulon"),
            new Actor("Blazer", "Coco Hawaii", 2),
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
            new Actor("Brute", "Jotunn Skolldir", 4),

            new Actor("Butterfly", "Genji"),
            new Actor("Butterfly", "Kage Genji", 2),
            new Actor("Butterfly", "Genji the Grey", 3),
            new Actor("Butterfly", "Grim Genji", 4),

            new Actor("Captain", "Admiral Swiggins"),
            new Actor("Captain", "Abyssal Swiggins", 2),
            new Actor("Captain", "Admiral Swiggins, PHD", 3),

            new Actor("Chameleon", "Leon Chameleon"),
            new Actor("Chameleon", "Mousquetaire Leon", 2),
            new Actor("Chameleon", "Pirate Leon", 3),
            new Actor("Chameleon", "Ghost Leon", 4),
            new Actor("Chameleon", "Leon Legionnaire", 5),

            new Actor("Commando", "Ted McPain"),
            new Actor("Commando", "Titanium Ted", 2),
            new Actor("Commando", "Party Boy McPain", 3),
            new Actor("Commando", "Scourge Capitain McPain", 4),

            new Actor("Cowboy", "Sheriff Lonestar"),
            new Actor("Cowboy", "Officer Lonestar", 2),
            new Actor("Cowboy", "Private Mels", 3),
            new Actor("Cowboy", "The Loninator", 4),
            new Actor("Cowboy", "Goldstar", 5),

            new Actor("Crawler", "Ksenia"),
            new Actor("Crawler", "Dragon Huntress Ksenia", 2),
            new Actor("Crawler", "Cosmic Captain Ksenia", 3),

            new Actor("Crumple", "Deadlift"),
            new Actor("Crumple", "Bullbarian Deadlift", 2),

            new Actor("Dasher", "Froggy G"),
            new Actor("Dasher", "Grandmaster Splash", 2),
            new Actor("Dasher", "Pimpy G", 3),
            new Actor("Dasher", "Digital G", 4),

            new Actor("Ellipto", "Professor Yoolip"),
            new Actor("Ellipto", "Clockwork Yoolip", 2),
            new Actor("Ellipto", "8 bit Yoolip", 3),

            new Actor("Gantlet", "Qi'Tara"),
            new Actor("Gantlet", "Dark Masquerade Qi'Tara", 2),

            new Actor("Gladiator", "Snork Gunk"),
            new Actor("Galdiator", "Bozo Gunk", 2),

            new Actor("Heavy", "Derpl Zork"),
            new Actor("Heavy", "Hotrod Derpl", 2),
            new Actor("Heavy", "Ahrpl", 3),

            new Actor("Hunter", "Raelynn"),
            new Actor("Hunter", "Ravishing Raelynn", 2),
            new Actor("Hunter", "Bionic Raelynn", 3),
            new Actor("Hunter", "Soulhuntress Raelynn", 4),

            new Actor("Hyper", "Chucho Krokk"),
            new Actor("Hyper", "Skull Chopper Chucho", 2),
            new Actor("Hyper", "Summertime Chucho", 3),

            new Actor("Jetter", "Yuri"),
            new Actor("Jetter", "Kosmonaut Yuri", 2),
            new Actor("Jetter", "Double-O-Yuri", 3),

            new Actor("Maw", "Gnaw"),
            new Actor("Maw", "Bumble Gnaw", 2),
            new Actor("Maw", "Gnabot", 3),
            new Actor("Maw", "Gnariachi", 4),

            new Actor("Paladin", "Scoop of Justice"),
            new Actor("Paladin", "Wraithlord Scoop", 2),
            new Actor("Paladin", "Roboscoop", 3),
            new Actor("Paladin", "Bravely Scoop IV: Eternal Fantasy", 4),
            new Actor("Paladin", "Helgo Scoop", 5),

            new Actor("Poacher", "Smiles"),
            new Actor("Poacher", "Pyromancer Smiles", 2),

            new Actor("Rascal", "Dizzy"),
            new Actor("Rascal", "Kunoichi Dizzy", 2),

            new Actor("Shaman", "Skree"),
            new Actor("Shaman", "Skreeletor", 2),
            new Actor("Shaman", "Sun Wukong Skree", 3),

            new Actor("Shifter", "Ix the Interloper"),
            new Actor("Shifter", "Steel Seraph Ix", 2),

            new Actor("Spy", "Sentry X-58"),
            new Actor("Spy", "Giga Sentorii", 2),
            new Actor("Spy", "Specimen X-58", 3),

            new Actor("Summoner", "Voltar the Omniscient"),
            new Actor("Summoner", "Disco Voltar", 2),
            new Actor("Summoner", "Necro Voltar", 3),
            new Actor("Summoner", "Voltar Bonaparte", 4),

            new Actor("Tank", "Clunk"),
            new Actor("Tank", "Expendable Clunk", 2),
            new Actor("Tank", "Creeper Clunk", 3),
            new Actor("Tank", "Cluck Clunk", 4),

            new Actor("Vampire", "Ayla"),
            new Actor("Vampire", "Shaolin Ayla", 2),
            new Actor("Vampire", "Teddy Ayla", 3),
            new Actor("Vampire", "Augmented Ayla", 4),

            new Actor("Wakuwaku", "Commander Rocket"),
            new Actor("Wakuwaku", "Commander Cook-it", 2),

            new Actor("Warrior", "Jimmy and the Lux5000"),
            new Actor("Warrior", "Sir Jimmy Lionheart", 2),

            new Actor("Wozzle", "Rocco"),
            new Actor("Wozzle", "Shinobi Rocco", 2),
            new Actor("Wozzle", "Electronic Supersonic Cybertronic Rocco", 3)
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
            Areas.Add(new Area("test_area", 1));
            Areas[0].GetCharacter("blinker001").SoloDialogue.Add(new Area.Dialogue
            (
                "ClementH doesn't like me :(",
                "IconCharacterBlinker",
                2,
                0
            ));
            Areas[0].GetCharacter("blinker001").TeamDialogues[0].Dialogues.Add(new Area.Dialogue
            (
                "If ClementH ever likes me, I'll give him an egg... not!",
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
