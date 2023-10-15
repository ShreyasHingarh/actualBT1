using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ActualGame.ScreenAndGraph
{
    public class LNode<T>
    {
        public T Value;
        public LNode<T> Next;
        public LNode<T> Previous;
        public LNode(T value)
        {
            Value = value;
        }
    }

    public struct Enumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        LNode<T> Root;
        List<T> NextValues = new List<T>();
        int index = 0;
        public Enumerator(LNode<T> actual)
        {
            Root = actual;
            NextValues = InOrder();

        }

        private List<T> InOrder()
        {
            List<T> temp = new List<T>();
            inorder(Root, temp);
            return temp;
        }
        private void inorder(LNode<T> Current, List<T> Values)
        {
            if (Current == null || Values.Contains(Current.Value)) return;

            Values.Add(Current.Value);
            inorder(Current.Next, Values);
        }
        public bool MoveNext()
        {
            if (index >= NextValues.Count) return false;
            Current = NextValues[index];
            index++;
            return true;
        }
        public void Reset()
        {
            NextValues = new List<T>();
            Current = default;
        }

        public void Dispose()
        {
        }

        public T Current { get; private set; } = default;

        object IEnumerator.Current => Current;
    }

    internal class LinkedL<T> where T : IComparable<T>
    {
        public LNode<T> Head { get; set; }
        public LNode<T> Tail { get; set; }
        public int Count { get; private set; }

        public IComparer<T> Comparer => throw new NotImplementedException();

        public LinkedL()
        {
            Count = 0;
        }
        public bool IsEmpty()
        {
            return Head == null;
        }

        private T GetValue(int key)
        {
            int count = 0;
            foreach (var item in this)
            {
                if (count == key) return item;
                count++;
            }
            return Tail.Value;
        }
        private void SetValue(int key, T value)
        {
            if (this[key].Equals(value)) return;
            for (int i = 0; i < Count; i++)
            {
                if (i == key)
                {
                    this[i] = value;
                }
            }
        }
        public T this[int key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }

        public bool preliminaryChecks(T value, LNode<T> node, LNode<T> nodeToAdd)
        {
            if (MakeListNotEmpty(nodeToAdd))
            {
                Count++;
                return true;
            }
            return node == null;

        }
        private bool MakeListNotEmpty(LNode<T> newHead)
        {
            if (!IsEmpty()) return false;

            Head = newHead;
            Tail = Head;

            return true;

        }
        public void AddFirst(T value)
        {
            Count++;
            var nodeToAdd = new LNode<T>(value);

            if (MakeListNotEmpty(nodeToAdd)) return;

            // List is not empty
            var temp = Head;
            Head = nodeToAdd;
            Head.Next = temp;
            temp.Previous = Head;
            Head.Previous = Tail;
        }
        public void AddLast(T value)
        {
            Count++;
            var nodeToAdd = new LNode<T>(value);

            if (MakeListNotEmpty(nodeToAdd)) return;

            // List is not empty
            var temp = Tail;
            Tail.Next = nodeToAdd;
            Tail = nodeToAdd;
            Tail.Previous = temp;
            Tail.Next = Head;
            Head.Previous = Tail;
        }
        public void AddBefore(T value, LNode<T> node)
        {
            var NodeToAdd = new LNode<T>(value);
            if (node == Head)
            {
                AddFirst(value);
                return;
            }
            if (preliminaryChecks(value, node, NodeToAdd))
            {
                return;
            }

            var OneToMove = node.Previous;
            node.Previous = NodeToAdd;
            NodeToAdd.Previous = OneToMove;
            OneToMove.Next = NodeToAdd;
            NodeToAdd.Next = node;
            Count++;
        }
        public void AddAfter(T value, LNode<T> node)
        {
            var NodeToAdd = new LNode<T>(value);
            if (node == Tail)
            {
                AddLast(value);
                return;
            }
            if (preliminaryChecks(value, node, NodeToAdd))
            {
                return;
            }

            var OneToMove = node.Next;
            node.Next = NodeToAdd;
            NodeToAdd.Next = OneToMove;
            OneToMove.Previous = NodeToAdd;
            NodeToAdd.Previous = node;
            Count++;
        }
        private bool CheckForOneItemInList()
        {
            if (Tail == Head)
            {
                Tail = null;
                Head = null;
                Count--;
                return true;
            }
            return false;
        }
        public void RemoveFirst()
        {
            if (CheckForOneItemInList()) return;

            Head = Head.Next;
            Head.Previous = Tail;
            Count--;
        }
        public void RemoveLast()
        {
            if (CheckForOneItemInList()) return;
            Tail = Tail.Previous;
            Tail.Next = Head;
            Count--;
        }
        public LNode<T> Search(T value)
        {
            var NodeToSearchFor = new LNode<T>(value);
            var temp = Head;
            while (!temp.Value.Equals(NodeToSearchFor.Value))
            {
                if (temp.Next == null) return null;
                temp = temp.Next;
            }
            return temp;
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public bool Contains(T value)
        {
            return Search(value) != null;
        }

        public void Remove(T value)
        {
            LNode<T> oneToRemove = Search(value);
            if (oneToRemove == null || CheckForOneItemInList()) return;
            if (value.Equals(Head.Value))
            {
                RemoveFirst();
                return;
            }
            else if (value.Equals(Tail.Value))
            {
                RemoveLast();
                return;
            }
            LNode<T> temp = oneToRemove.Previous;
            temp.Next = oneToRemove.Next;

            if (temp.Next != null) temp.Next.Previous = temp;
            Count--;
        }


        public IEnumerator<T> GetEnumerator() => new Enumerator<T>(Head);

    }
}
