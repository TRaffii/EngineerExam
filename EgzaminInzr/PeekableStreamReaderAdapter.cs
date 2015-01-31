using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgzaminInzr
{
    public class PeekableStreamReaderAdapter
    {
        public StreamReader Underlying;
        public Queue<string> BufferedLines;

        public PeekableStreamReaderAdapter(StreamReader underlying)
        {
            Underlying = underlying;
            BufferedLines = new Queue<string>();
        }

        public string PeekLine()
        {
            string line = Underlying.ReadLine();
            if (line == null)
                return null;
            BufferedLines.Enqueue(line);
            return line;
        }


        public string ReadLine()
        {
            if (BufferedLines.Count > 0)
                return BufferedLines.Dequeue();
            return Underlying.ReadLine();
        }
    }
}
