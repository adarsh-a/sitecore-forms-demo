using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Mvc.Pipelines.ExecuteSubmit;
using Sitecore.Mvc.Pipelines;
using System;
using System.Collections.Generic;

namespace Px.SitecoreForms.Demo
{
    public class ExecuteActions : MvcPipelineProcessor<ExecuteSubmitActionsEventArgs>
    {
        public override void Process(ExecuteSubmitActionsEventArgs args)
        {
            Assert.ArgumentNotNull((object)args, nameof(args));
            foreach (ParameterizedSubmitAction submitAction in (IEnumerable<ParameterizedSubmitAction>)args.SubmitActions)
            {
                if (args.FormSubmitContext.Canceled)
                    break;
                submitAction.SubmitAction.ExecuteAction(args.FormSubmitContext, submitAction.Parameters);
            }
        }
    }
}
