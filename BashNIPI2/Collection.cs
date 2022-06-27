using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BashNIPI2
{
    public struct StructPipe
    {
        [DisplayName("Длина от начала трубы")]
        public double LengthFromBeginningPipe { get; set; }
        [DisplayName("Давление, атм.")]
        public double Pressure { get; set; }
    };
    public class Collection : Simple
    {
        public List<StructPipe> Pipe;

        public Collection(int i, Random rand) : base(i, rand)
        {
            Pipe = new List<StructPipe>();
            int countPairs = rand.Next(6, 20);
            for (int j = 0; j < countPairs; j++)
            {
                Pipe.Add(new StructPipe()
                {
                    Pressure = rand.NextDouble(),
                    LengthFromBeginningPipe = rand.NextDouble()
                });
            }

            Name = "Collection " + i;
        }
    }
}