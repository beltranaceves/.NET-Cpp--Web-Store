using Es.Udc.DotNet.ModelUtil.Transactions;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao;
using Ninject;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.TagService
{
    public interface ITagService
    {
        [Inject]
        ITagDao TagDao { set; }

        /// <summary>
        /// Find all the tags
        /// </summary>
        /// <returns> The tags </returns>
        [Transactional]
        List<Tag> GetAllTags();

        /// <summary>
        /// Find a tag from her name
        /// </summary>
        /// <param name="tagName">The name of the tag</param>
        /// <returns> The tag </returns>
        [Transactional]
        Tag FindTagByName(string tagName);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="tagName">The name of the tag</param>
        /// <returns> The tag </returns>
        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        Tag Create(string tagName);

        /// <summary>
        /// Find more used tags
        /// </summary>
        /// <returns> The tags </returns>
        [Transactional]
        List<Tag> GetMoreUsedTags();
    }
}