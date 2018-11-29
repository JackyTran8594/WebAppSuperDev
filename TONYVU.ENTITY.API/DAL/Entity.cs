using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TONYVU.ENTITY.API.Infrastructure;

namespace TONYVU.ENTITY.API.DAL
{
    public abstract class Entity: IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
