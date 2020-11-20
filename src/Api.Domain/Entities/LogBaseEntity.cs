using System;
using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Entities {
    public abstract class LogBaseEntity {
        [Key]
        public DateTime CreateAt { get; set; }
        public virtual bool Authenticated { get; set; }
        public virtual string Message { get; set; }
        public virtual string Token { get; set; }
        public virtual DateTime Expiration { get; set; }
        public virtual string Ipv6 { get; set; }
        public virtual string Ipv4 { get; set; }
        public virtual string Hostname { get; set; }
    
    
    }
}