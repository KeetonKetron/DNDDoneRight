using DirtyDand.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using static DirtyDand.Globals.GlobalVariables;

namespace DirtyDand.Handlers
{
    public class SpellHandler
    {
        public SpellHandler()
        {
            string result;
            result = File.ReadAllText("./Resources\\Spells5e.txt");
            string[] spells = result.Split('~');

            foreach (string e in spells)
            {
                Spell current = new Spell();
                //Splits file into spells
                List<string> lines = e.Split('\r').ToList();
                if (lines[0] == "")
                    lines.RemoveAt(0);

                for (int i = 0; i < 6; i++)
                    if (lines[i].StartsWith("\n"))
                        lines[i] = lines[i].Remove(0, 1) + " ";
                //Gets the spell name

                current.spellName = lines[0];

                //Gets the spell level
                if (Int32.TryParse(lines[1].Substring(0, 1), out int strLevel))
                    current.level = strLevel;

                //Gets the spell school
                if (lines[1].IndexOf("Abjuration") >= 0 || lines[1].IndexOf("abjuration") >= 0)
                    current.school = School.Abjuration;
                else if (lines[1].IndexOf("Conjuration") >= 0 || lines[1].IndexOf("conjuration") >= 0)
                    current.school = School.Conjuration;
                else if (lines[1].IndexOf("Divination") >= 0 || lines[1].IndexOf("divination") >= 0)
                    current.school = School.Divination;
                else if (lines[1].IndexOf("Enchantment") >= 0 || lines[1].IndexOf("enchantment") >= 0)
                    current.school = School.Enchantment;
                else if (lines[1].IndexOf("Evocation") >= 0 || lines[1].IndexOf("evocation") >= 0)
                    current.school = School.Evocation;
                else if (lines[1].IndexOf("Illusion") >= 0 || lines[1].IndexOf("illusion") >= 0)
                    current.school = School.Illusion;
                else if (lines[1].IndexOf("Necromancy") >= 0 || lines[1].IndexOf("necromancy") >= 0)
                    current.school = School.Necromancy;
                else if (lines[1].IndexOf("Transmutation") >= 0 || lines[1].IndexOf("transmutation") >= 0)
                    current.school = School.Transmutation;

                //Determines if the spell can be ritual cast
                if (lines[1].Contains("(ritual)"))
                    current.ritual = true;

                //Gets the spell casting time
                if (lines[2].Contains("1 action"))
                    current.time = Time.A;
                else if (lines[2].Contains("1 bonus action"))
                    current.time = Time.Ba;
                else if (lines[2].Contains("1 reaction"))
                    current.time = Time.R;
                else if (lines[2].Contains("1 minute"))
                    current.time = Time.M;
                else if (lines[2].Contains("10 minutes"))
                    current.time = Time.Ms;
                else if (lines[2].Contains("1 hour"))
                    current.time = Time.H;
                // Gets the range of the spell
                int range = -1;
                if (!Int32.TryParse(lines[3].Substring(7, 3), out range))
                    if (!Int32.TryParse(lines[3].Substring(7, 2), out range))
                        if (!Int32.TryParse(lines[3].Substring(7, 1), out range))
                            if (lines[3].Substring(7, 1).Equals("T"))
                                current.range = -1;//Touch Range
                            else if (lines[3].Substring(7, 2).Equals("Sp"))
                            {
                                current.range = -1;
                                current.specialRange = "Special";
                            }
                            else if (lines[3].Substring(7, 2).Equals("Se") && lines[3].Length == 12)
                                current.range = 0;//Self Range
                            else if (lines[3].Substring(7, 2).Equals("Si"))
                            {
                                current.range = -1;
                                current.specialRange = "Sight"; //The damn sight ranges
                            }
                            else if (lines[3].Substring(7, 2).Equals("Un"))
                            {
                                current.range = -1;
                                current.specialRange = "Unlimited";
                            }
                            else
                            {
                                current.range = 0;
                                current.specialRange = " " + lines[3].Substring(lines[3].IndexOf("(")+1, lines[3].Length - lines[3].IndexOf("(")-3);
                            }
                if (range != -1)
                    current.range = range;
                if (lines[3].Contains("mile"))
                    current.specialRange = " mile";

                //Gets the spell components
                if (lines[4].IndexOf("V") >= 0)
                    current.componentsList.Add(Components.V);
                if (lines[4].IndexOf("S") >= 0)
                    current.componentsList.Add(Components.S);
                if (lines[4].IndexOf("M") >= 0)
                {
                    current.componentsList.Add(Components.M);
                    current.material = lines[4].Substring(lines[4].IndexOf("M") + 3,lines[4].Length - lines[4].IndexOf("M")-5);
                }

                //Gets the spell duration
                current.duration = lines[5].Substring(10);
                if (current.duration.Contains("Concentration"))
                {
                    current.concentration = true;
                    current.duration = current.duration.Remove(0, current.duration.IndexOf("to") + 3);
                }

                //Gets the full spell description
                int count = 6;
                while (!lines[count].Contains("Classes:") && !lines[count].Contains("Subclasses:") && !lines[count].Contains("Backgrounds:"))
                {
                    current.spellDescript += lines[count];
                    ++count;
                }

                //Gets the list of classes able to use the spell
                //Artificer, Bard, Cleric, Druid, Paladin, Ranger, Sorcerer, Warlock, Wizard
                /*string classList = lines[count];
                if (lines[count].Contains("Artificer"))
                    current.casterList.Add(Caster.Artificer);
                if (lines[count].Contains("Bard"))
                    current.casterList.Add(Caster.Bard);
                if (lines[count].Contains("Cleric"))
                    current.casterList.Add(Caster.Cleric);
                if (lines[count].Contains("Druid"))
                    current.casterList.Add(Caster.Druid);
                if (lines[count].Contains("Paladin"))
                    current.casterList.Add(Caster.Paladin);
                if (lines[count].Contains("Ranger"))
                    current.casterList.Add(Caster.Ranger);
                if (lines[count].Contains("Sorcerer"))
                    current.casterList.Add(Caster.Sorcerer);
                if (lines[count].Contains("Warlock"))
                    current.casterList.Add(Caster.Warlock);
                if (lines[count].Contains("Wizard"))
                    current.casterList.Add(Caster.Wizard);*/

                //Gets the source the spell was published from
                string fakeSource = lines[lines.Count() - 2].Substring(8);
                if (fakeSource.Contains("PHB"))
                    current.source = Source.PHB;
                else if (fakeSource.Contains("DMG"))
                    current.source = Source.DMG;
                else if (fakeSource.Contains("XGE"))
                    current.source = Source.XGE;
                else if (fakeSource.Contains("TCE"))
                    current.source = Source.TCE;
                else if (fakeSource.Contains("GGR"))
                    current.source = Source.GGR;
                else if (fakeSource.Contains("IDRotF"))
                    current.source = Source.IDRotF;
                else if (fakeSource.Contains("MTF"))
                    current.source = Source.MTF;
                else if (fakeSource.Contains("MOT"))
                    current.source = Source.MOT;
                else if (fakeSource.Contains("AI"))
                    current.source = Source.AI;
                else if (fakeSource.Contains("SCAG"))
                    current.source = Source.SCAG;
                else if (fakeSource.Contains("EEPC"))
                    current.source = Source.EEPC;
                else if (fakeSource.Contains("VGM"))
                    current.source = Source.VGM;
                else if (fakeSource.Contains("ERLW"))
                    current.source = Source.ERLW;
                else if (fakeSource.Contains("AWM"))
                    current.source = Source.AWM;
                else if (fakeSource.Contains("LR"))
                    current.source = Source.LR;
                else if (fakeSource.Contains("LLK"))
                    current.source = Source.LLK;
                else if (fakeSource.Contains("OGA"))
                    current.source = Source.OGA;
                else if (fakeSource.Contains("PS"))
                    current.source = Source.PS;
                else if (fakeSource.Contains("TTP"))
                    current.source = Source.TTP;
                else if (fakeSource.Contains("UA"))
                    current.source = Source.UA;
                else if (fakeSource.Contains("WGE"))
                    current.source = Source.WGE;
                spellRegistry.Add(current.spellName.ToLower(), current);
            }
        }

        public void SortLevel()
        {
            Dictionary<string,Spell>[] levelLists = new Dictionary<string, Spell>[10];

            for (int i = 0; i < 10; i++)
                levelLists[i] = new Dictionary<string, Spell>();

            foreach (KeyValuePair<string,Spell> s in spellRegistry)
                levelLists[s.Value.level].Add(s.Key,s.Value);

            spellRegistry.Clear();

            foreach (Dictionary<string, Spell> l in levelLists)
                foreach (KeyValuePair<string, Spell> i in l)
                    spellRegistry.Add(i.Key, i.Value);
        }
    }
}
