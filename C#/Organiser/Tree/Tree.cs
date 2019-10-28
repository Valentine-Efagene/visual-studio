#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace Tree
{
    public class NodeCollection<Element> : IEnumerable<Node<Element>> where Element : class
    {
        #region Implementation Detail:
        List<Node<Element>> mList = new List<Node<Element>>();
        Node<Element> mOwner = null;

        #endregion
        #region Internal Interface:
        internal NodeCollection(Node<Element> owner)
        {
            if (null == owner)
                throw new ArgumentNullException("owner");

            mOwner = owner;
        }

        #endregion
        #region Public Interface:
        public void Add(Node<Element> rhs)
        {
            if (mOwner.DoesShareHierarchyWith(rhs))
                throw new InvalidOperationException("Cannot add an ancestor or descendant.");

            mList.Add(rhs);
            rhs.Parent = mOwner;
        }

        public void Remove(Node<Element> rhs)
        {
            mList.Remove(rhs);
            rhs.Parent = null;
        }

        public bool Contains(Node<Element> rhs)
        {
            return mList.Contains(rhs);
        }

        public void Clear()
        {
            foreach (Node<Element> n in this)
                n.Parent = null;

            mList.Clear();
        }

        public int Count
        {
            get
            {
                return mList.Count;
            }
        }

        public Node<Element> Owner
        {
            get
            {
                return mOwner;
            }
        }

        public Node<Element> this[int index]
        {
            get
            {
                return mList[index];
            }
        }
        #endregion

        #region IEnumerable<Element> Members
        public IEnumerator<Node<Element>> GetEnumerator()
        {
            return mList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    } // class NodeCollection

    public class Node<Element> where Element : class
    {
        #region Implementation Detail:
        NodeCollection<Element> mChildren = null;
        Node<Element> mParent = null;
        Element mData = null;
        #endregion
        #region Public Interface:

        public Node(Element nodedata)
        {
            mChildren = new NodeCollection<Element>(this);
            mData = nodedata;
        }

        public Node<Element> Parent
        {
            get
            {
                return mParent;
            }
            internal set
            {
                mParent = value;
            }
        }

        public NodeCollection<Element> Children
        {
            get
            {
                return mChildren;
            }
        }

        public Node<Element> Root
        {
            get
            {
                if (null == mParent) return this;
                return mParent.Root;
            }
        }

        public bool IsAncestorOf(Node<Element> rhs)
        {
            if (mChildren.Contains(rhs))
                return true;

            foreach (Node<Element> kid in mChildren)
                if (kid.IsAncestorOf(rhs)) return true;
            return false;
        }

        public bool IsDescendantOf(Node<Element> rhs)
        {
            if (null == mParent)
                return false;

            if (rhs == mParent)
                return true;

            return mParent.IsDescendantOf(rhs);
        }

        public bool DoesShareHierarchyWith(Node<Element> rhs)
        {
            if (rhs == this)
                return true;

            if (this.IsAncestorOf(rhs))
                return true;

            if (this.IsDescendantOf(rhs))
                return true;

            return false;
        }

        public Element Data
        {
            get
            {
                return mData;
            }
        }

        public IEnumerator<Element> GetDepthFirstEnumerator()
        {
            yield return mData;

            foreach (Node<Element> kid in mChildren)
            {
                IEnumerator<Element> kidenumerator = kid.GetDepthFirstEnumerator();

                while (kidenumerator.MoveNext())
                    yield return kidenumerator.Current;
            }
        }

        public IEnumerator<Element> GetBreadthFirstEnumerator()
        {
            Queue<Node<Element>> todo = new Queue<Node<Element>>();
            todo.Enqueue(this);

            while (0 < todo.Count)
            {
                Node<Element> n = todo.Dequeue();

                foreach (Node<Element> kid in n.mChildren)
                    todo.Enqueue(kid);

                yield return n.mData;
            }
        }
        #endregion
    }       // class Node
} // namespace AzazelDev.Collections.Trees
