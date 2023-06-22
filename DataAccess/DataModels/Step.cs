using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.DataModels
{
    public partial class Step
    {
        public int StepId { get; set; }
        public string StepName { get; set; }
        public string Description { get; set; }
        public int Index { get; set; }
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
