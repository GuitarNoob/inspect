using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIInspection.MieTrak
{
    public class MieTrakConnectionManager
    {
        MIETRAKEntities mietrakDb = new MIETRAKEntities();      

        public List<MieTrak.User> GetUsers()
        {
            return mietrakDb.Users.ToList();
        }

        public List<MieTrak.Router> GetRouters()
        {
            return mietrakDb.Routers.ToList();
        }

        public List<MieTrak.WorkOrder> GetWorkOrders()
        {
            return mietrakDb.WorkOrders.ToList();
        }
    }
}
