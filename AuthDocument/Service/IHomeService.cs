using AuthDocument.Models;

namespace AuthDocument.Service
{
    public interface IHomeService
    {
        Task<List<Document>> GetListDocument();
        Task<Document> GetDocument(int DocumentId);
        Task<string> Upload(IFormFile file);
    }
}
