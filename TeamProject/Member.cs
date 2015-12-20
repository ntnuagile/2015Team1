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
		private string type_;
		private string inviter_;
		private DateTime regtime_;


		public void SetName(string name) { name_ = name; }

		public void SetDate(DateTime d) { regtime_ = d; }



		public string GetName() { return name_; }
	}
}
