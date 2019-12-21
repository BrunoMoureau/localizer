namespace LocalizedApp.Components.Localizer.Interfaces.Dependencies
{
    public interface ILocalizerService
    {
        /// <summary>
        /// Get the user preferred culture if available
        /// </summary>
        string GetPreferredUserCulture();
    }
}