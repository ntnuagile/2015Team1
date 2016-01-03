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

		public int MemberNum() { return numOfmembers_; }

		public bool AddMember(Member m)
		{
			if (SearchMember(m.GetName()) || SearchEmail(m.GetEmail()))
			{
				// If this guy is in memberbase
				return false;
			}

			members[numOfmembers_] = m;
			numOfmembers_ += 1;
			return true;
		}

		public bool EditMember(Member m, string name, string password, string email)
		{
			if (SearchMember(m.GetName()))
			{
				m.SetName(name);
				m.SetPassword(password);
				m.SetEmail(email);
				members[numOfmembers_] = m;
				return true;
			}
			return false;
		}

		/* ===================================================================================== */

		public bool SearchMember(string name)
		{
			for (int i = 0; i < numOfmembers_; ++i)
				if (members[i].GetName() == name)
					return true;
			return false;
		}

		public bool SearchEmail(string email)
		{
			for (int i = 0; i < numOfmembers_; ++i)
				if (members[i].GetEmail() == email)
					return true;
			return false;
		}

		/* ===================================================================================== */

		//public void ShareToWeb(Book[] historyList)
		//{

		//}

	}
}
