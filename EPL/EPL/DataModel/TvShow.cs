using System;

namespace EPL.DataModel
{
    public class TvShow 
    {
        public DateTime ModifiedOn { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public string Episode { get; set; }
        public string Link { get; set; }
        public string Category { get; set; }
    }
}