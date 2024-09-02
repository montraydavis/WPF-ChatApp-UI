using WorkflowCore.Interface;

namespace QNAGen.Workflows
{
    /// <summary>
    /// Represents the workflow for generating SQL queries based on user input.
    /// </summary>
    public class SQLGenerationWorkflow : IWorkflow<SQLGenerationData>
    {
        /// <summary>
        /// Gets the unique identifier for the workflow.
        /// </summary>
        public string Id => "sql-generation-workflow";

        /// <summary>
        /// Gets the version of the workflow.
        /// </summary>
        public int Version => 1;

        /// <summary>
        /// Builds the workflow steps.
        /// </summary>
        /// <param name="builder">The workflow builder.</param>
        public void Build(IWorkflowBuilder<SQLGenerationData> builder)
        {
            builder
                .StartWith<AugmentUserPrompt>()
                    .Input(step => step.UserPrompt, data => data.UserPrompt)
                    .Output(data => data.AugmentedPrompt, step => step.AugmentedPrompt)
                .Then<GenerateSQL>()
                    .Input(step => step.AugmentedPrompt, data => data.AugmentedPrompt)
                    .Output(data => data.GeneratedSQL, step => step.GeneratedSQL)
                .Then<EvaluateResponse>()
                    .Input(step => step.GeneratedSQL, data => data.GeneratedSQL)
                    .Output(data => data.FinalResponse, step => step.FinalResponse);
        }
    }

    /// <summary>
    /// Represents the data used in the SQL generation workflow.
    /// </summary>
    public class SQLGenerationData
    {
        /// <summary>
        /// Gets or sets the user prompt.
        /// </summary>
        public string UserPrompt { get; set; }

        /// <summary>
        /// Gets or sets the augmented prompt after processing the user prompt.
        /// </summary>
        public string AugmentedPrompt { get; set; }

        /// <summary>
        /// Gets or sets the generated SQL query.
        /// </summary>
        public string GeneratedSQL { get; set; }

        /// <summary>
        /// Gets or sets the final response after evaluating the generated SQL query.
        /// </summary>
        public string FinalResponse { get; set; }
    }
}
