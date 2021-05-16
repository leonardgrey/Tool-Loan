using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLoan.Classes
{
    class MemberCollection : iMemberCollection
    {
        public int Number => throw new NotImplementedException();

        public void add(Member member)
        {
            throw new NotImplementedException();
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
