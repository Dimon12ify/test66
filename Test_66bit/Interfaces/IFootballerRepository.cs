using System.Collections;
using System.Collections.Generic;
using Test_66bit.Controllers;
using Test_66bit.Models;

namespace Test_66bit.Interfaces
{
    public interface IFootballerRepository
    {
        IEnumerable<Footballer> All { get; }
        Footballer GetById(long footballerId);

        void AddOrEdit(Footballer footballer, FootballerController.ActionType type);
    }
}