﻿using System;
using Ddp.Data.Ef;
using Ddp.Domain.EntityRelationshipModel.EntityTypes;

namespace Testapp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var thing = new EntityType(Guid.NewGuid(), "mm");
            thing.Rename("mmmmmmm");
            
        }
    }
}
