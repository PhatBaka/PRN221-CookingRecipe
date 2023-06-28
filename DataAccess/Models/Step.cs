using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Step
    {
        public string StepName { get; set; }
        public string Description { get; set; }
        public int StepIndex { get; set; }
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
