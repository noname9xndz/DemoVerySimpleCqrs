﻿using DemoVerySimpleCqrs.Domain.Commands;
using System;

namespace DemoVerySimpleCqrs
{
    class Program
    {
        static Guid newSupplierId = new Guid("28b1b06b-74ba-4e6f-82a1-4b2e057f1647");

        static void Main(string[] args)
        {
            var b = new Bootstrapper();
            b.Start();

            // WRITE SIDE
            var supplierName = "Jin";
            var createSupplierCmd = new CreateSupplierCmd(newSupplierId, supplierName);
            Bootstrapper.CommandBus.ProcessCommand(createSupplierCmd);

            // add 2 new locations
            Bootstrapper.CommandBus.ProcessCommand(new AddSupplierLocationCmd(newSupplierId, Guid.NewGuid(), "AAA"));
            Bootstrapper.CommandBus.ProcessCommand(new AddSupplierLocationCmd(newSupplierId, Guid.NewGuid(), "BBB"));

            // ======================================================

            // READ SIDE: get data from [views]
            // create sql query to get data from 2 view tables: FirstView & SecondView
            // ex: dapper.Query<SecondViewModel>(x=>x.LocationName = "BBB");

            Console.ReadKey();
        }
    }
}
