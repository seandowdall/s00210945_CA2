using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s00210945_CA2
{
    public class Activity
    {
        
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        
        public ActivityType TypeOfActivity { get; set; }
        public enum ActivityType
        {
            Air,
            Water,
            Land
        }



        public override string ToString()
        {
            return $"{Name } - {ActivityDate }";
        }

        public string GetActivityDescriptionAndCost()
        {
            return $"Description: {Description }\n Cost: €{Cost }";
        }
    }
}
