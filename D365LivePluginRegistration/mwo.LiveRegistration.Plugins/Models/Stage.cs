namespace mwo.LiveRegistration.Plugins.Models
{
    /// <summary>
    /// Enum that binds names to the int values of the Dynamics Event Pipeline Stages.
    /// Code can assume these match the event pipeline, do not change int values.
    /// </summary>
    public enum Stage
    {
        PreValidation = 10,
        PreOperation = 20,
        PostOperation = 40,
    }
}
