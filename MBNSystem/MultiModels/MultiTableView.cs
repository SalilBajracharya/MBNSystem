using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MBNSystem.Models;

namespace MBNSystem.MultiModels
{
    public class MultiTableView
    {
        public IEnumerable<Client> Client { get; set; }
        public IEnumerable<ClientsBranch> ClientBranch { get; set; }
        public IEnumerable<ClientsContact> ClientContact { get; set; }
    }
}