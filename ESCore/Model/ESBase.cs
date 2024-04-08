using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.Model
{
    public class ESBase
    {
        private readonly ILazyLoader _lazyLoader;

        [IgnoreDataMember]
        private DateTime _created;

        public ESBase() { }

        public ESBase(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
            if (this.CreateDateTime == DateTime.MinValue)
                this.CreateDateTime = DateTime.Now;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType("integer")]
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateDateTime
        {
            get
            {
                if (this._created == DateTime.MinValue) return DateTime.Now;
                return this._created;
            }
            set
            {
                _created = value;
            }

        }
        [DataType(DataType.DateTime)]
        public DateTime UpdateDateTime { get; set; } = DateTime.Now;

    }
}
