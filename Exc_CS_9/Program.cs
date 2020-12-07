using Exc_CS_9.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exc_CS_9 {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Hello");
			Random rnd = new Random();

			SkipList skippy = new SkipList(rnd);
			skippy.Insert(8);
			skippy.Insert(15);
			skippy.Insert(12);
			skippy.Insert(5);
			skippy.Insert(2);
			
			skippy.Print();
			skippy.PrintDetails();

			Console.WriteLine(skippy.Search(8));
			Console.WriteLine(skippy.Search(15));
			Console.WriteLine(skippy.Search(2));

			Console.WriteLine("\nDelete:");

			skippy.Clear();

			for(int i = 0; i < 10; i++) {
				skippy.Insert(8);
				skippy.Insert(15);
				skippy.Insert(12);
				skippy.Insert(5);
				skippy.Insert(2);

				skippy.Delete(8);
				skippy.Delete(15);
				skippy.Delete(5);
				skippy.Delete(5);
				skippy.Delete(2);
				skippy.Delete(12);

				skippy.Print();
				skippy.PrintDetails();
			}
		}
	}
}
