
using AuthDocument.Context;
using AuthDocument.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace AuthDocument.Service
{
    public class HomeService : IHomeService
    {
        DatabaseContext _dbContext = null;
        public HomeService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Document> GetDocument(int DocumentId)
        {
            var result = await _dbContext.Documents.Where(w=> w.DocumentId == DocumentId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Document>> GetListDocument()
        {
            var result = await _dbContext.Documents.ToListAsync();
            return result;
        }

        public async Task<string> Upload(IFormFile file)
        {
            try
            {
                byte[] fileBytes;
                Document document = new Document();
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    fileBytes = stream.ToArray();
                    document.FileName = file.FileName;
                    document.FileType = file.ContentType;
                    document.FileData = fileBytes;
                }

                _dbContext.Documents.Add(document);
                await _dbContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
            
        }
    }
}
