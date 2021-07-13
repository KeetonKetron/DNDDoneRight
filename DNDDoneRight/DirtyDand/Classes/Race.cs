using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DirtyDand.Globals.GlobalVariables;

namespace DirtyDand.Classes
{
    public class Race
    {
        
        public enum Size {s, m};
        private int age {get; set;}
        private Alignment alignment {get; set;}
        private Size size { get; set;}
        private int speed {get; set;}
        private List<String> language {get; set;}
        private int darkvision {get; set;}
        private int[] abilityScores {get; set;}


    }
}
