using System;
using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Entities {
    public abstract class BaseEntity {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public virtual bool Authenticated { get; set; }
        public virtual string Message { get; set; }
        public virtual string Token { get; set; }
        public virtual DateTime Expiration { get; set; }
    }
}