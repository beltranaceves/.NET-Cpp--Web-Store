
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Service.TagService
{
    public interface ITagService
    {
        [Inject]
        ITagDao TagDao { set; }

        [Inject]
        IProductDao ProductDao { set; }

        [Transactional]
        List<TagDetails> GetAllTags();

        [Transactional]
        void TagProduct(long productId, long tagId);

        [Transactional]
        void UntagProduct(long productId, long tagId);

        [Transactional]
        List<TagDetails> GetProductTags(long productId);

        [Transactional]
        long CreateTag(TagDetails newTag);

        [Transactional]
        TagDetails FindByTagId(long tagId);
        
    }
}
