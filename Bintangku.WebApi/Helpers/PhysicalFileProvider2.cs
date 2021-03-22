using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace Bintangku.WebApi.Helpers
{
    public class PhysicalFileProvider2 : IFileProvider
    {
        private string _root;
        private PhysicalFileProvider physicalFileProvider;
        public PhysicalFileProvider2(string root)
        {
            _root = root;
        }
        
        private PhysicalFileProvider GetPhysicalFileProvider()
        {
            if (!File.Exists(_root))
                Directory.CreateDirectory(_root);

            if (physicalFileProvider == null)
                physicalFileProvider = new PhysicalFileProvider(_root);

            return physicalFileProvider;
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return GetPhysicalFileProvider().GetDirectoryContents(subpath);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            return GetPhysicalFileProvider().GetFileInfo(subpath);
        }

        public IChangeToken Watch(string filter)
        {
            return GetPhysicalFileProvider().Watch(filter);
        }
    }
}