namespace mwo.LiveRegistration.Plugins.Models
{
    /// <summary>
    /// Enum that binds names to the int values of the Dynamics Image Types.
    /// Code can assume these match the image types, do not change int values.
    /// </summary>
    public enum ImageType
    {
        PreImage = 0,
        PostImage = 1,
        Both = 2,
        None = 1000 //Does not exist in CRM!
    }
}
