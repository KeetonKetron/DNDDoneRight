using System;
using System.Collections.Generic;
using static DirtyDand.Globals.GlobalVariables;

namespace DirtyDand.Classes
{
    public class Spell
    {

        public String spellName { get; set; }
        public String spellDescript { get; set; }
        public School school { get; set; }
        public bool concentration { get; set; }
        public bool ritual { get; set; }
        public Time time { get; set; }
        public string duration { get; set; }
        public int level { get; set; }
        public int range { get; set; }
        public List<Caster> casterList { get; set; }
        public List<Components> componentsList { get; set; }
        public string material { get; set; }
        public Source source { get; set; }
        public string specialRange { get; set; }

        public Spell()
        {
            level = 0;
            ritual = false;
            specialRange = " feet";
            componentsList = new List<Components>();
            material = String.Empty;
            concentration = false;
            spellDescript = String.Empty;
            casterList = new List<Caster>();
        }

        public string GetCastTime()
        {
            switch (time)
            {
                case Time.A:
                    return "Action";

                case Time.Ba:
                    return "Bonus Action";

                case Time.day:
                    return "1 Day";

                case Time.H:
                    return "1 Hour";

                case Time.M:
                    return "1 Minute";

                case Time.Ms:
                    return "10 Minutes";

                case Time.R:
                    return "1 Reaction";
                default:
                    return "ERROR 404: NOT FOUND";

            }
        }

        public string GetRange()
        {
            switch (range)
            {
                case -1:
                    return specialRange;
                case 0:
                    if (specialRange.Equals(" feet"))
                        return "Self";
                    return "Self" + specialRange;
                case -2:
                    return "Touch";
                default:
                    return range.ToString() + specialRange;
            }
        }

        public string GetComponents()
        {
            string value = "";
            foreach (Components c in componentsList)
                value += c.ToString("g") + ", ";
            value = value.Remove(value.LastIndexOf(","), 1);
            if (material != string.Empty)
                value += material;
            return value;
        }
    }
}
