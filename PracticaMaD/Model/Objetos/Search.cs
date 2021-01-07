using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Objetos
{
    public class Search
    {
        public string Keyword { get; set; }
        public int StartIndex { get; set; }
        public int Count { get; set; }

        public long? CatId { get; set; }

        public Search(string keyword, long? catId, int startIndex, int count)
        {
            this.Count = count;
            this.StartIndex = startIndex;
            this.Keyword = keyword;
            this.CatId = catId;
        }
    }
}