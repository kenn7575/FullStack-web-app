using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public enum EntityStateOption
    {
        Active,
        Deleted
    }
    public abstract class EntityBase
    {
        //properties
        public EntityStateOption EntityState { get; set; }
        public bool IsNeW { get; private set; }
        public bool HasChanges { get; set; }
        public bool IsValid => Validate();
        public abstract bool Validate();
    }
}
