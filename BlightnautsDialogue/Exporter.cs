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
                    File.WriteAllText(path + "\\speech_pickCharacter.xml", PickCharacterFile());
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

            private static string PickCharacterFile()
            {
                // I know that this is very dumb, but for now it's how I roll.
                return "<?xml version=\"1.0\" ?>\n" +
                    "<enemy>\n" +
                    "    <behaviour>\n" +
                    "        <root x=\"80\" y=\"20\">\n" +
                    "            <string id=\"Comment\">Randomize Character</string>\n" +
                    "            <normal>\n" +
                    "                <condition id=\"IsLevelButtonDown\">\n" +
                    "                    <string id=\"buttons\">players_1</string>\n" +
                    "                    <string id=\"Minimized\">yes</string>\n" +
                    "                    <normal>\n" +
                    "                        <action id=\"adjustCounter\">\n" +
                    "                            <string id=\"id\">character</string>\n" +
                    "                            <string id=\"value\">1</string>\n" +
                    "                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                        </action>\n" +
                    "                        <action id=\"adjustCounter\">\n" +
                    "                            <string id=\"id\">previous</string>\n" +
                    "                            <string id=\"value\">1</string>\n" +
                    "                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                        </action>\n" +
                    "                    </normal>\n" +
                    "                </condition>\n" +
                    "                <condition id=\"IsLevelButtonDown\">\n" +
                    "                    <string id=\"buttons\">players_2</string>\n" +
                    "                    <string id=\"Minimized\">yes</string>\n" +
                    "                    <normal>\n" +
                    "                        <condition id=\"checkCounter\">\n" +
                    "                            <string id=\"id\">previous</string>\n" +
                    "                            <string id=\"value\">1</string>\n" +
                    "                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                            <string id=\"Comment\">Don&apos;t choose character 1 again</string>\n" +
                    "                            <normal>\n" +
                    "                                <action id=\"adjustCounter\">\n" +
                    "                                    <string id=\"id\">character</string>\n" +
                    "                                    <string id=\"value\">2</string>\n" +
                    "                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                </action>\n" +
                    "                                <action id=\"adjustCounter\">\n" +
                    "                                    <string id=\"id\">previous</string>\n" +
                    "                                    <string id=\"value\">2</string>\n" +
                    "                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                </action>\n" +
                    "                            </normal>\n" +
                    "                            <else>\n" +
                    "                                <condition id=\"checkCounter\">\n" +
                    "                                    <string id=\"id\">previous</string>\n" +
                    "                                    <string id=\"value\">2</string>\n" +
                    "                                    <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                    <string id=\"Comment\">Don&apos;t choose character 2 again</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">character</string>\n" +
                    "                                            <string id=\"value\">1</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                        </action>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">previous</string>\n" +
                    "                                            <string id=\"value\">1</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                        </action>\n" +
                    "                                    </normal>\n" +
                    "                                    <else>\n" +
                    "                                        <condition id=\"branch\">\n" +
                    "                                            <string id=\"Comment\">Neutral random</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <condition id=\"random\">\n" +
                    "                                                    <string id=\"amount\">2</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">1</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">1</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">2</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">2</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </normal>\n" +
                    "                                        </condition>\n" +
                    "                                    </else>\n" +
                    "                                </condition>\n" +
                    "                            </else>\n" +
                    "                        </condition>\n" +
                    "                    </normal>\n" +
                    "                </condition>\n" +
                    "                <condition id=\"IsLevelButtonDown\">\n" +
                    "                    <string id=\"buttons\">players_3</string>\n" +
                    "                    <string id=\"Minimized\">yes</string>\n" +
                    "                    <normal>\n" +
                    "                        <condition id=\"checkCounter\">\n" +
                    "                            <string id=\"id\">previous</string>\n" +
                    "                            <string id=\"value\">1</string>\n" +
                    "                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                            <string id=\"Comment\">Don&apos;t choose character 1 again</string>\n" +
                    "                            <normal>\n" +
                    "                                <condition id=\"random\">\n" +
                    "                                    <string id=\"amount\">2</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">character</string>\n" +
                    "                                            <string id=\"value\">2</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                        </action>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">previous</string>\n" +
                    "                                            <string id=\"value\">2</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                        </action>\n" +
                    "                                    </normal>\n" +
                    "                                    <else>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">character</string>\n" +
                    "                                            <string id=\"value\">3</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                        </action>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">previous</string>\n" +
                    "                                            <string id=\"value\">3</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                        </action>\n" +
                    "                                    </else>\n" +
                    "                                </condition>\n" +
                    "                            </normal>\n" +
                    "                            <else>\n" +
                    "                                <condition id=\"checkCounter\">\n" +
                    "                                    <string id=\"id\">previous</string>\n" +
                    "                                    <string id=\"value\">2</string>\n" +
                    "                                    <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                    <string id=\"Comment\">Don&apos;t choose character 2 again</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <condition id=\"random\">\n" +
                    "                                            <string id=\"amount\">2</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">character</string>\n" +
                    "                                                    <string id=\"value\">1</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">previous</string>\n" +
                    "                                                    <string id=\"value\">1</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                            </normal>\n" +
                    "                                            <else>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">character</string>\n" +
                    "                                                    <string id=\"value\">3</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">previous</string>\n" +
                    "                                                    <string id=\"value\">3</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                            </else>\n" +
                    "                                        </condition>\n" +
                    "                                    </normal>\n" +
                    "                                    <else>\n" +
                    "                                        <condition id=\"checkCounter\">\n" +
                    "                                            <string id=\"id\">previous</string>\n" +
                    "                                            <string id=\"value\">3</string>\n" +
                    "                                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                            <string id=\"Comment\">Don&apos;t choose character 3 again</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <condition id=\"random\">\n" +
                    "                                                    <string id=\"amount\">2</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">1</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">1</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">2</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">2</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </normal>\n" +
                    "                                            <else>\n" +
                    "                                                <condition id=\"branch\">\n" +
                    "                                                    <string id=\"Comment\">Neutral random</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <condition id=\"random\">\n" +
                    "                                                            <string id=\"amount\">3</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">1</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">1</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </normal>\n" +
                    "                                                            <else>\n" +
                    "                                                                <condition id=\"random\">\n" +
                    "                                                                    <string id=\"amount\">2</string>\n" +
                    "                                                                    <normal>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">2</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">2</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </normal>\n" +
                    "                                                                    <else>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">3</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">3</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </else>\n" +
                    "                                                                </condition>\n" +
                    "                                                            </else>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </normal>\n" +
                    "                                                </condition>\n" +
                    "                                            </else>\n" +
                    "                                        </condition>\n" +
                    "                                    </else>\n" +
                    "                                </condition>\n" +
                    "                            </else>\n" +
                    "                        </condition>\n" +
                    "                    </normal>\n" +
                    "                </condition>\n" +
                    "                <condition id=\"IsLevelButtonDown\">\n" +
                    "                    <string id=\"buttons\">players_4</string>\n" +
                    "                    <string id=\"Minimized\">yes</string>\n" +
                    "                    <normal>\n" +
                    "                        <condition id=\"checkCounter\">\n" +
                    "                            <string id=\"id\">previous</string>\n" +
                    "                            <string id=\"value\">1</string>\n" +
                    "                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                            <string id=\"Comment\">Don&apos;t choose character 1 again</string>\n" +
                    "                            <normal>\n" +
                    "                                <condition id=\"random\">\n" +
                    "                                    <string id=\"amount\">3</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">character</string>\n" +
                    "                                            <string id=\"value\">2</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                        </action>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">previous</string>\n" +
                    "                                            <string id=\"value\">2</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                        </action>\n" +
                    "                                    </normal>\n" +
                    "                                    <else>\n" +
                    "                                        <condition id=\"random\">\n" +
                    "                                            <string id=\"amount\">2</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">character</string>\n" +
                    "                                                    <string id=\"value\">3</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">previous</string>\n" +
                    "                                                    <string id=\"value\">3</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                            </normal>\n" +
                    "                                            <else>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">character</string>\n" +
                    "                                                    <string id=\"value\">4</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">previous</string>\n" +
                    "                                                    <string id=\"value\">4</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                            </else>\n" +
                    "                                        </condition>\n" +
                    "                                    </else>\n" +
                    "                                </condition>\n" +
                    "                            </normal>\n" +
                    "                            <else>\n" +
                    "                                <condition id=\"checkCounter\">\n" +
                    "                                    <string id=\"id\">previous</string>\n" +
                    "                                    <string id=\"value\">2</string>\n" +
                    "                                    <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                    <string id=\"Comment\">Don&apos;t choose character 2 again</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <condition id=\"random\">\n" +
                    "                                            <string id=\"amount\">3</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">character</string>\n" +
                    "                                                    <string id=\"value\">1</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">previous</string>\n" +
                    "                                                    <string id=\"value\">1</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                            </normal>\n" +
                    "                                            <else>\n" +
                    "                                                <condition id=\"random\">\n" +
                    "                                                    <string id=\"amount\">2</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">3</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">3</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">4</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">4</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </else>\n" +
                    "                                        </condition>\n" +
                    "                                    </normal>\n" +
                    "                                    <else>\n" +
                    "                                        <condition id=\"checkCounter\">\n" +
                    "                                            <string id=\"id\">previous</string>\n" +
                    "                                            <string id=\"value\">3</string>\n" +
                    "                                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                            <string id=\"Comment\">Don&apos;t choose character 3 again</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <condition id=\"random\">\n" +
                    "                                                    <string id=\"amount\">3</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">1</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">1</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <condition id=\"random\">\n" +
                    "                                                            <string id=\"amount\">2</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </normal>\n" +
                    "                                                            <else>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">4</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">4</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </else>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </normal>\n" +
                    "                                            <else>\n" +
                    "                                                <condition id=\"checkCounter\">\n" +
                    "                                                    <string id=\"id\">previous</string>\n" +
                    "                                                    <string id=\"value\">4</string>\n" +
                    "                                                    <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                                    <string id=\"Comment\">Don&apos;t choose character 4 again</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <condition id=\"random\">\n" +
                    "                                                            <string id=\"amount\">3</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">1</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">1</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </normal>\n" +
                    "                                                            <else>\n" +
                    "                                                                <condition id=\"random\">\n" +
                    "                                                                    <string id=\"amount\">2</string>\n" +
                    "                                                                    <normal>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">2</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">2</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </normal>\n" +
                    "                                                                    <else>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">3</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">3</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </else>\n" +
                    "                                                                </condition>\n" +
                    "                                                            </else>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <condition id=\"branch\">\n" +
                    "                                                            <string id=\"Comment\">Neutral random</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <condition id=\"random\">\n" +
                    "                                                                    <string id=\"amount\">4</string>\n" +
                    "                                                                    <normal>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">1</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">1</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </normal>\n" +
                    "                                                                    <else>\n" +
                    "                                                                        <condition id=\"random\">\n" +
                    "                                                                            <string id=\"amount\">3</string>\n" +
                    "                                                                            <normal>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                            </normal>\n" +
                    "                                                                            <else>\n" +
                    "                                                                                <condition id=\"random\">\n" +
                    "                                                                                    <string id=\"amount\">2</string>\n" +
                    "                                                                                    <normal>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                            <string id=\"value\">3</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                            <string id=\"value\">3</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                    </normal>\n" +
                    "                                                                                    <else>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                            <string id=\"value\">4</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                            <string id=\"value\">4</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                    </else>\n" +
                    "                                                                                </condition>\n" +
                    "                                                                            </else>\n" +
                    "                                                                        </condition>\n" +
                    "                                                                    </else>\n" +
                    "                                                                </condition>\n" +
                    "                                                            </normal>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </else>\n" +
                    "                                        </condition>\n" +
                    "                                    </else>\n" +
                    "                                </condition>\n" +
                    "                            </else>\n" +
                    "                        </condition>\n" +
                    "                    </normal>\n" +
                    "                </condition>\n" +
                    "                <condition id=\"IsLevelButtonDown\">\n" +
                    "                    <string id=\"buttons\">players_5</string>\n" +
                    "                    <string id=\"Minimized\">yes</string>\n" +
                    "                    <normal>\n" +
                    "                        <condition id=\"checkCounter\">\n" +
                    "                            <string id=\"id\">previous</string>\n" +
                    "                            <string id=\"value\">1</string>\n" +
                    "                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                            <string id=\"Comment\">Don&apos;t choose character 1 again</string>\n" +
                    "                            <normal>\n" +
                    "                                <condition id=\"random\">\n" +
                    "                                    <string id=\"amount\">4</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">character</string>\n" +
                    "                                            <string id=\"value\">2</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                        </action>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">previous</string>\n" +
                    "                                            <string id=\"value\">2</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                        </action>\n" +
                    "                                    </normal>\n" +
                    "                                    <else>\n" +
                    "                                        <condition id=\"random\">\n" +
                    "                                            <string id=\"amount\">3</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">character</string>\n" +
                    "                                                    <string id=\"value\">3</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">previous</string>\n" +
                    "                                                    <string id=\"value\">3</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                            </normal>\n" +
                    "                                            <else>\n" +
                    "                                                <condition id=\"random\">\n" +
                    "                                                    <string id=\"amount\">2</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">4</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">4</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">5</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">5</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </else>\n" +
                    "                                        </condition>\n" +
                    "                                    </else>\n" +
                    "                                </condition>\n" +
                    "                            </normal>\n" +
                    "                            <else>\n" +
                    "                                <condition id=\"checkCounter\">\n" +
                    "                                    <string id=\"id\">previous</string>\n" +
                    "                                    <string id=\"value\">2</string>\n" +
                    "                                    <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                    <string id=\"Comment\">Don&apos;t choose character 2 again</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <condition id=\"random\">\n" +
                    "                                            <string id=\"amount\">4</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">character</string>\n" +
                    "                                                    <string id=\"value\">1</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">previous</string>\n" +
                    "                                                    <string id=\"value\">1</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                            </normal>\n" +
                    "                                            <else>\n" +
                    "                                                <condition id=\"random\">\n" +
                    "                                                    <string id=\"amount\">3</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">3</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">3</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <condition id=\"random\">\n" +
                    "                                                            <string id=\"amount\">2</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">4</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">4</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </normal>\n" +
                    "                                                            <else>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">5</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">5</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </else>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </else>\n" +
                    "                                        </condition>\n" +
                    "                                    </normal>\n" +
                    "                                    <else>\n" +
                    "                                        <condition id=\"checkCounter\">\n" +
                    "                                            <string id=\"id\">previous</string>\n" +
                    "                                            <string id=\"value\">3</string>\n" +
                    "                                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                            <string id=\"Comment\">Don&apos;t choose character 3 again</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <condition id=\"random\">\n" +
                    "                                                    <string id=\"amount\">4</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">1</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">1</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <condition id=\"random\">\n" +
                    "                                                            <string id=\"amount\">3</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </normal>\n" +
                    "                                                            <else>\n" +
                    "                                                                <condition id=\"random\">\n" +
                    "                                                                    <string id=\"amount\">2</string>\n" +
                    "                                                                    <normal>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">4</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">4</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </normal>\n" +
                    "                                                                    <else>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">5</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">5</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </else>\n" +
                    "                                                                </condition>\n" +
                    "                                                            </else>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </normal>\n" +
                    "                                            <else>\n" +
                    "                                                <condition id=\"checkCounter\">\n" +
                    "                                                    <string id=\"id\">previous</string>\n" +
                    "                                                    <string id=\"value\">4</string>\n" +
                    "                                                    <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                                    <string id=\"Comment\">Don&apos;t choose character 4 again</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <condition id=\"random\">\n" +
                    "                                                            <string id=\"amount\">4</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">1</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">1</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </normal>\n" +
                    "                                                            <else>\n" +
                    "                                                                <condition id=\"random\">\n" +
                    "                                                                    <string id=\"amount\">3</string>\n" +
                    "                                                                    <normal>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">2</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">2</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </normal>\n" +
                    "                                                                    <else>\n" +
                    "                                                                        <condition id=\"random\">\n" +
                    "                                                                            <string id=\"amount\">2</string>\n" +
                    "                                                                            <normal>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                    <string id=\"value\">3</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                    <string id=\"value\">3</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                            </normal>\n" +
                    "                                                                            <else>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                    <string id=\"value\">5</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                    <string id=\"value\">5</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                            </else>\n" +
                    "                                                                        </condition>\n" +
                    "                                                                    </else>\n" +
                    "                                                                </condition>\n" +
                    "                                                            </else>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <condition id=\"checkCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">5</string>\n" +
                    "                                                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                                            <string id=\"Comment\">Don&apos;t choose character 5 again</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <condition id=\"random\">\n" +
                    "                                                                    <string id=\"amount\">4</string>\n" +
                    "                                                                    <normal>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">1</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">1</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </normal>\n" +
                    "                                                                    <else>\n" +
                    "                                                                        <condition id=\"random\">\n" +
                    "                                                                            <string id=\"amount\">3</string>\n" +
                    "                                                                            <normal>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                            </normal>\n" +
                    "                                                                            <else>\n" +
                    "                                                                                <condition id=\"random\">\n" +
                    "                                                                                    <string id=\"amount\">2</string>\n" +
                    "                                                                                    <normal>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                            <string id=\"value\">3</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                            <string id=\"value\">3</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                    </normal>\n" +
                    "                                                                                    <else>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                            <string id=\"value\">4</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                            <string id=\"value\">4</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                    </else>\n" +
                    "                                                                                </condition>\n" +
                    "                                                                            </else>\n" +
                    "                                                                        </condition>\n" +
                    "                                                                    </else>\n" +
                    "                                                                </condition>\n" +
                    "                                                            </normal>\n" +
                    "                                                            <else>\n" +
                    "                                                                <condition id=\"branch\">\n" +
                    "                                                                    <string id=\"Comment\">Neutral random</string>\n" +
                    "                                                                    <normal>\n" +
                    "                                                                        <condition id=\"random\">\n" +
                    "                                                                            <string id=\"amount\">5</string>\n" +
                    "                                                                            <normal>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                    <string id=\"value\">1</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                    <string id=\"value\">1</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                            </normal>\n" +
                    "                                                                            <else>\n" +
                    "                                                                                <condition id=\"random\">\n" +
                    "                                                                                    <string id=\"amount\">4</string>\n" +
                    "                                                                                    <normal>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                            <string id=\"value\">2</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                            <string id=\"value\">2</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                    </normal>\n" +
                    "                                                                                    <else>\n" +
                    "                                                                                        <condition id=\"random\">\n" +
                    "                                                                                            <string id=\"amount\">3</string>\n" +
                    "                                                                                            <normal>\n" +
                    "                                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                                    <string id=\"value\">3</string>\n" +
                    "                                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                </action>\n" +
                    "                                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                                    <string id=\"value\">3</string>\n" +
                    "                                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                </action>\n" +
                    "                                                                                            </normal>\n" +
                    "                                                                                            <else>\n" +
                    "                                                                                                <condition id=\"random\">\n" +
                    "                                                                                                    <string id=\"amount\">2</string>\n" +
                    "                                                                                                    <normal>\n" +
                    "                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                                            <string id=\"value\">4</string>\n" +
                    "                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                        </action>\n" +
                    "                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                                            <string id=\"value\">4</string>\n" +
                    "                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                        </action>\n" +
                    "                                                                                                    </normal>\n" +
                    "                                                                                                    <else>\n" +
                    "                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                                            <string id=\"value\">5</string>\n" +
                    "                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                        </action>\n" +
                    "                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                                            <string id=\"value\">5</string>\n" +
                    "                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                        </action>\n" +
                    "                                                                                                    </else>\n" +
                    "                                                                                                </condition>\n" +
                    "                                                                                            </else>\n" +
                    "                                                                                        </condition>\n" +
                    "                                                                                    </else>\n" +
                    "                                                                                </condition>\n" +
                    "                                                                            </else>\n" +
                    "                                                                        </condition>\n" +
                    "                                                                    </normal>\n" +
                    "                                                                </condition>\n" +
                    "                                                            </else>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </else>\n" +
                    "                                        </condition>\n" +
                    "                                    </else>\n" +
                    "                                </condition>\n" +
                    "                            </else>\n" +
                    "                        </condition>\n" +
                    "                    </normal>\n" +
                    "                </condition>\n" +
                    "                <condition id=\"IsLevelButtonDown\">\n" +
                    "                    <string id=\"buttons\">players_6</string>\n" +
                    "                    <string id=\"Minimized\">yes</string>\n" +
                    "                    <normal>\n" +
                    "                        <condition id=\"checkCounter\">\n" +
                    "                            <string id=\"id\">previous</string>\n" +
                    "                            <string id=\"value\">1</string>\n" +
                    "                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                            <string id=\"Comment\">Don&apos;t choose character 1 again</string>\n" +
                    "                            <normal>\n" +
                    "                                <condition id=\"random\">\n" +
                    "                                    <string id=\"amount\">5</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">character</string>\n" +
                    "                                            <string id=\"value\">2</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                        </action>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">previous</string>\n" +
                    "                                            <string id=\"value\">2</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                        </action>\n" +
                    "                                    </normal>\n" +
                    "                                    <else>\n" +
                    "                                        <condition id=\"random\">\n" +
                    "                                            <string id=\"amount\">4</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">character</string>\n" +
                    "                                                    <string id=\"value\">3</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">previous</string>\n" +
                    "                                                    <string id=\"value\">3</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                            </normal>\n" +
                    "                                            <else>\n" +
                    "                                                <condition id=\"random\">\n" +
                    "                                                    <string id=\"amount\">3</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">4</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">4</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <condition id=\"random\">\n" +
                    "                                                            <string id=\"amount\">2</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">5</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">5</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </normal>\n" +
                    "                                                            <else>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">6</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">6</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </else>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </else>\n" +
                    "                                        </condition>\n" +
                    "                                    </else>\n" +
                    "                                </condition>\n" +
                    "                            </normal>\n" +
                    "                            <else>\n" +
                    "                                <condition id=\"checkCounter\">\n" +
                    "                                    <string id=\"id\">previous</string>\n" +
                    "                                    <string id=\"value\">2</string>\n" +
                    "                                    <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                    <string id=\"Comment\">Don&apos;t choose character 2 again</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <condition id=\"random\">\n" +
                    "                                            <string id=\"amount\">5</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">character</string>\n" +
                    "                                                    <string id=\"value\">1</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                                <action id=\"adjustCounter\">\n" +
                    "                                                    <string id=\"id\">previous</string>\n" +
                    "                                                    <string id=\"value\">1</string>\n" +
                    "                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                </action>\n" +
                    "                                            </normal>\n" +
                    "                                            <else>\n" +
                    "                                                <condition id=\"random\">\n" +
                    "                                                    <string id=\"amount\">4</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">3</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">3</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <condition id=\"random\">\n" +
                    "                                                            <string id=\"amount\">3</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">4</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">4</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </normal>\n" +
                    "                                                            <else>\n" +
                    "                                                                <condition id=\"random\">\n" +
                    "                                                                    <string id=\"amount\">2</string>\n" +
                    "                                                                    <normal>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">5</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">5</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </normal>\n" +
                    "                                                                    <else>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">6</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">6</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </else>\n" +
                    "                                                                </condition>\n" +
                    "                                                            </else>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </else>\n" +
                    "                                        </condition>\n" +
                    "                                    </normal>\n" +
                    "                                    <else>\n" +
                    "                                        <condition id=\"checkCounter\">\n" +
                    "                                            <string id=\"id\">previous</string>\n" +
                    "                                            <string id=\"value\">3</string>\n" +
                    "                                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                            <string id=\"Comment\">Don&apos;t choose character 3 again</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <condition id=\"random\">\n" +
                    "                                                    <string id=\"amount\">5</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">character</string>\n" +
                    "                                                            <string id=\"value\">1</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">1</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <condition id=\"random\">\n" +
                    "                                                            <string id=\"amount\">4</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </normal>\n" +
                    "                                                            <else>\n" +
                    "                                                                <condition id=\"random\">\n" +
                    "                                                                    <string id=\"amount\">3</string>\n" +
                    "                                                                    <normal>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">4</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">4</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </normal>\n" +
                    "                                                                    <else>\n" +
                    "                                                                        <condition id=\"random\">\n" +
                    "                                                                            <string id=\"amount\">2</string>\n" +
                    "                                                                            <normal>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                    <string id=\"value\">5</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                    <string id=\"value\">5</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                            </normal>\n" +
                    "                                                                            <else>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                    <string id=\"value\">6</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                    <string id=\"value\">6</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                            </else>\n" +
                    "                                                                        </condition>\n" +
                    "                                                                    </else>\n" +
                    "                                                                </condition>\n" +
                    "                                                            </else>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </normal>\n" +
                    "                                            <else>\n" +
                    "                                                <condition id=\"checkCounter\">\n" +
                    "                                                    <string id=\"id\">previous</string>\n" +
                    "                                                    <string id=\"value\">4</string>\n" +
                    "                                                    <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                                    <string id=\"Comment\">Don&apos;t choose character 4 again</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <condition id=\"random\">\n" +
                    "                                                            <string id=\"amount\">5</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                    <string id=\"value\">1</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">1</string>\n" +
                    "                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                </action>\n" +
                    "                                                            </normal>\n" +
                    "                                                            <else>\n" +
                    "                                                                <condition id=\"random\">\n" +
                    "                                                                    <string id=\"amount\">4</string>\n" +
                    "                                                                    <normal>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">2</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">2</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </normal>\n" +
                    "                                                                    <else>\n" +
                    "                                                                        <condition id=\"random\">\n" +
                    "                                                                            <string id=\"amount\">3</string>\n" +
                    "                                                                            <normal>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                    <string id=\"value\">3</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                    <string id=\"value\">3</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                            </normal>\n" +
                    "                                                                            <else>\n" +
                    "                                                                                <condition id=\"random\">\n" +
                    "                                                                                    <string id=\"amount\">2</string>\n" +
                    "                                                                                    <normal>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                            <string id=\"value\">5</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                            <string id=\"value\">5</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                    </normal>\n" +
                    "                                                                                    <else>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                            <string id=\"value\">6</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                            <string id=\"value\">6</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                    </else>\n" +
                    "                                                                                </condition>\n" +
                    "                                                                            </else>\n" +
                    "                                                                        </condition>\n" +
                    "                                                                    </else>\n" +
                    "                                                                </condition>\n" +
                    "                                                            </else>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <condition id=\"checkCounter\">\n" +
                    "                                                            <string id=\"id\">previous</string>\n" +
                    "                                                            <string id=\"value\">5</string>\n" +
                    "                                                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                                            <string id=\"Comment\">Don&apos;t choose character 5 again</string>\n" +
                    "                                                            <normal>\n" +
                    "                                                                <condition id=\"random\">\n" +
                    "                                                                    <string id=\"amount\">5</string>\n" +
                    "                                                                    <normal>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                            <string id=\"value\">1</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                            <string id=\"value\">1</string>\n" +
                    "                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                        </action>\n" +
                    "                                                                    </normal>\n" +
                    "                                                                    <else>\n" +
                    "                                                                        <condition id=\"random\">\n" +
                    "                                                                            <string id=\"amount\">4</string>\n" +
                    "                                                                            <normal>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                            </normal>\n" +
                    "                                                                            <else>\n" +
                    "                                                                                <condition id=\"random\">\n" +
                    "                                                                                    <string id=\"amount\">3</string>\n" +
                    "                                                                                    <normal>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                            <string id=\"value\">3</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                            <string id=\"value\">3</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                    </normal>\n" +
                    "                                                                                    <else>\n" +
                    "                                                                                        <condition id=\"random\">\n" +
                    "                                                                                            <string id=\"amount\">2</string>\n" +
                    "                                                                                            <normal>\n" +
                    "                                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                                    <string id=\"value\">4</string>\n" +
                    "                                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                </action>\n" +
                    "                                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                                    <string id=\"value\">4</string>\n" +
                    "                                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                </action>\n" +
                    "                                                                                            </normal>\n" +
                    "                                                                                            <else>\n" +
                    "                                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                                    <string id=\"value\">6</string>\n" +
                    "                                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                </action>\n" +
                    "                                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                                    <string id=\"value\">6</string>\n" +
                    "                                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                </action>\n" +
                    "                                                                                            </else>\n" +
                    "                                                                                        </condition>\n" +
                    "                                                                                    </else>\n" +
                    "                                                                                </condition>\n" +
                    "                                                                            </else>\n" +
                    "                                                                        </condition>\n" +
                    "                                                                    </else>\n" +
                    "                                                                </condition>\n" +
                    "                                                            </normal>\n" +
                    "                                                            <else>\n" +
                    "                                                                <condition id=\"checkCounter\">\n" +
                    "                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                    <string id=\"value\">6</string>\n" +
                    "                                                                    <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                                                    <string id=\"Comment\">Don&apos;t choose character 6 again</string>\n" +
                    "                                                                    <normal>\n" +
                    "                                                                        <condition id=\"random\">\n" +
                    "                                                                            <string id=\"amount\">5</string>\n" +
                    "                                                                            <normal>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                    <string id=\"value\">1</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                    <string id=\"value\">1</string>\n" +
                    "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                </action>\n" +
                    "                                                                            </normal>\n" +
                    "                                                                            <else>\n" +
                    "                                                                                <condition id=\"random\">\n" +
                    "                                                                                    <string id=\"amount\">4</string>\n" +
                    "                                                                                    <normal>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                            <string id=\"value\">2</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                            <string id=\"value\">2</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                    </normal>\n" +
                    "                                                                                    <else>\n" +
                    "                                                                                        <condition id=\"random\">\n" +
                    "                                                                                            <string id=\"amount\">3</string>\n" +
                    "                                                                                            <normal>\n" +
                    "                                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                                    <string id=\"value\">3</string>\n" +
                    "                                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                </action>\n" +
                    "                                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                                    <string id=\"value\">3</string>\n" +
                    "                                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                </action>\n" +
                    "                                                                                            </normal>\n" +
                    "                                                                                            <else>\n" +
                    "                                                                                                <condition id=\"random\">\n" +
                    "                                                                                                    <string id=\"amount\">2</string>\n" +
                    "                                                                                                    <normal>\n" +
                    "                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                                            <string id=\"value\">4</string>\n" +
                    "                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                        </action>\n" +
                    "                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                                            <string id=\"value\">4</string>\n" +
                    "                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                        </action>\n" +
                    "                                                                                                    </normal>\n" +
                    "                                                                                                    <else>\n" +
                    "                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                                            <string id=\"value\">5</string>\n" +
                    "                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                        </action>\n" +
                    "                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                                            <string id=\"value\">5</string>\n" +
                    "                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                        </action>\n" +
                    "                                                                                                    </else>\n" +
                    "                                                                                                </condition>\n" +
                    "                                                                                            </else>\n" +
                    "                                                                                        </condition>\n" +
                    "                                                                                    </else>\n" +
                    "                                                                                </condition>\n" +
                    "                                                                            </else>\n" +
                    "                                                                        </condition>\n" +
                    "                                                                    </normal>\n" +
                    "                                                                    <else>\n" +
                    "                                                                        <condition id=\"branch\">\n" +
                    "                                                                            <string id=\"Comment\">Neutral random</string>\n" +
                    "                                                                            <normal>\n" +
                    "                                                                                <condition id=\"random\">\n" +
                    "                                                                                    <string id=\"amount\">6</string>\n" +
                    "                                                                                    <normal>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                            <string id=\"value\">1</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                            <string id=\"value\">1</string>\n" +
                    "                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                        </action>\n" +
                    "                                                                                    </normal>\n" +
                    "                                                                                    <else>\n" +
                    "                                                                                        <condition id=\"random\">\n" +
                    "                                                                                            <string id=\"amount\">5</string>\n" +
                    "                                                                                            <normal>\n" +
                    "                                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                </action>\n" +
                    "                                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                                    <string id=\"value\">2</string>\n" +
                    "                                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                </action>\n" +
                    "                                                                                            </normal>\n" +
                    "                                                                                            <else>\n" +
                    "                                                                                                <condition id=\"random\">\n" +
                    "                                                                                                    <string id=\"amount\">4</string>\n" +
                    "                                                                                                    <normal>\n" +
                    "                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                                            <string id=\"value\">3</string>\n" +
                    "                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                        </action>\n" +
                    "                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                                            <string id=\"value\">3</string>\n" +
                    "                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                        </action>\n" +
                    "                                                                                                    </normal>\n" +
                    "                                                                                                    <else>\n" +
                    "                                                                                                        <condition id=\"random\">\n" +
                    "                                                                                                            <string id=\"amount\">3</string>\n" +
                    "                                                                                                            <normal>\n" +
                    "                                                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                                                    <string id=\"id\">character</string>\n" +
                    "                                                                                                                    <string id=\"value\">4</string>\n" +
                    "                                                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                                </action>\n" +
                    "                                                                                                                <action id=\"adjustCounter\">\n" +
                    "                                                                                                                    <string id=\"id\">previous</string>\n" +
                    "                                                                                                                    <string id=\"value\">4</string>\n" +
                    "                                                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                                </action>\n" +
                    "                                                                                                            </normal>\n" +
                    "                                                                                                            <else>\n" +
                    "                                                                                                                <condition id=\"random\">\n" +
                    "                                                                                                                    <string id=\"amount\">2</string>\n" +
                    "                                                                                                                    <normal>\n" +
                    "                                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                                                            <string id=\"value\">5</string>\n" +
                    "                                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                                        </action>\n" +
                    "                                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                                                            <string id=\"value\">5</string>\n" +
                    "                                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                                        </action>\n" +
                    "                                                                                                                    </normal>\n" +
                    "                                                                                                                    <else>\n" +
                    "                                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                                            <string id=\"id\">character</string>\n" +
                    "                                                                                                                            <string id=\"value\">6</string>\n" +
                    "                                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                                        </action>\n" +
                    "                                                                                                                        <action id=\"adjustCounter\">\n" +
                    "                                                                                                                            <string id=\"id\">previous</string>\n" +
                    "                                                                                                                            <string id=\"value\">6</string>\n" +
                    "                                                                                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                                                                                        </action>\n" +
                    "                                                                                                                    </else>\n" +
                    "                                                                                                                </condition>\n" +
                    "                                                                                                            </else>\n" +
                    "                                                                                                        </condition>\n" +
                    "                                                                                                    </else>\n" +
                    "                                                                                                </condition>\n" +
                    "                                                                                            </else>\n" +
                    "                                                                                        </condition>\n" +
                    "                                                                                    </else>\n" +
                    "                                                                                </condition>\n" +
                    "                                                                            </normal>\n" +
                    "                                                                        </condition>\n" +
                    "                                                                    </else>\n" +
                    "                                                                </condition>\n" +
                    "                                                            </else>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </else>\n" +
                    "                                        </condition>\n" +
                    "                                    </else>\n" +
                    "                                </condition>\n" +
                    "                            </else>\n" +
                    "                        </condition>\n" +
                    "                    </normal>\n" +
                    "                </condition>\n" +
                    "            </normal>\n" +
                    "        </root>\n" +
                    "    </behaviour>\n" +
                    "</enemy>\n";
            }
        }

        public static class MapExporter
        {
            public static int Export(string mapPath)
            {
                if (!File.Exists(mapPath))
                    return 1;

                string content = File.ReadAllText(mapPath);
                string result = string.Empty;
                float positionX = -28.995f;
                float positionY = 28.995f;
                int start = content.IndexOf("<level>") + "<level>".Length;

                foreach (ProjectManager.Actor actor in ProjectManager.Characters)
                {
                    string buttonName = "speech_actorSpeaking_" + actor.IndexedName;

                    // Skip if it already exists to avoid duplicates.
                    if (content.Contains("<string id=\"influenceName\">" + buttonName + "</string>"))
                        continue;

                    // Create actor buttons.
                    result += string.Format
                    (
                        "    <levelObjectButton>\n" +
                        "        <vector2 id=\"position\">{1} {2}</vector2>\n" +
                        "        <vector2 id=\"size\">0.01 0.01</vector2>\n" +
                        "        <bool id=\"pressableByHumanPlayers\">0</bool>\n" +
                        "        <bool id=\"pressableByBotPlayers\">0</bool>\n" +
                        "        <bool id=\"pressableByCreeps\">0</bool>\n" +
                        "        <bool id=\"pressableByTeamZero\">0</bool>\n" +
                        "        <bool id=\"pressableByTeamOne\">0</bool>\n" +
                        "        <bool id=\"pressableByTeamNone\">0</bool>\n" +
                        "        <string id=\"pressableOnlyByClass\"></string>\n" +
                        "        <bool id=\"notPressableWhileTeamZeroOnIt\">0</bool>\n" +
                        "        <bool id=\"notPressableWhileTeamOneOnIt\">0</bool>\n" +
                        "        <bool id=\"notPressableWhileTeamNoneOnIt\">0</bool>\n" +
                        "        <int id=\"minimumCharactersRequired\">1</int>\n" +
                        "        <int id=\"maximumCharactersAllowed\">999</int>\n" +
                        "        <float id=\"timeRequiredBeforeCountsAsPress\">0</float>\n" +
                        "        <float id=\"timeToRemainPressedAfter\">0</float>\n" +
                        "        <bool id=\"invertOnOff\">0</bool>\n" +
                        "        <string id=\"influenceName\">{0}</string>\n" +
                        "        <float id=\"reactionSpeedForward\">10</float>\n" +
                        "        <float id=\"reactionSpeedBackward\">10</float>\n" +
                        "        <float id=\"autoPressAfterGameTime\">-1</float>\n" +
                        "        <bool id=\"networkSynchingEnabled\">1</bool>\n" +
                        "        <bool id=\"frozen\">0</bool>\n" +
                        "        <bool id=\"hidden\">0</bool>\n" +
                        "        <int id=\"ownID\">-1</int>\n" +
                        "    </levelObjectButton>\n",
                        buttonName,
                        positionX,
                        positionY
                    );
                    positionX += 0.01f;
                    if (positionX > 28.995f)
                    {
                        positionX = -28.995f;
                        positionY -= 0.01f;
                    }
                }

                // Create area dialogue buttons.
                foreach (Area area in ProjectManager.Areas)
                {
                    string buttonName = "speech_active_" + area.Name;

                    // Skip if it already exists to avoid duplicates.
                    if (content.Contains("<string id=\"influenceName\">" + buttonName + "</string>"))
                        continue;

                    result += string.Format
                    (
                        "    <levelObjectButton>\n" +
                        "        <vector2 id=\"position\">{1} {2}</vector2>\n" +
                        "        <vector2 id=\"size\">0.01 0.01</vector2>\n" +
                        "        <bool id=\"pressableByHumanPlayers\">0</bool>\n" +
                        "        <bool id=\"pressableByBotPlayers\">0</bool>\n" +
                        "        <bool id=\"pressableByCreeps\">0</bool>\n" +
                        "        <bool id=\"pressableByTeamZero\">0</bool>\n" +
                        "        <bool id=\"pressableByTeamOne\">0</bool>\n" +
                        "        <bool id=\"pressableByTeamNone\">0</bool>\n" +
                        "        <string id=\"pressableOnlyByClass\"></string>\n" +
                        "        <bool id=\"notPressableWhileTeamZeroOnIt\">0</bool>\n" +
                        "        <bool id=\"notPressableWhileTeamOneOnIt\">0</bool>\n" +
                        "        <bool id=\"notPressableWhileTeamNoneOnIt\">0</bool>\n" +
                        "        <int id=\"minimumCharactersRequired\">1</int>\n" +
                        "        <int id=\"maximumCharactersAllowed\">999</int>\n" +
                        "        <float id=\"timeRequiredBeforeCountsAsPress\">0</float>\n" +
                        "        <float id=\"timeToRemainPressedAfter\">0</float>\n" +
                        "        <bool id=\"invertOnOff\">0</bool>\n" +
                        "        <string id=\"influenceName\">{0}</string>\n" +
                        "        <float id=\"reactionSpeedForward\">10</float>\n" +
                        "        <float id=\"reactionSpeedBackward\">10</float>\n" +
                        "        <float id=\"autoPressAfterGameTime\">-1</float>\n" +
                        "        <bool id=\"networkSynchingEnabled\">1</bool>\n" +
                        "        <bool id=\"frozen\">0</bool>\n" +
                        "        <bool id=\"hidden\">0</bool>\n" +
                        "        <int id=\"ownID\">-1</int>\n" +
                        "    </levelObjectButton>\n",
                        buttonName,
                        positionX,
                        positionY
                    );
                    positionX += 0.01f;
                    if (positionX > 28.995f)
                    {
                        positionX = -28.995f;
                        positionY -= 0.01f;
                    }
                }

                positionX = 0;
                positionY = 0;

                // Iterating through the same array again is inefficient but easier to manage.
                // Create trigger buttons that the modder must position manually.
                // These are larger and appear around the 0,0 coordinates so they are easier to find.
                foreach (Area area in ProjectManager.Areas)
                {
                    string buttonName = "speech_trigger_" + area.Name;

                    // Skip if it already exists to avoid duplicates.
                    if (content.Contains("<string id=\"influenceName\">" + buttonName + "</string>"))
                        continue;

                    result += string.Format
                    (
                        "    <levelObjectButton>\n" +
                        "        <vector2 id=\"position\">{1} {2}</vector2>\n" +
                        "        <vector2 id=\"size\">0.1 0.1</vector2>\n" +
                        "        <bool id=\"pressableByHumanPlayers\">1</bool>\n" +
                        "        <bool id=\"pressableByBotPlayers\">1</bool>\n" +
                        "        <bool id=\"pressableByCreeps\">0</bool>\n" +
                        "        <bool id=\"pressableByTeamZero\">1</bool>\n" +
                        "        <bool id=\"pressableByTeamOne\">1</bool>\n" +
                        "        <bool id=\"pressableByTeamNone\">1</bool>\n" +
                        "        <string id=\"pressableOnlyByClass\"></string>\n" +
                        "        <bool id=\"notPressableWhileTeamZeroOnIt\">0</bool>\n" +
                        "        <bool id=\"notPressableWhileTeamOneOnIt\">0</bool>\n" +
                        "        <bool id=\"notPressableWhileTeamNoneOnIt\">0</bool>\n" +
                        "        <int id=\"minimumCharactersRequired\">1</int>\n" +
                        "        <int id=\"maximumCharactersAllowed\">999</int>\n" +
                        "        <float id=\"timeRequiredBeforeCountsAsPress\">0</float>\n" +
                        "        <float id=\"timeToRemainPressedAfter\">0</float>\n" +
                        "        <bool id=\"invertOnOff\">0</bool>\n" +
                        "        <string id=\"influenceName\">{0}</string>\n" +
                        "        <float id=\"reactionSpeedForward\">10</float>\n" +
                        "        <float id=\"reactionSpeedBackward\">10</float>\n" +
                        "        <float id=\"autoPressAfterGameTime\">-1</float>\n" +
                        "        <bool id=\"networkSynchingEnabled\">1</bool>\n" +
                        "        <bool id=\"frozen\">0</bool>\n" +
                        "        <bool id=\"hidden\">0</bool>\n" +
                        "        <int id=\"ownID\">-1</int>\n" +
                        "    </levelObjectButton>\n",
                        buttonName,
                        positionX,
                        positionY
                    );
                    positionX += 0.1f;
                    if (positionX > 10)
                    {
                        positionX = 0;
                        positionY -= 0.1f;
                    }
                }

                try
                {
                    File.WriteAllText(mapPath, content.Substring(0, start) + "\n" + result + content.Substring(start));
                    return 0;
                }
                catch
                {
                    return 2;
                }
            }
        }
    }
}
