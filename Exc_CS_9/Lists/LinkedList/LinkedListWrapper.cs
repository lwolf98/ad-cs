using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exc_CS_9.Lists.LinkedList {
	class LinkedListWrapper<T> : ILinkedList<T> {
		private LinkedList<T> list;

		public LinkedListWrapper() {
			list = new LinkedList<T>();
		}

		public LinkedListNode<T> First => list.First;

		public LinkedListNode<T> Last => list.Last;

		public LinkedListNode<T> AppendFirst(T val) {
			return list.AddFirst(val);
		}

		public LinkedListNode<T> AppendLast(T val) {
			return list.AddLast(val);
		}

		public void DeleteList() {
			list.Clear();
		}

		public void DeleteValue(T val) {
			list.Remove(val);
		}

		public void Print() {
			throw new NotImplementedException();
		}

		public int Size() {
			return list.Count;
		}

		public void Sort() {
			throw new NotImplementedException();
		}

		IEnumerator GetEnumerator() {
			return list.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator() {
			return (IEnumerator<T>)GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}
