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

		public SkipList() {
			start = new SkipEntry(null);
			start.List.AppendLast(new NodeInfo(start, null, null));
			height = 0;
			rnd = new Random();
		}

		public void Init() {
			
		}

		public void Deinit() {

		}

		public void Print() {
			LinkedListNode<NodeInfo> cur = start.List.Last;

			while(cur != null) {
				Console.Write(cur.Value.Parent.Value + ", ");

				cur = cur.Value.Next;
			}
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

		}

		public bool Search(Int32 key) {
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
	}
}
