using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using Mefunc;

namespace WorkflowFunc
{
    [Export(typeof(IMefunc))]
    [ExportMetadata("Name", "WorkflowFunc")]
    internal class Program : IMefunc
    {
        private static void Main( string[] args )
        {
            int result = ExecuteWorkflow( 1001, 100 );

            Console.WriteLine( result );
        }

        private static int ExecuteWorkflow( int x, int y )
        {
            int result = 0;

            using ( var workflowRuntime = new WorkflowRuntime() )
            {
                workflowRuntime.WorkflowCompleted += ( ( _, e ) => { result = (int) e.OutputParameters[ "Result" ]; } );

                var scheduler = new ManualWorkflowSchedulerService();
                workflowRuntime.AddService( scheduler );

                var args = new Dictionary<string, object> { { "X", x }, { "Y", y } };
                WorkflowInstance instance = workflowRuntime.CreateWorkflow( typeof( Workflow1 ), args );

                instance.Start();
                scheduler.RunWorkflow( instance.InstanceId );
            }

            return result;
        }

        public int Apply( int x, int y )
        {
            return ExecuteWorkflow( x, y );
        }

        public string Name
        {
            get { return "WorkflowFunc"; }
        }
    }
}