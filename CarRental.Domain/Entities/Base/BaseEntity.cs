using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public bool IsRemoved { get; set; } = false;
        public DateTime RemoveDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public DateTime InsertDateTime { get; set; } = DateTime.Now;
    }
    public abstract class BaseEntity<TKey>:BaseEntity
    {
        public TKey Id { get; set; }
    }
}
