using System;
using EKadry.Domain.Pkzp.Position;

namespace EKadry.Domain.Pkzp
{
    public class Pkzp
    {
        public Guid Id { get; set; }
        public Guid IdWorker { get; set; }
        public float Balance { get; set; }
        public float Debit { get; set; }
        public float Credit { get; set; }
        public PkzpType PkzpType { get; set; }
        public PkzpPosition IdPkzpPosition { get; set; }

        public Pkzp()
        {
        }

        public static Pkzp CreatePkzp()
        {
            return new Pkzp()
            {
                Id = Guid.NewGuid(),
            };
        }
    }
}