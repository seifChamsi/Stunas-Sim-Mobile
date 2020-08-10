using System;
using System.Collections.Generic;

namespace StunasMobile.Entities.Entitites
{
    public  partial class  Historique
    {
        public int Id { get; set; }
        public List<string> ChangedColumns { get; set; }
        public List<string> PreviousValues { get; set; } 
        public List<string> NewValues { get; set; }
        public DateTime CreatedAt { get; set; }
        //Foreign Key
        public int RecordId { get; set; }
        public Mobile Mobile { get; set; }
    }
}