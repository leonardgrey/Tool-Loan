using Assignment;
using BSTreeClass;
using System;
using System.Collections.Generic;
using System.Text;
using ToolLoan.Interfaces;
using System.Linq;

namespace ToolLoan.Classes
{
    class MemberCollection : iMemberCollection
    {
        public int Number { get; set; }

        private BSTree MemberCollections { get; set; }

        public MemberCollection()
        {
            this.MemberCollections = new BSTree();
        }

        public void add(Member member)
        {
            this.MemberCollections.Insert(member);
            Number++;
        }

        public void delete(Member member)
        {
            this.MemberCollections.Delete(member);
            Number--;
        }

        public bool search(Member member)
        {
            //TODO: search for member in collection
            if (member != null)
            {
                return this.MemberCollections.Search(member);
            }
            return false;
        }

        public Member FindMember(string username, bool staff=false, string passcode="")
        {
            foreach (var item in toArray())
            {
                if (item.Username == username.ToUpper())
                {
                    if (staff)
                    {
                        return item;
                    }
                    else
                    {
                        if (item.PIN == passcode)
                        {
                            return item;
                        }
                    }
                }
            }

            return null;
        }

        public Member[] toArray()
        {
            var t = MemberCollections.PreOrderTraverse().ToList();

            return MemberCollections.PreOrderTraverse()
                    .ToList()
                    .Select(i => (Member) i )
                    .ToArray();
        }

    }
}
