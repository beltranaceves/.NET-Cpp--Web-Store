using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao
{
    /// <summary>
    /// Specific Operations for Product
    /// </summary>
    public class CategoryDaoEntityFramework : GenericDaoEntityFramework<Category, Int64>, ICategoryDao
    {
    }
}