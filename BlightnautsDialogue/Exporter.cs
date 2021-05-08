using System;
using System.IO;

namespace BlightnautsDialogue
{
    public static class Exporter
    {
        public static class DialogueExporter
        {
            static string result = string.Empty;

            public static int Export(string path)
            {
                if (!Directory.Exists(path))
                {
                    return 1;
                }

                foreach (Area area in ProjectManager.Areas)
                {
                    foreach (Area.Character naut in area.CharacterDialogue)
                    {
                        int GetDialogues(bool solo)
                        {
                            result = string.Empty;
                            Area.Dialogue[] dialogues;
                            if (solo)
                                dialogues = naut.SoloDialogue.ToArray();
                            else
                                dialogues = naut.TeamDialogue.ToArray();

                            if (Area.GetTotalDuration(dialogues) == 0)
                                return 0;

                            AppendStartText(dialogues);
                            PrintDialogues(dialogues);
                            AppendEndText();

                            try
                            {
                                File.WriteAllText
                                (
                                    string.Format
                                    (
                                        "{0}\\Speech_{1}_{2}_{3}.xml",
                                        path,
                                        naut.Name,
                                        area.Name,
                                        solo ? "solo" : "team"
                                    ),
                                    result
                                );
                                return 0;
                            }
                            catch
                            {
                                return 2;
                            }
                        }

                        int process = GetDialogues(true);
                        if (process != 0)
                            return process;
                        else
                            process = GetDialogues(false);
                        if (process != 0)
                            return process;
                    }
                }
                return 0;
            }

            private static void AppendStartText(Area.Dialogue[] dialogues)
            {
                result += string.Format
                (
                    "<?xml version=\"1.0\" ?>\n" +
                    "<Animation>\n" +
                    "    <float id=\"animationLength\">{0}</float>\n" +
                    "    <bool id=\"updateAnimationLength\">0</bool>\n" +
                    "    <Vector2 id=\"animationSize\">0.947 0.135</Vector2>\n" +
                    "    <bool id=\"updateAnimationSize\">1</bool>\n",
                    Area.GetTotalDuration(dialogues)
                );
            }

            private static void AppendEndText()
            {
                result += "</Animation>\n";
            }

            private static void PrintDialogues(Area.Dialogue[] dialogues)
            {
                foreach (Area.Dialogue dialogue in dialogues)
                {
                    result += string.Format
                    (
                        "    <animationVisual>\n" +
                        "        <vector2 id=\"position\">0.0596424 0</vector2>\n" +
                        "        <vector2 id=\"size\">0.812965 0.120596</vector2>\n" +
                        "        <float id=\"depth\">0.03</float>\n" +
                        "        <string id=\"colourCombineModeAlpha\">MULTIPLY</string>\n" +
                        "        <colour id=\"colourRGBA\" mode=\"KEY\" inCurveType=\"LINEAR_LINEAR_LINEAR_LINEAR\" outCurveType=\"LINEAR_LINEAR_LINEAR_LINEAR\" keyAnchor=\"0 0 0 0#{0}_0 0 0 200#{1}_0 0 0 200#{2}_0 0 0 0#{3}\">0 0 0 200</colour>\n" +
                        "        <string id=\"textureName\">sfx_square_black</string>\n" +
                        "        <colour id=\"levelsBrightnesses\">0 127 255 255</colour>\n" +
                        "        <int id=\"ownID\">39</int>\n" +
                        "    </animationVisual>\n" +
                        "    <animationVisual>\n" +
                        "        <vector2 id=\"position\">-0.405904 0</vector2>\n" +
                        "        <vector2 id=\"size\">0.121292 0.121292</vector2>\n" +
                        "        <float id=\"depth\">0.03</float>\n" +
                        "        <string id=\"colourCombineModeAlpha\">MULTIPLY</string>\n" +
                        "        <colour id=\"colourRGBA\" mode=\"KEY\" inCurveType=\"LINEAR_LINEAR_LINEAR_LINEAR\" outCurveType=\"LINEAR_LINEAR_LINEAR_LINEAR\" keyAnchor=\"0 0 0 0#{0}_0 0 0 255#{1}_0 0 0 255#{2}_0 0 0 0#{3}\">0 0 0 0</colour>\n" +
                        "        <string id=\"textureName\">sfx_square_black</string>\n" +
                        "        <colour id=\"levelsBrightnesses\">0 127 255 255</colour>\n" +
                        "        <int id=\"ownID\">888</int>\n" +
                        "    </animationVisual>\n" +
                        "    <animationVisual>\n" +
                        "        <vector2 id=\"size\">0.947204 0.135316</vector2>\n" +
                        "        <string id=\"textureName\">(mod) DialogueBox</string>\n" +
                        "        <string id=\"colourCombineModeAlpha\">MULTIPLY</string>\n" +
                        "        <colour id=\"colourRGBA\" mode=\"KEY\" inCurveType=\"LINEAR_LINEAR_LINEAR_LINEAR\" outCurveType=\"LINEAR_LINEAR_LINEAR_LINEAR\" keyAnchor=\"0 0 0 0#{0}_0 0 0 255#{1}_0 0 0 255#{2}_0 0 0 0#{3}\">0 0 0 255</colour>\n" +
                        "        <int id=\"ownID\">866</int>\n" +
                        "    </animationVisual>\n" +
                        "    <animationVisual>\n" +
                        "        <vector2 id=\"position\">-0.405904 0</vector2>\n" +
                        "        <vector2 id=\"size\">0.121292 0.121292</vector2>\n" +
                        "        <float id=\"depth\">0.01</float>\n" +
                        "        <string id=\"colourCombineModeAlpha\">MULTIPLY</string>\n" +
                        "        <colour id=\"colourRGBA\" mode=\"KEY\" inCurveType=\"LINEAR_LINEAR_LINEAR_LINEAR\" outCurveType=\"LINEAR_LINEAR_LINEAR_LINEAR\" keyAnchor=\"0 0 0 0#{0}_0 0 0 255#{1}_0 0 0 255#{2}_0 0 0 0#{3}\">0 0 0 0</colour>\n" +
                        "        <string id=\"textureName\">{4}</string>\n" +
                        "        <colour id=\"levelsBrightnesses\">0 127 255 255</colour>\n" +
                        "        <int id=\"ownID\">888</int>\n" +
                        "    </animationVisual>\n" +
                        "    <animationText>\n" +
                        "        <vector2 id=\"position\">-0.377277 0.039424</vector2>\n" +
                        "        <vector2 id=\"size\">0.245579 0.245579</vector2>\n" +
                        "        <float id=\"depth\">0.02</float>\n" +
                        "        <string id=\"colourCombineModeAlpha\">MULTIPLY</string>\n" +
                        "        <colour id=\"colourRGBA\" mode=\"KEY\" inCurveType=\"LINEAR_LINEAR_LINEAR_LINEAR\" outCurveType=\"LINEAR_LINEAR_LINEAR_LINEAR\" keyAnchor=\"0 0 0 0#{0}_0 0 0 255#{1}_0 0 0 255#{2}_0 0 0 0#{3}\">0 0 0 0</colour>\n" +
                        "        <string id=\"directText\">{5}</string>\n" +
                        "        <float id=\"lineWidth\">3.1</float>\n" +
                        "        <int id=\"parentID\">39</int>\n" +
                        "        <int id=\"ownID\">689</int>\n" +
                        "    </animationText>\n",
                        Convert.ToSingle(Area.GetStartTime(dialogue, dialogues)),
                        Convert.ToSingle(Area.GetStartTime(dialogue, dialogues)) + 0.1f,
                        Convert.ToSingle(Area.GetEndTime(dialogue, dialogues)) - 0.1f,
                        Convert.ToSingle(Area.GetEndTime(dialogue, dialogues)),
                        dialogue.Portrait,
                        dialogue.Content
                    );
                }
            }
        }

        public static class BehaviourExporter
        {
            static string result = string.Empty;

            public static int Export(string path)
            {
                if (!Directory.Exists(path))
                {
                    return 1;
                }

                result = string.Empty;
                AppendStartText();
                AppendValues();
                AppendEndText();

                try
                {
                    File.WriteAllText(path + "\\speech_checkCharacter.xml", result);
                    return 0;
                }
                catch
                {
                    return 2;
                }
            }

            private static void AppendStartText()
            {
                result += "<?xml version=\"1.0\" ?>\n" +
                    "<enemy>\n" +
                    "    <behaviour>\n" +
                    "        <root x=\"80\" y=\"20\">\n" +
                    "            <normal>";
            }

            private static void AppendValues()
            {
                foreach (ProjectManager.Actor actor in ProjectManager.Characters)
                {
                    // Default skin.
                    if (actor.SkinIndex == 1)
                    {
                        result += string.Format
                        (
                            "<condition id=\"branch\">\n" +
                            "                    <string id=\"Comment\">{0}</string>\n" +
                            "                    <normal>\n" +
                            "                        <action id=\"selectTarget\">\n" +
                            "                            <string id=\"groups to select\" values=\"target groups\" multiselect=\"true\">PLAYERS;;</string>\n" +
                            "                            <string id=\"teams\" values=\"teams\" multiselect=\"true\">OWN_TEAM;;</string>\n" +
                            "                            <string id=\"class\">{1}</string>\n" +
                            "                            <string id=\"only check parent\" values=\"yesno\">no</string>\n" +
                            "                            <string id=\"remove if not found\" values=\"yesno\">yes</string>\n" +
                            "                            <float id=\"xOffset\">0.00</float>\n" +
                            "                            <float id=\"yOffset\">0.00</float>\n" +
                            "                            <string id=\"width\">60</string>\n" +
                            "                            <string id=\"height\">60</string>\n" +
                            "                            <string id=\"horizontal alignment to character\" values=\"alignmentToCharacterHorizontal\">Centre</string>\n" +
                            "                            <string id=\"vertical alignment to character\" values=\"alignmentToCharacterVertical\">Centre</string>\n" +
                            "                            <string id=\"debugAreaColour\">0 0 0 0</string>\n" +
                            "                            <string id=\"compare method\" values=\"valuecompare2\">greater or equal</string>\n" +
                            "                            <string id=\"health value\"></string>\n" +
                            "                            <string id=\"distance check\" values=\"distance check\">NONE</string>\n" +
                            "                            <string id=\"check line of sight\" values=\"yesno\">no</string>\n" +
                            "                            <string id=\"ignore invisibility\" values=\"yesno\">yes</string>\n" +
                            "                            <string id=\"never detect invisible targets without character collision\" values=\"yesno\">no</string>\n" +
                            "                        </action>\n" +
                            "                        <andblock>\n" +
                            "                            <normal>\n" +
                            "                                <action id=\"setBool\">\n" +
                            "                                    <string id=\"id\">actorExists_{2}</string>\n" +
                            "                                    <string id=\"value\" values=\"flagtoggle\">yes</string>\n" +
                            "                                </action>\n" +
                            "                            </normal>\n" +
                            "                            <else>\n" +
                            "                                <action id=\"setBool\">\n" +
                            "                                    <string id=\"id\">actorExists_{2}</string>\n" +
                            "                                    <string id=\"value\" values=\"flagtoggle\">no</string>\n" +
                            "                                </action>\n" +
                            "                            </else>\n" +
                            "                            <or>\n" +
                            "                                <condition id=\"hasTarget\">\n" +
                            "                                    <string id=\"condition\" values=\"yesno\">yes</string>\n" +
                            "                                </condition>\n" +
                            "                                <condition id=\"checkClass\">\n" +
                            "                                    <string id=\"check on\" values=\"targetself\">target</string>\n" +
                            "                                    <string id=\"class\">{1}</string>\n" +
                            "                                </condition>\n" +
                            "                            </or>\n" +
                            "                        </andblock>\n" +
                            "                    </normal>\n" +
                            "                </condition>",
                            actor.RealName,
                            actor.ClassName,
                            actor.IndexedName
                        );
                    }

                    // Non-default skins have an extra check to verify the skin index.
                    else
                    {
                        result += string.Format
                        (
                            "<condition id=\"branch\">\n" +
                            "                    <string id=\"Comment\">{0}</string>\n" +
                            "                    <normal>\n" +
                            "                        <action id=\"selectTarget\">\n" +
                            "                            <string id=\"groups to select\" values=\"target groups\" multiselect=\"true\">PLAYERS;;</string>\n" +
                            "                            <string id=\"teams\" values=\"teams\" multiselect=\"true\">OWN_TEAM;;</string>\n" +
                            "                            <string id=\"class\">{1}</string>\n" +
                            "                            <string id=\"only check parent\" values=\"yesno\">no</string>\n" +
                            "                            <string id=\"remove if not found\" values=\"yesno\">yes</string>\n" +
                            "                            <float id=\"xOffset\">0.00</float>\n" +
                            "                            <float id=\"yOffset\">0.00</float>\n" +
                            "                            <string id=\"width\">60</string>\n" +
                            "                            <string id=\"height\">60</string>\n" +
                            "                            <string id=\"horizontal alignment to character\" values=\"alignmentToCharacterHorizontal\">Centre</string>\n" +
                            "                            <string id=\"vertical alignment to character\" values=\"alignmentToCharacterVertical\">Centre</string>\n" +
                            "                            <string id=\"debugAreaColour\">0 0 0 0</string>\n" +
                            "                            <string id=\"compare method\" values=\"valuecompare2\">greater or equal</string>\n" +
                            "                            <string id=\"health value\"></string>\n" +
                            "                            <string id=\"distance check\" values=\"distance check\">NONE</string>\n" +
                            "                            <string id=\"check line of sight\" values=\"yesno\">no</string>\n" +
                            "                            <string id=\"ignore invisibility\" values=\"yesno\">yes</string>\n" +
                            "                            <string id=\"never detect invisible targets without character collision\" values=\"yesno\">no</string>\n" +
                            "                        </action>\n" +
                            "                        <andblock>\n" +
                            "                            <normal>\n" +
                            "                                <action id=\"setBool\">\n" +
                            "                                    <string id=\"id\">actorExists_{2}</string>\n" +
                            "                                    <string id=\"value\" values=\"flagtoggle\">yes</string>\n" +
                            "                                </action>\n" +
                            "                            </normal>\n" +
                            "                            <else>\n" +
                            "                                <action id=\"setBool\">\n" +
                            "                                    <string id=\"id\">actorExists_{2}</string>\n" +
                            "                                    <string id=\"value\" values=\"flagtoggle\">no</string>\n" +
                            "                                </action>\n" +
                            "                            </else>\n" +
                            "                            <or>\n" +
                            "                                <condition id=\"hasTarget\">\n" +
                            "                                    <string id=\"condition\" values=\"yesno\">yes</string>\n" +
                            "                                </condition>\n" +
                            "                                <condition id=\"checkClass\">\n" +
                            "                                    <string id=\"check on\" values=\"targetself\">target</string>\n" +
                            "                                    <string id=\"class\">{1}</string>\n" +
                            "                                </condition>\n" +
                            "                                <condition id=\"skin\">\n" +
                            "                                    <float id=\"skinIndex\">{3}.00</float>\n" +
                            "                                    <string id=\"condition\" values=\"yesno\">yes</string>\n" +
                            "                                    <string id=\"check on\" values=\"targetself\">target</string>\n" +
                            "                                </condition>\n" +
                            "                            </or>\n" +
                            "                        </andblock>\n" +
                            "                    </normal>\n" +
                            "                </condition>",
                            actor.RealName,
                            actor.ClassName,
                            actor.IndexedName,
                            actor.SkinIndex
                        );
                    }
                }
            }

            private static void AppendEndText()
            {
                result += "</normal>\n" +
                    "        </root>\n" +
                    "    </behaviour>\n" +
                    "</enemy>";
            }
        }
    }
}
