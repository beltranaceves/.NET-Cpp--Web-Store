using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderLineDao
{
    public class ClientOrderLineDaoEntityFramework :
        GenericDaoEntityFramework<ClientOrderLine, Int64>, IClientOrderLineDao
    {}
}