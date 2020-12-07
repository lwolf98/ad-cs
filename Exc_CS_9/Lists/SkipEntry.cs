using Exc_CS_9.Lists.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exc_CS_9.Lists {
	class SkipEntry {
		public SkipEntry(Int32? val) {
			Value = val;
			List = new LinkedListWrapper<NodeInfo>();
		}

		public override string ToString() {
			string val = Value == null ? "null" : Value.ToString();
			return "Value: " + val + ", Height: " + (List.Size() - 1);
		}

		public ILinkedList<NodeInfo> List { get; set; }
		public Int32? Value { get; set; }
	}
}
