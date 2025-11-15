using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbtractClasses;

namespace ClassLibrary.Models;

public class ITSupport : User
{
        public Role Specialization { get; set; }

        public enum Role
        {
            Network,
            Software,
            Hardware,
            Security,
            HelpDesk
        }

        public ITSupport() { }

        public ITSupport(int id, string name, string email, bool isactive, Role spec) : base(id, name, email, isactive)
        {
            Specialization = spec;
        }

        public override string ToString()
        {
            return base.ToString() + $", Specialization: {Specialization}";
            ;
        }
}   

