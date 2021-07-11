using OnlineAkademi.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Core.Domain.Entities
{
    public abstract class BaseEntity:IBaseEntity
    {
        public int Id { get; set; }
    }

}
