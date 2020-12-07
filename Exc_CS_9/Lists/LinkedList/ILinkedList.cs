using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exc_CS_9.Lists.LinkedList {
	interface ILinkedList<T> : IEnumerable<T> {
		LinkedListNode<T> AppendFirst(T val);
		LinkedListNode<T> AppendLast(T val);
		void DeleteList();
		void DeleteValue(T val);
		void Print();
		int Size();
		void Sort();
		LinkedListNode<T> First { get; }
		LinkedListNode<T> Last { get; }
	}
}
