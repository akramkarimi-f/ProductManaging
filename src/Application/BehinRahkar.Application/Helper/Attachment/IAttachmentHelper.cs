using Framework.Core.Ioc;
using System.Threading.Tasks;

namespace BehinRahkar.Application.Helper.Attachment
{
    public interface IAttachmentHelper : ITransientDependency
    {
        string GetFileName(string contentType);
        Task SaveFileAsync(string content, string fileName, string path);
    }
}
