using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;


namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao
{
    /// <summary>
    /// Specific Operations for Product
    /// </summary>
    public class TagDaoEntityFramework : GenericDaoEntityFramework<Tag, Int64>, ITagDao
    {
        /// <summary>
        /// Finds a tag by tag name.
        /// </summary>
        /// <param name="tagName"> The name tag. </param>
        public Tag FindByTagName(String tagName)
        {
            Tag tag = null;

            DbSet<Tag> tags = Context.Set<Tag>();

            var result =
                (from t in tags
                 where t.tagName == tagName
                 select t);

            tag = result.FirstOrDefault();

             if(tag==null)
                throw new InstanceNotFoundException(tagName,
                    typeof(Tag).FullName);

            return tag;
        }


    }
}