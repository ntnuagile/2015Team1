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
			members[numOfmembers_] = m;
			members[numOfmembers_].SetDate(DateTime.Now);
			numOfmembers_ += 1;
		}
	}
}
