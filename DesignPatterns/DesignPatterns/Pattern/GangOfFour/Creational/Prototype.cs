using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace DesignPatterns.Pattern.GangOfFour.Creational
{
    public class Prototype
    {
    }

    public interface IUploadedFile
    {
        string FileName { get; set; }
        long Size { get; set; }
        string ContentType { get; set; }
        DateTime TimeStamp { get; set; }
        byte[] FileContent { get; set; }
        IUploadedFile Clone();
        IUploadedFile DeepCopy();
    }

    [Serializable]
    public class UploadedFile : IUploadedFile
    {
        public string ContentType { get; set; }

        public byte[] FileContent { get; set; }

        public string FileName { get; set; }

        public long Size { get; set; }

        public DateTime TimeStamp { get; set; }

        public IUploadedFile Clone()
        {
            // shadow copy
            return (IUploadedFile)this.MemberwiseClone();
        }

        public IUploadedFile DeepCopy()
        {
            if (!this.GetType().IsSerializable)
            {
                throw new Exception("object is not serializable");
            }

            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, this);
            ms.Seek(0, SeekOrigin.Begin);
            IUploadedFile deepCopy = (IUploadedFile)formatter.Deserialize(ms);
            ms.Close();
            return deepCopy;
        }
    }
}