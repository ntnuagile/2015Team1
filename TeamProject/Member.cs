using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
	public class Member
	{
		//private int id_;
		private string name_;
		private string password_;
		private bool isAdministrator_;
		private string inviter_;
		private DateTime regtime_;

        //public void SetID(string id) { id_ = id; }
		public void SetName(string name) { name_ = name; }
		public void SetPassword(string pw) { password_ = pw; }
		public void SetIsAdministrator(bool isAdministrator) { isAdministrator_ = isAdministrator; }
		public void SetInviter(string inviter) { inviter_ = inviter; }
		public void SetDate(DateTime d) { regtime_ = d; }

		public string GetName() { return name_; }
		public string GetPassword() { return password_; }
		public bool GetIsAdministrator() { return isAdministrator_; } //GetType has been used in default.
		public string GetInviter() { return inviter_; }
		public DateTime GetRegtime() { return regtime_; }
	}
}
