using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao;
using Ninject;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.TagService
{
    public class TagService : ITagService
    {
        [Inject]
        public ITagDao TagDao { private get; set; }

        [Transactional]
        public List<Tag> GetAllTags()
        {
            List<Tag> tags = TagDao.GetAllElements();

            return tags;
        }

        /// <summary>
        /// Find a tag from her name
        /// </summary>
        /// <param name="tagName">The name of the tag</param>
        /// <returns> The tag </returns>
        [Transactional]
        public Tag FindTagByName(string tagName)
        {
            Tag tag = TagDao.FindByTagName(tagName);
            return tag;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="tagName">The name of the tag</param>
        /// <returns> The tag </returns>
        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        public Tag Create(string tagName)
        {
            if (TagDao.existsByTagName(tagName))
            {
                throw new DuplicateInstanceException(tagName,
                    typeof(Tag).Name);
            }
            Tag tag = new Tag();
            tag.tagName = tagName;
            TagDao.Create(tag);
            return tag;
        }
    }
}