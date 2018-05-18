using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace XamFormsRealmDbMvvmNs.Models
{
    public class Customer : RealmObject
    {
        [PrimaryKey]
        public int CustomerId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}
