using Coolblue.API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coolblue.Api.Tests
{
    class InsuranceFunctionInLineData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                    new List<Product>()
                    {
                        new Product
                        {
                            Id = 11,
                            Name = "AEG L8FB86ES",
                            SalesPrice = 899,
                            ProductTypeId = 21,
                            ProductType = new ProductType
                            {
                                Id = 21,
                                Name = "Washing machines",
                                CanBeInsured = false
                            }
                        },
                        new Product
                        {
                            Id = 12,
                            Name = "AEG L8FB932",
                            SalesPrice = 499,
                            ProductTypeId = 22,
                            ProductType = new ProductType
                            {
                                Id = 22,
                                Name = "Air Fryer",
                                CanBeInsured = true
                             }
                        },
                        new Product
                        {
                            Id = 13,
                            Name = "AEG L8FB86ES",
                            SalesPrice = 2000,
                            ProductTypeId = 23,
                            ProductType = new ProductType
                            {
                                Id = 23,
                                Name = "Washing machines",
                                CanBeInsured = true
                            }
                        },
                        new Product
                        {
                            Id = 14,
                            Name = "Iphone 13",
                            SalesPrice = 2000,
                            ProductTypeId = 32,
                            ProductType = new ProductType
                            {
                                Id = 32,
                                Name = "Smartphones",
                                CanBeInsured = true
                            }
                        }
                    }
            };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

