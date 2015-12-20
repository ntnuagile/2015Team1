using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
	public class Member
	{
		private int id_;
		private string name_;
		private string password_;
		private string type_="reader";
		private string inviter_="self";
		private DateTime regtime_;


		public void SetName(string name) { name_ = name; }
		public void SetPassword(string pw) { password_ = pw; }
		public void SetType(string type) { type_ = type; }
		public void SetInviter(string inviter) { inviter_ = inviter; }
		public void SetDate(DateTime d) { regtime_ = d; }



		public string GetName() { return name_; }
		public string GetPassword() { return password_; }
		public string GetTp() { return type_; } //GetType has been used in default.
		public string GetInviter() { return inviter_; }
		public DateTime GetRegtime() { return regtime_; }

	}
}
