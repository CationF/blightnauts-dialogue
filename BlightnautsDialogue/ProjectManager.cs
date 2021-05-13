using System;
using System.IO;
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
            public bool UseDefaultSkin { get; set; }
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

            public void Reset()
            {
                if (SkinIndex == 1)
                    UseDefaultSkin = true;
                else
                    UseDefaultSkin = false;
            }

            public Actor(string className, string realName)
            {
                ClassName = className;
                RealName = realName;
                SkinIndex = 1;
                UseDefaultSkin = true;
            }

            public Actor(string className, string realName, int skinIndex)
            {
                ClassName = className;
                RealName = realName;
                if (skinIndex < 2)
                    skinIndex = 999;
                SkinIndex = skinIndex;
                UseDefaultSkin = false;
            }
        }

        public readonly static Actor[] Characters = new Actor[]
        {
            new Actor("Assassin", "Penny Fox"),
            new Actor("Assassin", "Desperado Penny", 2),
            new Actor("Assassin", "Cheerleader Penny", 3),

            new Actor("Bird", "Vinnie and Spike"),
            new Actor("Bird", "Cap'n Vinnie and Seadog Spike", 2),
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

        public static string FilePath { get; private set; }
        public static string ModPath { get; set; }
        public static List<Area> Areas { get; private set; }

        public static bool SaveFileExists { get => File.Exists(FilePath); }

        public static void NewProject()
        {
            FilePath = string.Empty;
            ModPath = string.Empty;
            Areas = new List<Area>();

            foreach (var actor in Characters)
            {
                actor.Reset();
            }
        }

        public static int SaveProject(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                return 1;
            }

            string content = string.Format
            (
                "[GLOBAL]\nMODDIRECTORY={0}\nUSEDEFAULTSKIN=",
                ModPath
            );

            foreach (Actor actor in Characters)
            {
                content += actor.UseDefaultSkin ? "1" : "0";
            }
            content += "\n\n\n";

            foreach (Area area in Areas)
            {
                content += SerializeArea(area) + "\n\n";
            }

            try
            {
                File.WriteAllText(path, content);
                FilePath = path;
            }
            catch
            {
                return 2;
            }
            return 0;
        }

        private static string SerializeArea(Area area)
        {
            string content = string.Format("[AREA]\nNAME={0}\nDIALOGUES={1}\n", area.Name, area.TeamDialogues);

            foreach (var naut in area.CharacterDialogue)
            {
                content += SerializeCharacter(naut, area);
            }

            return content;
        }

        private static string SerializeCharacter(Area.Character character, Area area)
        {
            bool empty = true;
            if (character.SoloDialogue.Count > 0)
                empty = false;
            for (int i = 0; i < area.TeamDialogues; i++)
            {
                if (character.TeamDialogues[i].Dialogues.Count > 0)
                {
                    empty = false;
                    break;
                }
            }

            if (empty)
                return string.Empty;

            string content = string.Format
            (
                "[CHARACTER]\nNAME={0}\n",
                character.Name
            );

            if (character.SoloDialogue.Count > 0)
            {
                content += string.Format
                (
                    "[SEQUENCE]\nCOUNT={0}\n",
                    character.SoloDialogue.Count
                );

                foreach (var dialogue in character.SoloDialogue)
                {
                    content += string.Format
                    (
                        "CONTENT={0}\nPORTRAIT={1}\nTEXTURE={2}\nVALUES={3};{4};{5}\n",
                        dialogue.Content,
                        dialogue.Portrait,
                        dialogue.Texture,
                        dialogue.Duration,
                        dialogue.Delay,
                        dialogue.GenerateAnimationTemplate ? "1" : "0"
                    );
                }
            }

            for (int i = 0; i < area.TeamDialogues; i++)
            {
                if (character.TeamDialogues[i].Dialogues.Count > 0)
                {
                    content += string.Format
                    (
                        "[SEQUENCE]\nCOUNT={0}",
                        character.TeamDialogues[i].Dialogues.Count
                    );

                    foreach (var dialogue in character.TeamDialogues[i].Dialogues)
                    {
                        content += string.Format
                        (
                            "{0}\n{1}\n{2}\n{3};{4};{5}",
                            dialogue.Content,
                            dialogue.Portrait,
                            dialogue.Texture,
                            dialogue.Duration,
                            dialogue.Delay,
                            dialogue.GenerateAnimationTemplate ? "1" : "0"
                        );
                    }
                }
            }

            return content;
        }

        public static int LoadProject(string path)
        {
            if (!File.Exists(path))
            {
                return 1;
            }

            string[] content = File.ReadAllLines(path);

            for (int i = 0; i < content.Length; i++)
            {
                string line = content[i];
                if (line.StartsWith("[GLOBAL]"))
                {
                    if (content[i + 1].StartsWith("MODDIRECTORY="))
                    {
                        ModPath = content[i + 1].Substring("MODDIRECTORY=".Length);
                    }
                    if (content[i + 2].StartsWith("USEDEFAULTSKIN="))
                    {
                        LoadUseDefaultSkin(content[i + 2].Substring("USEDEFAULTSKIN=".Length));
                    }
                }
            }

            return 0;
        }

        private static void LoadUseDefaultSkin(string content)
        {
            for (int i = 0; i < Characters.Length; i++)
            {
                if (content[i] == '1')
                {
                    Characters[i].UseDefaultSkin = true;
                }
                else
                {
                    Characters[i].UseDefaultSkin = false;
                }
            }
        }
    }
}
