using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
	class MemberBase
	{
		public const int maxMemberNum = 1000;
		private int numOfmembers_ = 0;
		public Member[] members = new Member[maxMemberNum];

		public int MemberNum() {return numOfmembers_;}

		public void AddMember(Member m)
		{
            if(SearchMember(m.GetName()) == false  &&  SearchMember(m.GetEmail()) == false)
            {
                members[numOfmembers_] = m;
			    members[numOfmembers_].SetDate(DateTime.Now);
			    numOfmembers_ += 1;
            }
		}
        public void EditMember(Member m,string name,string password,DateTime d,string email)
        {
            if (SearchMember(m.GetName()) == true)
            {
                m.SetName(name);
                m.SetPassword(password);
                m.SetDate(d);
                m.SetEmail(email);
                members[numOfmembers_] = m;
            }
        }

		public bool SearchMember(String name)
		{
			for (int i = 0; i < numOfmembers_ ; ++i)
				if (members[i].GetName() == name)
					return true;
			return false;
		}

        public bool SearchEmail(String email)
        {
            for (int i = 0; i < numOfmembers_; ++i)
                if (members[i].GetEmail() == email)
                    return true;
            return false;
        }
	}
}
