using System.Collections.Generic;

namespace BlightnautsDialogue
{
    public class Area
    {
        public string Name;
        public Character[] CharacterDialogue { get; private set; }
        public Character GetCharacter(string name)
        {
            foreach (var character in CharacterDialogue)
            {
                if (character.Name.ToLower() == name.ToLower())
                    return character;
            }
            return null;
        }
        public static decimal GetTotalDuration(Dialogue[] dialogues)
        {
            decimal result = 0;
            foreach (Dialogue dialogue in dialogues)
            {
                result += dialogue.Duration + dialogue.Delay;
            }
            return result;
        }
        public static decimal GetStartTime(Dialogue dialogue, Dialogue[] dialogueArray)
        {
            decimal result = 0;
            foreach (var item in dialogueArray)
            {
                if (item == dialogue)
                    return result + dialogue.Delay;

                result += dialogue.Duration + dialogue.Delay;
            }
            return -1;
        }

        public static decimal GetEndTime(Dialogue dialogue, Dialogue[] dialogueArray)
        {
            return GetStartTime(dialogue, dialogueArray) + dialogue.Duration;
        }

        public class Character
        {
            public readonly string Name;
            public readonly List<Dialogue> SoloDialogue;
            public readonly List<Dialogue> TeamDialogue;

            public Character(string name)
            {
                Name = name;
                SoloDialogue = new List<Dialogue>();
                TeamDialogue = new List<Dialogue>();
            }
        }

        public class Dialogue
        {
            public string Portrait, Content;
            public decimal Duration, Delay;

            public Dialogue()
            {
                Portrait = string.Empty;
                Content = string.Empty;
                Duration = 0;
                Delay = 0;
            }

            public Dialogue(string content, string portrait, decimal duration, decimal delay)
            {
                Portrait = portrait;
                Content = content;
                Duration = duration;
                Delay = delay;
            }
        }

        public Area(string name)
        {
            Name = name;
            CharacterDialogue = new Character[ProjectManager.Characters.Length];
            for (int i = 0; i < CharacterDialogue.Length; i++)
            {
                CharacterDialogue[i] = new Character(ProjectManager.Characters[i].IndexedName);
            }
        }
    }
}
