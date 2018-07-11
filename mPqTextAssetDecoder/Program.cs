using System;
using System.IO;
using System.Text;

namespace mPqTextAssetDecoder
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                PrintUsage();
                return -1;
            }

            try
            {
                Run(args);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return -1;
            }
        }

        static void Run(string[] args)
        {
            var data = File.ReadAllBytes(args[0]);
            MessageData md = new MessageData();
            md.Decode(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md.messages.Count; i++)
            {
                sb.AppendFormat("{0}\t{1}\n", i, md.messages[i]);
            }

            var decoded = sb.ToString();
            if (args.Length > 1)
            {
                File.WriteAllText(args[1], decoded);
            }
            else
            {
                Console.Write(decoded);
            }
        }

        static void PrintUsage()
        {
            Console.WriteLine("Usage: mPqTextAssetDecoder input [output]");
            Console.WriteLine("  input: TextAsset bytes file");
            Console.WriteLine("  output: output file name, if not give, output to stdout");
        }
    }
}
