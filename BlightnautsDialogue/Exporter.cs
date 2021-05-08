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
                        // -1 = solo
                        // 0 and beyond = team dialogues
                        int GetDialogues(int index)
                        {
                            result = string.Empty;
                            Area.Dialogue[] dialogues;
                            if (index == -1)
                                dialogues = naut.SoloDialogue.ToArray();
                            else
                                dialogues = naut.TeamDialogues[index].Dialogues.ToArray();

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
                                        "{0}\\speech_textbox_{1}_{2}_{3}{4}.xml",
                                        path,
                                        naut.Name,
                                        area.Name,
                                        index == -1 ? "solo" : "team",
                                        index >= 0 ? index.ToString() : string.Empty
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

                        int process = GetDialogues(-1);
                        if (process != 0)
                            return process;
                        else
                        {
                            for (int i = 0; i < naut.TeamDialogues.Length; i++)
                            {
                                process = GetDialogues(i);
                                if (process != 0)
                                    return process;
                            }
                        }
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
            static string resultCheckCharacter = string.Empty;
            static string resultSpeechLogic = string.Empty;

            public static int Export(string path)
            {
                if (!Directory.Exists(path))
                {
                    return 1;
                }

                resultCheckCharacter = string.Empty;
                CheckCharacterAppendStartText();
                CheckCharacterAppendValues();
                CheckCharacterAppendEndText();

                try
                {
                    File.WriteAllText(path + "\\speech_checkCharacter.xml", resultCheckCharacter);
                    File.WriteAllText(path + "\\speech_pickCharacter.xml", PickCharacterFile());
                }
                catch
                {
                    return 2;
                }

                foreach (Area area in ProjectManager.Areas)
                {
                    try
                    {
                        resultSpeechLogic = string.Empty;
                        SpeechLogicAppendStartText1(area);
                        SpeechLogicAppendValues1(area);
                        SpeechLogicAppendStartText2(area);
                        SpeechLogicAppendValues2(area);
                        SpeechLogicAppendEndText();
                        File.WriteAllText(path + "\\speech_triggers_" + area.Name + ".xml", resultSpeechLogic);
                    }
                    catch
                    {
                        return 2;
                    }
                }
                return 0;
            }

            private static void CheckCharacterAppendStartText()
            {
                resultCheckCharacter += "<?xml version=\"1.0\" ?>\n" +
                    "<enemy>\n" +
                    "    <behaviour>\n" +
                    "        <root x=\"80\" y=\"20\">\n" +
                    "            <normal>";
            }

            private static void CheckCharacterAppendValues()
            {
                foreach (ProjectManager.Actor actor in ProjectManager.Characters)
                {
                    resultCheckCharacter += string.Format
                    (
                        "                <condition id=\"branch\">\n" +
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

            private static void CheckCharacterAppendEndText()
            {
                resultCheckCharacter += "</normal>\n" +
                    "        </root>\n" +
                    "    </behaviour>\n" +
                    "</enemy>";
            }

            private static void SpeechLogicAppendStartText1(Area area)
            {
                resultSpeechLogic += string.Format
                (
                    "<?xml version=\"1.0\" ?>\n" +
                    "<enemy>\n" +
                    "    <behaviour>\n" +
                    "        <root x=\"80\" y=\"20\">\n" +
                    "            <normal>\n" +
                    "                <condition id=\"once\">\n" +
                    "                    <normal>\n" +
                    "                        <action id=\"adjustCounter\">\n" +
                    "                            <string id=\"id\">cooldown_{0}</string>\n" +
                    "                            <string id=\"value\">0</string>\n" +
                    "                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                        </action>\n" +
                    "                        <action id=\"adjustCounter\">\n" +
                    "                            <string id=\"id\">count_{0}</string>\n" +
                    "                            <string id=\"value\">0</string>\n" +
                    "                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                        </action>\n" +
                    "                    </normal>\n" +
                    "                </condition>\n" +
                    "                <condition id=\"isCharacterInArea\">\n" +
                    "                    <string id=\"groups\" values=\"target receive groups\" multiselect=\"true\">PLAYERS;;</string>\n" +
                    "                    <string id=\"teams\" values=\"teams\" multiselect=\"true\">OWN_TEAM;;</string>\n" +
                    "                    <string id=\"class\"></string>\n" +
                    "                    <string id=\"only check parent\" values=\"yesno\">no</string>\n" +
                    "                    <string id=\"only check children\" values=\"yesno\">no</string>\n" +
                    "                    <string id=\"count characters out of combat\" values=\"yesno\">yes</string>\n" +
                    "                    <string id=\"condition\" values=\"charactervaluesCheckable\">health</string>\n" +
                    "                    <string id=\"comparison\" values=\"valuecompare\">greater or equal</string>\n" +
                    "                    <string id=\"value\"></string>\n" +
                    "                    <string id=\"character minimum\">2</string>\n" +
                    "                    <float id=\"xOffset\">0.00</float>\n" +
                    "                    <float id=\"yOffset\">0.00</float>\n" +
                    "                    <string id=\"width\">60</string>\n" +
                    "                    <string id=\"height\">60</string>\n" +
                    "                    <string id=\"horizontal alignment to character\" values=\"alignmentToCharacterHorizontal\">Centre</string>\n" +
                    "                    <string id=\"vertical alignment to character\" values=\"alignmentToCharacterVertical\">Centre</string>\n" +
                    "                    <string id=\"debugAreaColour\">0 0 0 0</string>\n" +
                    "                    <string id=\"check line of sight\" values=\"yesno\">no</string>\n" +
                    "                    <string id=\"ignore invisibility\" values=\"yesno\">yes</string>\n" +
                    "                    <string id=\"never detect invisible targets without character collision\" values=\"yesno\">no</string>\n" +
                    "                    <string id=\"Comment\">Check if not in single player</string>\n" +
                    "                    <normal>\n" +
                    "                        <condition id=\"checkCounter\">\n" +
                    "                            <string id=\"id\">count_{0}</string>\n" +
                    "                            <string id=\"value\">0</string>\n" +
                    "                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                            <string id=\"Comment\">Team</string>\n" +
                    "                            <normal>\n" +
                    "                                <condition id=\"IsLevelButtonDown\">\n" +
                    "                                    <string id=\"buttons\">speech_{0}</string>\n" +
                    "                                    <string id=\"Comment\">Trigger</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <action id=\"executeBehaviourTree\">\n" +
                    "                                            <string id=\"fileName\">(mod) CheckCharacter</string>\n" +
                    "                                            <string id=\"Minimized\">yes</string>\n" +
                    "                                        </action>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">count_{0}</string>\n" +
                    "                                            <string id=\"value\">1</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">add</string>\n" +
                    "                                        </action>\n" +
                    "                                    </normal>\n" +
                    "                                </condition>\n" +
                    "                            </normal>\n" +
                    "                            <else>\n" +
                    "                                <condition id=\"checkCounter\">\n" +
                    "                                    <string id=\"id\">count_{0}</string>\n" +
                    "                                    <string id=\"value\">1</string>\n" +
                    "                                    <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                    <string id=\"Comment\">1 frame delay if triggered</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">count_{0}</string>\n" +
                    "                                            <string id=\"value\">1</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">add</string>\n" +
                    "                                        </action>\n" +
                    "                                    </normal>\n",
                    //"                                    <else>",
                    area.Name
                );
            }

            private static void SpeechLogicAppendValues1(Area area)
            {
                // Team
                for (int i = 0; i < area.TeamDialogues; i++)
                {
                    resultSpeechLogic += string.Format
                    (
                        "                                    <else>\n" +
                        "                                        <condition id=\"checkCounter\">\n" +
                        "                                            <string id=\"id\">count_{0}</string>\n" +
                        "                                            <string id=\"value\">{1}</string>\n" +
                        "                                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                        "                                            <normal>\n" +
                        "                                                <condition id=\"checkCounter\">\n" +
                        "                                                    <string id=\"id\">cooldown_{0}</string>\n" +
                        "                                                    <string id=\"value\">0</string>\n" +
                        "                                                    <string id=\"compare method\" values=\"valuecompare\">greater</string>\n" +
                        "                                                    <normal>\n" +
                        "                                                        <action id=\"adjustCounter\">\n" +
                        "                                                            <string id=\"id\">cooldown_{0}</string>\n" +
                        "                                                            <string id=\"value\">-1</string>\n" +
                        "                                                            <string id=\"adjust method\" values=\"valueadjust\">add</string>\n" +
                        "                                                        </action>\n" +
                        "                                                    </normal>\n" +
                        "                                                    <else>\n" +
                        "                                                        <action id=\"adjustCounter\">\n" +
                        "                                                            <string id=\"id\">count_{0}</string>\n" +
                        "                                                            <string id=\"value\">1</string>\n" +
                        "                                                            <string id=\"adjust method\" values=\"valueadjust\">add</string>\n" +
                        "                                                        </action>\n" +
                        "                                                        <action id=\"executeBehaviourTree\">\n" +
                        "                                                            <string id=\"fileName\">(mod) PickCharacter</string>\n" +
                        "                                                            <string id=\"Comment\">Randomize Character</string>\n" +
                        "                                                            <string id=\"Minimized\">yes</string>\n" +
                        "                                                        </action>\n" +
                        "                                                        <condition id=\"branch\">\n" +
                        "                                                            <string id=\"Comment\">Pick speaker</string>\n" +
                        "                                                            <string id=\"Minimized\">yes</string>\n" +
                        "                                                            <normal>",
                        area.Name,
                        i + 2
                    );

                    foreach (var naut in area.CharacterDialogue)
                    {
                        if (Area.GetTotalDuration(naut.TeamDialogues[i].Dialogues.ToArray()) == 0)
                            continue;

                        resultSpeechLogic += string.Format
                        (
                            "                                                                <andblock>\n" +
                            "                                                                    <string id=\"Comment\">{0}</string>\n" +
                            "                                                                    <normal>\n" +
                            "                                                                        <action id=\"adjustCounter\">\n" +
                            "                                                                            <string id=\"id\">character</string>\n" +
                            "                                                                            <string id=\"value\">-1</string>\n" +
                            "                                                                            <string id=\"adjust method\" values=\"valueadjust\">add</string>\n" +
                            "                                                                        </action>\n" +
                            "                                                                        <condition id=\"checkCounter\">\n" +
                            "                                                                            <string id=\"id\">character</string>\n" +
                            "                                                                            <string id=\"value\">0</string>\n" +
                            "                                                                            <string id=\"compare method\" values=\"valuecompare\">less or equal</string>\n" +
                            "                                                                            <normal>\n" +
                            "                                                                                <action id=\"adjustCounter\">\n" +
                            "                                                                                    <string id=\"id\">cooldown_{2}</string>\n" +
                            "                                                                                    <string id=\"value\">{3}</string>\n" +
                            "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                            "                                                                                </action>\n" +
                            "                                                                                <sequence>\n" +
                            "                                                                                    <string id=\"Is blocking\">yes</string>\n" +
                            "                                                                                    <normal>\n" +
                            "                                                                                        <action id=\"setLevelButton\">\n" +
                            "                                                                                            <string id=\"button\">speech_actorSpeaking_{1}</string>\n" +
                            "                                                                                            <string id=\"down\" values=\"yesno\">yes</string>\n" +
                            "                                                                                        </action>\n" +
                            "                                                                                        <action id=\"wait\">\n" +
                            "                                                                                            <float id=\"time\">0.30</float>\n" +
                            "                                                                                        </action>\n" +
                            "                                                                                        <action id=\"setLevelButton\">\n" +
                            "                                                                                            <string id=\"button\">speech_actorSpeaking_{1}</string>\n" +
                            "                                                                                            <string id=\"down\" values=\"yesno\">no</string>\n" +
                            "                                                                                        </action>\n" +
                            "                                                                                    </normal>\n" +
                            "                                                                                </sequence>\n" +
                            "                                                                            </normal>\n" +
                            "                                                                        </condition>\n" +
                            "                                                                    </normal>\n" +
                            "                                                                    <or>\n" +
                            "                                                                        <condition id=\"checkCounter\">\n" +
                            "                                                                            <string id=\"id\">character</string>\n" +
                            "                                                                            <string id=\"value\">0</string>\n" +
                            "                                                                            <string id=\"compare method\" values=\"valuecompare\">greater</string>\n" +
                            "                                                                        </condition>\n" +
                            "                                                                        <condition id=\"getBoolEquals\">\n" +
                            "                                                                            <string id=\"id\">speech_actorExists_{1}</string>\n" +
                            "                                                                            <string id=\"value\" values=\"yesno\">yes</string>\n" +
                            "                                                                        </condition>\n" +
                            "                                                                    </or>\n" +
                            "                                                                </andblock>",
                            naut.Name,
                            naut.Name,
                            area.Name,
                            System.Convert.ToInt32((Area.GetTotalDuration(naut.TeamDialogues[i].Dialogues.ToArray()) * 10))
                        );
                    }

                    resultSpeechLogic += "                                                            </normal>\n" +
                        "                                                        </condition>\n" +
                        "                                                    </else>\n" +
                        "                                                </condition>\n" +
                        "                                            </normal>";
                }

                for (int i = 0; i < area.TeamDialogues; i++)
                {
                    resultSpeechLogic += "                                                        </condition>\n" +
                        "                                                    </else>";
                }

                resultSpeechLogic += "                                </condition>\n" +
                    "                            </else>\n" +
                    "                        </condition>\n" +
                    "                    </normal>";
            }

            private static void SpeechLogicAppendStartText2(Area area)
            {
                resultSpeechLogic += string.Format
                (
                    "                    <else>\n" +
                    "                        <condition id=\"checkCounter\">\n" +
                    "                            <string id=\"id\">count_{0}</string>\n" +
                    "                            <string id=\"value\">0</string>\n" +
                    "                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                            <string id=\"Comment\">Solo</string>\n" +
                    "                            <normal>\n" +
                    "                                <condition id=\"IsLevelButtonDown\">\n" +
                    "                                    <string id=\"buttons\">speech_{0}</string>\n" +
                    "                                    <string id=\"Comment\">Trigger</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <action id=\"executeBehaviourTree\">\n" +
                    "                                            <string id=\"fileName\">(mod) CheckCharacter</string>\n" +
                    "                                            <string id=\"Minimized\">yes</string>\n" +
                    "                                        </action>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">count_{0}</string>\n" +
                    "                                            <string id=\"value\">1</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">add</string>\n" +
                    "                                        </action>\n" +
                    "                                    </normal>\n" +
                    "                                </condition>\n" +
                    "                            </normal>\n" +
                    "                            <else>\n" +
                    "                                <condition id=\"checkCounter\">\n" +
                    "                                    <string id=\"id\">count_{0}</string>\n" +
                    "                                    <string id=\"value\">1</string>\n" +
                    "                                    <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                    <string id=\"Comment\">1 frame delay if triggered</string>\n" +
                    "                                    <normal>\n" +
                    "                                        <action id=\"adjustCounter\">\n" +
                    "                                            <string id=\"id\">count_{0}</string>\n" +
                    "                                            <string id=\"value\">1</string>\n" +
                    "                                            <string id=\"adjust method\" values=\"valueadjust\">add</string>\n" +
                    "                                        </action>\n" +
                    "                                    </normal>\n" +
                    "                                    <else>\n" +
                    "                                        <condition id=\"checkCounter\">\n" +
                    "                                            <string id=\"id\">count_{0}</string>\n" +
                    "                                            <string id=\"value\">2</string>\n" +
                    "                                            <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                            <normal>\n" +
                    "                                                <condition id=\"checkCounter\">\n" +
                    "                                                    <string id=\"id\">cooldown_{0}</string>\n" +
                    "                                                    <string id=\"value\">0</string>\n" +
                    "                                                    <string id=\"compare method\" values=\"valuecompare\">equal</string>\n" +
                    "                                                    <normal>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">cooldown_{0}</string>\n" +
                    "                                                            <string id=\"value\">-1</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                    </normal>\n" +
                    "                                                    <else>\n" +
                    "                                                        <action id=\"adjustCounter\">\n" +
                    "                                                            <string id=\"id\">count_{0}</string>\n" +
                    "                                                            <string id=\"value\">5</string>\n" +
                    "                                                            <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <action id=\"executeBehaviourTree\">\n" +
                    "                                                            <string id=\"fileName\">(mod) PickCharacter</string>\n" +
                    "                                                            <string id=\"Comment\">Randomize Character</string>\n" +
                    "                                                            <string id=\"Minimized\">yes</string>\n" +
                    "                                                        </action>\n" +
                    "                                                        <condition id=\"branch\">\n" +
                    "                                                            <string id=\"Comment\">Pick speaker</string>\n" +
                    "                                                            <string id=\"Minimized\">yes</string>\n" +
                    "                                                            <normal>",
                    area.Name
                );
            }

            private static void SpeechLogicAppendValues2(Area area)
            {
                // Solo
                foreach (var naut in area.CharacterDialogue)
                {
                    if (Area.GetTotalDuration(naut.SoloDialogue.ToArray()) == 0)
                        continue;

                    resultSpeechLogic += string.Format
                    (
                        "                                                                <andblock>\n" +
                        "                                                                    <string id=\"Comment\">{0}</string>\n" +
                        "                                                                    <normal>\n" +
                        "                                                                        <action id=\"adjustCounter\">\n" +
                        "                                                                            <string id=\"id\">character</string>\n" +
                        "                                                                            <string id=\"value\">-1</string>\n" +
                        "                                                                            <string id=\"adjust method\" values=\"valueadjust\">add</string>\n" +
                        "                                                                        </action>\n" +
                        "                                                                        <condition id=\"checkCounter\">\n" +
                        "                                                                            <string id=\"id\">character</string>\n" +
                        "                                                                            <string id=\"value\">0</string>\n" +
                        "                                                                            <string id=\"compare method\" values=\"valuecompare\">less or equal</string>\n" +
                        "                                                                            <normal>\n" +
                        "                                                                                <action id=\"adjustCounter\">\n" +
                        "                                                                                    <string id=\"id\">cooldown_{2}</string>\n" +
                        "                                                                                    <string id=\"value\">{3}</string>\n" +
                        "                                                                                    <string id=\"adjust method\" values=\"valueadjust\">set</string>\n" +
                        "                                                                                </action>\n" +
                        "                                                                                <sequence>\n" +
                        "                                                                                    <string id=\"Is blocking\">yes</string>\n" +
                        "                                                                                    <normal>\n" +
                        "                                                                                        <action id=\"setLevelButton\">\n" +
                        "                                                                                            <string id=\"button\">speech_actorSpeaking_{1}</string>\n" +
                        "                                                                                            <string id=\"down\" values=\"yesno\">yes</string>\n" +
                        "                                                                                        </action>\n" +
                        "                                                                                        <action id=\"wait\">\n" +
                        "                                                                                            <float id=\"time\">0.30</float>\n" +
                        "                                                                                        </action>\n" +
                        "                                                                                        <action id=\"setLevelButton\">\n" +
                        "                                                                                            <string id=\"button\">speech_actorSpeaking_{1}</string>\n" +
                        "                                                                                            <string id=\"down\" values=\"yesno\">no</string>\n" +
                        "                                                                                        </action>\n" +
                        "                                                                                    </normal>\n" +
                        "                                                                                </sequence>\n" +
                        "                                                                            </normal>\n" +
                        "                                                                        </condition>\n" +
                        "                                                                    </normal>\n" +
                        "                                                                    <or>\n" +
                        "                                                                        <condition id=\"checkCounter\">\n" +
                        "                                                                            <string id=\"id\">character</string>\n" +
                        "                                                                            <string id=\"value\">0</string>\n" +
                        "                                                                            <string id=\"compare method\" values=\"valuecompare\">greater</string>\n" +
                        "                                                                        </condition>\n" +
                        "                                                                        <condition id=\"getBoolEquals\">\n" +
                        "                                                                            <string id=\"id\">speech_actorExists_{1}</string>\n" +
                        "                                                                            <string id=\"value\" values=\"yesno\">yes</string>\n" +
                        "                                                                        </condition>\n" +
                        "                                                                    </or>\n" +
                        "                                                                </andblock>",
                        naut.Name,
                        naut.Name,
                        area.Name,
                        System.Convert.ToInt32((Area.GetTotalDuration(naut.SoloDialogue.ToArray()) * 10))
                    );
                }
            }

            private static void SpeechLogicAppendEndText()
            {
                resultSpeechLogic += "                                                            </normal>\n" +
                    "                                                        </condition>\n" +
                    "                                                    </else>\n" +
                    "                                                </condition>\n" +
                    "                                            </normal>\n" +
                    "                                        </condition>\n" +
                    "                                    </else>\n" +
                    "                                </condition>\n" +
                    "                            </else>\n" +
                    "                        </condition>\n" +
                    "                    </else>\n" +
                    "                </condition>\n" +
                    "            </normal>\n" +
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
