using System;
using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Entities {
    public abstract class BaseEntity {
        [Key]
        public Guid Id { get; set; }

        //CreateAt
        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; } 
            set { _createAt = (value == null ? DateTime.Now : value); } 
        }

        //UpdateAt
        private DateTime? _updateAt;
        public DateTime? UpdateAt 
        { 
            get { return _updateAt; } 
            set { _updateAt = (value == null ? DateTime.Now : value); } 
        }
      
        public virtual bool Authenticated { get; set; }
        public virtual string Message { get; set; }
        public virtual string Token { get; set; }
        public virtual DateTime Expiration { get; set; }
    }
}