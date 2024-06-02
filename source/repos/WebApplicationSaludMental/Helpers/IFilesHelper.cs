namespace WebApplicationSaludMental.Helpers
{
    public interface IFilesHelper
    {
        Task<string> SubirArchivo (Stream archivo, string nombre);
    }
}
