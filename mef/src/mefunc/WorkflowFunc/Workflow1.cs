using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace WorkflowFunc
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public int X { get; set; }
        public int Y { get; set; }
        
        public int Result { get; set; }

        private void GreaterThan100_ExecuteCode(object sender, EventArgs e)
        {
            Result = X + Y;
        }

        private void LessThan100_ExecuteCode(object sender, EventArgs e)
        {
            Result = X - Y;
        }


    }

}
