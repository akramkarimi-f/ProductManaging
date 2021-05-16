using System;
using System.Threading.Tasks;

namespace BehinRahkar.Application.Helper.Attachment
{
    public class AttachmentHelper : IAttachmentHelper
    {
        public string GetFileName(string contentType)
        {
            return Guid.NewGuid().ToString();
        }

        public Task SaveFileAsync(string content, string fileName, string path)
        {
            throw new NotImplementedException();
        }
    }
}
