using BlightnautsDialogue;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Legacy
{
    public static class LegacyLoader
    {
        private static bool AreasValid
        {
            get
            {
                if (ProjectManager.Areas[0].Name.ToLower() != "intro" || ProjectManager.Areas[0].TeamDialogues != 3)
                    return false;
                else if (ProjectManager.Areas[1].Name.ToLower() != "obelisk" || ProjectManager.Areas[1].TeamDialogues != 2)
                    return false;
                else if (ProjectManager.Areas[2].Name.ToLower() != "spitblight" || ProjectManager.Areas[2].TeamDialogues != 2)
                    return false;
                else if (ProjectManager.Areas[3].Name.ToLower() != "key1" || ProjectManager.Areas[3].TeamDialogues != 1)
                    return false;
                else if (ProjectManager.Areas[4].Name.ToLower() != "turret" || ProjectManager.Areas[4].TeamDialogues != 2)
                    return false;
                else if (ProjectManager.Areas[5].Name.ToLower() != "water" || ProjectManager.Areas[5].TeamDialogues != 1)
                    return false;
                else if (ProjectManager.Areas[6].Name.ToLower() != "treasure" || ProjectManager.Areas[6].TeamDialogues != 1)
                    return false;
                else if (ProjectManager.Areas[7].Name.ToLower() != "key2" || ProjectManager.Areas[7].TeamDialogues != 1)
                    return false;
                else if (ProjectManager.Areas[8].Name.ToLower() != "switches" || ProjectManager.Areas[8].TeamDialogues != 2)
                    return false;
                else if (ProjectManager.Areas[9].Name.ToLower() != "bottom" || ProjectManager.Areas[9].TeamDialogues != 2)
                    return false;
                else if (ProjectManager.Areas[10].Name.ToLower() != "sawpuzzle" || ProjectManager.Areas[10].TeamDialogues != 2)
                    return false;
                else if (ProjectManager.Areas[11].Name.ToLower() != "sawtrap" || ProjectManager.Areas[11].TeamDialogues != 1)
                    return false;
                else if (ProjectManager.Areas[12].Name.ToLower() != "finalintro" || ProjectManager.Areas[12].TeamDialogues != 3)
                    return false;
                else if (ProjectManager.Areas[13].Name.ToLower() != "finalshield" || ProjectManager.Areas[13].TeamDialogues != 1)
                    return false;
                return true;
            }
        }

        public static int Load(string path, int character)
        {
            if (!File.Exists(path))
                return 2;

            if (ProjectManager.Areas.Count < 12 || !AreasValid)
                return 3;

            string[] file = File.ReadAllLines(path);
            List<Area.Dialogue>[] areas = new List<Area.Dialogue>[38];
            areas[0] = ProjectManager.Areas[0].CharacterDialogue[character].SoloDialogue;                   // Intro_Solo
            areas[1] = ProjectManager.Areas[0].CharacterDialogue[character].TeamDialogues[0].Dialogues;     // Intro_Team
            areas[2] = ProjectManager.Areas[0].CharacterDialogue[character].TeamDialogues[1].Dialogues;     // Intro2_Team
            areas[3] = ProjectManager.Areas[0].CharacterDialogue[character].TeamDialogues[2].Dialogues;     // Intro3_Team
            areas[4] = ProjectManager.Areas[1].CharacterDialogue[character].SoloDialogue;                   // Obelisk_Solo
            areas[5] = ProjectManager.Areas[1].CharacterDialogue[character].TeamDialogues[0].Dialogues;     // Obelisk_Team
            areas[6] = ProjectManager.Areas[1].CharacterDialogue[character].TeamDialogues[1].Dialogues;     // Obelisk2_Team
            areas[7] = ProjectManager.Areas[2].CharacterDialogue[character].SoloDialogue;                   // Spitblight_Solo
            areas[8] = ProjectManager.Areas[2].CharacterDialogue[character].TeamDialogues[0].Dialogues;     // Spitblight_Team
            areas[9] = ProjectManager.Areas[2].CharacterDialogue[character].TeamDialogues[1].Dialogues;     // Spitblight2_Team
            areas[10] = ProjectManager.Areas[3].CharacterDialogue[character].SoloDialogue;                  // Key1_Solo
            areas[11] = ProjectManager.Areas[3].CharacterDialogue[character].TeamDialogues[0].Dialogues;    // Key1_Team
            areas[12] = ProjectManager.Areas[4].CharacterDialogue[character].SoloDialogue;                  // Turret_Solo
            areas[13] = ProjectManager.Areas[4].CharacterDialogue[character].TeamDialogues[0].Dialogues;    // Turret_Team
            areas[14] = ProjectManager.Areas[4].CharacterDialogue[character].TeamDialogues[1].Dialogues;    // Turret2_Team
            areas[15] = ProjectManager.Areas[5].CharacterDialogue[character].SoloDialogue;                  // Water_Solo
            areas[16] = ProjectManager.Areas[5].CharacterDialogue[character].TeamDialogues[0].Dialogues;    // Water_Team
            areas[17] = ProjectManager.Areas[6].CharacterDialogue[character].SoloDialogue;                  // Treasure_Solo
            areas[18] = ProjectManager.Areas[6].CharacterDialogue[character].TeamDialogues[0].Dialogues;    // Treasure_Team
            areas[19] = ProjectManager.Areas[7].CharacterDialogue[character].SoloDialogue;                  // Key2_Solo
            areas[20] = ProjectManager.Areas[7].CharacterDialogue[character].TeamDialogues[0].Dialogues;    // Key2_Team
            areas[21] = ProjectManager.Areas[8].CharacterDialogue[character].SoloDialogue;                  // Switches_Solo
            areas[22] = ProjectManager.Areas[8].CharacterDialogue[character].TeamDialogues[0].Dialogues;    // Switches_Team
            areas[23] = ProjectManager.Areas[8].CharacterDialogue[character].TeamDialogues[1].Dialogues;    // Switches2_Team
            areas[24] = ProjectManager.Areas[9].CharacterDialogue[character].SoloDialogue;                  // Bottom_Solo
            areas[25] = ProjectManager.Areas[9].CharacterDialogue[character].TeamDialogues[0].Dialogues;    // Bottom_Team
            areas[26] = ProjectManager.Areas[9].CharacterDialogue[character].TeamDialogues[1].Dialogues;    // Bottom2_Team
            areas[27] = ProjectManager.Areas[10].CharacterDialogue[character].SoloDialogue;                 // SawPuzzle_Solo
            areas[28] = ProjectManager.Areas[10].CharacterDialogue[character].TeamDialogues[0].Dialogues;   // SawPuzzle_Team
            areas[29] = ProjectManager.Areas[10].CharacterDialogue[character].TeamDialogues[1].Dialogues;   // SawPuzzle2_Team
            areas[30] = ProjectManager.Areas[11].CharacterDialogue[character].SoloDialogue;                 // SawTrap_Solo
            areas[31] = ProjectManager.Areas[11].CharacterDialogue[character].TeamDialogues[0].Dialogues;   // SawTrap_Team
            areas[32] = ProjectManager.Areas[12].CharacterDialogue[character].SoloDialogue;                 // FinalIntro_Solo
            areas[33] = ProjectManager.Areas[12].CharacterDialogue[character].TeamDialogues[0].Dialogues;   // FinalIntro_Team
            areas[34] = ProjectManager.Areas[12].CharacterDialogue[character].TeamDialogues[1].Dialogues;   // FinalIntro2_Team
            areas[35] = ProjectManager.Areas[12].CharacterDialogue[character].TeamDialogues[2].Dialogues;   // FinalIntro3_Team
            areas[36] = ProjectManager.Areas[13].CharacterDialogue[character].SoloDialogue;                 // FinalShield_Solo
            areas[37] = ProjectManager.Areas[13].CharacterDialogue[character].TeamDialogues[0].Dialogues;   // FinalShield_Team

            areas[0].Clear();
            areas[1].Clear();
            areas[2].Clear();
            areas[3].Clear();
            areas[4].Clear();
            areas[5].Clear();
            areas[6].Clear();
            areas[7].Clear();
            areas[8].Clear();
            areas[9].Clear();
            areas[10].Clear();
            areas[11].Clear();
            areas[12].Clear();
            areas[13].Clear();
            areas[14].Clear();
            areas[15].Clear();
            areas[16].Clear();
            areas[17].Clear();
            areas[18].Clear();
            areas[19].Clear();
            areas[20].Clear();
            areas[21].Clear();
            areas[22].Clear();
            areas[23].Clear();
            areas[24].Clear();
            areas[25].Clear();
            areas[26].Clear();
            areas[27].Clear();
            areas[28].Clear();
            areas[29].Clear();
            areas[30].Clear();
            areas[31].Clear();
            areas[32].Clear();
            areas[33].Clear();
            areas[34].Clear();
            areas[35].Clear();
            areas[36].Clear();
            areas[37].Clear();

            try
            {
                for (int i = 0; i < file.Length; i++)
                {
                    if (file[i].Contains("[DIALOGUE]"))
                    {
                        LoadData(file, i, areas);
                    }
                }
            }
            catch
            {
                return 1;
            }

            return 0;
        }

        private static void LoadData(string[] file, int index, List<Area.Dialogue>[] areas)
        {
            int area = int.Parse(file[index + 1].Substring(5));
            string portrait = file[index + 2].Substring(9);
            string content = file[index + 3].Substring(8);
            float start = float.Parse(file[index + 4].Substring(6), CultureInfo.InvariantCulture);
            float end = float.Parse(file[index + 5].Substring(4), CultureInfo.InvariantCulture);

            Area.Dialogue dialogue = new Area.Dialogue(content, portrait, ImageLoader.Default, 0, 0);
            dialogue.Duration = Area.GetDurationFromStartEnd(start, end);
            float delay = start - Area.GetTotalDuration(areas[area].ToArray());
            if (delay < 0)
                delay = 0;
            dialogue.Delay = delay;

            areas[area].Add(dialogue);
        }
    }
}
