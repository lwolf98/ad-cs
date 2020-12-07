using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exc_CS_9.Lists {
	public class SkipList {
		private SkipEntry start;
		private int height;
		private Random rnd;

		public SkipList(Random rnd) {
			Init();
			this.rnd = rnd;
		}

		public SkipList() : this(new Random()) {	}

		public void Clear() {
			Init();
		}

		private void Init() {
			start = new SkipEntry(null);
			start.List.AppendLast(new NodeInfo(start, null, null));
			height = 0;
		}

		public void Print() {
			String res = "";
			LinkedListNode<NodeInfo> cur = start.List.Last;

			while(cur != null) {
				if(cur.Value.Parent.Value != null)
					res += cur.Value.Parent.Value + ", ";

				cur = cur.Value.Next;
			}

			if(res.Length >= 2)
				res = res.Substring(0, res.Length - 2);

			Console.WriteLine(res);
		}

		public void PrintDetails() {
			LinkedListNode<NodeInfo> cur = start.List.Last;

			while(cur != null) {
				Console.WriteLine(cur.Value.Parent);

				cur = cur.Value.Next;
			}
		}

		public void Insert(Int32 key) {
			/*
			 * 1. Münzwurf -> Höhe bestimmen
			 * 2. neue Höhe > height => height anpassen, null-Knoten hinzufügen
			 * 3. SkipEntry anlegen
			 * 4. height von oben nach unten durchlaufen
			 *	> h <= Einfüghöhe?
			 *		> nein: continue
			 *		> ja: while K(h).next < value: Skip
			 *		
			 *		> Einfügen
			 * 
			 */

			int insertHeight = NewHeight();
			UpdateHeight(insertHeight);
			SkipEntry newSkipEntry = new SkipEntry(key);

			LinkedListNode<NodeInfo> cur = start.List.First;
			for(int h = height; h >= 0; h--) {
				if(h <= insertHeight) {
					LinkedListNode<NodeInfo> nextNode = cur.Value.Next;
					Int32? nextVal = nextNode?.Value.Parent.Value;

					//While does also terminate if nextVal is null
					while(nextVal < newSkipEntry.Value) {
						cur = nextNode;
						nextNode = nextNode.Value.Next;
						nextVal = nextNode?.Value.Parent.Value;
					}

					LinkedListNode<NodeInfo> newNode = newSkipEntry.List.AppendLast(new NodeInfo(newSkipEntry, cur, nextNode));
					cur.Value.Next = newNode;
					if(nextNode != null)
						nextNode.Value.Prev = newNode;

				}

				cur = cur.Next;
			}
		}

		public void Delete(Int32 key) {
			LinkedListNode<NodeInfo> cur = start.List.First;
			for(int h = height; h >= 0; h--) {
				LinkedListNode<NodeInfo> nextNode = cur.Value.Next;
				Int32? nextVal = nextNode?.Value.Parent.Value;

				//While does also terminate if nextVal is null
				while(nextVal <= key) {
					cur = nextNode;
					nextNode = nextNode.Value.Next;
					nextVal = nextNode?.Value.Parent.Value;

					if(cur.Value.Parent.Value == key) {
						DeleteEntry(cur.Value.Parent);
						CleanHeight();
						return;
					}
				}

				cur = cur.Next;
			}

			return;
		}

		public bool Search(Int32 key) {
			LinkedListNode<NodeInfo> cur = start.List.First;
			for(int h = height; h >= 0; h--) {
				LinkedListNode<NodeInfo> nextNode = cur.Value.Next;
				Int32? nextVal = nextNode?.Value.Parent.Value;

				//While does also terminate if nextVal is null
				while(nextVal <= key) {
					cur = nextNode;
					nextNode = nextNode.Value.Next;
					nextVal = nextNode?.Value.Parent.Value;

					if(cur.Value.Parent.Value == key)
						return true;
				}

				cur = cur.Next;
			}

			return false;
		}

		private int NewHeight() {
			int up;
			int h = 0;
			do {
				up = rnd.Next(2);
				h += up;
			} while(up != 0) ;

			return h;
		}

		private void UpdateHeight(int h) {
			int diff = h - height;

			for(int i = 0; i < diff; i++) {
				start.List.AppendFirst(new NodeInfo(start, null, null));
				height++;
			}
		}

		private void DeleteEntry(SkipEntry e) {
			LinkedListNode<NodeInfo> cur = e.List.First;

			while(cur != null) {
				NodeInfo iCur = cur.Value;
				LinkedListNode<NodeInfo> prev = iCur.Prev;
				LinkedListNode<NodeInfo> next = iCur.Next;

				prev.Value.Next = next;
				if(next != null)
					next.Value.Prev = prev;

				cur = cur.Next;
			}
		}

		private void CleanHeight() {
			LinkedListNode<NodeInfo> cur = start.List.First;

			while(cur.Next != null) {
				LinkedListNode<NodeInfo> next = cur.Next;
				if(cur.Value.Next == null) {
					start.List.DeleteValue(cur.Value);
					height--;
				}

				cur = next;
			}
		}
	}
}
