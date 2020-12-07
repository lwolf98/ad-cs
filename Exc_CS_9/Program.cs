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

			for(int i = 0; i < 10; i++) {
				SkipList skippy = new SkipList();
				skippy.Insert(8);
				skippy.Insert(15);
				skippy.Insert(12);
				skippy.Insert(5);
				skippy.Insert(2);

				skippy.Print();
				skippy.PrintDetails();
			}
		}
	}
}
