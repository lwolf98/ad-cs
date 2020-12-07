using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exc_CS_9.Lists {
	class NodeInfo {
		public NodeInfo(SkipEntry parent, LinkedListNode<NodeInfo> prev, LinkedListNode<NodeInfo> next) {
			Parent = parent;
			Prev = prev;
			Next = next;
		}

		public SkipEntry Parent { get; set; }
		public LinkedListNode<NodeInfo> Prev { get; set; }
		public LinkedListNode<NodeInfo> Next { get; set; }
	}
}
