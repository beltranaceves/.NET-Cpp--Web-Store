using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.TagDao
{
    [Serializable]
    public class TagDetails
    {
        public long tagId { get; }

        public string tagName { get; }

        public TagDetails(long tagId,string tagName)
        {
            this.tagName = tagName;
            this.tagId = tagId;
        }

        public TagDetails(string tagName)
        {
            this.tagName = tagName;
        }
    }
}
