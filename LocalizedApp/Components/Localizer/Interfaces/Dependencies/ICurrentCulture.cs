namespace LocalizedApp.Components.Localizer.Interfaces.Dependencies
{
    public interface ICurrentCulture
    {
        /// <summary>
        /// Get the user preferred culture if available
        /// </summary>
        string GetPreferredUserCulture();
    }
}