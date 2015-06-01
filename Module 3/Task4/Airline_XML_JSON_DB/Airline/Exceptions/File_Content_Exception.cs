using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
    

namespace Airline.Exceptions
{
    [Serializable]
    public class File_Content_Exception : Exception
    {
        private string fileName;
 
        public string FileName { get { return fileName; } }
        public override string Message
        {
            get
            {
                if (fileName == null) return base.Message;
                else
                    return "File " + FileName + " does not have content corresponding to AviaModel type";
            }
        }
 
        //Standart constructors
        public File_Content_Exception() { }

        public File_Content_Exception(string message) : base(message) { }

        public File_Content_Exception(string message, Exception inner) : base(message, inner) { }

        //FileName constructor
        public File_Content_Exception(string message, string fileName) : this(message) { this.fileName = fileName; }
    }
}
