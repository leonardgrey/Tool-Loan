using Assignment;
using BSTreeClass;
using System;
using System.Collections.Generic;
using System.Text;
using ToolLoan.Interfaces;

namespace ToolLoan.Classes
{
    class MemberCollection : iMemberCollection
    {
        public int Number { get; set; }

        public BSTree MemberCollections { get; set; }

        public MemberCollection()
        {
            this.MemberCollections = new BSTree();
        }

        public void add(Member member)
        {
            this.MemberCollections.Insert(member);
            Console.WriteLine("");
        }

        public void delete(Member member)
        {
            throw new NotImplementedException();
        }

        public bool search(Member member)
        {
            //TODO: search for member in collection
            return true;
        }

        public Member[] toArray()
        {
            throw new NotImplementedException();
        }
    }
}
