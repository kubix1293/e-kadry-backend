using System;
using EKadry.Domain.Pkzp.Position;
using EKadry.Domain.Workers;

namespace EKadry.Domain.Pkzp
{
    public class Pkzp
    {
        public Guid Id { get; set; }
        public Guid IdWorker { get; set; }
        public Worker Worker { get; set; }
        public float Balance { get; set; }
        public float Debit { get; set; }
        public float Credit { get; set; }
        public PkzpType PkzpType { get; set; }
        public Guid IdPkzpPosition { get; set; }
        public PkzpPosition PkzpPosition { get; set; }

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