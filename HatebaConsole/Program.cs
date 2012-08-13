using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.IO;
using PHP.Core;

namespace HatebaConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = ReadSample();

			HatenaSharp.Output = Console.Out;
			HatenaSharp.OutputStream = Console.OpenStandardOutput();

			string html = HatenaSharp.Render(input);

			Console.WriteLine(html);
			Console.WriteLine("-- pause --");
			Console.ReadKey();
		}

		static private string ReadSample()
		{
			var asm = System.Reflection.Assembly.GetEntryAssembly();

			string path = Path.Combine(Path.GetDirectoryName(asm.Location), "sample.htn");

			using (var reader = new StreamReader(path))
			{
				return reader.ReadToEnd();
			}
		}

		static private void dd(string str)
		{
			Console.WriteLine(str);
		}
	}
}
