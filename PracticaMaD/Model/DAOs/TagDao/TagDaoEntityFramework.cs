using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
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

            return tag;
        }

        public Boolean existsByTagName(String tagName)
        {
            Tag tag = null;

            DbSet<Tag> tags = Context.Set<Tag>();

            var result =
                (from t in tags
                 where t.tagName == tagName
                 select t);

            tag = result.FirstOrDefault();

            if (tag is null)
            {
                return false;
            }
            else
            {
                return tag.tagName == tagName;
            }
        }

        /// <summary>
        /// Finds more used tags.
        /// </summary>
        public List<Tag> FindMoreUsedTags()
        {
            List<Tag> tag = null;

            DbSet<Tag> tags = Context.Set<Tag>();

            var result =
                (from t in tags
                 select t).OrderByDescending(t => t.timesUsed).Take(5);

            tag = result.ToList();

            return tag;
        }
    }
}