namespace Atelier.Gateway.Interfaces
{
    public interface IUrlFactory
    {
        /// <summary>
        /// Url read only property that must be previously set by using the "SetBooksCatalogUrl" method
        /// </summary>
        string Url { get; }

        /// <summary>
        /// 
        /// </summary>
        void SetCatsCatalogUrl();
    }
}
