using System.Collections.Generic;

namespace BlightnautsDialogue
{
    public class Area
    {
        public string Name;
        public readonly int TeamDialogues;
        public Character[] CharacterDialogue { get; private set; }
        public bool Repeatable { get; set; }
        public bool Interruptable { get; set; }
        public Character GetCharacter(string name)
        {
            foreach (var character in CharacterDialogue)
            {
                if (character.Name.ToLower() == name.ToLower())
                    return character;
            }
            return null;
        }
        public static float GetTotalDuration(Dialogue[] dialogues)
        {
            float result = 0;
            foreach (Dialogue dialogue in dialogues)
            {
                result += dialogue.Duration + dialogue.Delay;
            }
            return result;
        }
        public static float GetStartTime(Dialogue dialogue, Dialogue[] dialogueArray)
        {
            float result = 0;
            foreach (var item in dialogueArray)
            {
                if (item == dialogue)
                    return result + dialogue.Delay;

                result += item.Duration + item.Delay;
            }
            return -1;
        }
        public static float GetDurationFromStartEnd(float start, float end)
        {
            return end - start;
        }

        public static float GetEndTime(Dialogue dialogue, Dialogue[] dialogueArray)
        {
            return GetStartTime(dialogue, dialogueArray) + dialogue.Duration;
        }

        public class Character
        {
            public readonly string Name;
            public readonly List<Dialogue> SoloDialogue;
            public readonly TeamDialogue[] TeamDialogues;
            public class TeamDialogue
            {
                public readonly List<Dialogue> Dialogues;

                public TeamDialogue()
                {
                    Dialogues = new List<Dialogue>();
                }
            }

            public Character(string name, int teamDialogues)
            {
                Name = name;
                SoloDialogue = new List<Dialogue>();
                TeamDialogues = new TeamDialogue[teamDialogues];
                for (int i = 0; i < TeamDialogues.Length; i++)
                {
                    TeamDialogues[i] = new TeamDialogue();
                }
            }
        }

        public class Dialogue
        {
            public string Portrait, Texture, Content;
            public float Duration, Delay;
            public bool GenerateAnimationTemplate { get; set; }

            public Dialogue()
            {
                Portrait = string.Empty;
                Texture = string.Empty;
                Content = string.Empty;
                Duration = 0;
                Delay = 0;
                GenerateAnimationTemplate = true;
            }

            public Dialogue(string portrait)
            {
                Portrait = portrait;
                Texture = string.Empty;
                Content = string.Empty;
                Duration = 0;
                Delay = 0;
                GenerateAnimationTemplate = true;
            }

            public Dialogue(string portrait, string texture)
            {
                Portrait = portrait;
                Texture = texture;
                Content = string.Empty;
                Duration = 0;
                Delay = 0;
                GenerateAnimationTemplate = true;
            }

            public Dialogue(string content, string portrait, string texture, float duration, float delay)
            {
                Portrait = portrait;
                Texture = texture;
                Content = content;
                Duration = duration;
                Delay = delay;
                GenerateAnimationTemplate = true;
            }

            public Dialogue(string content, string portrait, string texture, float duration, float delay, bool generateAnimationTemplate)
            {
                Portrait = portrait;
                Texture = texture;
                Content = content;
                Duration = duration;
                Delay = delay;
                GenerateAnimationTemplate = generateAnimationTemplate;
            }
        }

        public Area(string name, int teamDialogues)
        {
            Name = name;
            if (teamDialogues < 1)
                teamDialogues = 1;
            TeamDialogues = teamDialogues;
            CharacterDialogue = new Character[ProjectManager.Characters.Length];
            for (int i = 0; i < CharacterDialogue.Length; i++)
            {
                CharacterDialogue[i] = new Character(ProjectManager.Characters[i].IndexedName, TeamDialogues);
            }
        }
    }
}
