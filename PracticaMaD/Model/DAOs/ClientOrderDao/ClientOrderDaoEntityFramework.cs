using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderDao
{
    public class ClientOrderDaoEntityFramework :
        GenericDaoEntityFramework<ClientOrder, Int64>, IClientOrderDao
    {
    }
}