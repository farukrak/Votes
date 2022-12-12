
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Votes.Interfaces
{
    interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
