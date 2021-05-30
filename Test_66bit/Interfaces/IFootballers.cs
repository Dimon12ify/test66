using System.Collections;
using System.Collections.Generic;
using Test_66bit.Models;

namespace Test_66bit.Interfaces
{
    public interface IFootballers
    {
        IEnumerable<Footballer> All { get; }
        Footballer GetFootballerById(long footballerId);

    }
}