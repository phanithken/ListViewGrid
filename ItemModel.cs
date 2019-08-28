using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ListViewGrid
{
    [DataContract]
    public class ItemModel
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Price { get; set; }

        [DataMember]
        public string Image { get; set; }

    }
}
