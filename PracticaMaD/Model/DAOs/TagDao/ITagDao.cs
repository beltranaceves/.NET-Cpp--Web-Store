using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao
{
    public interface ITagDao : IGenericDao<Tag, Int64>
    {
        /// <summary>
        /// Finds a tag by tag name.
        /// </summary>
        /// <param name="tagName"> The name tag. </param>
        Tag FindByTagName(String tagName);

        /// <summary>
        /// Checks for a tag by tag name.
        /// </summary>
        /// <param name="tagName"> The name tag. </param>
        Boolean existsByTagName(String tagName);

        /// <summary>
        /// Finds more used tags.
        /// </summary>
        List<Tag> FindMoreUsedTags();
    }
}