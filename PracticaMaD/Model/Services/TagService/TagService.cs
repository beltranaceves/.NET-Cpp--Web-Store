using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Service.TagService
{
    public class TagService : ITagService
    {
        [Inject]
        public ITagDao TagDao { private get; set; }

        [Inject]
        public IProductDao ProductDao { private get; set; }

        [Transactional]
        public List<TagDetails> GetAllTags()
        {
            List<TagDetails> tagsList = new List<TagDetails>();
            List<Tag> tagList = TagDao.GetAllElements();

            for (int i = 0; i < tagList.Count; i++)
            {
                string name = tagList.ElementAt(i).tagName;
                long tagId = tagList.ElementAt(i).tagId;

                tagsList.Add(new TagDetails(tagId, tagName));
            }

            return tagsList;
        }

        [Transactional]
        public void AddTagToProduct(long productId, long tagId)
        {
            Product product = ProductDao.Find(productId);
            Tag tag = TagDao.Find(tagId);

            if (!product.Tags.Contains(tag))
                tag.Products.Add(product);

            TagDao.Update(tag);
        }

        [Transactional]
        public List<TagDetails> GetProductTags(long productId)
        {
            Product product = ProductDao.Find(productId);
            List<TagDetails> tagsDetails = new List<TagDetails>();
            List<Tag> productTags = product.Tags.ToList();

            for (int i = 0; i < productTags.Count; i++)
                tagsDetails.Add(new TagDetails(productTags.ElementAt(i).tagId,
                productTags.ElementAt(i).tagName));

            return tagsDetails;
        }

        [Transactional]
        public long CreateTag(TagDetails tag)
        {
            Tag auxTag = null;
            try
            {
                Tag t = TagDao.GetTagByName(tag.tagName);

                throw new DuplicateInstanceException(tag.tagName,
                    typeof(Tag).FullName);
            }
            catch (InstanceNotFoundException)
            {
                auxTag = new Tag();
                auxTag.name = tag.tagName;
                TagDao.Create(auxTag);
            }

            return auxTag.tagId;
        }

        public TagDetails FindByTagId(long tagId)
        {
            Tag auxTag = null;
            TagDetails tagDetails = null;
            try
            {
                auxTag = TagDao.Find(tagId);
                tagDetails = new TagDetails(auxTag.tagId, auxTag.tagName);
            }
            catch (InstanceNotFoundException e)
            {
                throw new InstanceNotFoundException(tagId, "Tag not found");
            }

            return tagDetails;
        }

        public void RemoveTagToProduct(long productId, long tagId)
        {
            Product auxProduct = null;
            try
            {
                auxProduct = ProductDao.Find(productId);
            }
            catch (InstanceNotFoundException)
            {
                throw new InstanceNotFoundException(productId, "Product not found");
            }
            for (int i = 0; i < auxProduct.Tags.Count; i++)
            {
                if (auxProduct.Tags.ElementAt(i).tagId == tagId)
                {
                    auxProduct.Tags.Remove(TagDao.Find(tagId));
                    ProductDao.Update(auxProduct);
                }
            }
        }
    }
}